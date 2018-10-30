using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.SceneManagement;

public class onMouseOver : MonoBehaviour {

	public GameObject panel;
	public GameObject panel2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MouseOver()
	{
		panel.gameObject.SetActive(true);
		panel2.gameObject.SetActive(true);
	}

	public void MouseExit() {
		panel.gameObject.SetActive(false);
		panel2.gameObject.SetActive(false);
	}
}
