using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWProject.Logic.Abstract;
using TPWProject.Logic;
using TPWProject.Data;

namespace TPWProject.Presentation.Model
{
    internal class BallsModel : IObservable<IBall>
    {
        private IBallRepository ballsRepository;
        private int _maxLeft = 800;
        private int _maxTop = 600;
        public BallsModel()
        {
            ballsRepository = new BallRepository();
        }

        public void Start(int numberOfBalls)
        {
            Random random = new Random();
            for (int i = 0; i < numberOfBalls; i++)
            {
                Ball ball = new Ball(random.Next(76, 358), random.Next(0, 800), random.Next(10, 100), random.Next(1, 5));
                ballsRepository.Add(ball);
            }
        }

        public void Stop()
        {
            ballsRepository.RemoveAll();
        }

        public IEnumerable<IBall> GetBalls()
        {
            return ballsRepository.GetAll();
        }

        public IDisposable Subscribe(IObserver<IBall> observer)
        {
            throw new NotImplementedException();
        }
    }
}
