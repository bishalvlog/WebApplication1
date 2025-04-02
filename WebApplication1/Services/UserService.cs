using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Model;
using WebApplication1.Services.Interface;

namespace WebApplication1.Services
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

        public UserGetById getById(int id) 
        {
            _context.Address.ToList();

            return new UserGetById
            {
               
            };
        }
    }
}
