using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TPWProject.Data.Abstract
{
    public interface IBall : INotifyBallPositionChanged
    {
        double Top { get; set; }
        double Left { get; set; }
        double Diameter { get; }
        double Mass { get; }
        double Speed { get; }

        void Move(double height, double width);
    }
}
