using SANYUKT.Datamodel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANYUKT.Datamodel.Library
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class SQLParam : Attribute
    {
        public SQLParamPlaces Usage { get; set; } = SQLParamPlaces.Default;
        public string ReaderName { get; set; }
        public string InputParamName { get; set; }
    }
}
