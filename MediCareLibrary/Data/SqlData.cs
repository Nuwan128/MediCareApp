using MediCareLibrary.Databases;
using MediCareLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCareLibrary.Data
{
    public class SqlData : IDatabaseData
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }

        public void CreateUser(FullUserModel user)
        {
           
            _db.SaveData("dbo.spUsers_Insert_User", new
            {
                firstName = user.FirstName,
                lastName = user.LastName,
                password = user.Password,
                NIC = user.NIC,
                birthday = user.Birthday,
                email = user.Email,
                address = user.Address,
                userType = user.UserType
            }, connectionStringName, true);

            FullUserModel newUser = _db.LoadData<FullUserModel, dynamic>("SELECT * FROM dbo.Users WHERE NIC = @NIC", new { NIC = user.NIC }, connectionStringName, false).First();

            newUser.phoneNumbers = user.phoneNumbers;
            foreach (var phoneNumber in user.phoneNumbers)
            {
                phoneNumber.UserId = newUser.Id;
                PhoneNumberModel phoneNumber1 = new PhoneNumberModel
                {
                    UserId = phoneNumber.UserId,
                    PhoneNumber = phoneNumber.PhoneNumber
                };


                _db.SaveData("dbo.spUserPhoneNumbers_Insert_Number",
                             new
                             {
                                 Id = phoneNumber.UserId,
                                 phoneNumber = phoneNumber.PhoneNumber

                             }, connectionStringName, true);




                if (user.UserType.ToLower() == "admin")
                {
                    
                }
                else if(user.UserType.ToLower() == "doctor")
                {
                    _db.SaveData("dbo.spDoctor_Insert_Doctor",
                        new 
                        { 
                            Id = newUser.Id,
                            speciality = user.Speciality

                        }, connectionStringName, true);
                }
                else if (user.UserType.ToLower() == "patient")
                {
                    _db.SaveData("dbo.spPatient_Insert_Patient",
                        new
                        {
                            Id = newUser.Id,
                            height = user.Height,
                            weight = user.Weight

                        }, connectionStringName, true);
                }
            }



        }

        public void LoginUser(FullUserModel user)
        {
            _db.LoadData<FullUserModel, dynamic>("dbo.spUser_Verify_User",
                                                                            new 
                                                                            { 
                                                                                password = user.Password,
                                                                                email = user.Email,
                                                                                userType = user.UserType
                                                                            },
                                                                            connectionStringName,
                                                                            true).First();


            

        }

        public List<FullUserModel> GetUsers()
        {
            List<FullUserModel> users = _db.LoadData<FullUserModel, dynamic>("dbo.spUsers_Get_All_Users",
                                                                             new { },
                                                                             connectionStringName,
                                                                             true);

            foreach (var user in users)
            {
                List<PhoneNumberModel> phoneNumbers = GetUserPhoneNumbers(user.Id);
                user.phoneNumbers = phoneNumbers;
            }

            return users;
            //string sql = @"select * 
            //               from dbo.UserPhoneNumbers";
            //List<PhoneNumberModel> userPhoneNumbers = _db.LoadData<PhoneNumberModel, dynamic>(sql, new { }, connectionStringName, false);

            //foreach (var user in users)
            //{
            //    foreach (var phoneNumber in userPhoneNumbers)
            //    {
            //        if (user.Id == phoneNumber.UserId)
            //        {
            //            user.phoneNumbers.Add(phoneNumber);
            //        }

            //    }
            //}

            //return users;
        }
        public List<PhoneNumberModel> GetUserPhoneNumbers(int userId)
        {
            string sql = @"select * 
                           from dbo.UserPhoneNumbers ph
                           where ph.UserId = @Id
                            ";
            List<PhoneNumberModel> userPhoneNumbers = _db.LoadData<PhoneNumberModel, dynamic>(sql, new { Id = userId }, connectionStringName, false);
            return userPhoneNumbers;
        }

        public FullUserModel GetUserById(int id)
        {
            var user = _db.LoadData<FullUserModel, dynamic>("dbo.spUser_GetUserBy_Id", new { Id = id }, connectionStringName, true).First();

             

            user.phoneNumbers = GetUserPhoneNumbers(user.Id);

            return user;

        }
        public void DeleteUser()
        {

        }
    }
}
