using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameAndMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        Application.LoadLevel(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
