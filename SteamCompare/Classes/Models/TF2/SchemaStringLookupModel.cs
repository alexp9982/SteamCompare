using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCompare.Classes.Models.TF2
{
    public class SchemaStringLookupModel
    {
        public string TableName { get; set; }
        
        public IList<SchemaStringModel> Strings { get; set; }
    }
}
