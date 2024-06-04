using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANYUKT.Datamodel.Shared
{
    public class ListResponse : BaseResponse
    {
        public int TotalRecords { get; set; }
        public int CurrentPage { get; set; }
        public object Result { get; set; }
        public List<string> Headers { get; set; } = new List<string>();

        public ListResponse()
        {
        }

        public ListResponse(int TotalRecords, int CurrentPage, object Result)
        {
            this.TotalRecords = TotalRecords;
            this.CurrentPage = CurrentPage;
            this.Result = Result;
        }

        public void SetPagingOutput(SqlCommand cmd)
        {
            object obj = cmd.Parameters["@out_TotalRec"].Value;
            if (obj == null || obj == DBNull.Value)
            {
                TotalRecords = 0;
                return;
            }

            TotalRecords = Convert.ToInt32(obj);
        }
    }

}
