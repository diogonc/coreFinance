using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CoreFinance.Domain.Repositories;
using CoreFinance.Domain;
using CoreFinance.ViewModels;

namespace CoreFinance.Controllers
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
        public CreatedViewModel Post([FromBody]TransactionViewModel transactionViewModel)
        {
            transactionViewModel.PropertyUuid = Request.Headers["propertyuuid"];

            var account = (transactionViewModel.Account != null && !string.IsNullOrWhiteSpace(transactionViewModel.Account.Uuid))
                ? _accountRepository.Get(transactionViewModel.Account.Uuid, transactionViewModel.PropertyUuid)
                : null;

            var category = (transactionViewModel.Category != null && !string.IsNullOrWhiteSpace(transactionViewModel.Category.Uuid))
                ? _categoryRepository.Get(transactionViewModel.Category.Uuid, transactionViewModel.PropertyUuid)
                : null;

            var transaction = new Transaction(transactionViewModel.PropertyUuid,
                                              transactionViewModel.Date,
                                              transactionViewModel.Description,
                                              transactionViewModel.Value,
                                              account,
                                              category);

            _transactionRepository.Create(transaction);
            return new CreatedViewModel(transaction.Uuid);
        }

        [HttpPut("{uuid}")]
        public ActionResult Put(string uuid, [FromBody]TransactionViewModel transactionViewModel)
        {
            transactionViewModel.PropertyUuid = Request.Headers["propertyuuid"];

            var account = (transactionViewModel.Account != null && !string.IsNullOrWhiteSpace(transactionViewModel.Account.Uuid))
                           ? _accountRepository.Get(transactionViewModel.Account.Uuid, transactionViewModel.PropertyUuid)
                           : null;

            var category = (transactionViewModel.Category != null && !string.IsNullOrWhiteSpace(transactionViewModel.Category.Uuid))
                ? _categoryRepository.Get(transactionViewModel.Category.Uuid, transactionViewModel.PropertyUuid)
                : null;

            var transaction = _transactionRepository.Get(uuid, transactionViewModel.PropertyUuid);

            if (transaction != null)
            {
                transaction.Update(transactionViewModel.Date,
                                               transactionViewModel.Description,
                                               transactionViewModel.Value,
                                               account,
                                               category);

                _transactionRepository.Update(transaction);
            }

            return Ok();
        }

        [HttpDelete("{uuid}")]
        public ActionResult Delete(string uuid)
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            _transactionRepository.Delete(uuid, propertyUuid);

            return Ok();
        }
    }
}
