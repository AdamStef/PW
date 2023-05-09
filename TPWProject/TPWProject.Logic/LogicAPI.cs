using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
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
                            //HandleCollisions(ball);
                            CheckBallsCollision(ball);
                        }
                    Thread.Sleep(5);
                    }
                });
                thread.IsBackground = true;
                thread.Start();
            }
        }

        public void StopMovement()
        {
            IsRunning = false;
        }

        private void CheckBallsCollision(Ball ball)
        {
            foreach (Ball otherBall in dataAPI.GetBalls())
            {
                if (otherBall != ball) // Avoid self-collision
                {
                    double distance = Math.Sqrt(Math.Pow(otherBall.Top - ball.Top, 2) + Math.Pow(otherBall.Left - ball.Left, 2));

                    if (distance <= ball.Diameter / 2 + otherBall.Diameter / 2)
                    {
                        // Calculate the collision angle
                        double angle = Math.Atan2(otherBall.Top - ball.Top, otherBall.Left - ball.Left);

                        // Calculate the new velocities after the collision
                        double newSpeedX1 = ball.SpeedX * Math.Cos(angle) + ball.SpeedY * Math.Sin(angle);
                        double newSpeedY1 = ball.SpeedY * Math.Cos(angle) - ball.SpeedX * Math.Sin(angle);
                        double newSpeedX2 = otherBall.SpeedX * Math.Cos(angle) + otherBall.SpeedY * Math.Sin(angle);
                        double newSpeedY2 = otherBall.SpeedY * Math.Cos(angle) - otherBall.SpeedX * Math.Sin(angle);

                        // Update the ball velocities
                        ball.SpeedX = newSpeedX2;
                        ball.SpeedY = newSpeedY1;
                        otherBall.SpeedX = newSpeedX1;
                        otherBall.SpeedY = newSpeedY2;

                        // Update the ball positions to avoid overlap
                        double overlap = ball.Diameter / 2 + otherBall.Diameter / 2 - distance;
                        ball.Top -= overlap / 2 * Math.Sin(angle);
                        ball.Left -= overlap / 2 * Math.Cos(angle);
                        otherBall.Top += overlap / 2 * Math.Sin(angle);
                        otherBall.Left += overlap / 2 * Math.Cos(angle);

                        // Invoke the BallPositionChanged event to notify subscribers of the new positions
                        ball.Move();
                        otherBall.Move();
                    }
                }
            }
        }

        private void OnBallPositionChanged(object sender, BallPositionChangedEventArgs args)
        {
            Ball ball = (Ball)sender;
            CheckBoundaryCollision(ball);
        }
    }
}