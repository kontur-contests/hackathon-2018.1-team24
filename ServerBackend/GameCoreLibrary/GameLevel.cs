using System.Collections.Generic;
using System.Linq;

namespace GameCoreLibrary
{
    public class GameLevel
    {
        public List<IGameObject> GameObjects
        {
            get => gameObjects ?? (gameObjects = new List<IGameObject>());
            set => gameObjects = value;
        }

        private List<IGameObject> gameObjects { get; set; }

        //For serializer only
        public GameLevel()
        {
        }

        public GameLevel(Level level)
        {
            GameObjects = level.GameObjects.Select(x => x.Clone()).ToList();
        }

        public void DoSync(IList<IGameObject> gameObjects)
        {
            foreach (var gObject in gameObjects)
            {
                var existing = GameObjects.Find(x => x.Id == gObject.Id);
                if(existing == null)
                    GameObjects.Add(gObject);
                else
                {
                    existing.Pos = gObject.Pos;
                    existing.HealthPoints = gObject.HealthPoints;
                }
            }

            foreach (var remove in GameObjects.Where(x=> x.ObjectType != ObjectType.Player && gameObjects.All(go => go.Id != x.Id)).ToArray())
            {
                GameObjects.Remove(remove);
            }
        }
    }
}