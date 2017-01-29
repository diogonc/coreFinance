using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using financeApi.Repositories;
using financeApi.Models;
using financeApi.ViewModels;

namespace financeApi.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        private ITransactionRepository _transactionRepository;
        private IAccountRepository _accountRepository;
        private ICategoryRepository _categoryRepository;

        public TransactionController(ITransactionRepository transactionRepository,
                                     IAccountRepository accountRepository,
                                     ICategoryRepository categoryRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet("")]
        public IEnumerable<Transaction> Get()
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            return _transactionRepository.GetAll(propertyUuid);
        }

        [HttpGet("{uuid}")]
        public Transaction Get(string uuid)
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            return _transactionRepository.Get(uuid, propertyUuid);
        }

        [HttpPost]
        public string Post([FromBody]TransactionViewModel transactionViewModel)
        {
            transactionViewModel.PropertyUuid = Request.Headers["propertyuuid"];
            
            var account = _accountRepository.Get(transactionViewModel.AccountUuid,
                                                 transactionViewModel.PropertyUuid);

            var category = _categoryRepository.Get(transactionViewModel.CategoryUuid,
                                                   transactionViewModel.PropertyUuid);
            
            var transaction = new Transaction(transactionViewModel.PropertyUuid, 
                                              transactionViewModel.Date, 
                                              transactionViewModel.Description, 
                                              transactionViewModel.Value,
                                              account,
                                              category);

            _transactionRepository.Create(transaction);
            return transaction.Uuid;
        }

        [HttpPut("{uuid}")]
        public void Put(string uuid, [FromBody]TransactionViewModel transactionViewModel)
        {
            transactionViewModel.PropertyUuid = Request.Headers["propertyuuid"];

            var account = _accountRepository.Get(transactionViewModel.AccountUuid,
                                                 transactionViewModel.PropertyUuid);

            var category = _categoryRepository.Get(transactionViewModel.CategoryUuid,
                                                   transactionViewModel.PropertyUuid);
            
            var transaction = new Transaction(uuid, 
                                        transactionViewModel.PropertyUuid, 
                                        transactionViewModel.Date, 
                                        transactionViewModel.Description, 
                                        transactionViewModel.Value,
                                        account,
                                        category);

            _transactionRepository.Update(transaction);
        }

        [HttpDelete("{uuid}")]
        public void Delete(string uuid)
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            _transactionRepository.Delete(uuid, propertyUuid);
        }
    }
}
