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
        //public IBallRepository BallRepository { get; set; }
        //public Boundary Boundary { get; private set; }
        public bool IsRunning { get; private set; }

        private readonly object locked = new object();

        public DataAPI()
        {
            Boundary = new Boundary(0, 0);
        }

        public override List<IBall> GetBalls()
        {
            return Boundary.GetAll();
        }

        public override void RemoveAllBalls()
        {
            Boundary.RemoveAll();
        }

        public override void CreateSimulation(double height, double width, int ballCount)
        {
            Boundary = new Boundary(width, height);
            Boundary.GenerateBalls(ballCount);
            //StartBallMovement();
        }

        public override Boundary GetBoundary()
        {
            return Boundary;
        }
    }
}
