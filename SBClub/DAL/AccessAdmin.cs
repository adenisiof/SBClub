using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using SBClub;

namespace DAL
{
    class AccessAdmin
    {
        private string pathConn = SBClub.Properties.Settings.Default["SBClubConnectionString"].ToString();
    }
}
