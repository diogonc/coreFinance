using System.Linq;
using CoreFinance.Domain.Helpers.Validation;
using CoreFinance.Domain.Repositories;

namespace CoreFinance.Domain.Categories
{
    public class DeleteCategoryService
    {
        private ICategoryRepository _categoryRepository;
        private ITransactionRepository _transactionRepository;


        public DeleteCategoryService(ICategoryRepository categoryRepository, ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
            _categoryRepository = categoryRepository;
        }

        public void Delete(string uuid, string propertyUuid)
        {
            var transactions = _transactionRepository.GetFromCategory(propertyUuid, uuid);
            if (transactions.Any())
                return;

            Validations<DeleteCategoryService>.Build()
                            .When(transactions.Any(), "Categoria não pode ser excluída pois existem transações vinculadas a ela")
                            .Thwros();

            _categoryRepository.Delete(uuid, propertyUuid);
        }
    }
}
