using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWProject.Data.Abstract;

namespace TPWProject.Data
{
    public class Boundary
    {
        //public double Top { get; set; }
        //public double Left { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        private IBallRepository ballRepository;

        public Boundary(double width, double height)
        {
            Width = width;
            Height = height;
            ballRepository = new BallRepository();
            //GenerateBalls(ballCount);
        }

        private Ball GenerateBall()
        {
            Random random = new Random();
            double diameter = random.Next(50, 80);
            double x = random.NextDouble() * (Width - diameter);
            double y = random.NextDouble() * (Height - diameter);
            double mass = random.NextDouble() * 5.0;

            // TODO: Check if within other balls

            Ball ball = new Ball(y, x, diameter, mass);
            return ball;
        }

        public void GenerateBalls(int count)
        {
            ballRepository.Clear();
            for (int i = 0; i < count; i++)
            {
                Ball ball = GenerateBall();
                ballRepository.Add(ball);
            }
        }

        public List<IBall> GetAll()
        {
            return ballRepository.GetAll();
        }

        public void RemoveAll()
        {
            ballRepository.Clear();
        }
    }
}
