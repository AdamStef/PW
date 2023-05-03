using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using TPWProject.Presentation.Model;

namespace TPWProject.Presentation.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ModelAPI model;

        private ObservableCollection<BallModel> _balls;
        private int _ballsCount;
        private double _height;
        private double _width;

        #region Properties
        public ObservableCollection<BallModel> Balls
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
                model.SetHeight(value);
                OnPropertyChanged();
            }
        }
        public double Width
        {
            get => _width;
            set
            {
                _width = value;
                model.SetWidth(value);
                OnPropertyChanged();
            }
        }

        #endregion

        public ICommand StartButtonCommand { get; }
        public ICommand StopButtonCommand { get; }
        public ICommand ClearButtonCommand { get; }

        public MainViewModel()
        {
            _ballsCount = 5;
            StartButtonCommand = new RelayCommand(StartButton);
            StopButtonCommand = new RelayCommand(StopButton);
            ClearButtonCommand = new RelayCommand(ClearButton);
            model = new ModelAPI();
            _balls = new ObservableCollection<BallModel>();
        }

        private void StartButton(object obj)
        {
            if (BallsCount > 30)
            {
                MessageBox.Show("Max number of balls is 30", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            model.Stop();
            model.Start(Height, Width, BallsCount);
            Balls = model.GetBalls();
        }

        private void StopButton(object obj)
        {
            model.Stop();
        }
        private void ClearButton(object obj)
        {
            model.Stop();
            Balls = model.GetBalls();
        }

        public void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
