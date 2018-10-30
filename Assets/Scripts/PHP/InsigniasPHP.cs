using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.SceneManagement;

public class InsigniasPHP : MonoBehaviour
{
	public GameObject neurona;
	public GameObject investigador;
	public GameObject internista;
	public GameObject vara;

	public GameObject neuronaDes;
	public GameObject investigadorDes;
	public GameObject internistaDes;
	public GameObject varaDes;

	private String[] Lines;
	public Text usuario;

	public GameObject username;
	public GameObject password;

	private string Username;
	private string Neurona;


	// Use this for initialization
	void Start()
	{
		StartCoroutine(ComprobarNeurona());
		StartCoroutine(ComprobarInvestigador());
		StartCoroutine(ComprobarInternista());
		StartCoroutine(ComprobarVara());
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	
	public IEnumerator ComprobarNeurona()
	{
		Username = usuario.text;
		
		//Debug.Log(Username);
		WWW conexion = new WWW("www.arevolution.com.mx/synaptix/insignias.php?uss=" + Username + "&ins=neurona");
		//String con = "http://localhost/synaptix/insignias.php?uss=" + Username + "&ins=" + Neurona;
		yield return (conexion);
		//Debug.Log(con);
		//Debug.Log(conexion.text);
		if (conexion.text.Equals("bien"))
		{
			neuronaDes.gameObject.SetActive(false);
			neurona.gameObject.SetActive(true);
		}
	}

	public IEnumerator ComprobarInvestigador()
	{
		Username = usuario.text;
		//Debug.Log(Username);
		WWW conexion = new WWW("www.arevolution.com.mx/synaptix/insignias.php?uss=" + Username + "&ins=investigador");	
		yield return (conexion);
		//Debug.Log(conexion.text);
		if (conexion.text.Equals("bien"))
		{
			investigadorDes.gameObject.SetActive(false);
			investigador.gameObject.SetActive(true);
		}
	}

	public IEnumerator ComprobarInternista()
	{
		Username = usuario.text;
		//Debug.Log(Username);
		WWW conexion = new WWW("www.arevolution.com.mx/synaptix/insignias.php?uss=" + Username + "&ins=internista");
		yield return (conexion);
		//Debug.Log(conexion.text);
		if (conexion.text.Equals("bien"))
		{
			internistaDes.gameObject.SetActive(false);
			internista.gameObject.SetActive(true);
		}
	}

	public IEnumerator ComprobarVara()
	{
		Username = usuario.text;
		//Debug.Log(Username);
		WWW conexion = new WWW("www.arevolution.com.mx/synaptix/insignias.php?uss=" + Username + "&ins=vara");
		//String con = "http://localhost/synaptix/insignias.php?uss=" + Username + "&ins=" + Neurona;
		yield return (conexion);
		//Debug.Log(con);
		//Debug.Log(conexion.text);
		if (conexion.text.Equals("bien"))
		{
			varaDes.gameObject.SetActive(false);
			vara.gameObject.SetActive(true);
		}
	}


}
