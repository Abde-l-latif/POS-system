using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosDataAccessLayer
{
    internal class clsSecureInfo
    {
        static private string _server = ".";
        static private string _database = "POS_System";
        static private string _username = "sa";
        static private string _password = "sa123456";


        static public string server
        {
            get
            {
                return _server;
            }
        }

        static public string database
        {
            get
            {
                return _database;
            }
        }

        static public string username
        {
            get
            {
                return _username;
            }
        }

        static public string password
        {
            get
            {
                return _password;
            }
        }
    }
}
