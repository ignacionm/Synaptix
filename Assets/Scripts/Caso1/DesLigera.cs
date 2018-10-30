using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.SceneManagement;

public class DesLigera : MonoBehaviour
{
	private Transform myObjeto;
	public GameObject Texto;
	public string Escribir;
	public float distancia = 10;

	public GameObject Panel;
	public GameObject PanelPreg2;
	public GameObject PanelPreg3;
	public GameObject Resumen;

	public GameObject PanelRetro;
	public GameObject ButtonCont;
	public GameObject ButtonCont2;
	public GameObject ButtonCont3;
	public GameObject Puntuacion;
	public GameObject PuntuacionResumen;

	public GameObject ButtonSend1;
	public GameObject ButtonSend2;
	public GameObject ButtonSend3;

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
	public Toggle ResP3D;

	public int puntos = 0;
	public Text usuario;
	private String[] Lines;
	private string form;



	void OnMouseDrag()
	{

	}

	// Use this for initialization
	void Start()
	{
		Texto.GetComponent<Text>().text = Escribir.ToString();
		myObjeto = GetComponent<Transform>();

	}

	// Update is called once per frame
	void Update()
	{


	}


	public void ClickComenzar()
	{
		Texto.GetComponent<Text>().text = Escribir.ToString();
		myObjeto = GetComponent<Transform>();
		Texto.GetComponent<Text>().text = "Seleccionar la respuesta".ToString();
		Panel.gameObject.SetActive(true);
	}

	public void ActiveToggle()
	{
		ButtonSend1.gameObject.SetActive(false);
		if (ResP1A.isOn || ResP1B.isOn || ResP1C.isOn || ResP1D.isOn)
		{
			PanelRetro.gameObject.SetActive(true);
			if (ResP1A.isOn)
			{
				puntos += 30;
				Puntuacion.GetComponent<Text>().text = puntos.ToString();
				Texto.GetComponent<Text>().text = "Correcto: El cuadro clínico del paciente es congruente con una deshidratación leve y tolera la vía oral " +
					"\nRehidratación oral, ciprofloxacino, loperamida (antibiótico no está indicado en este momento)" +
	                "\nRehidratación IV(intravenosa), loperamida y trimetroprim - sulfametoxazol(Rehidratación intravenosa no encaja)" +
					 "\nRehidratación IV, modificaciones dietéticas, loperamida(Rehidratación intravenosa no encaja)".ToString();
				Debug.Log("Seleccionó la respuesta A");
			}
			else 
			{
				puntos += 0;
				Texto.GetComponent<Text>().text = "Incorrecto: El cuadro clínico del paciente es congruente con una deshidratación leve y tolera la vía oral por lo que la respuesta correcta es: Rehidratación oral, modificaciones dietéticas, loperamida . "+
					"\nRehidratación oral, ciprofloxacino, loperamida (antibiótico no está indicado en este momento)" +
                    "\nRehidratación IV(intravenosa), loperamida y trimetroprim - sulfametoxazol(Rehidratación intravenosa no encaja)" +
					"\nRehidratación IV, modificaciones dietéticas, loperamida(Rehidratación intravenosa no encaja) ".ToString(); 
				Debug.Log("Seleccionó la respuesta B");
			}
			
			ResP1A.enabled = false;
			ResP1B.enabled = false;
			ResP1C.enabled = false;
			ResP1D.enabled = false;
			ButtonCont.gameObject.SetActive(true);
		}
		else {
			ButtonSend1.gameObject.SetActive(true);
		}
	}

	public void ActivarPreguntas2()
	{
		Panel.gameObject.SetActive(false);
		PanelPreg2.gameObject.SetActive(true);
		PanelRetro.gameObject.SetActive(false);
		Texto.GetComponent<Text>().text = "";
	}

	public void ActivarPreguntas3()
	{
		PanelPreg2.gameObject.SetActive(false);
		PanelPreg3.gameObject.SetActive(true);
		PanelRetro.gameObject.SetActive(false);
		Texto.GetComponent<Text>().text = "";
	}

	public void ActivarResumen()
	{
		PanelPreg3.gameObject.SetActive(false);
		Resumen.gameObject.SetActive(true);
		PanelRetro.gameObject.SetActive(false);
		Texto.GetComponent<Text>().text = "";
	}

	public void ActiveToggle2()
	{
		ButtonSend2.gameObject.SetActive(false);
		if (ResP2A.isOn || ResP2B.isOn || ResP2C.isOn || ResP2D.isOn)
		{
			PanelRetro.gameObject.SetActive(true);
			if (ResP2C.isOn)
			{
				puntos += 30;
				Puntuacion.GetComponent<Text>().text = puntos.ToString();
				Texto.GetComponent<Text>().text = "Correcto: Ya que según la Guía de Practica Clínica indica que el tiempo esperado es de 24 a 48hr".ToString();
				Debug.Log("Seleccionó la respuesta C");
			}else 
			{
				puntos += 0;
				Texto.GetComponent<Text>().text = " Incorrecto: Ya que según la Guía de Practica Clínica indica que el tiempo esperado es de 24 a 48hr".ToString();
				Debug.Log("Seleccionó la respuesta D");
			}
			ResP2A.enabled = false;
			ResP2B.enabled = false;
			ResP2C.enabled = false;
			ResP2D.enabled = false;
			ButtonCont2.gameObject.SetActive(true);
		}else
		{
			ButtonSend2.gameObject.SetActive(true);
		}
	}

	public void ActiveToggle3()
	{
		ButtonSend3.gameObject.SetActive(false);
		if (ResP3A.isOn || ResP3B.isOn || ResP3C.isOn || ResP3D.isOn)
		{
			PanelRetro.gameObject.SetActive(true);
			if (ResP3B.isOn)
			{
				puntos += 40;
				Puntuacion.GetComponent<Text>().text = puntos.ToString();
				Texto.GetComponent<Text>().text = "Correcto:  Rehidratación es importante que continúe para asegurar recuperación." +
					"\nComo hubo resolución  continuar con loperamida puede causar estreñimiento." +
					"·\nComo hubo resolución puede regresar a su dieta normal.".ToString();
				Debug.Log("Seleccionó la respuesta B");
			}else 
			{
				puntos += 0;
				Texto.GetComponent<Text>().text = "Incorrecto:  Rehidratación es importante que continúe para asegurar recuperación." +
					"\nComo hubo resolución  continuar con loperamida puede causar estreñimiento." +
					"·\nComo hubo resolución puede regresar a su dieta normal.".ToString();
				Debug.Log("Seleccionó la respuesta D");
			}
			PuntuacionResumen.GetComponent<Text>().text = puntos.ToString();
			ResP3A.enabled = false;
			ResP3B.enabled = false;
			ResP3C.enabled = false;
			ResP3D.enabled = false;
			ButtonCont3.gameObject.SetActive(true);
			GuardarScorePHP();
			ProgresoInsigniasPHP();
		}
		else {
			ButtonSend3.gameObject.SetActive(true);
		}
	}

	public void GuardarScore()
	{
		Debug.Log("El usuario es " + usuario.text);
		if (System.IO.File.Exists(@"C:/UnityTestFolder/" + usuario.text + ".txt"))
		{
			Lines = System.IO.File.ReadAllLines(@"C:/UnityTestFolder/" + usuario.text + ".txt");
			Debug.Log("Usuario encontrado" + Lines[3].ToString());
			form = (Lines[0].ToString() + Environment.NewLine + Lines[1].ToString() + Environment.NewLine + Lines[2].ToString() + Environment.NewLine + puntos + Environment.NewLine + Lines[4].ToString() + Environment.NewLine + Lines[5].ToString() + Environment.NewLine + Lines[6].ToString() + Environment.NewLine + Lines[7].ToString());
			System.IO.File.WriteAllText(@"C:/UnityTestFolder/" + usuario.text + ".txt", form);

		}
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
		WWW conexion = new WWW("www.arevolution.com.mx/actualizarInsignias.php?uss=" + usuario.text + "&sc=" + puntos);
		yield return (conexion);
		//Debug.Log(conexion.text);
		if (conexion.text.Equals("actualizo"))
		{
			Debug.Log("Actualizo Insignias");
		}
	}




	public void CargarNivel(string NombreNivel)
	{
		SceneManager.LoadScene(NombreNivel);
	}

}
