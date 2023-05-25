using System;
using System.Threading.Tasks;
using TPWProject.Data.Abstract;

namespace TPWProject.Data
{
    public class Ball : IBall
    {
        private readonly object positionLock = new();
        private readonly object speedLock = new();
        private double _top;
        private double _left;
        private double _speedX;
        private double _speedY;
        public double Top 
        {
            get
            {
                lock (positionLock)
                {
                    return _top;
                }
            }
            set
            {
                lock (positionLock)
                {
                    _top = value;
                }
            }
        }
        public double Left
        {
            get
            {
                lock (positionLock)
                {
                    return _left;
                }
            }
            set
            {
                lock (positionLock)
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
                lock (speedLock)
                {
                    return _speedX;
                }
            }
            set
            {
                lock (speedLock)
                {
                    _speedX = value;
                }
            }
        }
        public double SpeedY
        {
            get
            {
                lock (speedLock)
                {
                    return _speedY;
                }
            }
            set
            {
                lock (speedLock)
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
