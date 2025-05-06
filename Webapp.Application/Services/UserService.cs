using Webapp.Application.Data;
using Webapp.Application.Dtos;
using Webapp.Application.Services.Interface;
using Webapp.Domain;

namespace Webapp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
           
        }
        public void AddUser(InsertUserDto userDto)
        {
            try
            {
                var user = new User 
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Gender = userDto.Gender,
                    ImageURL = userDto.ImageURL,
                    RegisteredDate = userDto.RegisteredDate,
                    IsActive = true
                };

                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding user: " + ex.Message);
                
            }
        }

        public void DeleteUser(Guid id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                    throw new Exception("User not found");

                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            catch (Exception ex) 
            {
                throw new Exception("Error deleting user: " + ex.Message);
            }
        }

        public List<GetAllUser> GetAllUsers()
        {
            try
            {
                var users = _context.Users.Where(u => !u.IsActive).ToList();

                if (users == null)
                    throw new Exception("No active users found");

                var result = new List<GetAllUser>();

                foreach(var u in users)
                {
                   result.Add( new GetAllUser
                   {
                        FirstName = u.FirstName,
                        LastName  = u.LastName,
                        Gender   = u.Gender,
                        ImageURL = u.ImageURL,
                        RegisteredDate = u.RegisteredDate
                   });
                }

                return result;
                           
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);

            }
        }

        public GetAllUser GetById(Guid id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                throw new Exception("No active users found");

            var result = new GetAllUser()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                ImageURL = user.ImageURL,
                RegisteredDate = user.RegisteredDate
            };

            return result;
        }

        public void UpdateUser(Guid id, UpdateUserDto userDto)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                    throw new Exception("User not found");

                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                user.Gender = userDto.Gender;
                user.ImageURL = userDto.ImageURL;
                user.IsActive  = userDto.IsActive;

                _context.Users.Update(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating user: " + ex.Message);
            }
        }
    }
}
