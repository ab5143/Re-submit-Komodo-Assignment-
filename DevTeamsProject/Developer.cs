using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool AccessToPluralSight { get; set; }


        public Developer() { }
        public Developer(string name, int idX, bool accesstoPluralSight)
        {
            Name = name;
            Id = idX;
            AccessToPluralSight = accesstoPluralSight;





        }
    }
}



