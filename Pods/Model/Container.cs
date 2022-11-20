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
        private int _loadWeight; // KG

        public Container(string tag)
        {
            Tag = tag;
            LoadWeight = 0;
        }

        public string Tag { get => _tag; set => _tag = value; }
        public int LoadWeight { get => _loadWeight; set => _loadWeight = value; }
    }
}
