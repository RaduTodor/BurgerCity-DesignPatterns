using System;
using BurgerCity.Contracts;

namespace BurgerCity.Entities
{
    public class PointsAccount : IAccount
    {
        public int Points { get; set; }

        public PointsAccount()
        {
            Points = 0;
        }

        public void AddPoints(int pointsNumber)
        {
            Points += pointsNumber;
        }

        public bool RemovePoints(int pointsNumber)
        {
            if (IsEnough(pointsNumber))
            {
                Points -= pointsNumber;
                return true;
            }
            return false;
        }

        public int GetPointsAmount()
        {
            return Points;
        }

        public bool IsEnough(int neededPoints)
        {
            if (Points >= neededPoints)
                return true;
            return false;
        }
    }
}