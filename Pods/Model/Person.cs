using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Person
    {
        private String _name;
        private String _face; // supposedly the _face model for _face recognition. In reality: maybe a path to the picture
        private Boolean _podLicense;

        /// <summary>
        /// 
        /// </summary>
        /// <param _name="word"></param>
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
            _podLicense = false;
            _face = GetStringSha256Hash(name);
        }

        public Person(string name, string face, bool podLicense) : this(name)
        {
            _face = face;
            _podLicense = podLicense;
        }

        public string Name { get => _name; set => _name = Capitalize(value); }
        public string Face { get => _face; set => _face = value; }
        public bool PodLicense { get => _podLicense; set => _podLicense = value; }

        internal static string GetStringSha256Hash(string text)
        {
            if (String.IsNullOrEmpty(text))
                return String.Empty;

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }
    }
}
