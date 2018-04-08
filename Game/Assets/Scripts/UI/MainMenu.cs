using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public void Play()
    {
        SoundManager.Instance.Play("open");
        Application.LoadLevel(Application.loadedLevel + 1);
    }
    
    public void Exit()
    {
        Application.Quit();
    }

    public void ToMainMenu()
    {
        Application.LoadLevel(1);
    }
}
