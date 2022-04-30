using AutoMapper;
using Goodis.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.GeneralModels;
using Models.Interfaces;
using Models.Specifications;
using Models.Specifications.SpecificationsParameters;
using static Goodis.Dtos.OrderToCreateDto;

namespace Goodis.Controllers
{
    public class BusinessPartnersController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BusinessPartnersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<Pagination<BusinessPartner>>> Get([FromQuery] BusinessPartnerSpecParams specParams)
        {
            IReadOnlyList<BusinessPartner> partners = await _unitOfWork.Repository<BusinessPartner>().ListBySpecAsync(new BusinessPartnerSpecification(specParams));

            int totalItems = await _unitOfWork.Repository<BusinessPartner>().CountAsync(new BusinessPartnerSpecification(specParams, false));

            if (partners == null) return NotFound();
            IReadOnlyList<BusinessPartnerDto> partnersDtos = _mapper.Map<IReadOnlyList<BusinessPartner>, IReadOnlyList<BusinessPartnerDto>>(partners);
            Pagination<BusinessPartnerDto> pagination = new Pagination<BusinessPartnerDto>(specParams.PageIndex, specParams.PageSize, totalItems, partnersDtos);
            
            return Ok(pagination);
        }
    }
}
