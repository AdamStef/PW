using System;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Timers;
using TPWProject.Data.Abstract;

namespace TPWProject.Data
{
    public class Ball : IBall
    {
        private readonly object _positionLock = new();
        private readonly object _speedLock = new();

        private readonly Timer _timer;
        [JsonIgnore]
        public ILogger Logger { get; set; }

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
        [JsonIgnore]
        public double Diameter { get; }
        [JsonIgnore]
        public double Mass { get; }
        [JsonIgnore]
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
        [JsonIgnore]
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

            _timer = new Timer();
            _timer.Interval = 5000;
        }

        public void Move()
        {
            Top += SpeedY;
            Left += SpeedX;

            BallPositionChanged?.Invoke(this, new BallPositionChangedEventArgs(Top, Left));
        }

        public void StartLogging()
        {
            if (Logger != null)
            {
                _timer.Elapsed += async (sender, e) =>
                {
                    BallJsonModel ballToSave;
                    lock (_positionLock)
                    {
                        Debug.WriteLine(DateTime.Now.Millisecond.ToString() + "   " + Top);
                        ballToSave = new BallJsonModel(Id, Top, Left);
                    }
                    await Logger.Log(ballToSave);
                };
                _timer.Start();
            }
        }

        public void StopLogging()
        {
            _timer?.Stop();
            _timer.Dispose();
        }
    }
}
