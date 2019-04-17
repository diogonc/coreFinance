using System;
using CoreFinance.Domain.Repositories;

namespace CoreFinance.Domain.Categories
{
    public class UpdateGroupService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly UpdateCategoryService _updateCategoryService;

        public UpdateGroupService(ICategoryRepository categoryRepository, IGroupRepository groupRepository, UpdateCategoryService updateCategoryService)
        {
            _categoryRepository = categoryRepository;
            _groupRepository = groupRepository;
            _updateCategoryService = updateCategoryService;
        }

        public void Update(string uuid, string propertyUuid, string name, int priority)
        {
            var group = _groupRepository.Get(uuid, propertyUuid);

            group.Update(name, priority);

            var categories = _categoryRepository.GetFromGroup(propertyUuid, group.Uuid);
            foreach (var category in categories)
            {
                _updateCategoryService.Update(category.Uuid, propertyUuid, category.Name, category.CategoryType, group, category.Priority);
            }

            _groupRepository.Update(group);
        }
    }
}
