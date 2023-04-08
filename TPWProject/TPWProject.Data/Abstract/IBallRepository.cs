using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWProject.Data;
using TPWProject.Data.Abstract;

namespace TPWProject.Data.Abstract
{
    public interface IBallRepository
    {
        public void Add(Shape ball);
        public void Remove(Shape ball);
        public void RemoveAll();
        public IList<Shape> GetAll();
        public int Count();
    }
}
