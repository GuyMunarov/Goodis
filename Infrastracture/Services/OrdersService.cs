using Models.Entities;
using Models.Enums;
using Models.Interfaces;
using Models.Specifications;
using Models.Specifications.SpecificationsParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrdersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        public async Task<IOrder> CreateOrder(IOrder order)
        {

            if(!await IsValidBpForOrder(order))
                throw new ApplicationException("Partner isnt compatible with this type of order");

            order.CreateDate = DateTime.Now;

            if (order is PurchaseOrder)
                await CreatePurchaseOrder((PurchaseOrder)order);
            else
            {
               await CreateSaleOrder((SaleOrder)order);
            }
            
            return order;
        }    

        public async Task<IOrder> UpdateOrder(IOrder order)
        {

            if (!await IsValidBpForOrder(order))
                throw new ApplicationException("Partner isnt compatible with this type of order");

            if (order is PurchaseOrder)
            {

                await UpdatePurchaseOrder((PurchaseOrder)order);
                return order;

            }
            else
            {
                await UpdateSaleOrder((SaleOrder)order);
                return order;


            }
        }


        public async Task DeleteOrder(OrderType type, int id)
        {
            switch (type)
            {
                case OrderType.Sale:
                    SaleOrder saleToDelete = await _unitOfWork.Repository<SaleOrder>().GetByIdAsync(id);
                    if (saleToDelete == null) throw new ApplicationException("Order to delete not found");

                    _unitOfWork.Repository<SaleOrder>().Delete(saleToDelete);
                    break;

                case OrderType.Purchase:
                    PurchaseOrder purchaseToDelete = await _unitOfWork.Repository<PurchaseOrder>().GetByIdAsync(id);
                    if (purchaseToDelete == null) throw new ApplicationException("Order to delete not found");

                    _unitOfWork.Repository<PurchaseOrder>().Delete(purchaseToDelete);
                    break;

                default:
                    throw new ApplicationException("Order Type Is Incorrect");
                    break;            
            }
            await _unitOfWork.Complete();
            return;
        }

        public async Task<IOrder> GetOrder(OrderType type, int id)
        {
            switch (type)
            {
                case OrderType.Purchase:
                    {
                        PurchaseOrder purchase = await _unitOfWork.Repository<PurchaseOrder>().GetFirstOrDefaultBySpecAsync(new PurchaseOrderSpecification(id));
                        if(purchase == null) return purchase;

                        purchase.Lines = await _unitOfWork.Repository<PurchaseOrderLine>().ListBySpecAsync(new PurchaseOrderLinesSpecification(id)) as List<PurchaseOrderLine>;
                        return purchase;
                    }
                    break;
                case OrderType.Sale:
                    SaleOrder sale =  await _unitOfWork.Repository<SaleOrder>().GetFirstOrDefaultBySpecAsync(new SaleOrderSpecification(id));
                    if (sale == null) return sale;
                    
                    sale.Lines = await _unitOfWork.Repository<SaleOrderLine>().ListBySpecAsync(new SaleOrderLineSpecification(id)) as List<SaleOrderLine>;

                    sale.Lines.ForEach(async x => 
                    x.Comments = await _unitOfWork.Repository<SalesOrderLineComment>().ListBySpecAsync(new SaleOrderLineCommentsSpecification(new CommentSpecParams(x.LineID))) as List<SalesOrderLineComment>                 
                    );

                    return sale;
                    break;
                default:
                    throw new ApplicationException("Wron Order Type Provided");
                    break;
            }
            return null;
        }

       

       

        private async Task CreatePurchaseOrder(PurchaseOrder purchase)
        {
            if (purchase.Lines.Count == 0)
                throw new ApplicationException("Order must come with lines");
            await HandleOrderAndLinesOnCreate(purchase, purchase.Lines);
        }

        private async Task CreateSaleOrder(SaleOrder order)
        {
            SaleOrder sale = (SaleOrder)order;
            if (sale.Lines.Count == 0)
                throw new ApplicationException("Order must come with lines");
            await HandleOrderAndLinesOnCreate(sale, sale.Lines);

            await HandleCommentsOnCreate(sale.Lines);
        }


        private async Task UpdatePurchaseOrder(PurchaseOrder purchase)
        {
            await HandleOrderObjectOnUpdate(purchase, new PurchaseOrderSpecification(purchase.Id));

            IReadOnlyList<PurchaseOrderLine> previousOrderLines = await _unitOfWork.Repository<PurchaseOrderLine>().ListBySpecAsync(new PurchaseOrderLinesSpecification(purchase.Id));
            await HandleOrderAndLinesOnUpdate(purchase, purchase.Lines, previousOrderLines);
        }

        private async Task UpdateSaleOrder(SaleOrder sale)
        {
             await HandleOrderObjectOnUpdate(sale, new SaleOrderSpecification(sale.Id));

            IReadOnlyList<SaleOrderLine> previousOrderLines = await _unitOfWork.Repository<SaleOrderLine>().ListBySpecAsync(new SaleOrderLineSpecification(sale.Id));
            await HandleOrderAndLinesOnUpdate(sale, sale.Lines, previousOrderLines);

            IReadOnlyList<SalesOrderLineComment> previousOrderComments = await _unitOfWork.Repository<SalesOrderLineComment>().ListBySpecAsync(new SaleOrderLineCommentsSpecification(sale.Id));
            await HandleCommentsOnUpdate(sale, sale.Lines, previousOrderComments);
        }

        private async Task<bool> IsValidBpForOrder(IOrder order)
        {
            BusinessPartner bp = await _unitOfWork.Repository<BusinessPartner>().GetFirstOrDefaultBySpecAsync(new BusinessPartnerSpecification(order.BpCode));
            if (bp == null)
                throw new ApplicationException("Business partner code is incorrect");

            if (!bp.Active || order is PurchaseOrder && bp.BpType.TypeCode == "S" || order is SaleOrder && bp.BpType.TypeCode == "V")
                return false;
            return true;
        }


        private async Task HandleOrderAndLinesOnCreate<TOrder, TLine>(TOrder order, List<TLine> lines)
            where TLine: BaseOrderLine
            where TOrder : BaseOrder
           {
            await _unitOfWork.Repository<TOrder>().AddAsync(order);
            await _unitOfWork.Complete();

            foreach (TLine line in lines)
            {
                line.DocID = order.Id;
                line.CreatedById = order.CreatedById;
                line.CreateDate = DateTime.Now;

                Item item = await _unitOfWork.Repository<Item>().GetFirstOrDefaultBySpecAsync(new ItemSpecification(line.ItemCode));
                if (!item.Active)
                    throw new ApplicationException("item is inactive");
            }
            await _unitOfWork.Repository<TLine>().AddRangeAsync(lines);
            await _unitOfWork.Complete();
        }

        private async Task HandleOrderAndLinesOnUpdate<TOrder, TLine>(TOrder order, List<TLine> newOrderLines, IReadOnlyList<TLine> previousOrderLines)
           where TLine : BaseOrderLine
           where TOrder : BaseOrder
        {

            await DeleteLinesOnUpdate(newOrderLines, previousOrderLines);

            for (int i = 0; i < newOrderLines.Count; i++)
            {
                TLine line = newOrderLines[i];
            }
            foreach (TLine line in newOrderLines)
            {


                if (line.LineID == 0)
                {
                    line.CreateDate = DateTime.Now;
                    line.DocID = order.Id;
                    line.CreatedById = order.LastUpdatedById.Value;
                    await _unitOfWork.Repository<TLine>().AddAsync(line);
                }
                else
                {
                    TLine lineToUpdate = previousOrderLines.FirstOrDefault(x => x.LineID == line.LineID);

                    if (lineToUpdate == null)
                        throw new ApplicationException("Provided wrong LINEID");

                    lineToUpdate.DocID = order.Id;
                    lineToUpdate.LastUpdatedById = order.LastUpdatedById;
                    lineToUpdate.LastUpdateDate = DateTime.Now;
                    lineToUpdate.Quantity = line.Quantity;

                    Item item = await _unitOfWork.Repository<Item>().GetFirstOrDefaultBySpecAsync(new ItemSpecification(line.ItemCode));
                    if (!item.Active)
                        throw new ApplicationException("item is inactive");
                    lineToUpdate.ItemCode = item.ItemCode;

                    _unitOfWork.Repository<TLine>().Update(lineToUpdate);

                    line.DocID = order.Id;
                    line.LastUpdatedById = order.LastUpdatedById;
                    line.LastUpdateDate = DateTime.Now;
                    line.CreateDate = lineToUpdate.CreateDate;
                    line.CreatedById = lineToUpdate.CreatedById;
                }

            }
            await _unitOfWork.Complete();
        }

        private async Task DeleteLinesOnUpdate<TLine>(List<TLine> newLines, IReadOnlyList<TLine> oldLines)
            where TLine : BaseOrderLine
        {
            List<TLine> deletedOrderLines = oldLines.Where(x => newLines.FirstOrDefault(z => z.LineID == x.LineID) == null).ToList();
            _unitOfWork.Repository<TLine>().DeleteRange(deletedOrderLines);

        }

        private async Task HandleCommentsOnCreate(List<SaleOrderLine> lines)
        {
            List<SalesOrderLineComment> comments = new List<SalesOrderLineComment>();
            lines.ForEach(x =>
            {
                x.Comments.ForEach(z =>
                {
                    z.DocId = x.DocID;
                    z.Line = x;
                });
                comments.AddRange(x.Comments);
            }
            );
            await _unitOfWork.Repository<SalesOrderLineComment>().AddRangeAsync(comments);
            await _unitOfWork.Complete();
        }


        private async Task HandleOrderObjectOnUpdate<TOrder>(TOrder order, ISpecification<TOrder> orderSpec)
            where TOrder: BaseOrder
        {
            TOrder lastOrder = await _unitOfWork.Repository<TOrder>().GetFirstOrDefaultBySpecAsync(orderSpec);

            if (lastOrder == null)
                throw new ApplicationException("Order does not exist in db");

            lastOrder.LastUpdateDate = DateTime.Now;
            lastOrder.LastUpdatedById = order.LastUpdatedById;
            lastOrder.BpCode = order.BpCode;

            order.LastUpdateDate = DateTime.Now;

            order.CreatedById = lastOrder.CreatedById;
            order.CreateDate = lastOrder.CreateDate;

            _unitOfWork.Repository<TOrder>().Update(lastOrder);

            await _unitOfWork.Complete();
        }

        private async Task HandleCommentsOnUpdate(SaleOrder order, List<SaleOrderLine> newLines, IReadOnlyList<SalesOrderLineComment> previousComments)
        {
            newLines.ForEach(x =>
            {
                x.Comments.ForEach(z =>
                {
                    z.DocId = order.Id;
                    z.LineId = x.LineID;
                });
            });
            List<SalesOrderLineComment> newComments =  DeleteCommentsOnUpdate(newLines, previousComments);

            foreach (SalesOrderLineComment comment in newComments)
            {


                SalesOrderLineComment commentToUpdate = previousComments.FirstOrDefault(x => x.CommentLineID == comment.CommentLineID);
                if (commentToUpdate != null)
                {
                    commentToUpdate.Comment = comment.Comment;
                    _unitOfWork.Repository<SalesOrderLineComment>().Update(commentToUpdate);
                }
                else
                    await _unitOfWork.Repository<SalesOrderLineComment>().AddAsync(comment);

                
            }
            await _unitOfWork.Complete();


        }

        private List<SalesOrderLineComment> DeleteCommentsOnUpdate(List<SaleOrderLine> newLines, IReadOnlyList<SalesOrderLineComment> previousComments)
        {
            List<SalesOrderLineComment> newComments = new List<SalesOrderLineComment>();
            newLines.ForEach(x => newComments.AddRange(x.Comments));

            List<SalesOrderLineComment> deletedComments = previousComments.Where(x => newComments.FirstOrDefault(z => z.CommentLineID == x.CommentLineID) == null).ToList();

            _unitOfWork.Repository<SalesOrderLineComment>().DeleteRange(deletedComments);
            return newComments;
        }
        
    }
}
