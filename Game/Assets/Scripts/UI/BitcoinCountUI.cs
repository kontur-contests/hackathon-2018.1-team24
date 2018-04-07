using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BitcoinCountUI : MonoBehaviour
{
    public static BitcoinCountUI Instance;

    public int count;
    public Text textCount;

    private void Awake()
    {
        Instance = this;
    }

    public void Add()
    {
        count++;
        textCount.text = count.ToString();
    }
}
