using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TPWProject.Data.Abstract;

namespace TPWProject.Data
{
    public class DataAPI : AbstractDataAPI
    {
        private List<BallLogger> _loggers = new List<BallLogger>();
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
            _loggers.ForEach(b => b.Dispose());
            _loggers.Clear();
            Boundary.RemoveAll();
        }

        public override void CreateSimulation(double height, double width, int ballCount)
        {
            Boundary = new Boundary(width, height);
            Boundary.GenerateBalls(ballCount);
        }

        public override Boundary GetBoundary()
        {
            return Boundary;
        }

        public override void EnableLogging(ILogger logger)
        {
            foreach (Ball b in Boundary.GetAll())
            {
                _loggers.Append(new BallLogger(logger, b));
            }
        }
    }
}
