using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TPWProject.Data;
using TPWProject.Data.Abstract;
using TPWProject.Presentation.Model;

namespace TPWProject.Presentation.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ModelAPI model;
        private ObservableCollection<Shape> _balls;
        private int _ballsCount;
        private double _height;
        private double _width;

        #region Properties
        public ObservableCollection<Shape> Balls
        {
            get => _balls;
            set
            {
                _balls = value;
                OnPropertyChanged();
            }
        }
        public int BallsCount
        {
            get => _ballsCount;
            set
            {
                _ballsCount = value;
                OnPropertyChanged();
            }
        }
        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                OnPropertyChanged();
            }
        }
        public double Width
        {
            get => _width;
            set
            {
                _width = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public ICommand StartButtonCommand { get; }
        public ICommand StopButtonCommand { get; }
        public ICommand ClearButtonCommand { get; }

        public MainViewModel()
        {
            _ballsCount = 3;
            StartButtonCommand = new RelayCommand(StartButton);
            StopButtonCommand = new RelayCommand(StopButton);
            ClearButtonCommand = new RelayCommand(ClearButton);
            model = new ModelAPI(Height, Width);
            _balls = new ObservableCollection<Shape>();

            //StartButton(null);
            //model.Start(3);
            //_balls = model.GetShapes();
            //Balls.Add(new Ball(200, 200, 50, 2));
            //Balls.Add(new BallModel(new Ball(400, 800, 50, 2)));
            //_balls.Add(new BallModel(new Ball(200, 200, 60, 2)));
        }

        private void StartButton(object obj)
        {
            model.Stop();
            model.SetDimentions(Height, Width);
            model.Start(BallsCount);
            Balls = model.GetShapes();
        }

        private void StopButton(object obj)
        {
            //TODO stop threads on window close event
            model.Stop();
        }
        private void ClearButton(object obj)
        {
            model.Stop();
            Balls = model.GetShapes();
        }
    }
}
