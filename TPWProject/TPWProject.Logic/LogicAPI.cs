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
        private void CheckBoundaryCollision(Ball ball)
        {
            if (ball.Top - ball.SpeedY <= 0)
            {
                ball.SpeedY *= -1;
                ball.Top = 0;
            }
            else if (ball.Top + ball.SpeedY + ball.Diameter >= dataAPI.Boundary.Height)
            {
                ball.SpeedY *= -1;
                ball.Top = dataAPI.Boundary.Height - ball.Diameter;
            }

            if (ball.Left - ball.SpeedX <= 0)
            {
                ball.SpeedX *= -1;
                ball.Left = 0;
            }
            else if (ball.Left + ball.SpeedX + ball.Diameter >= dataAPI.Boundary.Width)
            {
                ball.SpeedX *= -1;
                ball.Left = dataAPI.Boundary.Width - ball.Diameter;
            }
        }

        private void CheckBallsCollision(Ball ball)
        {
            //TODO: Check Collision
            //Debug.WriteLine("Checking collision for ball");
        }

        private void OnBallPositionChanged(object sender, BallPositionChangedEventArgs args)
        {
            Ball ball = (Ball)sender;
            CheckBoundaryCollision(ball);
            CheckBallsCollision(ball);
            Debug.WriteLine($"Checking collision for ball, pos: {args.Top} x {args.Left}; prev pos: {args.PrevTop} x {args.PrevLeft}");
        }
    }
}