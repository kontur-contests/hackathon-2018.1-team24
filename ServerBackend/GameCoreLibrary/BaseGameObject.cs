using System;
using System.Linq;

namespace GameCoreLibrary
{
    public abstract class BaseGameObject : IGameObject
    {
        public const int HitRange = 100;

        public abstract ObjectType ObjectType { get; set; }
        public Guid Id { get; set; }
        public Pos Pos { get; set; }
        public bool IsAlive { get; set; }
        public int HealthPoints { get; set; }
        public int MaxHealthPoints { get; set; }
        public double HealthPercent => (double) HealthPoints / MaxHealthPoints;
        public int HitPoints { get; set; }
        public int Speed { get; set; }
        public int Reward { get; set; }

        public bool Hit(IGameObject gameObject)
        {
            if (!gameObject.IsAlive || gameObject.Pos.DistTo(Pos) > HitRange)
                return false;
            gameObject.HealthPoints -= HitPoints;
            return true;
        }

        public float Height => MeasurementList.Measurements[ObjectType].Height;
        public float Width => MeasurementList.Measurements[ObjectType].Width;

        public IGameObject Clone()
        {
            var type = GetType();
            var instance = (IGameObject) Activator.CreateInstance(type);
            var properties = type.GetProperties();
            foreach (var propertyInfo in properties.Where(x => x.CanWrite))
            {
                var value = propertyInfo.GetValue(this, null);
                propertyInfo.SetValue(instance, value, null);
            }

            instance.Id = Guid.NewGuid();
            return instance;
        }
    }
}