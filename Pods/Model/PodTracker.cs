using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PodTracker
    {
        private Pod pod;
        private double _completion;

        public PodTracker(Pod pod)
        {
            this.Pod = pod;
            Completion = 0;
        }

        public Pod Pod { get => pod; set => pod = value; }
        public double Completion { get => _completion; set => _completion = value; }
    }
}
