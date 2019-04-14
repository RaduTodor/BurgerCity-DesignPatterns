using BurgerCity.Contracts;
using BurgerCity.Services;

namespace BurgerCity.Entities
{
    public class NullRatingObject:ARating
    {
        private static NullRatingObject _instance;
        private NullRatingObject()
        { }

        public static NullRatingObject Instance
        {
            get
            {
                if (_instance == null)
                    return new NullRatingObject();
                return _instance;
            }
        }

        public override void LogRatingValue()
        {
            LoggerSingleton.Logger.LogMessage($"The user didn't want to give us a rating for order with ID:{Order.UniqueKey}. Please see what we can do about it.");
        }
    }
}