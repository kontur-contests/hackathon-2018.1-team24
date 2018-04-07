using System;
using System.Linq;

namespace GameCoreLibrary
{
    public abstract class BaseGameObject : IGameObject
    {
        public Guid Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public bool IsAlive { get; set; }
        public int HealthPoints { get; set; }
        public int HitPoints { get; set; }

        public int Hit()
        {
            throw new NotImplementedException();
        }

        public float Height { get; }
        public float Width { get; }

        public IGameObject Clone()
        {
            var type = this.GetType();
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