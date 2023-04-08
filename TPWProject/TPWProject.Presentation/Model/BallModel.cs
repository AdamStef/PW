using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TPWProject.Data;

namespace TPWProject.Presentation.Model
{
    public class BallModel : INotifyPropertyChanged
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private double _top;
        private double _left;
        private double _diameter;
        private int _speed;
        private double _mass;

        public double Top
        {
            get => _top;
            set { _top = value; OnPropertyChanged(); }
        }
        public double Left
        {
            get => _left;
            set { _left = value; OnPropertyChanged(); }
        }
        public double Diameter
        {
            get => _diameter;
            set { _diameter = value; OnPropertyChanged(); }
        }
        public int Speed
        {
            get => _speed;
            set { _speed = value; OnPropertyChanged(); }
        }
        public double Mass
        {
            get => _mass;
            set { _mass = value; OnPropertyChanged(); }
        }

        public BallModel(Ball ball)
        {
            Top = ball.Top;
            Left = ball.Left;
            Diameter = ball.Diameter;
            Speed = ball.Speed;
            Mass = ball.Mass;
        }
    }

}
