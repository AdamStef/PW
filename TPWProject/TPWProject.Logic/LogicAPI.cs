using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using TPWProject.Data.Abstract;
using TPWProject.Logic.Abstract;

namespace TPWProject.Logic
{
    public class LogicAPI : AbstractLogicAPI
    {
        private AbstractDataAPI dataAPI;
        private double height;
        private double width;
        private bool isRunning = false;
        public LogicAPI(double height, double width)
        {
            dataAPI = AbstractDataAPI.CreateAPI();
            this.height = height;
            this.width = width;
        }

        public override void GenerateBalls(int ballsCount)
        {
            for (int i = 0; i < ballsCount; i++)
            {
                dataAPI.GenerateBall(height, width);
            }
        }

        public override void StartBallMovement()
        {
            isRunning = true;
            foreach (var ball in dataAPI.GetShapes())
            {
                Thread thread = new Thread(() =>
                {
                    while(isRunning)
                    {
                        ball.Move(height, width);
                        Thread.Sleep(5);
                    }
                });
                thread.Start();
            }
        }

        public override void StopMovement()
        {
            isRunning = false;
        }

        public override void ClearRepository()
        {
            dataAPI.RemoveAllShapes();
        }

        public override void SetDimentions(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public override IList<Shape> GetShapes()
        {
            return dataAPI.GetShapes();
        }
    }
}