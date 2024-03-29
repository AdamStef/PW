﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWProject.Data.Abstract;

namespace TPWProject.Data
{
    public class Boundary
    {
        public double Width { get; set; }
        public double Height { get; set; }

        private IBallRepository ballRepository;

        public Boundary(double width, double height)
        {
            Width = width;
            Height = height;
            ballRepository = new BallRepository();
        }

        private Ball GenerateBall(int id)
        {
            Random random = new Random();

            bool within;
            double diameter;
            double x;
            double y;
            double mass;
            do
            {
                within = false;
                diameter = random.Next(50, 70);
                x = random.NextDouble() * (Width - diameter);
                y = random.NextDouble() * (Height - diameter);
                mass = diameter / 50;

                double xCenter = x + diameter / 2;
                double yCenter = y + diameter / 2;

                foreach (var b in ballRepository.GetAll())
                {
                    double distance = Math.Sqrt(Math.Pow(b.Left + (b.Diameter * 0.5) - xCenter, 2) + Math.Pow(b.Top + (b.Diameter * 0.5) - yCenter, 2));
                    if (distance <= 0.5 * (b.Diameter + diameter))
                    {
                        within = true;
                    }
                }
            } while (within);

            Ball ball = new Ball(y, x, diameter, mass) { Id = id };
            return ball;
        }

        public void GenerateBalls(int count)
        {
            ballRepository.Clear();
            for (int i = 0; i < count; i++)
            {
                Ball ball = GenerateBall(i);
                ballRepository.Add(ball);
            }
        }

        public List<IBall> GetAll()
        {
            return ballRepository.GetAll();
        }

        public void RemoveAll()
        {
            ballRepository.Clear();
        }
    }
}
