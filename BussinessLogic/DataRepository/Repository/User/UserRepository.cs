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
using EntityState = Shared.EntityState;

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

        public async Task<UserDTO> Save(UserDTO userDto)
        {
            try
            {
                var MaxID = _context.AdUsers.DefaultIfEmpty().Max(x => x == null ? 0 : x.Id) + 1;
                var MaxContactID = _context.AdUserContactAddresses.DefaultIfEmpty().Max(x => x == null ? 0 : x.Id) + 1;
                var _userMapper = new MapperConfiguration(cfg =>
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

                var _userContactMapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UserContactAddress, AdUserContactAddress>()
                       .BeforeMap((src, dest) =>
                       {
                           src.Id = MaxContactID++;
                           src.IsActive = true;
                       })
                       .AfterMap((src, dest) =>
                       {
                           switch (src.tag)
                           {
                               case (int)EntityState.Added:
                                   _context.Add(src);
                                   break;
                               case (int)EntityState.Modified:
                                   _context.Update(src);
                                   break;
                               case (int)EntityState.Deleted:
                                   _context.Remove(src);
                                   break;
                               default:
                                   break;
                           }
                       });
                }).CreateMapper();

                // Mapping userDto to AdUser
                var user = _userMapper.Map<AdUser>(userDto);
                _context.Add(user);

                // User Contact Modification
                userDto.UserContactAddresses.ForEach(item =>
                {
                    var adUserContactAddress = _userContactMapper.Map<AdUserContactAddress>(item);
                    // This mapping will trigger the AfterMap actions
                });

                //Set User Login
                await SetUserLogin(userDto, MaxID);

                await _context.SaveChangesAsync();

                return userDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async Task SetUserLogin(UserDTO userDto, long MaxID)
        {
            var MaxID2 = await _context.AdUserLogins.DefaultIfEmpty().MaxAsync(x => x == null ? 0 : x.Id) + 1;
            AdUserLogin login = new AdUserLogin();
            login.Id = MaxID2;
            login.UserId = MaxID;
            login.UserName = userDto.UserName;
            login.Password = userDto.Password;
            login.IsActive = true;
            login.CreatedDate = DateTime.Now;
            login.LastUpdate = DateTime.Now;
            _context.Add(login);
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
