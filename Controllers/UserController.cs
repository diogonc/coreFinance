using CoreFinance.Domain;
using CoreFinance.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CoreFinance.Domain.Categories;
using CoreFinance.ViewModels;

namespace CoreFinance.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("")]
        public IEnumerable<User> Get()
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            return _userRepository.GetAll(propertyUuid);
        }

        [HttpGet("{uuid}")]
        public User Get(string uuid)
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            return _userRepository.Get(uuid, propertyUuid);
        }

        [HttpPost]
        public CreatedViewModel Post([FromBody]UserViewModel userViewModel)
        {
            userViewModel.PropertyUuid = Request.Headers["propertyuuid"];
            var user = new User(userViewModel.PropertyUuid, userViewModel.Username, userViewModel.Password);
            _userRepository.Create(user);

            return new CreatedViewModel(user.Uuid);
        }

        [HttpPut("{uuid}")]
        public ActionResult Put(string uuid, [FromBody]UserViewModel userViewModel)
        {
            userViewModel.PropertyUuid = Request.Headers["propertyuuid"];

            var user = _userRepository.Get(uuid, userViewModel.PropertyUuid);
            user.Update(userViewModel.Username, userViewModel.Password);
            _userRepository.Update(user);

            return Ok();
        }

        [HttpDelete("{uuid}")]
        public ActionResult Delete(string uuid)
        {
            var propertyUuid = Request.Headers["propertyuuid"];

            _userRepository.Delete(uuid, propertyUuid);

            return Ok();
        }
    }
}
