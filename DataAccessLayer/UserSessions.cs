using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class UserSessions
    {

        public string userid { get; set; }
        public string username { get; set; }
        public string userpass { get; set; }
		public string? roles { get; set; }
		public string? useremail { get; set; }



    }
}
