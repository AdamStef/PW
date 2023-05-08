using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPWProject.Data
{
    public delegate void BallPositionChangedEventHandler(object sender, BallPositionChangedEventArgs e);
    public class BallPositionChangedEventArgs
    {
        public double PrevTop { get; private set; }
        public double PrevLeft { get; private set; }
        public double Top { get; private set; }
        public double Left { get; private set; }
        public BallPositionChangedEventArgs(double top, double left)
        {
            PrevTop = Top;
            PrevLeft = Left;
            Top = top;
            Left = left;
        }
    }
}
