using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    public static PlayerHPBar Instance;
    public Slider slider;
    
	void Awake ()
    {
        Instance = this;
        Set(0);
    }

    public void Set(float value)
    {
        slider.value = value;
    }

}
