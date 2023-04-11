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
        public IBallRepository BallRepository { get; set; }

        public DataAPI()
        {
            BallRepository = new BallRepository();
        }
        public override Ball GenerateBall(double height, double width)
        {
            Random random = new Random();
            double diameter = random.Next(50, 80);
            double x = random.NextDouble() * (width - diameter);
            double y = random.NextDouble() * (height - diameter);
            double mass = random.NextDouble() * 5.0;
            Ball ball = new Ball(y, x, diameter, mass);
            BallRepository.Add(ball);
            return ball;
        }

        public override IList<IBall> GetBalls()
        {
            return BallRepository.GetAll();
        }

        public override void RemoveAllBalls()
        {
            BallRepository.RemoveAll();
        }
    }
}
