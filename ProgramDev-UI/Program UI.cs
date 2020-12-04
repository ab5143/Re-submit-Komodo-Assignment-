﻿using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramDev_UI
{
    class ProgramUI
    {

        
        /// </summary
        /// you have to create it here in program UI
        private DeveloperRepo _contentDeveloper = new DeveloperRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();

        public void Run()
        {
            SeedContentList();
            Menu();
        }


        private void Menu()
        {

            //??
            bool keepRunning = true;
            while (keepRunning)
            {

                // Display the options to the user 
                Console.WriteLine("Select a Developer Option:\n" +

                    "1. Create New Developer\n" +
                    "2. View All Developers\n" +
                    "3. Developers with Access To Pluralsight\n" +
                    "4. Update Developers\n" +
                    "5. Delete Developers\n" +
                    "6. Create Teams\n" +
                    "7. Read Teams\n" +
                    "8. Exit");


                //Get the User's Input
                string input = Console.ReadLine();

                //Evaluate User's Input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create New Developer
                        CreateNewName();
                        break;
                    case "2":
                        // View All Developers
                        DisplayAllNames();
                        break;
                    case "3":
                        // Developers with Access To Pluralsight
                        DisplayNameswithPluralsight();
                        break;
                    case "4":
                        //Update Developers ----------------------------------------------------------
                        UpdateDevelopers();
                        break;
                    case "5":
                        //Delete Developers ----------------------------------------------------------
                        DeleteDevelopers();
                        break;
                    case "6":
                        // Create NewDevTeams
                        CreateNewTeams();
                        break;
                    case "7":
                        // Read List of DevTeams
                        ReadDevTeams();
                        break;
                    case "8":
                        //Exit 
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter a Valid Number. ");
                        break;

                }

                Console.WriteLine("Please Press any Key to Continue........");
                Console.ReadKey();
                Console.Clear();
            }

        }

        // 1 Create New Names 

        private void CreateNewName()
        {

            Console.Clear();
            Developer NewNames = new Developer();

            // Names

            Console.WriteLine("Enter the Name of the Developer");
            NewNames.Name = Console.ReadLine();


            //ID
            Console.WriteLine("Enter the ID of the Developer");

            NewNames.Id = int.Parse(Console.ReadLine());

            //AccessTo Pluralsight 
            Console.WriteLine(" Does this Developer has access to Pluralsight? Y/N");

            string Response = Console.ReadLine();

            if (Response == "Y")
            {
                NewNames.AccessToPluralSight = true;
            }
            else
            {
                NewNames.AccessToPluralSight = false;
            }

            _contentDeveloper.AddNamesToList(NewNames);
        }



        // 2 View All Developers are saved 


        private void DisplayAllNames()
        {
            Console.Clear();
            List<Developer> ListOfDevelopers = _contentDeveloper.GetContentlist();
            foreach (Developer content in ListOfDevelopers)
            {
                Console.WriteLine($"Name: {content.Name}\n" +
                    $"Id: {content.Id}");
            }

        }



        // 3.  Developers with Access To Pluralsight

        private void DisplayNameswithPluralsight()
        {
            Console.Clear();
            List<Developer> listOfDevelopes = _contentDeveloper.GetContentlist();
            foreach (Developer developer in listOfDevelopes)
            {
                if (developer.AccessToPluralSight == false)
                {
                    Console.WriteLine(developer.Name + "   need License");
                }

            }

        }

                //View Existing Content-Names
        private void NamesWithPluralsight()
        {
            Console.Clear();
            //prompt user to give me a name
            Console.WriteLine("Enter the Name");

            //Get the user's input
            string name = Console.ReadLine();
            int idX = int.Parse(name);

            //Find the Content By ID
            Developer content = _contentDeveloper.GetName(idX);

            //Display Content if it isn't null
            if (content != null)
            {
                Console.WriteLine($"Name: {content.Name}\n +" +
                        $"Description: {content.Id}\n" +
                         $"Access to pluralsight: {content.AccessToPluralSight}");
            }
            else
            {
                Console.WriteLine("No content by that Name.");
            }

        }
        //  4.     update Developers-------------------------------------------------------------------------------
        private void UpdateDevelopers()
        {
            //Display All Content 
            DisplayAllNames();

            //As for the name of the content to update
            Console.WriteLine("Enter the ID of the Developer you'd Like to Update");

            //Get The Name
            ///oldname is user input - do not have to match up
            string OldName = Console.ReadLine();
            int Num = int.Parse(OldName);

            //We will add the new Developer 
            Developer newContent = new Developer();

            //Name     ---------------------------Ask ???????
            Console.WriteLine("Enter the new name for the Developer");
            newContent.Name = Console.ReadLine();

            //ID 
            Console.WriteLine("Enter the new ID");
            newContent.Id = int.Parse(Console.ReadLine());

            //Access ro pluralsight 
            Console.WriteLine("Do they have Access to PluralSight for the New Developer");
            string YesNo = Console.ReadLine().ToLower();

            if (YesNo == "y")
            {
                newContent.AccessToPluralSight = true;
            }
            else
            {
                newContent.AccessToPluralSight = false;
            }
            

            //    Verify Update Work
            bool wasUpdated = _contentDeveloper.UpdateExistingNames(Num, newContent);

            if (wasUpdated)
            {
                Console.WriteLine("Dveloper was Updated!");
            }
            else
            {
                Console.WriteLine("Developer Could not Update Developer");
            }


        }

        //5.      delete existing content 

        private void DeleteDevelopers()
        {

            DisplayAllNames();

            //Get the names they want to remove 
            Console.WriteLine("Enter the ID of the Developer you would like to remove");
            //// Atif please remember that Console.readline only takes string hence we parse
            string input = Console.ReadLine();
            int Intp = int.Parse(input);
            //Call the delete method

            bool wasDeleted = _contentDeveloper.RemoveNameFromList(Intp);


            if (wasDeleted)
            {
                Console.WriteLine("The Developer was successfully Deleted");
            }
            else
            {
                Console.WriteLine("The Developer could not be deleted");
            }

        }

        // 6. CreateDevTeams 
        private void CreateNewTeams()
        {
            Console.Clear();
            DevTeamContent newTeam = new DevTeamContent();

            //Names 

            Console.WriteLine("Enter the new DevTeam Name");
            newTeam.TeamName = Console.ReadLine();

            //Number
            Console.WriteLine("Enter the Number for the Team");
            newTeam.TeamNumber = int.Parse(Console.ReadLine());
            // Console.Readline does not read numbers only words so use Parse to convert it

            // Add DevTeam to the Repo
            _devTeamRepo.AddContentToList(newTeam);
        }

        //7.  Read List of DevTeams 

        private void ReadDevTeams()
        {
            Console.Clear();
            List<DevTeamContent> listOfTeams = _devTeamRepo.GetContentList();

            foreach (DevTeamContent devTeam in listOfTeams)
            {
                Console.WriteLine(devTeam.TeamName);
            }

        }

        //see method

        private void SeedContentList()

        {
            Developer Michael = new Developer("Michael", 1, true);
            Developer John = new Developer("John", 2, false);
            Developer Atif = new Developer("Atif", 3, true);
            _contentDeveloper.AddNamesToList(Michael);
            _contentDeveloper.AddNamesToList(John);
            _contentDeveloper.AddNamesToList(Atif);


        }


    }


}
