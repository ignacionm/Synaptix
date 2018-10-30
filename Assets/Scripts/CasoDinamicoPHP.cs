using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using SimpleJSON;
using System;
using UnityEngine.SceneManagement;

public class CasoDinamicoPHP : MonoBehaviour {
	public Text usuario;
	public Text historial;
	public Text exploracion;
	public InputField IdCasoAleatorio;

	public GameObject panelExpFis;
	int contador=1;

	public Text cabeza;
	public Text sistemaNerv;
	public Text corazon;
	public Text pecho;
	public Text abdomen;
	public Text extremidades;
	public Text piel;

	private int contpreg=0;
	private int contresp=0;

	public Text pregunta;
	public string numPreg;

	public Toggle respuestaA;
	public Toggle respuestaB;
	public Toggle respuestaC;
	public Toggle respuestaD;
	public Text resA;
	public Text resB;
	public Text resC;
	public Text resD;

	public string retroA;
	public string retroB;
	public string retroC;
	public string retroD;
	public int valorA;
	public int valorB;
	public int valorC;
	public int valorD;
	public int puntos=0;
	public GameObject Texto;
	public GameObject ButtonSend;
	public GameObject ButtonContinuar;
	public GameObject Puntuacion;
	public GameObject PanelRetro;
	public GameObject PanelPreguntas;

	public string totpreg;

	public void BuscarExpedientes(){
		StartCoroutine (BuscaExpediente());
		//mensaje.text+="Caso Registrado \n";

	}

	public void BuscarExploracion(){
		StartCoroutine (BuscaExploraciones());
		//mensaje.text+="Caso Registrado \n";

	}

	public void CargaPreguntas(){
		StartCoroutine (BuscaPreguntas());
		PanelPreguntas.gameObject.SetActive (true);
	}

	public void CargarRespuestas(){
		StartCoroutine (BuscaRespuestas());
	}

	public void Continuar(){
		//prueba
		totalPreg();
		if (contpreg.ToString () == totpreg) {
			GuardarScore ();
			SceneManager.LoadScene ("Scores");
		}
		Debug.Log("Preguntas No. "+contpreg + "BD: " +totpreg);
		//checa
		ButtonSend.gameObject.SetActive(true);
		ButtonContinuar.gameObject.SetActive(false);
		PanelRetro.gameObject.SetActive(false);
		respuestaA.GetComponent<Toggle>().isOn = false;
		respuestaB.GetComponent<Toggle>().isOn = false;
		respuestaC.GetComponent<Toggle>().isOn = false;
		respuestaD.GetComponent<Toggle>().isOn = false;
		StartCoroutine (BuscaPreguntas());
	}

	public void ConsultaRetroScore(){
		//Verifica la opción seleccionada
		PanelRetro.gameObject.SetActive (true);
		if (respuestaA.isOn) {
			puntos += valorA;
			Puntuacion.GetComponent<Text> ().text = puntos.ToString ();
			Texto.GetComponent<Text> ().text = retroA;
		} else if (respuestaB.isOn) {
			puntos += valorB;
			Texto.GetComponent<Text> ().text = retroB;
		} else if (respuestaC.isOn) {
			puntos += valorC;
			Texto.GetComponent<Text> ().text = retroC;
		}
		else if(respuestaD.isOn) {
			puntos += valorD; 
			Texto.GetComponent<Text> ().text = retroD;
		}
		respuestaA.enabled = false;
		respuestaA.enabled = false;
		respuestaA.enabled = false;
		respuestaA.enabled = false;
		ButtonSend.gameObject.SetActive(false);
		ButtonContinuar.gameObject.SetActive(true);
		//termina verificación
	}

	public void showPanel(){
		contador++;
		if (contador % 2 == 1) {
			panelExpFis.gameObject.SetActive (false);
		} else {
			panelExpFis.gameObject.SetActive (true);
			BuscarExploracion ();
		}
	}

	public void totalPreg(){
		StartCoroutine (TotalPreguntas());
	}

	public void GuardarScore(){
		StartCoroutine (actualizaScore ());
	}
	// Use this for initialization
	void Start () {
		StartCoroutine (CasoAleatorio());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator BuscaExpediente(){
		WWW conexion = new WWW ("www.arevolution.com.mx/synaptix/consultaExpediente.php?casoa=" + IdCasoAleatorio.text);
		//localhost/synaptix/buscaCaso.php  
		yield return(conexion);
		JSONNode nodo = JSON.Parse(conexion.text.ToString());
		Debug.Log("JSON Descargado: " + nodo.ToString());
		Debug.Log (nodo[0][0].ToString());
		Debug.Log (nodo[0][1].ToString());
		//idCaso.text = conexion.text;
		historial.text = nodo[0][0].ToString();
		exploracion.text = nodo[0][1].ToString();
	}

	IEnumerator BuscaExploraciones(){
		WWW conexion = new WWW ("www.arevolution.com.mx/synaptix/consultaexploraciones.php?casoa=" + IdCasoAleatorio.text);
		//localhost/synaptix/buscaCaso.php  
		yield return(conexion);
		JSONNode nodo = JSON.Parse(conexion.text.ToString());
		Debug.Log("JSON Descargado: " + nodo.ToString());
		Debug.Log (nodo[0][0].ToString());
		Debug.Log (nodo[0][1].ToString());
		//idCaso.text = conexion.text;
		cabeza.text = nodo[0][0].ToString();
		sistemaNerv.text = nodo[0][1].ToString();
		corazon.text = nodo[0][2].ToString();
		pecho.text = nodo[0][3].ToString();
		abdomen.text = nodo[0][4].ToString();
		extremidades.text = nodo[0][5].ToString();
		piel.text = nodo[0][6].ToString();
	}

	IEnumerator BuscaPreguntas(){
		WWW conexion = new WWW ("www.arevolution.com.mx/synaptix/consultapreguntas.php?casoa=" + IdCasoAleatorio.text);
		//localhost/synaptix/buscaCaso.php  
		yield return(conexion);
		Debug.Log (conexion.text);
		JSONNode nodo = JSON.Parse(conexion.text.ToString());
		Debug.Log ("Tamaño: " + nodo.ToString ().Length);
		Debug.Log("JSON Descargado: " + nodo.ToString());
		Debug.Log (nodo[contpreg][1].ToString());
		if (nodo [contpreg] [1].ToString () != "") {
			numPreg = nodo [contpreg] [0].ToString ();
			Debug.Log ("No. Preg: " + numPreg);
			pregunta.text = nodo [contpreg] [1].ToString ();
			CargarRespuestas ();
			contpreg++;
		} 
		//if(nodo.ToString().Length){
		//}
		//idCaso.text = conexion.text;
		/*cabeza.text = nodo[0][0].ToString();
		sistemaNerv.text = nodo[0][1].ToString();
		corazon.text = nodo[0][2].ToString();
		pecho.text = nodo[0][3].ToString();
		abdomen.text = nodo[0][4].ToString();
		extremidades.text = nodo[0][5].ToString();
		piel.text = nodo[0][6].ToString();*/
	}

	IEnumerator BuscaRespuestas(){
		WWW conexion = new WWW ("www.arevolution.com.mx/synaptix/consultarespuestas.php?idPreg=" + numPreg);
		//localhost/synaptix/buscaCaso.php  
		yield return(conexion);
		Debug.Log (conexion.text);
		JSONNode nodo = JSON.Parse(conexion.text.ToString());
		Debug.Log("JSON Respuestas Descargado: " + nodo.ToString());
		Debug.Log (nodo[0][0].ToString());
		if (nodo [contresp] [0].ToString () != "") {
			resA.text = nodo [contresp] [0].ToString ();
			resB.text = nodo [contresp] [3].ToString ();
			resC.text = nodo [contresp] [6].ToString ();
			resD.text = nodo [contresp] [9].ToString ();

			valorA=nodo [contresp] [1].AsInt;
			retroA=nodo [contresp] [2].ToString ();
			valorB = nodo [contresp] [4].AsInt;
			retroB=nodo [contresp] [5].ToString ();
			valorC=nodo [contresp] [7].AsInt;
			retroC=nodo [contresp] [8].ToString ();
			valorD=nodo [contresp] [10].AsInt;
			retroD=nodo [contresp] [11].ToString ();
			contresp++;
		}
	}



	IEnumerator CasoAleatorio(){
		WWW conexion = new WWW ("www.arevolution.com.mx/synaptix/buscaCasoAleatorio.php");
		//localhost/synaptix/buscaCasoAleatorio.php
		yield return(conexion);
		IdCasoAleatorio.text = conexion.text;
	}

	IEnumerator TotalPreguntas(){
		WWW conexion = new WWW ("www.arevolution.com.mx/synaptix/buscaTotal.php?casoa=" + IdCasoAleatorio.text);
		//localhost/synaptix/buscaCaso.php  
		yield return(conexion);
		Debug.Log (conexion.text);
		totpreg = conexion.text.ToString();
	}

	IEnumerator actualizaScore(){
		WWW conexion = new WWW ("www.arevolution.com.mx/synaptix/registroScore.php?puntos=" + puntos+"&uss="+usuario.text);
		//localhost/synaptix/buscaCaso.php  
		yield return(conexion);
		Debug.Log (conexion.text);
	}

}

