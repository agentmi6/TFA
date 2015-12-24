using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsTFA.Domain
{
    public class Character : BaseEntity
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public bool isForceSensitive { get; set; }
        public string imgUrl { get; set; }


        public int SideID { get; set; }
        public virtual Side Side { get; set; }
    }
}
