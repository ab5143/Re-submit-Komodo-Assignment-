using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    

 public class DevTeamContent
        {
            public string TeamName { get; set; }
            public int TeamNumber { get; set; }


            
            public DevTeamContent() { }



            public DevTeamContent(string teamname, int teamnumber)
            {
                TeamName = teamname;
            TeamNumber = teamnumber;

            }
  }
}
