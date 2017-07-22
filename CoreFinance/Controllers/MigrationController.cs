using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Migration;
using Domain.Repositories;
using Domain;


namespace CoreFinance.Controllers
{
    [Route("api/[controller]")]
    public class MigrationController : Controller
    {
        private MigrateTransactions _migration;
        private ITransactionRepository _transactionRepository;
        private IAccountRepository _accountRepository;
        private ICategoryRepository _categoryRepository;

        public MigrationController(MigrateTransactions migration,
                                   ITransactionRepository transactionRepository,
                                   IAccountRepository accountRepository,
                                   ICategoryRepository categoryRepository)
        {
            _migration = migration;
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _categoryRepository = categoryRepository;
        }

            // GET api/values
        [HttpGet("20170722")]
        public void Migrate()
        {
            _migration.Migrate();
        }

        [HttpGet("backup")]
        public ActionResult Backup()
        {
            var categories = _categoryRepository.GetAll();
            var accounts = _accountRepository.GetAll();
            var transactions = _transactionRepository.GetAll();

            return Ok(new {categories, accounts, transactions});
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
