using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Models.Interfaces;

namespace RadioMarket.UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repo)
        {
            _repository = repo;
        }


        [HttpGet("{userId}")]
        public async Task<ActionResult<UserInfoDTO>> GetUserInfoByID(int userId)
        {
            var userData = await _repository.GetUserInfo(userId);

            if (userData.email is null)
            {
                return NotFound("User does not exist");
            } 
            else return Ok(userData);
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetUserCount()
        {
            var count = await _repository.GetUserCount();
            return Ok(count);
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewUser([FromBody] SignupDTO newUserInfo)
        {
            var result = await _repository.CreateNewUser(newUserInfo);

            if (result == ReqResult.Ok)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }

        [HttpPost("verify")]
        public async Task<ActionResult<ReqResult>> VerifyPassword([FromBody] IdentityDTO userIdentity)
        {
            var result = await _repository.VerifyUser(userIdentity);

            if (result == ReqResult.Ok)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }

    }
}
