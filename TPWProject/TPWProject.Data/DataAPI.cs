using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TPWProject.Data.Abstract;

namespace TPWProject.Data
{
    public class DataAPI : AbstractDataAPI
    {
        //public override IBallRepository BallRepository { get; set; }
        //private int _height;
        //private int _width;
        //public override int Height { get => _height; set { _height = value; } }
        //public override int Width { get => _width; set { _width = value; } }

        public DataAPI(/*int height, int width*/)
        {
            //TODO: Dependency Injection???
            ballRepository = new BallRepository();
            //Height = height;
            //Width = width;
        }
        public override Ball GenerateBall(double height, double width)
        {
            Random random = new Random();
            double diameter = random.Next(50, 80);
            double x = random.NextDouble() * (width - diameter);
            double y = random.NextDouble() * (height - diameter);
            double mass = random.NextDouble() * 5.0;
            Ball ball = new Ball(y, x, diameter, mass);
            ballRepository.Add(ball);
            return ball;
            //Thread thread = new Thread(() =>
            //{
            //    //TODO: change true
            //    while (true)
            //    {
            //        ball.Move();
            //        Thread.Sleep(100);
            //    }
            //});
            //thread.Start();
        }

        public override IList<Shape> GetShapes()
        {
            return ballRepository.GetAll();
        }

        public override void RemoveAllShapes()
        {
            ballRepository.RemoveAll();
        }
    }
}
