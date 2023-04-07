using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWProject.Data;
using TPWProject.Logic.Abstract;

namespace TPWProject.Logic
{
    public class BallRepository : IBallRepository
    {
        private List<IBall> balls;

        public BallRepository()
        {
            balls = new List<IBall>();
        }

        public void Add(Ball ball)
        {
            balls.Add(ball);
        }

        public void Remove(IBall ball)
        {
            ball.Dispose();
            balls.Remove(ball);
        }

        public void RemoveAll()
        {
            foreach (IBall ball in balls)
            {
                ball.Dispose();
            }
            balls.Clear();
        }

        public IEnumerable<IBall> GetAll()
        {
            return balls;
        }

        public int Count()
        {
            return balls.Count;
        }
    }
}
