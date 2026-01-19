using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosDataAccessLayer
{
    internal class clsDataSettings
    {
        static public string ConnectionString = $@"server={clsSecureInfo.server};database={clsSecureInfo.database};
        user ID={clsSecureInfo.username};password={clsSecureInfo.password}";
    }
}
