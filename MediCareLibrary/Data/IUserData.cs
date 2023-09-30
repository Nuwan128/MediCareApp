using MediCareLibrary.Models;

namespace MediCareLibrary.Data
{
    public interface IUserData
    {
        void CreateUser(FullUserModel user);
        void DeleteUser();
        FullUserModel GetUserById(int id);
        List<PhoneNumberModel> GetUserPhoneNumbers(int userId);
        List<FullUserModel> GetUsers();
        FullUserModel LoginUser(FullUserModel user);
    }
}