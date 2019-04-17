using CoreFinance.Domain.Categories;
using CoreFinance.DomainTest.Builders;
using Xunit;
using Moq;
using CoreFinance.Domain.Repositories;
using System.Collections.Generic;
using CoreFinance.Domain;
using System.Linq;

namespace CoreFinance.DomainTest.Categories
{
    public class UpdateGroupServiceTest
    {
        private Mock<ICategoryRepository> _categoryRepository;
        private Mock<IGroupRepository> _groupRepository;
        private Mock<UpdateCategoryService> _updateCategoryService;
        private UpdateGroupService _updateGroupService;
        private Category _category;
        private Group _group;

        public UpdateGroupServiceTest()
        {
            _categoryRepository = new Mock<ICategoryRepository>();
            _groupRepository = new Mock<IGroupRepository>();
            _updateCategoryService = new Mock<UpdateCategoryService>();

            _updateGroupService = new UpdateGroupService(_categoryRepository.Object, _groupRepository.Object, _updateCategoryService.Object);

            _category = CategoryBuilder.ACategory().Build();
            _group = new Group(_category.PropertyUuid, "gname", CategoryType.Debit, 9);
            _groupRepository.Setup(repository => repository.Get(_group.Uuid, _group.PropertyUuid)).Returns(_group);

        }

        [Fact]
        public void ShouldUpdateAGroup()
        {
            _updateGroupService.Update(_group.Uuid, _group.PropertyUuid, "new name", 2);

            Assert.Equal("new name", _group.Name);
            _groupRepository.Verify(repository => repository.Update(_group), Times.Once);
        }

        [Fact]
        public void ShouldUpdateAllCategories()
        {
            var firstCategory = CategoryBuilder.ACategory().WithName("teste").Build();
            var secondCategory = CategoryBuilder.ACategory().WithName("outro").Build();

            var categories = new List<Category>() {
                firstCategory, secondCategory
            };
            _categoryRepository.Setup(repository => repository.GetFromGroup(_group.PropertyUuid, _group.Uuid))
                                  .Returns(categories);

            _updateGroupService.Update(_group.Uuid, _group.PropertyUuid, "new name", 2);

            _updateCategoryService.Verify(service => service.Update(firstCategory.Uuid, firstCategory.PropertyUuid, firstCategory.Name,
                firstCategory.CategoryType, It.Is<Group>(group => group.Name == "new name"), firstCategory.Priority)
                                 , Times.Once);
            _updateCategoryService.Verify(service => service.Update(secondCategory.Uuid, secondCategory.PropertyUuid, secondCategory.Name,
                secondCategory.CategoryType, It.Is<Group>(group => group.Name == "new name"), secondCategory.Priority)
                                 , Times.Once);
        }
    }
}
