using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Cache
{
    public static class UserLoginCache
    {
        public static int Id { get; set; }
        public static string FullName { get; set; }
        public static string MobileNo { get; set; }
        public static string UserType { get; set; }
        public static string Email { get; set; }
    }
}
