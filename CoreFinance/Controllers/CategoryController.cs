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

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
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
            var category =  _categoryRepository.Get(uuid, propertyUuid);
            return Ok(category);
        }

        [HttpPost]
        public string Post([FromBody]CategoryViewModel categoryViewModel)
        {
            categoryViewModel.PropertyUuid = Request.Headers["propertyuuid"];
            
            var category = new Category(categoryViewModel.PropertyUuid,
                                        categoryViewModel.Name,
                                        (CategoryType)categoryViewModel.CategoryType,
                                        (CategoryNeed)categoryViewModel.CategoryNeed,
                                        categoryViewModel.Priority);
            _categoryRepository.Create(category);

            return category.Uuid;
        }

        [HttpPut("{uuid}")]
        public void Put(string uuid, [FromBody]CategoryViewModel categoryViewModel)
        {
            categoryViewModel.PropertyUuid = Request.Headers["propertyuuid"];
            var category = _categoryRepository.Get(uuid, categoryViewModel.PropertyUuid);
            category.Update(categoryViewModel.Name,
                            (CategoryType) categoryViewModel.CategoryType,
                            (CategoryNeed) categoryViewModel.CategoryNeed,
                            categoryViewModel.Priority);

            _categoryRepository.Update(category);
        }

        [HttpDelete("{uuid}")]
        public void Delete(string uuid)
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            _categoryRepository.Delete(uuid, propertyUuid);
        }
    }
}
