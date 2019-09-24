using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioReactivoDesktop.Util
{
    public class Utility
    {

        public static SqlParameter GetInputSqlParam(string parameterName, string value)
        {
            return new SqlParameter(parameterName, value)
            {
                DbType = DbType.String,
                Direction = ParameterDirection.Input
            };
        }

    }
}
