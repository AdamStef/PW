using System.Collections.ObjectModel;
using TPWProject.Logic.Abstract;

namespace TPWProject.Presentation.Model
{
    public abstract class AbstractModelAPI
    {
        public static ModelAPI CreateAPI(double height, double width)
        {
            return new ModelAPI(height, width);
        }

        public abstract ObservableCollection<BallModel> GetBalls();
        public abstract void SetHeight(double height);
        public abstract void SetWidth(double width);
        public abstract void SetDimensions(double height, double width);
        public abstract void Start(int numberOfBalls);
        public abstract void Stop();
    }
}