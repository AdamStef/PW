using System.Collections.Generic;
using TPWProject.Data;

namespace TPWProject.Logic.Abstract
{
    public interface IBallManager
    {
        void AddBall(IBall ball);
        ICollection<IBall> GetAllBalls();
        void RemoveBall(IBall ball);
    }
}