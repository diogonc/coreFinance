using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Domain.Repositories;
using Domain;
using CoreFinance.ViewModels;

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
        public Category Get(string uuid)
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            return _categoryRepository.Get(uuid, propertyUuid);
        }

        [HttpPost]
        public string Post([FromBody]CategoryViewModel categoryViewModel)
        {
            categoryViewModel.PropertyUuid = Request.Headers["propertyuuid"];
            var category = new Category(categoryViewModel.PropertyUuid,
                                        categoryViewModel.Name,
                                        categoryViewModel.CategoryType,
                                        categoryViewModel.Priority);
            _categoryRepository.Create(category);
            return category.Uuid;
        }

        [HttpPut("{uuid}")]
        public void Put(string uuid, [FromBody]CategoryViewModel categoryViewModel)
        {
            categoryViewModel.PropertyUuid = Request.Headers["propertyuuid"];
            var category = new Category(uuid,
                                        categoryViewModel.PropertyUuid,
                                        categoryViewModel.Name,
                                        categoryViewModel.CategoryType,
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
