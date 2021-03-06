using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CasosPHP : MonoBehaviour {
	public GameObject PanelCaso;
	public GameObject PanelExpediente;
	public GameObject PanelExploracion;
	public GameObject PanelPreguntas;
	public GameObject PanelRespuestas;

	//public Text mensaje;

	public GameObject caso;
	public GameObject categoria;
	public GameObject autor;
	private string Caso;
	private string Categoria;
	private string Autor;

	public GameObject historial;
	public GameObject exploracion;
	public InputField idCaso;
	private string Historial;
	private string Exploracion;
	//private string IdCaso;

	public GameObject cabeza;
	public GameObject sistema;
	public GameObject corazon;
	public GameObject pecho;
	public GameObject abdomen;
	public GameObject extremidades;
	public GameObject piel;
	private string Cabeza;
	private string Sistema;
	private string Corazon;
	private string Pecho;
	private string Abdomen;
	private string Extremidades;
	private string Piel;

	public GameObject pregunta;
	private string Pregunta;

	public GameObject respuestaA;
	public GameObject valorA;
	public GameObject retroA;
	private string RespuestaA;
	private string ValorA;
	private string RetroA;
	public GameObject respuestaB;
	public GameObject valorB;
	public GameObject retroB;
	private string RespuestaB;
	private string ValorB;
	private string RetroB;
	public GameObject respuestaC;
	public GameObject valorC;
	public GameObject retroC;
	private string RespuestaC;
	private string ValorC;
	private string RetroC;
	public GameObject respuestaD;
	public GameObject valorD;
	public GameObject retroD;
	private string RespuestaD;
	private string ValorD;
	private string RetroD;

	public InputField IdPregunta;

	public void RegisterButton(){
		StartCoroutine (Registro());
		//mensaje.text+="Caso Registrado \n";
		caso.GetComponent<InputField>().text="";
		autor.GetComponent<InputField>().text="";
	}

	public void RegisterExpediente(){
		StartCoroutine (Expediente());
		//mensaje.text+="Caso Registrado \n";
		historial.GetComponent<InputField>().text="";
		exploracion.GetComponent<InputField>().text="";
		autor.GetComponent<InputField>().text="";
	}

	public void RegisterExploracion(){
		StartCoroutine (Exploraciones());
		//mensaje.text+="Caso Registrado \n";
		cabeza.GetComponent<InputField>().text="";
		sistema.GetComponent<InputField>().text="";
		corazon.GetComponent<InputField>().text="";
		pecho.GetComponent<InputField>().text="";
		abdomen.GetComponent<InputField>().text="";
		extremidades.GetComponent<InputField>().text="";
		piel.GetComponent<InputField>().text="";
	}

	public void RegisterPreguntas(){
		StartCoroutine (Preguntas());
		//mensaje.text+="Caso Registrado \n";
		pregunta.GetComponent<InputField>().text="";
	}

	public void RegisterRespuestas(){
		StartCoroutine (Respuestas());
		//mensaje.text+="Caso Registrado \n";
		pregunta.GetComponent<InputField>().text="";

		respuestaA.GetComponent<InputField>().text="";
		valorA.GetComponent<InputField>().text="";
		retroA.GetComponent<InputField>().text="";

		respuestaB.GetComponent<InputField>().text="";
		valorB.GetComponent<InputField>().text="";
		retroB.GetComponent<InputField>().text="";

		respuestaC.GetComponent<InputField>().text="";
		valorC.GetComponent<InputField>().text="";
		retroC.GetComponent<InputField>().text="";

		respuestaD.GetComponent<InputField>().text="";
		valorD.GetComponent<InputField>().text="";
		retroD.GetComponent<InputField>().text="";
	}

	IEnumerator Registro(){
		WWW conexion = new WWW ("www.arevolution.com.mx/synaptix/registroCasos.php?caso=" + Caso+"&area="+Categoria+"&autor="+Autor);
		//localhost/synaptix/registroCasos.php?caso=xxx&area=medicinainterna&autor=itson
		yield return(conexion);
		Debug.Log (conexion.text);
		if (conexion.text == "caso registrado") {
			PanelExpediente.SetActive (true);
			StartCoroutine (ConsultaCaso());
		}
	}


	IEnumerator Expediente(){
		Debug.Log ("H= " + Historial + " " + Exploracion + " " + idCaso);
		WWW conexion = new WWW ("www.arevolution.com.mx/synaptix/registroExpediente.php?historial=" + Historial+"&exploracion="+Exploracion+"&idCaso="+idCaso.text);
		//localhost/synaptix/registroExpediente.php?historial=xxx&exploracion=medicinainterna&idCaso=1
		yield return(conexion);
		Debug.Log (conexion.text);
		if (conexion.text == "expediente registrado") {
			PanelExpediente.SetActive (false);
			PanelExploracion.SetActive (true);
			StartCoroutine (ConsultaCaso());
		}
	}

	IEnumerator Exploraciones(){
		Debug.Log ("H= " + Cabeza + " " + Sistema + " " + idCaso.text);
		WWW conexion = new WWW ("www.arevolution.com.mx/synaptix/registroExploraciones.php?cabeza=" + Cabeza+"&sistema="+Sistema+"&corazon="+Corazon+"&pecho="+Pecho+"&abdomen="+Abdomen+"&extremidades="+Extremidades+"&piel="+Piel+"&idCaso="+idCaso.text);
		//localhost/synaptix/registroExploraciones.php?cabeza=xxx&sistema=dsadsadsadsaa&corazon=xxxxx&pecho=xxxx&abdomen=xxxx&extremidades=xxxx&piel=xxxx&idCaso=1
		yield return(conexion);
		Debug.Log (conexion.text);
		if (conexion.text == "exploracion registrada") {
			PanelExpediente.SetActive (false);
			PanelExploracion.SetActive (false);
			PanelPreguntas.SetActive (true);
			StartCoroutine (ConsultaCaso());
		}
	}

	IEnumerator Preguntas(){
		Debug.Log ("Pregunta " + Pregunta + " " + idCaso);
		WWW conexion = new WWW ("www.arevolution.com.mx/synaptix/registroPreguntas.php?pregunta=" + Pregunta+"&idCaso="+idCaso.text);
		//localhost/synaptix/registroPreguntas.php?&pregunta=xxxx&idCaso=1
		yield return(conexion);
		Debug.Log (conexion.text);
		if (conexion.text == "pregunta registrada") {
			PanelExpediente.SetActive (false);
			PanelExploracion.SetActive (false);
			PanelPreguntas.SetActive (false);
			PanelRespuestas.SetActive (true);
			StartCoroutine (ConsultaCaso());
			StartCoroutine (ConsultaPregunta());
		}
	}

	IEnumerator Respuestas(){
		WWW conexion = new WWW ("www.arevolution.com.mx/synaptix/registroRespuestas.php?respuestaA=" + RespuestaA+"&valorA="+ValorA+"&retroA="+RetroA+"&respuestaB="+RespuestaB+"&valorB="+ValorB+"&retroB="+retroB+"&respuestaC="+RespuestaC+"&valorC="+ValorC+"&retroC="+RetroC+"&respuestaD="+RespuestaD+"&valorD="+ValorD+"&retroD="+RetroD+"&idPreg="+IdPregunta.text);
		//localhost/synaptix/registroPreguntas.php?&pregunta=xxxx&idCaso=1
		yield return(conexion);
		Debug.Log (conexion.text);
		if (conexion.text == "respuesta registrada") {
			PanelExpediente.SetActive (false);
			PanelExploracion.SetActive (false);
			PanelRespuestas.SetActive (false);
			PanelPreguntas.SetActive (true);
			StartCoroutine (ConsultaCaso());
			//StartCoroutine (ConsultaPregunta());
		}
	}

	IEnumerator ConsultaCaso(){
		WWW conexion = new WWW ("www.arevolution.com.mx/synaptix/buscaCaso.php");
		//localhost/synaptix/buscaCaso.php
		yield return(conexion);
		idCaso.text = conexion.text;

	}

	IEnumerator ConsultaPregunta(){
		WWW conexion = new WWW ("www.arevolution.com.mx/synaptix/buscaPregunta.php");
		//localhost/synaptix/buscaCaso.php
		yield return(conexion);
		IdPregunta.text = conexion.text;

	}

	void Update () {
		Caso = caso.GetComponent<InputField>().text;
		int menuIndex=categoria.GetComponent<Dropdown>().value;
		List<Dropdown.OptionData> menuOptions = categoria.GetComponent<Dropdown> ().options;
		Categoria = menuOptions [menuIndex].text;
		Debug.Log ("Categoria es: " + Categoria);
		Autor = autor.GetComponent<InputField>().text;
		StartCoroutine (ConsultaCaso());
		Historial=historial.GetComponent<InputField>().text;
		Exploracion=exploracion.GetComponent<InputField>().text;
		Cabeza=cabeza.GetComponent<InputField>().text;
		Sistema=sistema.GetComponent<InputField>().text;
		Corazon=corazon.GetComponent<InputField>().text;
		Pecho=pecho.GetComponent<InputField>().text;
		Abdomen=abdomen.GetComponent<InputField>().text;
		Extremidades=extremidades.GetComponent<InputField>().text;
		Piel=piel.GetComponent<InputField>().text;
		Pregunta=pregunta.GetComponent<InputField>().text;
		StartCoroutine (ConsultaPregunta());
		RespuestaA=respuestaA.GetComponent<InputField>().text;
		ValorA=valorA.GetComponent<InputField>().text;
		RetroA=retroA.GetComponent<InputField>().text;

		RespuestaB=respuestaB.GetComponent<InputField>().text;
		ValorB=valorB.GetComponent<InputField>().text;
		RetroB=retroB.GetComponent<InputField>().text;

		RespuestaC=respuestaC.GetComponent<InputField>().text;
		ValorC=valorC.GetComponent<InputField>().text;
		RetroC=retroC.GetComponent<InputField>().text;

		RespuestaD=respuestaD.GetComponent<InputField>().text;
		ValorD=valorD.GetComponent<InputField>().text;
		RetroD=retroD.GetComponent<InputField>().text;
	}

}
