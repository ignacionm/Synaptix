using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.SceneManagement;

public class Insignias : MonoBehaviour {
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

	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		comprobarInsignias();
	}

	public void comprobarInsignias() {
		Lines = System.IO.File.ReadAllLines(@"C:/UnityTestFolder/" + usuario.text + ".txt");
		if (Lines[4].ToString().Equals("neurona: True"))
		{
			neuronaDes.gameObject.SetActive(false);
			neurona.gameObject.SetActive(true);
		}
		if (Lines[5].ToString().Equals("investigador: True"))
		{
			investigadorDes.gameObject.SetActive(false);
			investigador.gameObject.SetActive(true);
		}
		if (Lines[6].ToString().Equals("internista: True"))
		{
			internistaDes.gameObject.SetActive(false);
			internista.gameObject.SetActive(true);
		}
		if (Lines[7].ToString().Equals("vara: True"))
		{
			varaDes.gameObject.SetActive(false);
			vara.gameObject.SetActive(true);
		}

	}


}
