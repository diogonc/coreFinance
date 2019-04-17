using System.Linq;
using CoreFinance.Domain.Helpers.Validation;
using CoreFinance.Domain.Repositories;

namespace CoreFinance.Domain.Categories
{
    public class DeleteGroupService
    {
        private IGroupRepository _groupRepository;
        private ICategoryRepository _categoryRepository;


        public DeleteGroupService(IGroupRepository groupRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _groupRepository = groupRepository;
        }

        public void Delete(string uuid, string propertyUuid)
        {
            var categories = _categoryRepository.GetFromGroup(propertyUuid, uuid);
            if (categories.Any())
                return;

            Validations<DeleteGroupService>.Build()
                            .When(categories.Any(), "Agrupamento de categoria não pode ser excluída pois existem categorias vinculadas a ela")
                            .Thwros();

            _groupRepository.Delete(uuid, propertyUuid);
        }
    }
}
