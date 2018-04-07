using GameCoreLibrary;

namespace BusinessLogic.Units
{
    public static class CommentsService
    {
        public static string GetComment(IGameObject gameObject)
        {
            switch (gameObject.ObjectType)
            {
                case ObjectType.Guard:
                    return FromGuard(gameObject);
                case ObjectType.Bug:
                    return FromBug(gameObject);
                case ObjectType.Bitcoin:
                    return gameObject.Reward.ToString();
                case ObjectType.Kachok:
                    return FromKachok(gameObject);
                default:
                    return "";
            }
        }

        private static string FromGuard(IGameObject gameObject)
        {
            if (gameObject.HealthPercent > 0.8)
                return "Привет БУТКАМПЕР";
            if (gameObject.HealthPercent > 0.3)
                return "Возьми пропуск";
            return "WELCOME!";
        }

        private static string FromBug(IGameObject gameObject)
        {
            if (gameObject.HealthPercent > 0.8)
                return "NULLRefernce Exception";
            if (gameObject.HealthPercent > 0.2)
                return "Outofmemory Exception";
            return "Done!";
        }

        private static string FromKachok(IGameObject gameObject)
        {
            if (gameObject.HealthPercent > 0.8)
                return "Скоро дедлайн";
            if (gameObject.HealthPercent > 0.3)
                return "Нужно закрыть 20 багов";
            return "Можно отдохнуть";
        }
    }
}