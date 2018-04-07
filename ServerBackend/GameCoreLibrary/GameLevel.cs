using System.Collections.Generic;
using System.Linq;

namespace GameCoreLibrary
{
    public class GameLevel
    {
        public LevelFloor LevelFloor  { get; set; }

        public List<IGameObject> GameObjects { get; set; }

        public GameLevel(Level level)
        {
            GameObjects = CloneObjects(level.GameObjects?? new IGameObject[]{});
            LevelFloor = level.LevelFloor;
        }

        private static List<IGameObject> CloneObjects(IEnumerable<IGameObject> objects)
        {
            return objects.Select(x => x.Clone()).ToList();
        }

        public void DoSync(GameLevel gameLevel)
        {
            if (LevelFloor != gameLevel.LevelFloor)
            {
                GameObjects = CloneObjects(gameLevel.GameObjects);
                LevelFloor = gameLevel.LevelFloor;
                return;
            }

            var gameObjects = gameLevel.GameObjects;
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

            foreach (var remove in GameObjects.Where(x=> x.ObjectType != ObjectType.Player && !gameObjects.Select(go => go.Id).Contains(x.Id)).ToArray())
            {
                GameObjects.Remove(remove);
            }
        }
    }
}