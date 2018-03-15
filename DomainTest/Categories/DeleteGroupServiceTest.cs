using System.Collections.Generic;
using Domain;
using Domain.Categories;
using Domain.Repositories;
using DomainTest.Builders;
using Domain.Helpers.Validation;
using Moq;
using Xunit;

namespace DomainTest.Categories
{
    public class DeleteGroupServiceTest{
        
        private DeleteGroupService _deleteGroupService;
        private Mock<IGroupRepository> _groupRepository;
        private Mock<ICategoryRepository> _categoryRepository;
        private string _uuid = "234234234";
        private string _propertyUuid = "234929999";

        public DeleteGroupServiceTest()
        {
            _groupRepository = new Mock<IGroupRepository>();
            _categoryRepository = new Mock<ICategoryRepository>();
            _deleteGroupService = new DeleteGroupService(_groupRepository.Object, _categoryRepository.Object);
        }

        [Fact]
        public void ShoulDeleteGroup()
        {
            _deleteGroupService.Delete(_uuid, _propertyUuid);

            _groupRepository.Verify(repository => repository.Delete(_uuid, _propertyUuid), Times.Once);
        }

        [Fact]
        public void ShouldntDeleteIfThereWasACategory()
        {
            var categories = new List<Category>(){ CategoryBuilder.ACategory().Build()};
            _categoryRepository.Setup(repository => repository.GetFromGroup(_propertyUuid, _uuid)).Returns(categories);

            // var exception = Assert.Throws<DomainException<DeleteCategoryService>>(() => _deleteCategoryService.Delete(_uuid, _propertyUuid));
            // Assert.Equal("Categoria não pode ser excluída pois existem transações vinculadas a ela\n", exception.Message);

            _groupRepository.Verify(repository => repository.Delete(_uuid, _propertyUuid), Times.Never);
        }
    }
}
