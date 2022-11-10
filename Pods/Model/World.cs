﻿using System;
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
    public class World
    {
        public static Random alea = new Random();

        private List<Person> _population;
        private List<Hub> _hubs;
        private List<Road> _roads;
        private List<Pod> _fleet;

        public List<Person> Population { get => _population; set => _population = value; }
        public List<Hub> Hubs { get => _hubs; set => _hubs = value; }
        public List<Road> Roads { get => _roads; set => _roads = value; }
        public List<Pod> Fleet { get => _fleet; set => _fleet = value; }

        public World()
        {
            _population = new List<Person>();
            _hubs = new List<Hub>();
            _roads = new List<Road>();
            _fleet = new List<Pod>();
        }

        public void Init()
        {
            _hubs = new List<Hub>
                 {
                 new Hub ("Lausanne", new Vector2(250,600)),
                 new Hub ("Genève", new Vector2(120, 700)),
                 new Hub ("Berne", new Vector2(350, 200)),
                 new Hub ("Sion", new Vector2(800,500))
                 };
            _roads = new List<Road>
                 {
                 new Road("A12",_hubs[0],_hubs[1]),
                 new Road("A23",_hubs[1],_hubs[2]),
                 new Road("A34",_hubs[2],_hubs[3]),
                 new Road("A41",_hubs[3],_hubs[0]),
                 new Road("A13",_hubs[0],_hubs[2]),
                 new Road("A31",_hubs[2],_hubs[0])
                 };

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
            foreach (string person in people)
            {
                _population.Add(new Person(person));
            }

            // put people in hubs
            for (int i = 0; i < _hubs.Count; i++)
                for (int p = 0; p < 50; p++)
                    _hubs[i].AddPerson(_population[50 * i + p]);

            // Fill hubs' parkings
            for (int i = 0; i < _hubs.Count; i++)
                for (int p = 0; p < 10; p++)
                    _hubs[i].AddPod(new Pod(Guid.NewGuid().ToString(), 2, 2));

            // put Pods on roads
            foreach (Road road in _roads)
            {
                for (int i = 0; i < 5; i++)
                {
                    double percent = alea.NextDouble();
                    Pod p = new Pod(Guid.NewGuid().ToString(), 2, 2);
                    p.Speed = alea.Next(50, 100);
                    road.AllowEnter(p);
                }
            }

        }
    }
}
