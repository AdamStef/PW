using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWProject.Data;
using TPWProject.Logic.Abstract;

namespace TPWProject.Logic
{
    public class BallManager : IBallManager
    {
        private IBallRepository ballRepository;
        public BallManager(IBallRepository ballRepository)
        {
            this.ballRepository = ballRepository;
        }
        public void AddBall(IBall ball)
        {
            ballRepository.Add(ball);
        }
        public void RemoveBall(IBall ball)
        {
            ballRepository.Remove(ball);
        }
        public ICollection<IBall> GetAllBalls()
        {
            return ballRepository.GetAll();
        }
    }
}
