using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace owncloudsharp.Types
{
    public class GroupFolder
    {
        public int id { get; set; }
        public string name { get; set; }
        public int quota { get; set; }
        public int size { get; set; }
        public bool acl { get; set; }
    }
}
