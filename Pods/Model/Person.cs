using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Person
    {
        private String name;
        private String face; // supposedly the face model for face recognition. In reality: maybe a path to the picture
        private Boolean podLicense;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private String Capitalize(String word)
        {
            return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
        }

        public Person()
        {
        }

        public Person(string name)
        {
            Name = Capitalize(name);
            podLicense = false;
        }

        public string Name { get => name; set => name = Capitalize(value); }
        public string Face { get => face; set => face = value; }
        public bool PodLicense { get => podLicense; set => podLicense = value; }
    }
}
