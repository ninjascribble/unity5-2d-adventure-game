﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToContinue : MonoBehaviour {

	public string scene;

	private bool loadLock;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!loadLock && Input.GetMouseButtonDown(0)) {
			LoadScene ();
		}
	}

	void LoadScene () {
		loadLock = true;
		SceneManager.LoadScene (scene);
	}
}
