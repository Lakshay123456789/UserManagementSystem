using Models;

namespace BusinessAccessLayer.UserBusinessLayer
{
    public interface IUserBusinessLayer
    {
        Task DeleteMethod(Guid obj);
        Task<User> GetByIdUser(Guid Id);
        Task<IEnumerable<User>> GetMethod();
        Task InsertMethod(UserDto userDto);
        Task UpdateMethod(UserDto userDto, Guid Id);
    }
}