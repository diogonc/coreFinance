using System.Linq;
using Domain.Helpers.Validation;
using Domain.Repositories;

namespace Domain.Accounts
{
    public class DeleteOwnerService
    {
        private IOwnerRepository _ownerRepository;
        private IAccountRepository _accountRepository;


        public DeleteOwnerService(IAccountRepository accountRepository, IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
            _accountRepository = accountRepository;
        }

        public void Delete(string uuid, string propertyUuid)
        {
            var accounts = _accountRepository.GetFromOwner(propertyUuid, uuid);
            if(accounts.Any())
                return;

            Validations<DeleteOwnerService>.Build()
                            .When(accounts.Any(), "Dono não pode ser excluído pois existem contas vinculadas a ele")
                            .Thwros();

            _ownerRepository.Delete(uuid, propertyUuid);
        }
    }
}
