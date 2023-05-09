using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TPWProject.Data.Abstract;

namespace TPWProject.Data
{
    public class Ball : IBall
    {
        private readonly object speedLocked = new object();
        private readonly object positionLocked = new object();

        private double _top;
        private double _left;
        private double _speedX;
        private double _speedY;

        public double Top
        {
            get
            {
                lock (positionLocked)
                {
                    return _top;
                }
            }
            set
            {
                lock (positionLocked)
                {
                    _top = value;
                }
            }
        }
        public double Left
        {
            get
            {
                lock (positionLocked)
                {
                    return _left;
                }
            }
            set
            {
                lock (positionLocked)
                {
                    _left = value;
                }
            }
        }
        public double Diameter { get; }
        public double Mass { get; }
        public double SpeedX 
        { 
            get
            {
                lock (speedLocked)
                {
                    return _speedX;
                }
            }
            set
            {
               lock (speedLocked)
                {
                    _speedX = value;
                }
            }
        }
        public double SpeedY 
        {
            get
            {
                lock (speedLocked)
                {
                    return _speedY;
                }
            }
            set
            {
                lock (speedLocked)
                {
                    _speedY = value;
                }
            }
        }

        public event BallPositionChangedEventHandler BallPositionChanged;


        public Ball(double top, double left, double diameter, double mass)
        {
            Random random = new();
            Top = top;
            Left = left;
            Diameter = diameter;
            Mass = mass;
            SpeedX = random.NextDouble() + 0.5;
            SpeedY = random.NextDouble() + 0.5;
        }

        public void Move()
        {
            Top += SpeedY;
            Left += SpeedX;

            BallPositionChanged?.Invoke(this, new BallPositionChangedEventArgs(Top, Left));
        }
    }
}
