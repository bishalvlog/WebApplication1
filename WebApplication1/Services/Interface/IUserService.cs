using WebApplication1.Dtos;

namespace WebApplication1.Services.Interface
{
    public interface IUserService
    {
        void AddUser(InsertUserDto userDto);
    }
}
