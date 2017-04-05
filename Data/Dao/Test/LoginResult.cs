using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dao.Test
{
    public class LoginDtoResult
    {
        public LoginResult Result { get; set; }
    }

    public enum LoginResult
    {
        Ok,
        EmailNotFound,
        PasswordNotCorrect,
        NotActive,
    }
}
