using Domain;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Domain.Categories;
using CoreFinance.ViewModels;

namespace CoreFinance.Controllers
{
    [Route("api/[controller]")]
    public class GroupController : Controller
    {
        private IGroupRepository _groupRepository;
        private UpdateGroupService _updateGroupService;
        private DeleteGroupService _deleteGroupService;

        public GroupController(IGroupRepository groupRepository, UpdateGroupService updateGroupService,
                               DeleteGroupService deleteGroupService)
        {
            _groupRepository = groupRepository;
            _updateGroupService = updateGroupService;
            _deleteGroupService = deleteGroupService;
        }

        [HttpGet("")]
        public IEnumerable<Group> Get()
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            return _groupRepository.GetAll(propertyUuid);
        }

        [HttpGet("{uuid}")]
        public Group Get(string uuid)
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            return _groupRepository.Get(uuid, propertyUuid);
        }

        [HttpPost]
        public CreatedViewModel Post([FromBody]GroupViewModel groupViewModel)
        {
            groupViewModel.PropertyUuid = Request.Headers["propertyuuid"];
            var group = new Group(groupViewModel.PropertyUuid, groupViewModel.Name, (CategoryType)groupViewModel.CategoryType, groupViewModel.Priority);
            _groupRepository.Create(group);

            return new CreatedViewModel(group.Uuid);
        }

        [HttpPut("{uuid}")]
        public ActionResult Put(string uuid, [FromBody]GroupViewModel groupViewModel)
        {
            groupViewModel.PropertyUuid = Request.Headers["propertyuuid"];

            _updateGroupService.Update(uuid, groupViewModel.PropertyUuid, groupViewModel.Name, groupViewModel.Priority);
            
            return Ok();
        }

        [HttpDelete("{uuid}")]
        public ActionResult Delete(string uuid)
        {
            var propertyUuid = Request.Headers["propertyuuid"];

            _deleteGroupService.Delete(uuid, propertyUuid);

            return Ok();
        }
    }
}
