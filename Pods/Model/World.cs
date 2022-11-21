using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Model
{
    public static class World
    {
        public static Random alea = new Random();
        public static readonly int WIDTH = 1500;
        public static readonly int HEIGHT = 800;
        public static readonly int TAXI_RATIO = 90; // % of taxis in the whole fleet

        private static List<Person> _population = new List<Person>();
        private static List<Hub> _hubs = new List<Hub>();
        private static List<Road> _roads = new List<Road>();
        private static List<Pod> _fleet = new List<Pod>();

        public static List<Person> Population { get => _population; set => _population = value; }
        public static List<Hub> Hubs { get => _hubs; set => _hubs = value; }
        public static List<Road> Roads { get => _roads; set => _roads = value; }
        public static List<Pod> Fleet { get => _fleet; set => _fleet = value; }

        public static void Init()
        {
            _hubs = new List<Hub>
                 {
                 new Hub ("Lausanne", new Vector2(5 * 35 + 50, HEIGHT - 5 * 35 - 50)),
                 new Hub ("Genève", new Vector2(5 * 0 + 50, HEIGHT -5 * 0 - 50)),
                 new Hub ("Berne", new Vector2(5 * 100 + 50, HEIGHT - 5 * 80 - 50)),
                 new Hub ("Sion", new Vector2(5 * 90 + 50, HEIGHT - 5 * 0 - 50)),
                 new Hub ("Zurich", new Vector2(5 * 180 + 50, HEIGHT - 5 * 130 - 50)),
                 new Hub ("Lucerne", new Vector2(5 * 160 + 50, HEIGHT - 5 * 90 - 50)),
                 new Hub ("Coire", new Vector2(5 * 260 + 50, HEIGHT - 5 * 70 - 50)),
                 new Hub ("Lugano", new Vector2(5 * 215 + 50, HEIGHT - 5 * 0 - 50)),
                 };

            // Build roads
            string[] roadNames = {
                "A12 Lausanne-Genève",
                "A21 Genève-Lausanne",
                "A34 Bern-Sion",
                "A14 Lausanne-Sion",
                "A41 Sion-Lausanne",
                "A13 Lausanne-Berne",
                "A35 Berne-Zurich",
                "A53 Zurich-Berne",
                "A56 Zurich-Lucerne",
                "A65 Lucerne-Zurich",
                "A63 Lucerne-Berne",
                "A31 Berne-Lausanne",
                "A67 Lucerne-Coire",
                "A76 Coire-Lucerne",
                "A78 Coire-Lugano",
                "A86 Lugano-Lucerne"
            };
            _roads = new List<Road>();
            // Create roads based on name: second digit is the index of the starting hub, third of the ending one
            foreach (string roadName in roadNames)
            {
                Roads.Add(new Road(roadName, _hubs[(int)(roadName[1] - '0') - 1], _hubs[(int)(roadName[2] - '0') - 1]));
            }

            // generate population
            string[] people = {
                "Michael Bailey",
                "Hailey Swift",
                "Roger Myatt",
                "Bethany Porter",
                "Bart Weston",
                "Tony Nanton",
                "Chadwick Bryson",
                "Doris Jarrett",
                "Daphne Cann",
                "Domenic Huggins",
                "Hank Stanton",
                "Daria Nash",
                "Kirsten Williams",
                "Candace Walsh",
                "Florence Flett",
                "Maia Wade",
                "Marla Gray",
                "Felicity Myatt",
                "Erica Judd",
                "Daniel Sherry",
                "Catherine Cork",
                "Henry Thompson",
                "Gloria Neville",
                "Fred Reynolds",
                "Freya Giles",
                "Andie Tindall",
                "Payton Foxley",
                "Matt Thorne",
                "Florence Keys",
                "Fiona Warden",
                "Ronald Alcroft",
                "Chad Everett",
                "Dalia Emmott",
                "Nathan Reynolds",
                "Maribel Shea",
                "Johnathan Woodcock",
                "Oliver John",
                "Charlize Warren",
                "Miriam Noon",
                "Mavis Vane",
                "Johnathan Tanner",
                "Daniel Graham",
                "Chuck Preston",
                "Judith Vallory",
                "Robyn Sherry",
                "William Tate",
                "Rick Greenwood",
                "Juliet Townend",
                "Martin Boyle",
                "Martin Tyler",
                "Chadwick Mcneill",
                "Elijah Walter",
                "Hank Trent",
                "Alexander Eddison",
                "Denis Bell",
                "Gabriel Glynn",
                "Tom Bradley",
                "Abbey Saunders",
                "Marjorie Dempsey",
                "Enoch Cann",
                "Barry Morley",
                "Julius Griffiths",
                "Doug Thomson",
                "Nick Harvey",
                "Bob Hall",
                "Darlene Grant",
                "Aiden Cowan",
                "Erick Stevens",
                "Jacob Gilbert",
                "Clint Wright",
                "Henry York",
                "Luke Uttridge",
                "Nick Mcnally",
                "Benjamin Cox",
                "Johnny Ogilvy",
                "Nick Jeffery",
                "Britney Plant",
                "Summer Morrow",
                "Rosalie Simmons",
                "Kirsten Thorpe",
                "Boris Hopkinson",
                "Charlotte Ranks",
                "Chadwick Harrington",
                "Michael Waterhouse",
                "Ryan Rose",
                "Luna Griffiths",
                "Peter Mann",
                "Gabriel Brown",
                "Janelle Bailey",
                "Danny Gray",
                "Lauren Morgan",
                "Liv Needham",
                "Roger Snow",
                "Adalind Gilmour",
                "Jocelyn Morgan",
                "Rosalee Whinter",
                "Carl Morris",
                "Hope Robinson",
                "Samantha Hunter",
                "Danny Anderson",
                "Nicholas Davies",
                "Cassandra Kidd",
                "Priscilla Fox",
                "Anthony Bradshaw",
                "David Swift",
                "Tyler Moore",
                "Gil Baker",
                "Julian Rogers",
                "Jessica Squire",
                "Sadie Whittle",
                "Meredith Villiger",
                "Jack Mcgee",
                "Amy Oldfield",
                "Tony Bennett",
                "Luke Smith",
                "Kamila Tobin",
                "Harry Lane",
                "Harmony Lakey",
                "Lauren Evans",
                "Hayden Rose",
                "Roger Malone",
                "Harvey Redden",
                "David Trent",
                "Karla Skinner",
                "Rosalie Ward",
                "Hanna Holt",
                "Clarissa Andrews",
                "Tom Radcliffe",
                "Katelyn Morrow",
                "Henry Harrison",
                "Nathan Tyrrell",
                "Elisabeth Mccall",
                "Iris Fenton",
                "Thea Rogers",
                "William Little",
                "Callie Durrant",
                "Leilani Upton",
                "Ilona Pickard",
                "Keira Tailor",
                "Carmella Andersson",
                "Mara Rodgers",
                "Norah Alcroft",
                "Ronald Baxter",
                "Rufus Potter",
                "Phillip Thomson",
                "Jayden Waterson",
                "Wade Morris",
                "Gabriel Walsh",
                "Barney Collingwood",
                "Chelsea Burnley",
                "Melanie Adams",
                "Benjamin Bristow",
                "Cadence Everett",
                "Ember Vince",
                "Denis Fox",
                "Rae Roberts",
                "Kenzie Cattell",
                "William Long",
                "Henry Whittle",
                "Janice Clifton",
                "Chris Cooper",
                "Louise Lane",
                "Catherine Murray",
                "Tyson Mason",
                "Nate Patel",
                "Martin Shaw",
                "Francesca King",
                "Julius Ainsworth",
                "Julius Pond",
                "Alice Simpson",
                "Caleb Knott",
                "Tyler Randall",
                "Dani Oatway",
                "Beatrice Dobson",
                "Ember Garcia",
                "Michael Rixon",
                "Matt Ellwood",
                "Harry Simpson",
                "Jamie May",
                "Jules Dunbar",
                "Mason Nicholls",
                "Mike Simpson",
                "Hank Cattell",
                "Alexander Hill",
                "Bob Davies",
                "Mike Atkinson",
                "Julius Jordan",
                "Logan Hogg",
                "Anabel Kelly",
                "Mark Rosenbloom",
                "Hope Bryant",
                "Zoe Coleman",
                "Allison Rees",
                "Aiden Murray",
                "Ryan Driscoll",
                "Rocco Russell",
                "Owen Weldon",
                "Enoch Verdon",
                "Beatrice Allington",
                "Jacob Robertson"
             };
            _population = new List<Person>();
            foreach (string person in people)
            {
                _population.Add(new Person(person));
            }

            // put people in hubs
            int peopleByHub = _population.Count / _hubs.Count;
            for (int i = 0; i < _hubs.Count; i++)
                for (int p = 0; p < peopleByHub; p++)
                    _hubs[i].AddPerson(_population[peopleByHub * i + p]);

            // Fill hubs' parkings
            for (int i = 0; i < _hubs.Count; i++)
                for (int p = 0; p < 50; p++)
                {
                    if (alea.Next(100) < TAXI_RATIO)
                    {
                        Taxi newTaxi = new Taxi(Guid.NewGuid().ToString(), 2);
                        // Make it "rideable" right away
                        newTaxi.addTraveller(new Person(Guid.NewGuid().ToString()));
                        _hubs[i].AddPod(newTaxi);
                        World.Fleet.Add(newTaxi);
                    } else
                    {
                        Truck newTruck = new Truck(Guid.NewGuid().ToString(), 2);
                        _hubs[i].AddPod(newTruck);
                        World.Fleet.Add(newTruck);
                    }
                }

        }

        /// <summary>
        /// Recursive method used to find a path from one hub to another
        /// If there are multiple possibilities, this algorithm will only return the first it found
        /// </summary>
        /// <param name="From">The hub where we are</param>
        /// <param name="To">The Hub where we want to go</param>
        /// <param name="PassedThrough">A list of hubs through which the search has already passed - and must therefore no pass again (would create an endless loop)</param>
        /// <returns>A List of roads to follow to get from start to finish</returns>
        public static Itinerary FindItinerary(Hub From, Hub To, List<Hub> PassedThrough)
        {
            PassedThrough.Add(From);
            Itinerary res = new Itinerary();
            if (World.Roads.Where(r => r.From == From && r.To == To).Any()) // We are lucky: there a direct road between or hubs
                res.Roads.Add(World.Roads.Where(r => r.From == From && r.To == To).First());
            else
                // Let's try all roads that leave from the 'From' hub
                foreach (Road road in World.Roads.Where(r => r.From == From).ToList())
                    if (!PassedThrough.Contains(road.To)) // The road does not take us to somewhere we have already been, it is thus worth exploring
                    {
                        // Assuming we take that road, let's see if there is an itinerary that goes from the end of that road to the final destination
                        Itinerary restOfTheTrip = FindItinerary(road.To, To, PassedThrough); // !!!! Recursive call
                        if (restOfTheTrip.Roads.Count > 0) // there is a path to the destination beyon that road !!!
                        {
                            res.Roads.Add(road);
                            res.Roads.AddRange(restOfTheTrip.Roads);
                            return res; // That road and the rest is the path to destination
                        }
                    }
            return res;
        }
    }
}
