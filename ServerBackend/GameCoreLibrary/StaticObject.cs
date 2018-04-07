using System;

namespace GameCoreLibrary
{
    public class StaticObject : BaseGameObject
    {
        public override ObjectType ObjectType { get; set; }

        public StaticObject()
        {
            Id = Guid.NewGuid();
        }
    }
}