using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.SceneManagement;

public class ConsultaScore : MonoBehaviour {
	public Text usuario;
	private string Username;
	public Text puntos;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void VerScore() {
		StartCoroutine(ComprobarScore());
	}
	public IEnumerator ComprobarScore()
	{
		Username = usuario.text;
	    //Debug.Log(Username);
	    //WWW conexion = new WWW("www.arevolution.com.mx/synaptix/objetivos.php?uss=" + Username);
		WWW conexion = new WWW("www.arevolution.com.mx/synaptix/consultaScore.php?uss=" + Username);
		yield return (conexion);
		puntos.text = conexion.text;
		//Debug.Log(con);
		//Debug.Log(conexion.text);
		
	}
}
