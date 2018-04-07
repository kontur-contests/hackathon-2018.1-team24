using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;
using GameCoreLibrary;
using System;
using System.IO;

[ExecuteInEditMode]
public class LevelSerialized : MonoBehaviour
{
    [Serializable]
    public class LevelSetup
    {
        public LevelFloor levelFloor { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public Guid PlayerId { get; set; }
    }

    public LevelSetup levelSetup;

    public bool save;

    public void SetList()
    {
        var items = FindObjectsOfType<LevelItem>().ToList();
        items.ForEach(x => x.UpdateParams());
        levelSetup.items = items.Select(x => x.levelItem).ToList();
        var json = JsonConvert.SerializeObject(levelSetup);
        print(Application.persistentDataPath + levelSetup.levelFloor + ".json");
        File.WriteAllText(Application.persistentDataPath+ "/level_" + levelSetup.levelFloor + ".json", json);
    }

    private void Update()
    {
        if (save)
        {
            save = false;
            SetList();
        }
    }
}
