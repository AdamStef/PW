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
        public void Add(IBall ball);
        public void Remove(IBall ball);
        public void RemoveAll();
        public List<IBall> GetAll();
        public int Count();
        public void Clear();
    }
}
