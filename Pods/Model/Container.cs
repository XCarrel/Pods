using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Container
    {
        private string _tag;

        public Container(string tag)
        {
            Tag = tag;
        }

        public string Tag { get => _tag; set => _tag = value; }
    }
}
