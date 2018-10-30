using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;

public class AbrirURL : MonoBehaviour
{


	public Text URL; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AbrirPagina() {
		Application.OpenURL(URL.text);
		
	}
	public void OpenLinkJSPlugin()
	{
		#if !UNITY_EDITOR
		openWindow(URL.text);
		#endif
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}

