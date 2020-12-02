using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        private readonly List<DevTeamContent> _ListOfTeams = new List<DevTeamContent>();





        // this gives you access to the _developerDirectory so you can access existing Developers and add them to a team
        ///private readonly List<DevTeam> _devTeams = new List<DevTeam>();

        //DevTeam Create----------------------------------------------------

        public void AddContentToList(DevTeamContent content)
        {
            _ListOfTeams.Add(content);
        }

        //DevTeam Read

        public List<DevTeamContent> GetContentList()
        {
            return _ListOfTeams;
        }
        //---------------------------------------------



        //DevTeam Update


        public bool UpdateExistingTeam(string OriginalTeamName, int OriginalTeamNumber, DevTeamContent newContent)

        {

            DevTeamContent oldTeam = GetNewTeam(OriginalTeamNumber);


            if (oldTeam != null)
            {
                oldTeam.TeamName = newContent.TeamName;
                oldTeam.TeamNumber = newContent.TeamNumber;

                return true;

            }

            return false;

        }





        //DevTeam Delete

        public bool RemoveContentFromList(int teamnumberz)
        {
            DevTeamContent content = GetNewTeam(teamnumberz);


            if (content == null)
            {
                return false;

            }

            int initialcount = _ListOfTeams.Count;

            _ListOfTeams.Remove(content);

            if (initialcount > _ListOfTeams.Count)

            {
                return true;
            }
            else
            {
                return false;
            }

        }




        //DevTeam Helper (Get Team by ID)
        public DevTeamContent GetNewTeam(int teamnumberX)

        {
            foreach (DevTeamContent content in _ListOfTeams)
            {
                if (content.TeamNumber == teamnumberX)
                {
                    return content;
                }

            }

            return null;
        }

    }
}

