using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWProject.Data;
using TPWProject.Data.Abstract;

namespace TPWProject.Data
{
    public class BallRepository : IBallRepository
    {
        private readonly List<IBall> balls;

        public BallRepository()
        {
            balls = new List<IBall>();
        }

        public void Add(IBall ball)
        {
            balls.Add(ball);
        }

        public void Remove(IBall ball)
        {
            balls.Remove(ball);
        }

        public void RemoveAll()
        {
            balls.Clear();
        }

        public List<IBall> GetAll()
        {
            return balls;
        }

        public int Count()
        {
            return balls.Count;
        }

        public void Clear()
        {
            balls.Clear();
        }
    }
}
