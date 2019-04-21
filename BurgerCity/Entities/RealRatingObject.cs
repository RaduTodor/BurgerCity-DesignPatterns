using BurgerCity.Contracts;
using BurgerCity.Services;

namespace BurgerCity.Entities
{
    public class RealRatingObject:ARating
    {
        public override void LogRatingValue()
        {
            LoggerSingleton.Logger.LogMessage($"A user has given a rating with value of {this.NumberOfStars} stars for order with ID:{Order.UniqueKey}.");
        }
    }
}