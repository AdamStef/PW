using System.Collections.ObjectModel;
using TPWProject.Data;
using TPWProject.Logic.Abstract;

namespace TPWProject.Presentation.Model
{
    public class ModelAPI : AbstractModelAPI
    {
        private AbstractLogicAPI logicAPI;

        public ModelAPI(double height, double width)
        {
            logicAPI = AbstractLogicAPI.CreateAPI(height, width);
        }

        public override void Start(int numberOfBalls)
        {
            logicAPI.GenerateBalls(numberOfBalls);
            logicAPI.StartBallMovement();
        }

        public override void Stop()
        {
            logicAPI.StopMovement();
            logicAPI.ClearRepository();
        }

        public override void SetDimentions(double height, double width)
        {
            logicAPI.SetDimentions(height, width);
        }

        public override ObservableCollection<BallModel> GetShapes()
        {
            ObservableCollection<BallModel> balls = new ObservableCollection<BallModel>();
            foreach (Ball ball in logicAPI.GetShapes())
                balls.Add(new BallModel(ball));
            return balls;
        }
    }
}
