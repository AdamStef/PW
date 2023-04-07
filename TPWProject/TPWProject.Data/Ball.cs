using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPWProject.Data
{
    public class Ball : IBall
    {
        private double _top;
        private double _left;
        public double Top { get => _top; set { _top = value; OnPropertyChanged(); } }
        public double Left { get => _left; set { _left = value; OnPropertyChanged(); } }

        private double _maxTop;
        private double _maxLeft;
        public double MaxTop { get => _maxTop; set { _maxTop = value; OnPropertyChanged(); } }
        public double MaxLeft { get => _maxLeft; set { _maxLeft = value; OnPropertyChanged(); } }

        public int Diameter { get; }
        public double Mass { get; }
        public int Speed { get; }

        private readonly Timer timer;
        private readonly Random random;


        public Ball(double top, double left, int diameter, double mass)
        {
            Top = top;
            Left = left;
            Diameter = diameter;
            Mass = mass;
            Speed = 10;
            timer = new Timer(Move, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(100));
            random = new Random();
        }

        public void Dispose()
        {
            timer.Dispose();
            GC.SuppressFinalize(this);
        }

        private void Move(object state)
        {
            //TODO change to smooth movement
            Top += (random.NextDouble() - 0.5) * Speed;
            Left += (random.NextDouble() - 0.5) * Speed;
            Debug.Print($"top: {MaxTop}; Left: {MaxLeft}");
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
