using MediCareLibrary.Models;

namespace MediCareLibrary.Data
{
    public interface IDatabaseData
    {
        void CreateUser(FullUserModel user);
        List<FullUserModel> GetUsers();
        FullUserModel GetUserById(int id);
        FullUserModel LoginUser(FullUserModel user);
    }
}