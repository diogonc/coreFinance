using System;
using Domain.Repositories;

namespace Domain.Categories
{
    public class UpdateCategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITransactionRepository _transactionRepository;

        public UpdateCategoryService(ICategoryRepository categoryRepository, ITransactionRepository transactionRepository)
        {
            _categoryRepository = categoryRepository;
            _transactionRepository = transactionRepository;
        }

        public void Update(string uuid, string propertyUuid, string name, CategoryType categoryType, Group group, int priority)
        {
            var category = _categoryRepository.Get(uuid, propertyUuid);

            category.Update(name, categoryType, group, priority);

            UpdateTransactions(category);

            _categoryRepository.Update(category);
        }

        private void UpdateTransactions(Category category)
        {
            var transactions = _transactionRepository.GetFromCategory(category.PropertyUuid, category.Uuid);

            foreach(var transaction in transactions)
            {
                transaction.UpdateCategory(category);
                _transactionRepository.Update(transaction);
            }
        }
    }
}
