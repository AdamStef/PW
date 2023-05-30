using System;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Timers;
using TPWProject.Data.Abstract;

namespace TPWProject.Data
{
    public class Ball : IBall
    {
        public object _positionLock { get; } = new();
        public object _speedLock { get; } = new();

        public int Id { get; set; }


        private double _top;
        private double _left;
        private double _speedX;
        private double _speedY;

        public double Top
        {
            get
            {
                lock (_positionLock)
                {
                    return _top;
                }
            }
            set
            {
                lock (_positionLock)
                {
                    _top = value;
                }
            }
        }
        public double Left
        {
            get
            {
                lock (_positionLock)
                {
                    return _left;
                }
            }
            set
            {
                lock (_positionLock)
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
                lock (_speedLock)
                {
                    return _speedX;
                }
            }
            set
            {
                lock (_speedLock)
                {
                    _speedX = value;
                }
            }
        }
        public double SpeedY
        {
            get
            {
                lock (_speedLock)
                {
                    return _speedY;
                }
            }
            set
            {
                lock (_speedLock)
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
