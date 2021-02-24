using _12_APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_APIs
{
    public class SWAPIUI
    {
        private SWAPIService _service;

        // Dependency injection example:

        public SWAPIUI(SWAPIService service)
        {
            _service = service;
        }
     
        public void Run()
        {
            _service = new SWAPIService();
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("What would you like to look up?\n\n" +
                    "1. Person\n" +
                    "2. Planet\n" +
                    "3. Vehicle\n" +
                    "4. StarShip\n" +
                    "5. Search People\n" +
                    "6. Search Planets\n" +
                    "7. Exit\n\n");
                string choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        GetPerson();
                        break;
                    case "2":
                        ShowPlanet();
                        break;
                    case "3":
                        ShowVehicle();
                        break;
                    case "4":
                        ShowStarShip();
                        break;
                    case "5":
                        SearchPeople();
                        break;
                    case "6":
                        SearchPlanets();
                        break;
                    case "7":
                        continueToRun = false;
                        break;
                }
            }
        }

        public void GetPerson()
        {
            Console.Clear();
            Console.Write("What is the ID of the person you want to see? ");
            string id = Console.ReadLine();

            Console.WriteLine("Loading . . . ");
            Person person = _service.GetAsync<Person>($"https://swapi.dev/api/people/{id}").Result;
            Console.Clear();
            Console.WriteLine($"\n\n{person.Name} is {person.Height} cm tall and has " +
                    $"{person.Eye_Color} eyes.");
            Console.WriteLine("Press any key to continue . . . ");
            Console.ReadKey();

        }

        public void ShowPlanet()
        {
            Console.Clear();
            Console.Write("What is the ID of the planet you want to see? ");
            string id = Console.ReadLine();

            Console.WriteLine("Loading . . . ");
            Planet planet = _service.GetAsync<Planet>($"https://swapi.dev/api/planets/{id}/").Result;
            Console.Clear();
            Console.WriteLine($"\n\nThe name of the planet is {planet.Name}.");
            Console.WriteLine("Press any key to continue . . . ");
            Console.ReadKey();
        }

        public void ShowVehicle()
        {
            Console.Clear();
            Console.Write("What is the ID of the vehicle you want to see? ");
            string id = Console.ReadLine();

            Console.WriteLine("Loading . . . ");
            Vehicle vehicle = _service.GetAsync<Vehicle>($"https://swapi.dev/api/vehicles/{id}/").Result;
            Console.Clear();
            Console.WriteLine($"\n\nThe name of the vehicle is {vehicle.Name}." +
                $" It cost {vehicle.Cost_In_Credits} credits." +
                $" It was manufactured by {vehicle.Manufacturer}.");
            Console.WriteLine("Press any key to continue . . . ");
            Console.ReadKey();
        }

        public void ShowStarShip()
        {
            Console.Clear();
            Console.Write("What is the ID of the Star Ship you want to see? ");
            string id = Console.ReadLine();

            Console.WriteLine("Loading . . . ");
            StarShip starShip = _service.GetAsync<StarShip>($"https://swapi.dev/api/starships/{id}/").Result;
            Console.Clear();
            Console.WriteLine($"\n\nThe name of the Star Ship is {starShip.Name}." +
                $" It cost {starShip.Cost_In_Credits} credits." +
                $" It was manufactured by {starShip.Manufacturer}.");
            Console.WriteLine("Press any key to continue . . . ");
            Console.ReadKey();
        }

        public void SearchPeople()
        {
            Console.Clear();
            Console.Write("What name are you searching for? ");
            string query = Console.ReadLine();

            SearchResult<Person> results =
                _service.SearchPeopleAsync(query).Result;

            Console.Clear();
            Console.WriteLine($"Found {results.Count} results\n");

            foreach (Person person in results.Results)
            {
                Console.WriteLine($"{person.Name} - {person.Height}cm, " +
                    $"{person.Eye_Color} eyes.");
            }
            Console.WriteLine("\nPress any key to continue . . . ");
            Console.ReadKey();
        }

        public void SearchPlanets()
        {
            Console.Clear();
            Console.Write("What planet are you searching for? ");
            string query = Console.ReadLine();

            SearchResult<Planet> results =
                _service.SearchPlanetsAsync(query).Result;

            Console.Clear();
            Console.WriteLine($"Found {results.Count} results\n");

            foreach (Planet planet in results.Results)
            {
                Console.WriteLine($"{planet.Name} - {planet.Climate}cm, " +
                    $"{planet.Diameter} is the diameter.");
            }
            Console.WriteLine("\nPress any key to continue . . . ");
            Console.ReadKey();
        }
    }
}
