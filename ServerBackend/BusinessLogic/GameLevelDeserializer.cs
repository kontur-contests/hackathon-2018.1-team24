using System;
using System.Collections.Generic;
using GameCoreLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BusinessLogic
{
    public class GameLevelDeserializer
    {
        public GameLevel Deserialize(string value)
        {
            var level = JObject.Parse(value);
            var jarray = (JArray) level["GameObjects"];
            var gameLevel = new GameLevel();
            foreach (var element in jarray)
            {
                Enum.TryParse(element["ObjectType"].ToString(), out ObjectType objectType);
                var gameObject = (IGameObject)element.ToObject(Deserializers.Serializers[objectType]);
                gameLevel.GameObjects.Add(gameObject);
            }
            return gameLevel;
        }
    }

    public static class Deserializers
    {
        public static Dictionary<ObjectType, Type> Serializers = new Dictionary<ObjectType, Type>
        {
            {ObjectType.Bitcoin, typeof(StaticObject)},
            {ObjectType.Platform, typeof(StaticObject)},
            {ObjectType.Table, typeof(StaticObject)},
            {ObjectType.Player, typeof(Player)},
            {ObjectType.Enemy, typeof(Enemy)},
        };
    }
}