using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.GeneralModels;
using Models.Interfaces;
using Models.Specifications;
using Models.Specifications.SpecificationsParameters;

namespace Goodis.Controllers
{
    public class ItemsController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;


        public ItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<Pagination<Item>>> Get([FromQuery] ItemSpecParams specParams)
        {
            IReadOnlyList<Item> items = await _unitOfWork.Repository<Item>().ListBySpecAsync(new ItemSpecification(specParams));

            int totalItems = await _unitOfWork.Repository<Item>().CountAsync(new ItemSpecification(specParams, false));

            if (items == null) return NotFound();

            return Ok(new Pagination<Item>(specParams.PageIndex, specParams.PageSize, totalItems, items));
        }
    }
}
