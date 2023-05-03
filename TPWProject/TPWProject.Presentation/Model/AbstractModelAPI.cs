using System.Collections.ObjectModel;
using TPWProject.Logic.Abstract;

namespace TPWProject.Presentation.Model
{
    public abstract class AbstractModelAPI
    {
        public static ModelAPI CreateAPI()
        {
            return new ModelAPI();
        }

        public abstract ObservableCollection<BallModel> GetBalls();
        public abstract void SetHeight(double height);
        public abstract void SetWidth(double width);
        public abstract void Start(double height, double width, int ballCount);
        public abstract void Stop();
    }
}