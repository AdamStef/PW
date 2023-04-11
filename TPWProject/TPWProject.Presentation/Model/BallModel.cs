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

        private readonly Ball ball;

        public double Top
        {
            get => ball.Top;
            set { ball.Top = value; OnPropertyChanged(); }
        }
        public double Left
        {
            get => ball.Left;
            set { ball.Left = value; OnPropertyChanged(); }
        }
        public double Diameter
        {
            get => ball.Diameter;
        }

        public BallModel(Ball ball)
        {
            this.ball = ball;
            ball.BallPositionChanged += OnBallPositionChanged;
        }

        public void OnBallPositionChanged(object sender, BallPositionChangedEventArgs args)
        {

            OnPropertyChanged(nameof(Top));
            OnPropertyChanged(nameof(Left));
        }
    }
}
