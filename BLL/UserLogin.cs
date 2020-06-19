using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Library;

namespace BLL
{
    public class UserLogin
    {
        UserDbSet uDbSet = new UserDbSet();

        public bool LoginUser(string userName, string password)
        { 
            return uDbSet.Loging(userName, password);
        }
    }
}
