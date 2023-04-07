using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TPWProject.Data;
using TPWProject.Presentation.Model;

namespace TPWProject.Presentation.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly BallsModel model;
        private ObservableCollection<IBall> _balls;
        public ObservableCollection<IBall> Balls { get => _balls; set { _balls = value; OnPropertyChanged(); } }

        private int _ballsCount;
        public int BallsCount { get => _ballsCount; set { _ballsCount = value; OnPropertyChanged(); } }

        public ICommand StartButtonCommand { get; }

        public MainViewModel()
        {
            model = new BallsModel();
            //model.Start(10);
            _balls = new ObservableCollection<IBall>(model.GetBalls());
            StartButtonCommand = new RelayCommand(StartButton);
            //Balls.Add(new Ball(100, 200, 50, 2));
            //Balls.Add(new Ball(200, 200, 60, 2));
        }

        private void StartButton(object obj)
        {
            model.Stop();
            model.Start(BallsCount);
            Balls = new ObservableCollection<IBall>(model.GetBalls());
        }
    }
}
