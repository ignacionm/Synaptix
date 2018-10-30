using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.IO;
using SimpleJSON;

public class Score : MonoBehaviour {

	public Text archivos;
	public Text puntos;
	public Text usuario;
	// Use this for initialization
	private String[] Lines;
	private string form;

	public int cont = 0;
	public Text uss;
	public Text puntaje;
	void Start () {
		uss.text = "";
		puntaje.text = "";
		StartCoroutine(ObtenerPuntos());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator ObtenerPuntos()
	{
		//Debug.Log(Username);
		WWW conexion = new WWW("www.arevolution.com.mx/synaptix/puntajes.php");
		yield return (conexion);
		JSONNode nodo = JSON.Parse(conexion.text.ToString());
		/*puntaje.text += nodo[0].ToString()+"\t\t\t\t\t"+nodo[1].ToString()+ "\n";
		puntaje.text += nodo[2].ToString()+"\t\t\t\t\t"+nodo[3].ToString()+ "\n";*/
		
		for (int i=0;nodo[i]!=null; i=i+2) {

			uss.text += nodo[i].ToString().Replace('"', ' ').Trim() + "\n";
			puntaje.text +=nodo[i+1].ToString().Replace('"', ' ').Trim() + "\n";
		}
	}


		public void CargarNivel(string NombreNivel){
		SceneManager.LoadScene (NombreNivel);
	}
}
