using BurgerCity.Entities;

namespace BurgerCity.Contracts
{
    public abstract class ARating
    {
        public int NumberOfStars { get; set; }

        public Order Order { get; set; }

        public abstract void LogRatingValue();
    }
}