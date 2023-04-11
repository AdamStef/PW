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
        private readonly List<Shape> shapes;

        public BallRepository()
        {
            shapes = new List<Shape>();
        }

        public void Add(Shape ball)
        {
            shapes.Add(ball);
        }

        public void Remove(Shape ball)
        {
            shapes.Remove(ball);
        }

        public void RemoveAll()
        {
            shapes.Clear();
        }

        public IList<Shape> GetAll()
        {
            return shapes;
        }

        public int Count()
        {
            return shapes.Count;
        }
    }
}
