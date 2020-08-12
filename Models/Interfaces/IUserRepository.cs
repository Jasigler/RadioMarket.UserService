using DataLayer.DTOs;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Models.Interfaces
{
    public interface IUserRepository
    {
        public Task<ReqResult> CreateNewUser(SignupDTO newUserInfo);
        public Task<ReqResult> VerifyUser(IdentityDTO userLoginInfo);
        public Task<UserInfoDTO> GetUserInfo(int userId);
        

    }
}
