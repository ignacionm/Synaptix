using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.SceneManagement;

public class Cardiopatia : MonoBehaviour {

	private Transform myObjeto;
	public GameObject Texto;
	public string Escribir;
	public float distancia = 10;

	public GameObject Panel;
	public GameObject Estudios;
	public GameObject PanelPreg2;
	public GameObject Ecocardiograma;
	public GameObject PanelPreg3;
	public GameObject PanelPreg4;
	public GameObject Resumen;

	public GameObject PanelRetro;
	public GameObject ButtonCont;
	public GameObject ButtonCont2;
	public GameObject ButtonCont3;
	public GameObject ButtonCont4;
	public GameObject ButtonCont5;
	public GameObject ButtonCont6;

	public GameObject Puntuacion;
	public GameObject PuntuacionResumen;

	public GameObject ButtonSend1;
	public GameObject ButtonSend2;
	public GameObject ButtonSend3;
	public GameObject ButtonSend4;

	public Toggle ResP1A;
	public Toggle ResP1B;
	public Toggle ResP1C;
	public Toggle ResP1D;

	public Toggle ResP2A;
	public Toggle ResP2B;
	public Toggle ResP2C;
	public Toggle ResP2D;

	public Toggle ResP3A;
	public Toggle ResP3B;
	public Toggle ResP3C;

	public Toggle ResP4A;
	public Toggle ResP4B;
	public Toggle ResP4C;

	


	public int puntos = 0;
	public Text usuario;
	private String[] Lines;
	private string form;

	// Use this for initialization
	void Start () {
		Texto.GetComponent<Text>().text = Escribir.ToString();
		myObjeto = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ClickComenzar()
	{
		Texto.GetComponent<Text>().text = Escribir.ToString();
		myObjeto = GetComponent<Transform>();
		Texto.GetComponent<Text>().text = "Seleccionar la respuesta".ToString();
		Panel.gameObject.SetActive(true);
	}


	public void ActivarEstudios()
	{
		Panel.gameObject.SetActive(false);
		Estudios.gameObject.SetActive(true);
		PanelRetro.gameObject.SetActive(false);
		Texto.GetComponent<Text>().text = "";
	}

	public void ActivarPreguntas2()
	{
		Estudios.gameObject.SetActive(false);
		PanelPreg2.gameObject.SetActive(true);
		PanelRetro.gameObject.SetActive(false);
		Texto.GetComponent<Text>().text = "";
	}

	public void ActivarEco()
	{
		PanelPreg2.gameObject.SetActive(false);
		Ecocardiograma.gameObject.SetActive(true);
		PanelRetro.gameObject.SetActive(false);
		Texto.GetComponent<Text>().text = "";
	}

	public void ActivarPreguntas3()
	{
		Ecocardiograma.gameObject.SetActive(false);
		PanelPreg3.gameObject.SetActive(true);
		PanelRetro.gameObject.SetActive(false);
		Texto.GetComponent<Text>().text = "";
	}

	public void ActivarPreguntas4()
	{
		PanelPreg3.gameObject.SetActive(false);
		PanelPreg4.gameObject.SetActive(true);
		PanelRetro.gameObject.SetActive(false);
		Texto.GetComponent<Text>().text = "";
	}

	public void ActivarResumen()
	{
		PanelPreg4.gameObject.SetActive(false);
		Resumen.gameObject.SetActive(true);
		PanelRetro.gameObject.SetActive(false);
		Texto.GetComponent<Text>().text = "";
	}

	public void GuardarScorePHP()
	{
		StartCoroutine(Guardar());
	}

	public void ProgresoInsigniasPHP()
	{
		StartCoroutine(insignias());
	}

	

	public IEnumerator Guardar()
	{
		//Debug.Log(Username);
		WWW conexion = new WWW("www.arevolution.com.mx/synaptix/actualizarScore.php?uss=" + usuario.text + "&sc=" + puntos);
		yield return (conexion);
		//Debug.Log(conexion.text);
		if (conexion.text.Equals("actualizo"))
		{
			Debug.Log("Actualizo Score");
		}
	}


	public IEnumerator insignias()
	{
		//Debug.Log(Username);
		WWW conexion = new WWW("www.arevolution.com.mx/synaptix/actualizarInsignias.php?uss=" + usuario.text + "&sc=" + puntos);
		yield return (conexion);
		//Debug.Log(conexion.text);
		if (conexion.text.Equals("actualizo"))
		{
			Debug.Log("Actualizo Insignias");
		}
	}

	public void ActiveToggle()
	{
		ButtonSend1.gameObject.SetActive(false);
		if (ResP1A.isOn || ResP1B.isOn || ResP1C.isOn || ResP1D.isOn)
		{
			PanelRetro.gameObject.SetActive(true);
			if (ResP1C.isOn)
			{
				puntos += 20;
				Puntuacion.GetComponent<Text>().text = puntos.ToString();
				Texto.GetComponent<Text>().text = "Correcto:  Ya que según la Guía de Practica Clínica debe realizarse en paciente de sospecha de valvulopatía para evaluar la severidad hemodinámica de la enfermedad. " +
					"El Ecocardiograma Transesofagico se debe considerar solo en los casos en los que el Electrocardiagrama Transtorácico aporte información subóptima o que se sospeche de una trombosis o endocarditis infecciosa. " +
					"El electrocardigrama y la Radiografia de Torax se deben utilizar como parte de la evaluación clínica de pacientes con sospecha de valvulopatía para evaluar crecimiento de cavidades cardiacas calcificación anular o valvular, sin embargo no son los estudios de elección para la patología. ".ToString();
				Debug.Log("Seleccionó la respuesta C");
			}
			else
			{
				puntos += 0;
				Texto.GetComponent<Text>().text = "Incorrecto: Ya que según la Guía de Practica Clínica debe realizarse en paciente de sospecha de valvulopatía para evaluar la severidad hemodinámica de la enfermedad. " +
					"El Ecocardiograma Transesofagico se debe considerar solo en los casos en los que el Electrocardiagrama Transtorácico aporte información subóptima o que se sospeche de una trombosis o endocarditis infecciosa. " +
					"El electrocardigrama y la Radiografia de Torax se deben utilizar como parte de la evaluación clínica de pacientes con sospecha de valvulopatía para evaluar crecimiento de cavidades cardiacas calcificación anular o valvular, sin embargo no son los estudios de elección para la patología. ".ToString();
				Debug.Log("Seleccionó la respuesta C");
			}

			ResP1A.enabled = false;
			ResP1B.enabled = false;
			ResP1C.enabled = false;
			ResP1D.enabled = false;
			ButtonCont.gameObject.SetActive(true);
		}else {
			ButtonSend1.gameObject.SetActive(true);
		}
	}

	public void ActiveToggle2()
	{
		ButtonSend2.gameObject.SetActive(false);
		if (ResP2A.isOn || ResP2B.isOn || ResP2C.isOn || ResP2D.isOn)
		{
			PanelRetro.gameObject.SetActive(true);
			if (ResP2D.isOn)
			{
				puntos += 20;
				Puntuacion.GetComponent<Text>().text = puntos.ToString();
				Texto.GetComponent<Text>().text = "Correcto: Se trata de un electrocardiograma con ausencia de onda P e intervalo R-R irregular compatible con fibrilación auricular.".ToString();
				Debug.Log("Seleccionó la respuesta D");
			}
			else
			{
				puntos += 0;
				Texto.GetComponent<Text>().text = "Incorrecto: Se trata de un electrocardiograma con ausencia de onda P e intervalo R-R irregular compatible con fibrilación auricular.".ToString();
				Debug.Log("Seleccionó Otra");
			}

			ResP2A.enabled = false;
			ResP2B.enabled = false;
			ResP2C.enabled = false;
			ResP2D.enabled = false;
			ButtonCont3.gameObject.SetActive(true);
		}else
		{
			ButtonSend2.gameObject.SetActive(true);
		}
	}

	public void ActiveToggle3()
	{
		ButtonSend3.gameObject.SetActive(false);
		if (ResP3A.isOn || ResP3B.isOn || ResP3C.isOn)
		{
			PanelRetro.gameObject.SetActive(true);
			if (ResP3C.isOn)
			{
				puntos += 20;
				Puntuacion.GetComponent<Text>().text = puntos.ToString();
				Texto.GetComponent<Text>().text = "Correcto: De 2 a 2,5cm se considera estenosis mitral moderada y menos de 1 cm severa.".ToString();
				Debug.Log("Seleccionó la respuesta C");
			}
			else
			{
				puntos += 0;
				Texto.GetComponent<Text>().text = "Incorrecto: De 2 a 2,5cm se considera estenosis mitral moderada y menos de 1 cm severa.".ToString();
				Debug.Log("Seleccionó Otra");
			}

			ResP3A.enabled = false;
			ResP3B.enabled = false;
			ResP3C.enabled = false;
			ButtonCont5.gameObject.SetActive(true);
		}else
		{
			ButtonSend3.gameObject.SetActive(true);
		}
	}

	public void ActiveToggle4()
	{
		ButtonSend4.gameObject.SetActive(false);
		if (ResP4A.isOn || ResP4B.isOn || ResP4C.isOn)
		{
			PanelRetro.gameObject.SetActive(true);
			if (ResP4B.isOn)
			{
				puntos += 40;
				Puntuacion.GetComponent<Text>().text = puntos.ToString();

				Texto.GetComponent<Text>().text = "Correcto: La hipertensión pulmonar se define como una presión arterial pulmonar mayor de 25 mmhg en reposo o de 30 mmHg durante el ejercicio.  " +
					"La paciente de este caso tiene una presión arterial pulmonar de 86 mmHg por lo tanto cursa con hipertensión pulmonar severa.".ToString();
				Debug.Log("Seleccionó la respuesta B");
			}
			else
			{
				puntos += 0;
				Texto.GetComponent<Text>().text = "Incorrecto: La hipertensión pulmonar se define como una presión arterial pulmonar mayor de 25 mmhg en reposo o de 30 mmHg durante el ejercicio.  " +
					"La paciente de este caso tiene una presión arterial pulmonar de 86 mmHg por lo tanto cursa con hipertensión pulmonar severa.".ToString();
				Debug.Log("Seleccionó Otra");
			}
			PuntuacionResumen.GetComponent<Text>().text = puntos.ToString();
			ResP4A.enabled = false;
			ResP4B.enabled = false;
			ResP4C.enabled = false;
			ButtonCont6.gameObject.SetActive(true);
			GuardarScorePHP();
			ProgresoInsigniasPHP();
		}
		else
		{
			ButtonSend4.gameObject.SetActive(true);
		}
	}




}
