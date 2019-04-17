using CoreFinance.Domain.Accounts;
using CoreFinance.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CoreFinance.ViewModels;

namespace CoreFinance.Controllers
{
    [Route("api/[controller]")]
    public class OwnerController : Controller
    {
        private IOwnerRepository _ownerRepository;
        private UpdateOwnerService _updateOwnerService;
        private DeleteOwnerService _deleteOwnerService;

        public OwnerController(IOwnerRepository ownerRepository, UpdateOwnerService updateOwnerService, DeleteOwnerService deleteOwnerService)
        {
            _ownerRepository = ownerRepository;
            _updateOwnerService = updateOwnerService;
            _deleteOwnerService = deleteOwnerService;
        }

        [HttpGet("")]
        public IEnumerable<Owner> Get()
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            return _ownerRepository.GetAll(propertyUuid);
        }

        [HttpGet("{uuid}")]
        public Owner Get(string uuid)
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            return _ownerRepository.Get(uuid, propertyUuid);
        }

        [HttpPost]
        public CreatedViewModel Post([FromBody]OwnerViewModel ownerViewModel)
        {
            ownerViewModel.PropertyUuid = Request.Headers["propertyuuid"];
            var owner = new Owner(ownerViewModel.PropertyUuid, ownerViewModel.UserLogin, ownerViewModel.Name, ownerViewModel.Priority);
            _ownerRepository.Create(owner);

            return new CreatedViewModel(owner.Uuid);
        }

        [HttpPut("{uuid}")]
        public ActionResult Put(string uuid, [FromBody]OwnerViewModel ownerViewModel)
        {
            ownerViewModel.PropertyUuid = Request.Headers["propertyuuid"];

            _updateOwnerService.Update(uuid, ownerViewModel.PropertyUuid, ownerViewModel.UserLogin, ownerViewModel.Name, ownerViewModel.Priority);

            return Ok();
        }

        [HttpDelete("{uuid}")]
        public ActionResult Delete(string uuid)
        {
            var propertyUuid = Request.Headers["propertyuuid"];

            _deleteOwnerService.Delete(uuid, propertyUuid);

            return Ok();
        }
    }
}
