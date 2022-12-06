using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csd412_final.Models
{
    public class Notecards
    {
        public int Id { get; set; }
        public String Question { get; set; } = "";
        public String Answer { get; set; } = "";
        public string[] Decoys { get; set; }
        public int CollectionID { get; set; }
    }
}
