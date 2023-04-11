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

        public abstract ObservableCollection<BallModel> GetShapes();
        public abstract void SetDimentions(double height, double width);
        public abstract void Start(int numberOfBalls);
        public abstract void Stop();
    }
}