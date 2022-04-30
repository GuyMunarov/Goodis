using AutoMapper;
using Goodis.Dtos;
using Models.Entities;
using static Goodis.Dtos.OrderToCreateDto;

namespace Goodis.Helpers.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, UserToReturnDto>();

            CreateMap<CommentDto, SalesOrderLineComment>();
            CreateMap<SalesOrderLineComment, CommentDto>();

            CreateMap<BusinessPartner, BusinessPartnerDto>();
            CreateMap<BusinessPartnerDto, BusinessPartner>();

            CreateMap<BpType, BpTypeDto>();
            CreateMap<BpTypeDto, BpType>();

            CreateMap<GetLineDto, PurchaseOrderLine>();
            CreateMap<GetLineDto, SaleOrderLine>();



            CreateMap<PurchaseOrderLine, GetLineDto>()
                .ForMember(x => x.IsItemActive, o => o.MapFrom(z => z.Item.Active))
                .ForMember(x => x.ItemName, o => o.MapFrom(z => z.Item.ItemName));

            CreateMap<SaleOrderLine, GetLineDto>()
                .ForMember(x => x.IsItemActive, o => o.MapFrom(z => z.Item.Active))
                .ForMember(x => x.ItemName, o => o.MapFrom(z => z.Item.ItemName));


            CreateMap<PurchaseOrderLine, LineToReturnDto>();
            CreateMap<SaleOrderLine, LineToReturnDto>();



            CreateMap<OrderDataDto, PurchaseOrder>();
            CreateMap<OrderDataDto, SaleOrder>();


            CreateMap<PurchaseOrder, OrderDataDto>()
                .ForMember(x => x.CreatedByName, o => o.MapFrom(s => s.CreatedBy.FullName))
                .ForMember(x => x.LastUpdatedByName, o => o.MapFrom(s => s.LastUpdatedBy.FullName));

            CreateMap<SaleOrder, OrderDataDto>()
                .ForMember(x => x.CreatedByName, o => o.MapFrom(s => s.CreatedBy.FullName))
                .ForMember(x => x.LastUpdatedByName, o => o.MapFrom(s => s.LastUpdatedBy.FullName));


            CreateMap<PurchaseOrder, OrderToReturnDto>();
            CreateMap <SaleOrder, OrderToReturnDto> ();


        }
    }
}
