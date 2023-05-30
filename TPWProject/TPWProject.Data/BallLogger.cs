using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
//using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using TPWProject.Data.Abstract;

namespace TPWProject.Data
{
    public class BallLogger : IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;

        private Ball _ball;

        public BallLogger(ILogger logger, Ball ball)
        {
            _logger = logger;
            _ball = ball;

            _timer = new Timer()
            {
                Interval = 5000
            };
            _timer.Elapsed += async (sender, e) =>
            {
                BallJsonModel ballToSave;
                lock (_ball._positionLock)
                {
                    //Debug.WriteLine(DateTime.Now.Millisecond.ToString() + "   " + _ball.Top);
                    ballToSave = new BallJsonModel(_ball.Id, _ball.Top, _ball.Left);
                }
                await _logger.Log(ballToSave);
            };
            _timer.Start();
        }

        public void Dispose()
        {
            _timer.Stop();
            _timer.Dispose();
        }

        public void Start()
        {
            _timer.Elapsed += async (sender, e) =>
            {
                BallJsonModel ballToSave;
                lock (_ball._positionLock)
                {
                    Debug.WriteLine(DateTime.Now.Millisecond.ToString() + "   " + _ball.Top);
                    ballToSave = new BallJsonModel(_ball.Id, _ball.Top, _ball.Left);
                }
                await _logger.Log(ballToSave);
            };
            _timer.Start();
        }
    }
}
