using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.SceneManagement;

public class DesSevera : MonoBehaviour {
	private Transform myObjeto;
	public GameObject Texto;
	public string Escribir;
	public float distancia = 10;

	public GameObject Panel;
	public GameObject PanelPreg2;
	public GameObject PanelPreg3;
	public GameObject PanelPreg4;
	public GameObject Resumen;

	public GameObject PanelRetro;
	public GameObject ButtonCont;
	public GameObject ButtonCont2;
	public GameObject ButtonCont3;
	public GameObject ButtonCont4;
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
	public Toggle ResP3D;

	public Toggle ResP4A;
	public Toggle ResP4B;
	public Toggle ResP4C;
	public Toggle ResP4D;

	public int puntos = 0;
	public Text usuario;
	private String[] Lines;
	private string form;

	// Use this for initialization
	void Start () {
		
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

	public void ActiveToggle()
	{
		ButtonSend1.gameObject.SetActive(false);
		if (ResP1A.isOn || ResP1B.isOn || ResP1C.isOn || ResP1D.isOn)
		{
			PanelRetro.gameObject.SetActive(true);
			if (ResP1A.isOn)
			{
				puntos += 25;
				Puntuacion.GetComponent<Text>().text = puntos.ToString();
				Texto.GetComponent<Text>().text = "Correcto: La Guía de Práctica Clínica nos plantea que los 2 datos clínicos para determinar si un cuadro diarreico es considerado como grave, que son: Fiebre > 38 °C, > 10 evacuaciones en 8 horas.\r\n " +
					"- El dolor abdominal suele acompañar cuadros de diarrea, sin embargo no es indicador de gravedad, recordemos por ejemplo, que la diarrea por Cólera suele cursar asintomática o con dolor leve y sin embargo causar deshidratación severa, incluso mortal en cuestión de horas.\r\n" +
					"- El vómito en proyectil es un dato asociado de hipertensión intracraneal. Los vómitos desproporcionados en el caso de una gastroenteritis son sugestivos de un agente con neurotoxinas, como Escherichia coli -Enterotóxica.".ToString();
				Debug.Log("Seleccionó la respuesta A");
			}else 
			{
				puntos += 0;
				Texto.GetComponent<Text>().text = "Incorrecto: La Guía de Práctica Clínica nos plantea que los 2 datos clínicos para determinar si un cuadro diarreico es considerado como grave, que son: Fiebre > 38 °C, > 10 evacuaciones en 8 horas.\r\n " +
					"- El dolor abdominal suele acompañar cuadros de diarrea, sin embargo no es indicador de gravedad, recordemos por ejemplo, que la diarrea por Cólera suele cursar asintomática o con dolor leve y sin embargo causar deshidratación severa, incluso mortal en cuestión de horas.\r\n" +
					"- El vómito en proyectil es un dato asociado de hipertensión intracraneal. Los vómitos desproporcionados en el caso de una gastroenteritis son sugestivos de un agente con neurotoxinas, como Escherichia coli -Enterotóxica.".ToString();
				Debug.Log("Seleccionó la respuesta B");
			}
			
			
			ResP1A.enabled = false;
			ResP1B.enabled = false;
			ResP1C.enabled = false;
			ResP1D.enabled = false;
			ButtonCont.gameObject.SetActive(true);
		}else
		{
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

	public void ActiveToggle2()
	{
		ButtonSend2.gameObject.SetActive(false);
		if (ResP2A.isOn || ResP2B.isOn || ResP2C.isOn || ResP2D.isOn)
		{
			PanelRetro.gameObject.SetActive(true);
			if (ResP2A.isOn)
			{
				puntos += 25;
				Puntuacion.GetComponent<Text>().text = puntos.ToString();
				Texto.GetComponent<Text>().text = "Correcto: Aunque los otros datos suelen presentarse comúnmente en la diarrea inflamatoria, son inespecíficos, ya que suelen presentarse en diarreas con otros mecanismos. La presencia de moco y sangre en las evacuaciones es el dato más sugestivo de esta patología,  generalmente resultado de , por lo que también nos indica que es presumiblemente de origen infeccioso".ToString();

				Debug.Log("Seleccionó la respuesta A");
			}
			else if (ResP2B.isOn)
			{
				puntos += 0;
				Texto.GetComponent<Text>().text = "Incorrecto: Aunque los otros datos suelen presentarse comúnmente en la diarrea inflamatoria, son inespecíficos, ya que suelen presentarse en diarreas con otros mecanismos. La presencia de moco y sangre en las evacuaciones es el dato más sugestivo de esta patología,  generalmente resultado de , por lo que también nos indica que es presumiblemente de origen infeccioso".ToString();
				Debug.Log("Seleccionó la respuesta B");
			}
			else if (ResP2C.isOn)
			{
				puntos += 0;
				Puntuacion.GetComponent<Text>().text = puntos.ToString();
				Texto.GetComponent<Text>().text = "Incorrecto: Aunque los otros datos suelen presentarse comúnmente en la diarrea inflamatoria, son inespecíficos, ya que suelen presentarse en diarreas con otros mecanismos. La presencia de moco y sangre en las evacuaciones es el dato más sugestivo de esta patología,  generalmente resultado de , por lo que también nos indica que es presumiblemente de origen infeccioso".ToString();
				Debug.Log("Seleccionó la respuesta C");
			}
			else if (ResP2D.isOn)
			{
				puntos += 0;
				Texto.GetComponent<Text>().text = "Incorrecto: Aunque los otros datos suelen presentarse comúnmente en la diarrea inflamatoria, son inespecíficos, ya que suelen presentarse en diarreas con otros mecanismos. La presencia de moco y sangre en las evacuaciones es el dato más sugestivo de esta patología,  generalmente resultado de , por lo que también nos indica que es presumiblemente de origen infeccioso".ToString();
				Debug.Log("Seleccionó la respuesta D");
			}
			ResP2A.enabled = false;
			ResP2B.enabled = false;
			ResP2C.enabled = false;
			ResP2D.enabled = false;
			ButtonCont2.gameObject.SetActive(true);
		}
		else
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
			if (ResP3A.isOn)
			{
				puntos += 25;
				Puntuacion.GetComponent<Text>().text = puntos.ToString();
				Texto.GetComponent<Text>().text = "Correcto: El tratamiento de primera elección para Shigella es Ciprofloxacino, sin embargo, el paciente tiene historial de alergia a las fluoroquinolonas, por lo que en este caso, debe emplearse el tratamiento de segunda línea, que es Trimetroprim/Sulfametoxazol.".ToString();

				Debug.Log("Seleccionó la respuesta A");
			}
			else if (ResP3B.isOn)
			{
				puntos += 0;
				Texto.GetComponent<Text>().text = "Incorrecto: El tratamiento de primera elección para Shigella es Ciprofloxacino, sin embargo, el paciente tiene historial de alergia a las fluoroquinolonas, por lo que en este caso, debe emplearse el tratamiento de segunda línea, que es Trimetroprim/Sulfametoxazol.".ToString();
				Debug.Log("Seleccionó la respuesta B");
			}
			else if (ResP3C.isOn)
			{
				puntos += 0;
				Texto.GetComponent<Text>().text = "Incorrecto: El tratamiento de primera elección para Shigella es Ciprofloxacino, sin embargo, el paciente tiene historial de alergia a las fluoroquinolonas, por lo que en este caso, debe emplearse el tratamiento de segunda línea, que es Trimetroprim/Sulfametoxazol.".ToString();
				Debug.Log("Seleccionó la respuesta C");
			}
			else if (ResP3D.isOn)
			{
				puntos += 0;
				Texto.GetComponent<Text>().text = "Incorrecto: El tratamiento de primera elección para Shigella es Ciprofloxacino, sin embargo, el paciente tiene historial de alergia a las fluoroquinolonas, por lo que en este caso, debe emplearse el tratamiento de segunda línea, que es Trimetroprim/Sulfametoxazol.".ToString();
				Debug.Log("Seleccionó la respuesta D");
			}
			ResP3A.enabled = false;
			ResP3B.enabled = false;
			ResP3C.enabled = false;
			ResP3D.enabled = false;
			ButtonCont3.gameObject.SetActive(true);
		}
		else
		{
			ButtonSend3.gameObject.SetActive(true);
		}
	}

	public void ActiveToggle4()
	{
		ButtonSend4.gameObject.SetActive(false);
		if (ResP4A.isOn || ResP4B.isOn || ResP4C.isOn || ResP4D.isOn)
		{
			PanelRetro.gameObject.SetActive(true);
			if (ResP4A.isOn)
			{
				puntos += 25;
				Puntuacion.GetComponent<Text>().text = puntos.ToString();
				//Texto.GetComponent<Text>().text = "Correcto: El tratamiento de primera elección para Shigella es Ciprofloxacino, sin embargo, el paciente tiene historial de alergia a las fluoroquinolonas, por lo que en este caso, debe emplearse el tratamiento de segunda línea, que es Trimetroprim/Sulfametoxazol.".ToString();

				Debug.Log("Seleccionó la respuesta A");
			}
			else if (ResP4B.isOn)
			{
				puntos += 0;
				Puntuacion.GetComponent<Text>().text = puntos.ToString();
				//Texto.GetComponent<Text>().text = "Incorrecto: El tratamiento de primera elección para Shigella es Ciprofloxacino, sin embargo, el paciente tiene historial de alergia a las fluoroquinolonas, por lo que en este caso, debe emplearse el tratamiento de segunda línea, que es Trimetroprim/Sulfametoxazol.".ToString();
				Debug.Log("Seleccionó la respuesta B");
			}
			else if (ResP4C.isOn)
			{
				puntos += 0;
				//Texto.GetComponent<Text>().text = "Incorrecto: El tratamiento de primera elección para Shigella es Ciprofloxacino, sin embargo, el paciente tiene historial de alergia a las fluoroquinolonas, por lo que en este caso, debe emplearse el tratamiento de segunda línea, que es Trimetroprim/Sulfametoxazol.".ToString();
				Debug.Log("Seleccionó la respuesta C");
			}
			else if (ResP4D.isOn)
			{
				puntos += 0;
				//Texto.GetComponent<Text>().text = "Incorrecto: El tratamiento de primera elección para Shigella es Ciprofloxacino, sin embargo, el paciente tiene historial de alergia a las fluoroquinolonas, por lo que en este caso, debe emplearse el tratamiento de segunda línea, que es Trimetroprim/Sulfametoxazol.".ToString();
				Debug.Log("Seleccionó la respuesta D");
			}
			PuntuacionResumen.GetComponent<Text>().text = puntos.ToString();
			ResP4A.enabled = false;
			ResP4B.enabled = false;
			ResP4C.enabled = false;
			ResP4D.enabled = false;
			ButtonCont4.gameObject.SetActive(true);
			GuardarScorePHP();
			ProgresoInsigniasPHP();
		}
		else
		{
			ButtonSend4.gameObject.SetActive(true);
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
		WWW conexion = new WWW("www.arevolution.com.mx/synaptix/actualizarInsignias.php?uss=" + usuario.text + "&sc=" + puntos);
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
