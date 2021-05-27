using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_poc.Model;
using asp_poc.service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace asp_poc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
      

        private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;

        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public UserDto Get(string id)
        {
            _logger.LogInformation("Request get with id {[0]}", id);
            return _userService.GetUser(id);
        }  
        
        [HttpDelete]
        public UserDto Delete(string id)
        {
            _logger.LogInformation("Request delete with id {[0]}", id);
            return _userService.DeleteUser(id);
        } 
        
        [HttpPut]
        public UserDto Edit(string id, UserDto user)
        {
            _logger.LogInformation("Request edit with id {[0]}", id);
            return _userService.EditUser(id, user);
        }
        
        [HttpPost]
        public UserDto Save(UserDto user)
        {
            _logger.LogInformation("Request add with name {[0]}", user.Name);
            return _userService.AddUser(user);
        }
    }
}