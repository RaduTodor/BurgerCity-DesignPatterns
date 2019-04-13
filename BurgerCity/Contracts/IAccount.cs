namespace BurgerCity.Contracts
{
    public interface IAccount
    {
        void AddPoints(int pointsNumber);
        bool RemovePoints(int pointsNumber);
        int GetPointsAmount();
        bool IsEnough(int neededPoints);
    }
}