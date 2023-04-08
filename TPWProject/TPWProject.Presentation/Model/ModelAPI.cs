using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWProject.Logic.Abstract;
using TPWProject.Logic;
using TPWProject.Data;
using TPWProject.Data.Abstract;
using System.Collections.ObjectModel;

namespace TPWProject.Presentation.Model
{
    internal class ModelAPI
    {
        private AbstractLogicAPI logicAPI;
        public ModelAPI(double height, double width)
        {
            logicAPI = AbstractLogicAPI.CreateAPI(height, width);
        }

        public void Start(int numberOfBalls)
        {
            logicAPI.GenerateBalls(numberOfBalls);
            logicAPI.StartBallMovement();
        }

        public void Stop()
        {
            logicAPI.StopMovement();
            logicAPI.ClearRepository();
        }

        public void SetDimentions(double height, double width)
        {
            logicAPI.SetDimentions(height, width);
        }

        public ObservableCollection<Shape> GetShapes()
        {
            ObservableCollection<Shape> balls = new ObservableCollection<Shape>();
            foreach (Ball ball in logicAPI.GetShapes())
                balls.Add(ball);
            return balls;
        }
    }
}
