using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Levels : MonoBehaviour {

	public Text USUARIO;

	// Use this for initialization
	void Start () {
		USUARIO.text = Login.Username;
		Debug.Log ("Usuario: " + USUARIO.text);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CargarNivel(string NombreNivel){
		SceneManager.LoadScene (NombreNivel);
	}

	public void CargarCaso1() {
		int dice = Random.Range(1, 4);
		Debug.Log(dice);
		if (dice == 1)
		{
			SceneManager.LoadScene("RoomUno");
		}
		else if (dice == 2)
		{
			SceneManager.LoadScene("RoomDos");
		}
		else if (dice == 3)
		{
			SceneManager.LoadScene("RoomTres");
		}
		
		
		
	}

	public void Salir(){
		Application.Quit ();
	}

}
