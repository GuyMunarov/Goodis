using AutoMapper;
using Goodis.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Enums;
using Models.Interfaces;
using Models.Specifications;
using System.Text.Json;
using static Goodis.Dtos.OrderToCreateDto;

namespace Goodis.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IOrdersService _ordersService;
        private readonly IMapper _mapper;

        public OrdersController( IOrdersService ordersService, IMapper mapper)
        {
            _ordersService = ordersService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<IOrder>> Post([FromBody] OrderToCreateDto orderToCreate)
        {
            int userId = GetIdFromToken().Value;

            switch (orderToCreate.OrderType)
            {
                case (int)OrderType.Sale:
                    SaleOrder sale = _mapper.Map<OrderDataDto, SaleOrder>(orderToCreate.Data);
                    sale.CreatedById = userId;

                    SaleOrder saleRes = (SaleOrder)await _ordersService.CreateOrder(sale);
                    return Ok(_mapper.Map<SaleOrder, OrderToReturnDto>(saleRes));
                    break;

                case (int)OrderType.Purchase:
                    PurchaseOrder purchase = _mapper.Map<OrderDataDto, PurchaseOrder>(orderToCreate.Data);
                    purchase.CreatedById = userId;

                    PurchaseOrder purchaseRes = (PurchaseOrder)await _ordersService.CreateOrder(purchase);
                    return Ok(_mapper.Map<PurchaseOrder, OrderToReturnDto>(purchaseRes));
                    break;
                default:
                    throw new ApplicationException("incorrect order type");
                    break;
            }

        }

        [Authorize]
        [HttpDelete("type/{orderType}/id/{id}")]
        public async Task<ActionResult> Delete([FromRoute] OrderType orderType, [FromRoute] int id)
        {
            await _ordersService.DeleteOrder(orderType, id);
            return Ok();


        }

        [HttpPut]
        public async Task<ActionResult<IOrder>> Put([FromBody] OrderToCreateDto orderToUpdate)
        {
            if (orderToUpdate.Data.Id == null)
                throw new ApplicationException("Id is a required field");

            int userId = GetIdFromToken().Value;

            switch (orderToUpdate.OrderType)
            {
                case (int)OrderType.Sale:
                    SaleOrder sale = _mapper.Map<OrderDataDto, SaleOrder>(orderToUpdate.Data);
                    sale.LastUpdatedById = userId;

                    SaleOrder saleRes = (SaleOrder)await _ordersService.UpdateOrder(sale);
                    return Ok(_mapper.Map<SaleOrder, OrderToReturnDto>(saleRes));
                    break;

                case (int)OrderType.Purchase:
                    PurchaseOrder purchase = _mapper.Map<OrderDataDto, PurchaseOrder>(orderToUpdate.Data);
                    purchase.LastUpdatedById = userId;

                    PurchaseOrder purchaseRes = (PurchaseOrder)await _ordersService.UpdateOrder(purchase);
                    return Ok(_mapper.Map<PurchaseOrder, OrderToReturnDto>(purchaseRes));
                    break;

                default:
                    throw new ApplicationException("incorrect order type");
                    break;
            }

        }

        [HttpGet("type/{orderType}/id/{id}")]
        public async Task<ActionResult<IOrder>> Get([FromRoute] OrderType orderType, [FromRoute] int id)
        {

           IOrder order = await _ordersService.GetOrder(orderType, id);
            if (order == null)
                Ok(order);
            
            switch (orderType)
            {
                case OrderType.Purchase:
                    PurchaseOrder purchase = (PurchaseOrder)order;
                    return Ok(_mapper.Map<PurchaseOrder, OrderDataDto>(purchase));
                    break;
                case OrderType.Sale:
                    SaleOrder sale = (SaleOrder)order;
                    return Ok(_mapper.Map<SaleOrder, OrderDataDto>(sale));
                    break;
                default:
                    return null;
                    break;
            }

        }
    }

}
