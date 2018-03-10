using Domain.Accounts;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CoreFinance.ViewModels;

namespace CoreFinance.Controllers
{
    [Route("api/[controller]")]
    public class OwnerController : Controller
    {
        private IOwnerRepository _ownerRepository;

        public OwnerController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
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
            var owner = new Owner(ownerViewModel.PropertyUuid, ownerViewModel.Name, ownerViewModel.Priority);
            _ownerRepository.Create(owner);

            return new CreatedViewModel(owner.Uuid);
        }

        [HttpPut("{uuid}")]
        public ActionResult Put(string uuid, [FromBody]OwnerViewModel ownerViewModel)
        {
            ownerViewModel.PropertyUuid = Request.Headers["propertyuuid"];

            var owner = _ownerRepository.Get(uuid, ownerViewModel.PropertyUuid);
            
            owner.Update(ownerViewModel.Name, ownerViewModel.Priority);

            _ownerRepository.Update(owner);

            return Ok();
        }

        [HttpDelete("{uuid}")]
        public ActionResult Delete(string uuid)
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            _ownerRepository.Delete(uuid, propertyUuid);

            return Ok();
        }
    }
}
