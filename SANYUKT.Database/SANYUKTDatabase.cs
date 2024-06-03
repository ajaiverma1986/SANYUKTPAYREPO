using SANYUKT.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANYUKT.Database
{
    public class SANYUKTDatabase:BaseDatabase, ISANYUKTDatabase

    {
        private string _connectionString;
        public override string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    try
                    {
                        _connectionString = SANYUKTApplicationConfiguration.Instance.FIADB;
                    }
                    catch
                    {
                        throw;
                    }
                }
                return _connectionString;
            }
        }
    }
}
