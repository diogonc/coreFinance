using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Domain.Repositories;
using Domain;
using CoreFinance.ViewModels;
using Domain.Categories;

namespace CoreFinance.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepository;
        private IGroupRepository _groupRepository;
        private UpdateCategoryService _updateCategoryService;

        public CategoryController(ICategoryRepository categoryRepository, IGroupRepository groupRepository, UpdateCategoryService updateCategoryService)
        {
            _categoryRepository = categoryRepository;
            _groupRepository = groupRepository;
            _updateCategoryService = updateCategoryService;
        }

        [HttpGet("")]
        public IEnumerable<Category> Get()
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            return _categoryRepository.GetAll(propertyUuid);
        }

        [HttpGet("{uuid}")]
        public ActionResult Get(string uuid)
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            var category = _categoryRepository.Get(uuid, propertyUuid);
            return Ok(category);
        }

        [HttpPost]
        public CreatedViewModel Post([FromBody]CategoryViewModel categoryViewModel)
        {
            categoryViewModel.PropertyUuid = Request.Headers["propertyuuid"];

            var group = _groupRepository.Get(categoryViewModel.GroupUuid, categoryViewModel.PropertyUuid);

            var category = new Category(categoryViewModel.PropertyUuid,
                                        categoryViewModel.Name,
                                        (CategoryType)categoryViewModel.CategoryType,
                                        group,
                                        (CategoryNeed)categoryViewModel.CategoryNeed,
                                        categoryViewModel.Priority);
            _categoryRepository.Create(category);

            return new CreatedViewModel(category.Uuid);
        }

        [HttpPut("{uuid}")]
        public ActionResult Put(string uuid, [FromBody]CategoryViewModel categoryViewModel)
        {
            categoryViewModel.PropertyUuid = Request.Headers["propertyuuid"];

            var group = _groupRepository.Get(categoryViewModel.GroupUuid, categoryViewModel.PropertyUuid);

            _updateCategoryService.Update(uuid, categoryViewModel.PropertyUuid, categoryViewModel.Name,
                            (CategoryType)categoryViewModel.CategoryType,
                            group,
                            (CategoryNeed)categoryViewModel.CategoryNeed,
                            categoryViewModel.Priority);

            return Ok();
        }

        [HttpDelete("{uuid}")]
        public ActionResult Delete(string uuid)
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            _categoryRepository.Delete(uuid, propertyUuid);

            return Ok();
        }
    }
}
