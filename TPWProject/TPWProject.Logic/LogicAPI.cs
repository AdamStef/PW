using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using TPWProject.Data;
using TPWProject.Data.Abstract;
using TPWProject.Logic.Abstract;

namespace TPWProject.Logic
{
    public class LogicAPI : AbstractLogicAPI
    {
        private readonly AbstractDataAPI dataAPI;
        public bool IsRunning { get; private set; }

        private readonly object locked = new object();


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
            StartBallMovement();
        }

        public override void StopSimulation()
        {
            StopMovement();
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
            if (ball.Top + ball.SpeedY <= 0)
            {
                ball.SpeedY *= -1;
                ball.Top = 0;
            }
            else if (ball.Top + ball.SpeedY + ball.Diameter >= dataAPI.Boundary.Height)
            {
                ball.SpeedY *= -1;
                ball.Top = dataAPI.Boundary.Height - ball.Diameter;
            }

            if (ball.Left + ball.SpeedX <= 0)
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

        private void StartBallMovement()
        {
            IsRunning = true;
            foreach (Ball ball in dataAPI.GetBalls())
            {
                Thread thread = new(() =>
                {
                    while (IsRunning)
                    {
                        lock (locked)
                        {
                            ball.Move();
                        }
                        Thread.Sleep(10);
                    }
                });
                thread.IsBackground = true;
                thread.Start();
                //Task.Run(async () =>
                //{
                //    while (IsRunning)
                //    {
                //        lock (locked)
                //        {
                //            ball.Move();
                //        }
                //        await Task.Delay(5);
                //    }
                //});
            }
        }

        public void StopMovement()
        {
            IsRunning = false;
        }

        private void CheckBallCollisions()
        {
            List<IBall> balls = dataAPI.GetBalls();
            for (int i = 0; i < balls.Count - 1; i++)
            {
                Ball ball1 = (Ball)balls[i];
                for (int j = i + 1; j < balls.Count; j++)
                {
                    Ball ball2 = (Ball)balls[j];
                    double distance = Math.Sqrt(Math.Pow(ball2.Top - ball1.Top, 2) + Math.Pow(ball2.Left - ball1.Left, 2));
                    double minDistance = (ball1.Diameter / 2 + ball2.Diameter / 2);
                    if (distance <= minDistance)
                    {
                        double totalMass = ball1.Mass + ball2.Mass;
                        double v1x = (ball1.SpeedX * (ball1.Mass - ball2.Mass) + 2 * ball2.Mass * ball2.SpeedX) / totalMass;
                        double v1y = (ball1.SpeedY * (ball1.Mass - ball2.Mass) + 2 * ball2.Mass * ball2.SpeedY) / totalMass;
                        double v2x = (ball2.SpeedX * (ball2.Mass - ball1.Mass) + 2 * ball1.Mass * ball1.SpeedX) / totalMass;
                        double v2y = (ball2.SpeedY * (ball2.Mass - ball1.Mass) + 2 * ball1.Mass * ball1.SpeedY) / totalMass;

                        // Check if balls are moving towards each other before updating speeds
                        if ((v1x - ball1.SpeedX) * (ball2.Left - ball1.Left) + (v1y - ball1.SpeedY) * (ball2.Top - ball1.Top) < 0 &&
                            (v2x - ball2.SpeedX) * (ball1.Left - ball2.Left) + (v2y - ball2.SpeedY) * (ball1.Top - ball2.Top) < 0)
                        {
                            // Balls are moving towards each other, update speeds
                            ball1.SpeedX = v1x;
                            ball1.SpeedY = v1y;
                            ball2.SpeedX = v2x;
                            ball2.SpeedY = v2y;

                            double angle = Math.Atan2(ball2.Top - ball1.Top, ball2.Left - ball1.Left);
                            // Update the ball positions to avoid overlap
                            //double overlap = ball1.Diameter / 2 + ball2.Diameter / 2 - distance;
                            //ball1.Top -= overlap / 2 * Math.Sin(angle);
                            //ball1.Left -= overlap / 2 * Math.Cos(angle);
                            //ball2.Top += overlap / 2 * Math.Sin(angle);
                            //ball2.Left += overlap / 2 * Math.Cos(angle);
                        }
                    }
                }
            }
        }


        //private void CheckBallsCollision(Ball ball)
        //{
        //    foreach (Ball otherBall in dataAPI.GetBalls())
        //    {
        //        if (otherBall != ball) // Avoid self-collision
        //        {
        //            double distance = Math.Sqrt(Math.Pow(otherBall.Top - ball.Top, 2) + Math.Pow(otherBall.Left - ball.Left, 2));

        //            if (distance <= ball.Diameter / 2 + otherBall.Diameter / 2)
        //            {
        //                // Calculate the collision angle
        //                double angle = Math.Atan2(otherBall.Top - ball.Top, otherBall.Left - ball.Left);

        //                // Calculate the new velocities after the collision
        //                double newSpeedX1 = ball.SpeedX * Math.Cos(angle) + ball.SpeedY * Math.Sin(angle);
        //                double newSpeedY1 = ball.SpeedY * Math.Cos(angle) - ball.SpeedX * Math.Sin(angle);
        //                double newSpeedX2 = otherBall.SpeedX * Math.Cos(angle) + otherBall.SpeedY * Math.Sin(angle);
        //                double newSpeedY2 = otherBall.SpeedY * Math.Cos(angle) - otherBall.SpeedX * Math.Sin(angle);

        //                // Update the ball velocities
        //                ball.SpeedX = newSpeedX2;
        //                ball.SpeedY = newSpeedY1;
        //                otherBall.SpeedX = newSpeedX1;
        //                otherBall.SpeedY = newSpeedY2;

        //                // Update the ball positions to avoid overlap
        //                double overlap = ball.Diameter / 2 + otherBall.Diameter / 2 - distance;
        //                ball.Top -= overlap / 2 * Math.Sin(angle);
        //                ball.Left -= overlap / 2 * Math.Cos(angle);
        //                otherBall.Top += overlap / 2 * Math.Sin(angle);
        //                otherBall.Left += overlap / 2 * Math.Cos(angle);

        //                // Invoke the BallPositionChanged event to notify subscribers of the new positions
        //                ball.Move();
        //                otherBall.Move();
        //            }
        //        }
        //    }
        //}

        private void OnBallPositionChanged(object sender, BallPositionChangedEventArgs args)
        {
            Ball ball = (Ball)sender;
            lock (locked)
            {
                CheckBoundaryCollision(ball);
                CheckBallCollisions();
            }
        }
    }
}