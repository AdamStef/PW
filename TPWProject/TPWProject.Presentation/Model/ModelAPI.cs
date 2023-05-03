using System.Collections.ObjectModel;
using TPWProject.Data;
using TPWProject.Logic.Abstract;

namespace TPWProject.Presentation.Model
{
    public class ModelAPI : AbstractModelAPI
    {
        private readonly AbstractLogicAPI logicAPI;

        public ModelAPI(AbstractLogicAPI? logicAPI = null)
        {
            if (logicAPI != null)
                this.logicAPI = logicAPI;
            else
                this.logicAPI = AbstractLogicAPI.CreateAPI();
        }

        public override void Start(double height, double width, int ballCount)
        {
            logicAPI.StartSimulation(height, width, ballCount);
        }

        public override void Stop()
        {
            logicAPI.StopSimulation();
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
    }
}
