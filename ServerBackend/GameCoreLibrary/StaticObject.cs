namespace GameCoreLibrary
{
    public class StaticObject : BaseGameObject
    {
        public StaticObjectType StaticObjectType { get; set; }
    }

    public enum StaticObjectType
    {
        Table,
    }
}