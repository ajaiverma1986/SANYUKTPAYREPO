using SANYUKT.Datamodel.Common;
using SANYUKT.Datamodel.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANYUKT.Datamodel.Shared
{
    public class ListRequest
    {
        [SQLParam(Usage = SQLParamPlaces.None)]
        public int PageNo { get; set; } = 1;
        [SQLParam(Usage = SQLParamPlaces.None)]
        public int PageSize { get; set; } = 20;
        [SQLParam(Usage = SQLParamPlaces.None)]
        public string OrderBy { get; set; }

        public void SetDefaults()
        {
            this.PageNo = 1;
            this.PageSize = 10;
            this.OrderBy = null;
        }
    }
}
