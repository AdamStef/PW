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
        //private ILogger _logger;
        //private Timer _timer;

        public DataAPI(/*ILogger logger*/)
        {
            Boundary = new Boundary(0, 0);
            //_logger = new FileLogger();
            //_logger = logger;
            //_timer = new Timer();
            //_timer.AutoReset = true;
            //_timer.Interval = 1000;
            //_timer.Elapsed += ;
        }

        public override List<IBall> GetBalls()
        {
            return Boundary.GetAll();
        }

        public override void RemoveAllBalls()
        {
            Boundary.GetAll().ForEach(b => { b.StopLogging(); });
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
            Boundary.GetAll().ForEach(b => { b.Logger = logger; b.StartLogging(); });
        }
    }
}
