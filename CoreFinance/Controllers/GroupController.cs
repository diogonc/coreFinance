﻿using Domain;
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

        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
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
        public string Post([FromBody]AccountViewModel groupViewModel)
        {
            groupViewModel.PropertyUuid = Request.Headers["propertyuuid"];
            var group = new Group(groupViewModel.PropertyUuid, groupViewModel.Name, groupViewModel.Priority);
            _groupRepository.Create(group);
            return group.Uuid;
        }

        [HttpPut("{uuid}")]
        public void Put(string uuid, [FromBody]AccountViewModel groupViewModel)
        {
            groupViewModel.PropertyUuid = Request.Headers["propertyuuid"];

            var group = _groupRepository.Get(uuid, groupViewModel.PropertyUuid);
            
            group.Update(groupViewModel.Name, groupViewModel.Priority);

            _groupRepository.Update(group);
        }

        [HttpDelete("{uuid}")]
        public void Delete(string uuid)
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            _groupRepository.Delete(uuid, propertyUuid);
        }
    }
}
