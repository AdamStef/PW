using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWProject.Data;

namespace TPWProject.Logic.Abstract
{
    public interface IBallRepository
    {
        public void Add(Ball ball);
        public void Remove(IBall ball);
        public IEnumerable<IBall> GetAll();
        public int Count();
        void RemoveAll();
    }
}
