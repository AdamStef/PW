using System.Collections.ObjectModel;
using TPWProject.Data;
using TPWProject.Logic.Abstract;

namespace TPWProject.Presentation.Model
{
    public class ModelAPI : AbstractModelAPI
    {
        private readonly AbstractLogicAPI logicAPI;

        public ModelAPI(double height, double width, AbstractLogicAPI? logicAPI = null)
        {
            if (logicAPI != null)
                this.logicAPI = logicAPI;
            else
                this.logicAPI = AbstractLogicAPI.CreateAPI(height, width);
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

        public override ObservableCollection<BallModel> GetBalls()
        {
            ObservableCollection<BallModel> balls = new ObservableCollection<BallModel>();
            foreach (Ball ball in logicAPI.GetBalls())
                balls.Add(new BallModel(ball));
            return balls;
        }

        public override void SetHeight(double height)
        {
            logicAPI.SetHeight(height);
        }

        public override void SetWidth(double width)
        {
            logicAPI.SetWidth(width);
        }

        public override void SetDimensions(double height, double width)
        {
            logicAPI.SetHeight(height);
            logicAPI.SetWidth(width);
        }
    }
}
