using AutoMapper;
using DataLayer.Context;
using DataLayer.DTOs;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Models.Enums;
using Models.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly UserContext _context;
        private readonly IMapper _mapper;

        public UserRepository(UserContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReqResult> CreateNewUser(SignupDTO newUserInfo)
        {
            var emailIsUsed = await _context.Users
                .Where(user => user.email == newUserInfo.email)
                .FirstOrDefaultAsync();

            if (emailIsUsed != null)
            {
                return ReqResult.EmailInUse;
            }

            var newHash = BCrypt.Net.BCrypt.HashPassword(newUserInfo.password);

            var newUser = new NewUserDTO
            {
                email = newUserInfo.email,
                first_name = newUserInfo.first_name,
                last_name = newUserInfo.last_name,
                password_hash = newHash 
            };

            var dbInsertPayload = _mapper.Map<User>(newUser); 

            await _context.AddAsync(dbInsertPayload);
            await _context.SaveChangesAsync();

            return ReqResult.Ok;
        }

        public async Task<UserInfoDTO> GetUserInfo(int userId)
        {
            var user = await _context.Users
                .Where(user => user.user_id == userId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                var notFound = new UserInfoDTO();
                return notFound;
            }
            UserInfoDTO info = new UserInfoDTO
            {
                email = user.email,
                first_name = user.first_name,
                last_name = user.last_name
            };

            return info;
        }

        public async Task<ReqResult> VerifyUser(IdentityDTO userLoginInfo)
        {
            var userToVerify = await _context.Users
                 .Where(user => user.email == userLoginInfo.email)
                 .FirstOrDefaultAsync();

            if (userToVerify == null)
            {
                return ReqResult.EmailDoesntExist; 
            }

            bool isValidLogin = BCrypt.Net.BCrypt.Verify(userLoginInfo.password, 
                userToVerify.password_hash);

            if (isValidLogin)
            {
                return ReqResult.Ok;

            } else return ReqResult.BadPassword;
        }

        public async Task<int> GetUserCount()
        {
            return await _context.Users.CountAsync();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }
    }
}
