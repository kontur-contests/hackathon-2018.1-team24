using System;
using System.Linq;

namespace GameCoreLibrary
{
    public abstract class BaseGameObject : IGameObject
    {
        public abstract ObjectType ObjectType { get; set; }
        public Guid Id { get; set; }
        public Pos Pos { get; set; }
        public bool IsAlive { get; set; }
        public int HealthPoints { get; set; }
        public int HitPoints { get; set; }
        public int Reward { get; set; }

        public int Hit(IGameObject gameObject)
        {
            gameObject.HealthPoints -= HitPoints;
            return HitPoints;
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