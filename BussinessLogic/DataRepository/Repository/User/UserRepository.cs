using AutoMapper;
using BussinessLogics;
using Data.DataContext.Models;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DataRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbProjectContext _context;
        public UserRepository(DbProjectContext context)
        {
            _context = context;
        }

        public Task<bool> Delete(int id)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserDTO> Save(UserDTO User)
        {
            try
            {
                var MaxID = _context.AdUsers.DefaultIfEmpty().Max(x => x == null ? 0 : x.Id) + 1;
                var _mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UserDTO, AdUser>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => MaxID))
                    .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                    .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
                    .ForMember(dest => dest.LastUpdate, opt => opt.MapFrom(src => DateTime.Now))
                    .ForMember(dest => dest.LastUpdatedBy, opt => opt.MapFrom(src => 1))
                    .BeforeMap((src, dest) =>
                    {
                        //Code Here ,if Needed
                    })
                    .AfterMap((src, dest) =>
                    {
                        src.Id = dest.Id;
                        src.IsActive = dest.IsActive;
                        src.CreatedDate = dest.CreatedDate;
                        src.LastUpdate = dest.LastUpdate;
                        src.LastUpdatedBy = dest.LastUpdatedBy;
                    })
                    ;
                }).CreateMapper();

                var user = _mapper.Map<AdUser>(User);

                _context.Add(user);


                var MaxID2 = _context.AdUserLogins.DefaultIfEmpty().Max(x => x == null ? 0 : x.Id) + 1;
                AdUserLogin login = new AdUserLogin();
                login.Id = MaxID2;
                login.UserId = MaxID;
                login.UserName = User.UserName;
                login.Password = User.Password;
                login.IsActive = true;
                login.CreatedDate = DateTime.Now;
                login.LastUpdate = DateTime.Now;
                _context.Add(login);

                await _context.SaveChangesAsync();

                return User;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<UserDTO> UserLogin(UserLoginDTO User)
        {
            try
            {
                UserDTO objUser = new UserDTO();
                var _mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AdUser, UserDTO>();
                }).CreateMapper();

                var userLogin = await _context.AdUserLogins.Where(x => x.UserName == User.UserName && x.Password == User.Password).FirstOrDefaultAsync();
                if (userLogin != null)
                {
                    var UserInfo = await _context.AdUsers.Where(x => x.Id == userLogin.UserId).FirstOrDefaultAsync();
                    if (UserInfo != null)
                    {
                        objUser = _mapper.Map<UserDTO>(UserInfo);
                    }
                }
                return objUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
