using System.Collections.Generic;
using System.Diagnostics;
using TPWProject.Data;
using TPWProject.Data.Abstract;
using TPWProject.Logic.Abstract;

namespace TPWProject.Logic
{
    public class LogicAPI : AbstractLogicAPI
    {
        private readonly AbstractDataAPI dataAPI;
        

        public LogicAPI(AbstractDataAPI dataAPI = null)
        {
            if (dataAPI != null)
                this.dataAPI = dataAPI;
            else
                this.dataAPI = AbstractDataAPI.CreateAPI();
        }

        public override void StartSimulation(double height, double width, int ballCount)
        {
            dataAPI.CreateSimulation(height, width, ballCount);
            foreach (Ball ball in dataAPI.GetBalls())
            {
                ball.BallPositionChanged += OnBallPositionChanged;
            }
        }

        public override void StopSimulation()
        {
            dataAPI.StopMovement();
            dataAPI.RemoveAllBalls();
        }

        public override void CheckCollisions(Ball ball)
        {
            //TODO: Check Collision
            //Debug.WriteLine("Checking collision for ball");
        }

        public override List<IBall> GetBalls()
        {
            return dataAPI.GetBalls();
        }

        public override void SetHeight(double height)
        {
            dataAPI.GetBoundary().Height = height;
        }

        public override void SetWidth(double width)
        {
            dataAPI.GetBoundary().Width = width;
        }

        private void OnBallPositionChanged(object sender, BallPositionChangedEventArgs args)
        {
            Ball ball = (Ball)sender;
            CheckCollisions(ball);
            Debug.WriteLine($"Checking collision for ball, pos: {args.Top} x {args.Left}; prev pos: {args.PrevTop} x {args.PrevLeft}");
        }
    }
}