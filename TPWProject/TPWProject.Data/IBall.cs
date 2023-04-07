using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPWProject.Data
{
    public interface IBall : INotifyPropertyChanged, IDisposable
    {
        public double Top { get; }
        public double Left { get; }
        public int Diameter { get; }
        public double Mass { get; }

    }
}
