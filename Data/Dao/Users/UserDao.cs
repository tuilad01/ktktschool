using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Dao.Test;
using Data.EF;

namespace Data.Dao.Users
{
    public class UserDao
    {
        private readonly lawfirmDbContext db = null;

        public UserDao()
        {
            db = new lawfirmDbContext();
        }

        public TN_User GetUserByEmail(string email)
        {
            return db.TN_User.FirstOrDefault(d => d.Email == email);
        }

        public LoginDtoResult LoginUser(string email, string password)
        {
            var user = db.TN_User.FirstOrDefault(d => d.Email == email);

            if (user == null) return new LoginDtoResult()
            {
                Result = LoginResult.EmailNotFound
            };
            if (user.Password != password) return new LoginDtoResult()
            {
                Result = LoginResult.PasswordNotCorrect
            };

            if (user.IsActive.HasValue && !user.IsActive.Value) return new LoginDtoResult()
            {
                Result = LoginResult.NotActive
            };

            return new LoginDtoResult()
            {
                Result = LoginResult.Ok
            };
        }

        public void RegisterUser(string email, string password, string name, string phone, string address)
        {
            if(string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException();
            var now = DateTime.Now;
            var user = new TN_User()
            {
                UserName = email,
                Email =  email,
                Password = password,
                Address = address,
                Phone = phone,
                CreatedDate = now,
                IsActive = true,
                FullName = name,
                LowerEmail = email.ToLower(),
            };

            InsertUser(user);
        }

        public void InsertUser(TN_User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            db.TN_User.Add(user);
            db.SaveChanges();
        }

        public List<TN_User> GetAllUser()
        {
            return db.TN_User.ToList();
        }

        public TN_User GetUserById(int id)
        {
            return db.TN_User.FirstOrDefault(d => d.Id == id);
        }

        public List<TN_UserType> GetAllUserType()
        {
            return db.TN_UserType.ToList();
        }
    }
}
