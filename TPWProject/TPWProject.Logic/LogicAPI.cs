using System.Collections.Generic;
using System.Threading;
using TPWProject.Data.Abstract;
using TPWProject.Logic.Abstract;

namespace TPWProject.Logic
{
    public class LogicAPI : AbstractLogicAPI
    {
        private readonly AbstractDataAPI dataAPI;
        public double Height { get; private set; }
        public double Width { get; private set; }
        public bool IsRunning { get; private set; }

        public LogicAPI(double height, double width, AbstractDataAPI dataAPI = null)
        {
            if (dataAPI != null)
                this.dataAPI = dataAPI;
            else
                this.dataAPI = AbstractDataAPI.CreateAPI();

            Height = height;
            Width = width;
            IsRunning = false;
        }

        public override void GenerateBalls(int ballsCount)
        {
            for (int i = 0; i < ballsCount; i++)
            {
                dataAPI.GenerateBall(Height, Width);
            }
        }

        public override void StartBallMovement()
        {
            IsRunning = true;
            foreach (var ball in dataAPI.GetBalls())
            {
                Thread thread = new Thread(() =>
                {
                    while(IsRunning)
                    {
                        ball.Move(Height, Width);
                        Thread.Sleep(5);
                    }
                });
                thread.IsBackground = true;
                thread.Start();
            }
        }

        public override void StopMovement()
        {
            IsRunning = false;
        }

        public override void ClearRepository()
        {
            dataAPI.RemoveAllBalls();
        }

        public override void SetHeight(double height)
        {
            Height = height;
        }

        public override void SetWidth(double width)
        {
            Width = width;
        }

        public override IList<IBall> GetBalls()
        {
            return dataAPI.GetBalls();
        }
    }
}