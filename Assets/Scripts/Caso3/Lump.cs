using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.SceneManagement;

public class Lump : MonoBehaviour {
	private Transform myObjeto;
	public GameObject Texto;
	public string Escribir;
	public float distancia = 10;

	public GameObject Panel;
	public GameObject Estudios; 
	public GameObject PanelPreg2;
	public GameObject Biopsia;
	public GameObject EstudioDiag; 
	public GameObject EstudioLaboratorioad; 
	public GameObject PanelPreg3;
	public GameObject Diagnostico;
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

	public Toggle ResP1A;
	public Toggle ResP1B;
	public Toggle ResP1C;
	public Toggle ResP1D;
	public Toggle ResP1E;
	public Toggle ResP1F;

	public Toggle ResP2A;
	public Toggle ResP2B;
	public Toggle ResP2C;
	public Toggle ResP2D;

	public Toggle ResP3A;
	public Toggle ResP3B;
	public Toggle ResP3C;
	public Toggle ResP3D;
	public Toggle ResP3E;

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


	public void ActivarPreguntas2()
	{
		Panel.gameObject.SetActive(false);
		PanelPreg2.gameObject.SetActive(true);
		PanelRetro.gameObject.SetActive(false);
		Texto.GetComponent<Text>().text = "";
	}

	public void ActivarEstudios()
	{
		PanelPreg2.gameObject.SetActive(false);
		Estudios.gameObject.SetActive(true);
		PanelRetro.gameObject.SetActive(false);
		Texto.GetComponent<Text>().text = "";
	}


	public void ActivarPreguntas3()
	{
		Estudios.gameObject.SetActive(false);
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

	public void ActiveToggle()
	{
		ButtonSend1.gameObject.SetActive(false);

		if (ResP1A.isOn || ResP1B.isOn || ResP1C.isOn || ResP1D.isOn)
		{
			PanelRetro.gameObject.SetActive(true);
			if (ResP1C.isOn )
			{
				puntos += 30;
				Puntuacion.GetComponent<Text>().text = puntos.ToString();
				Texto.GetComponent<Text>().text = "Correcto: Radiografías PA y Lateral de tórax (Corresponde al estudio de elección como primer paso en el abordaje de patología pulmonar)" +
					"\n\nTomografía axial pulmonar contrastada(No se indica como primer paso en el abordaje)" +
					"\n\nUltrasonido pulmonar izquierdo(No se indica como primer paso en el abordaje, y en todo caso, debería ser comparativo)" +
					"\n\nCultivo de expectoración(se deberá realizar en algún momento, pero no es el primer paso para la evaluación de este paciente).".ToString();
				Debug.Log("Seleccionó la respuesta C");
			}
			else
			{
				puntos += 0;
				Texto.GetComponent<Text>().text = "Incorrecto: la respuesta correcta es Radiografías PA y Lateral de tórax que corresponde al estudio de elección como primer paso en el abordaje de patología pulmonar" +
					"\n\nTomografía axial pulmonar contrastada(No se indica como primer paso en el abordaje)" +
					"\n\nUltrasonido pulmonar izquierdo(No se indica como primer paso en el abordaje, y en todo caso, debería ser comparativo)" +
					"\n\nCultivo de expectoración(se deberá realizar en algún momento, pero no es el primer paso para la evaluación de este paciente).".ToString();
				Debug.Log("Seleccionó Otra");
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

	public void ActiveToggle2()
	{
		ButtonSend2.gameObject.SetActive(false);
		if (ResP2A.isOn || ResP2B.isOn || ResP2C.isOn || ResP2D.isOn )
		{
			PanelRetro.gameObject.SetActive(true);
			if (ResP2D.isOn)
			{
				puntos += 30;
				Puntuacion.GetComponent<Text>().text = puntos.ToString();
				Texto.GetComponent<Text>().text = "Correcto: Neumonía bacteriana (De acuerdo con el tiempo de evolución  > 1 semana, tos    mucopurulenta, fiebre, disnea, estertores y datos de derrame, es el diagnóstico más probable)" +
					"\n\nTuberculosis pulmonar(No se mencionan factores de riesgo, ni datos clásicos como la fiebre y diaforesis nocturna, ni hemoptisis)" +
	                "\n\nCáncer pulmonar(Sin datos de riesgo, recuerda que el principal factor de riesgo es el antecedente de tabaquismo)" +
					"\n\nNeumonía viral(Suele tener una evolución más corta, sin expectoración mucopurulenta y sin picos febriles altos, como se presentan en este paciente)".ToString();
				Debug.Log("Seleccionó la respuesta D");
			}
			else
			{
				puntos += 0;
				Texto.GetComponent<Text>().text = "Incorrecto: La respuesta correcta es Neumonía bacteriana de acuerdo con el tiempo de evolución  > 1 semana, tos mucopurulenta, fiebre, disnea, estertores y datos de derrame, es el diagnóstico más probable" +
					"Tuberculosis pulmonar(No se mencionan factores de riesgo, ni datos clásicos como la fiebre y diaforesis nocturna, ni hemoptisis)" +
					"Cáncer pulmonar(Sin datos de riesgo, recuerda que el principal factor de riesgo es el antecedente de tabaquismo)" +
					"Neumonía viral(Suele tener una evolución más corta, sin expectoración mucopurulenta y sin picos febriles altos, como se presentan en este paciente)".ToString();
				Debug.Log("Seleccionó Otra");
			}

			ResP2A.enabled = false;
			ResP2B.enabled = false;
			ResP2C.enabled = false;
			ResP2D.enabled = false;
			ButtonCont2.gameObject.SetActive(true);
		}
		else {
			ButtonSend2.gameObject.SetActive(true);
		}	

	    
	}

	public void ActiveToggle3()
	{
		ButtonSend3.gameObject.SetActive(false);
		if (ResP3A.isOn || ResP3B.isOn || ResP3C.isOn || ResP3D.isOn )
		{
			PanelRetro.gameObject.SetActive(true);
			if (ResP3B.isOn)
			{
				puntos += 40;
				Texto.GetComponent<Text>().text = "Correcto: Empiema (Corresponde con la clínica de neumonía bacteriana, se menciona que ha tenido expectoración mucopurulenta, por lo que el hallazgo de un empiema, es decir pus, es lo más probable)" +
					"\n\nCáncer pulmonar de células claras(Sin factores de riesgo)" +
					"\n\nNeumotórax a tensión(No compatible, se observaría atrapamiento aéreo con desviación de línea media)" +
					"\n\nHemotórax(Sin antecedente traumático, no suele ser septado).".ToString();
				Debug.Log("Seleccionó la respuesta B");
			}
			else
			{
				puntos += 0;
				Texto.GetComponent<Text>().text = "Incorrecto: La respuesta correcta es Empiema que corresponde con la clínica de neumonía bacteriana, se menciona que ha tenido expectoración mucopurulenta, por lo que el hallazgo de un empiema, es decir pus, es lo más probable" +
					"\n\nCáncer pulmonar de células claras(Sin factores de riesgo)" +
					"\n\nNeumotórax a tensión(No compatible, se observaría atrapamiento aéreo con desviación de línea media)" +
					"\n\nHemotórax(Sin antecedente traumático, no suele ser septado).".ToString();
				Debug.Log("Seleccionó Otra");
			}
			PuntuacionResumen.GetComponent<Text>().text = puntos.ToString();
			ResP3A.enabled = false;
			ResP3B.enabled = false;
			ResP3C.enabled = false;
			ResP3D.enabled = false;
			ButtonCont4.gameObject.SetActive(true);
			GuardarScorePHP();
			ProgresoInsigniasPHP();
		}
		else {
			ButtonSend3.gameObject.SetActive(true);
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


}
