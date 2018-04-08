using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    [System.Serializable]
    public class SoundItem
    {
        public string name;
        public AudioClip clip;
    }

    public List<SoundItem> items;
    public AudioSource source;

    public void Awake()
    {
        Instance = this;
    }

    public void Play(string name)
    {
        var clip = items.FirstOrDefault(x => x.name == name);
        if (clip != null)
        {
            source.Stop();
            source.clip = clip.clip;
            source.Play();
        }
    }
}
