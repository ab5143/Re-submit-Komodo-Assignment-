using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo 
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        //Developer Create
        public void AddNamesToList(Developer content)
        {
             _developerDirectory.Add(content);

        }

    



        //Developer Read


        public List<Developer> GetContentlist()
        {
            
            return _developerDirectory;
        }









        //Developer Update

        public bool UpdateExistingNames(int idX, Developer newNames)
        {

            Developer oldName = GetName(idX);

            if (oldName != null)

            {
                oldName.Name = newNames.Name;
                oldName.Id = newNames.Id;
                oldName.AccessToPluralSight = newNames.AccessToPluralSight;

                return true;


            }
            return false;



        }



        //Developer Delete

        public bool RemoveNameFromList(int idX)
        {

            Developer content = GetName(idX);


            if (content == null)
            {
                return false;

            }

            int NameIdCount = _developerDirectory.Count;


            _developerDirectory.Remove(content);


            if (NameIdCount > _developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        //Developer Helper (Get Developer by ID)

        public Developer GetName(int idX)
        {
            foreach (Developer content in _developerDirectory)
            {
                if (content.Id == idX)
                {
                    return content;
                }

            }
            return null;
        }




    }
}



