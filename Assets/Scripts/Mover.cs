using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.SceneManagement;

public class Mover : MonoBehaviour {
	private Transform myObjeto;
	public GameObject Texto;
	public string Escribir;
	public float distancia=10;

	public GameObject Panel;
	public GameObject PanelPreg2;
	public GameObject PanelPreg3;
	public GameObject PanelRetro;
	public GameObject ButtonCont;
	public GameObject ButtonCont2;
	public GameObject ButtonCont3;
	public GameObject Puntuacion;

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

	public int puntos=0;
	public Text usuario;
	private String[] Lines;
	private string form;



	void OnMouseDrag(){
		Vector3 mousePosition = new Vector3 (Input.mousePosition.x,Input.mousePosition.y,distancia);
		Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
		transform.position = objPosition;
	}
	// Use this for initialization
	void Start () {

		Texto.GetComponent<Text> ().text = Escribir.ToString ();
		myObjeto = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Mouse ScrollWheel") > 0f ) { // forward
			myObjeto.Translate (new Vector3(0,0,-1));
		}else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
		{
			myObjeto.Translate (new Vector3(0,0,1));
		}

		if (Input.GetMouseButtonDown (0)) {
			
		}


		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			myObjeto.Translate (new Vector3(0,0,-1));
		}
		if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
			myObjeto.Translate (new Vector3(0,0,1));
		}
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			myObjeto.Translate (new Vector3(1,0,0));
		}
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			myObjeto.Translate (new Vector3(-1,0,0));
		}
		if (Input.GetKey (KeyCode.Q)) {
			myObjeto.Translate (new Vector3(0,1,0));
		}
		if (Input.GetKey (KeyCode.E)) {
			myObjeto.Translate (new Vector3(0,-1,0));
		}

	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "estomago") {
			Debug.Log ("Detecto colision");
			Texto.GetComponent<Text> ().text = "Seleccionar la respuesta".ToString ();
			Panel.gameObject.SetActive (true);
		}
		if (other.tag == "cabeza") {
			Debug.Log ("Detecto colision");
			Texto.GetComponent<Text> ().text = "Dolor de Cabeza".ToString ();
		}
	}

	public void ActiveToggle(){
		ButtonSend1.gameObject.SetActive (false);
		PanelRetro.gameObject.SetActive (true);
		if (ResP1A.isOn) {
			puntos += 20;
			Puntuacion.GetComponent<Text> ().text = puntos.ToString();
			Texto.GetComponent<Text> ().text = "Correcto: Loperamida, 2 mg cada ocho horas, o bismuto, subsalicilato en suspensión, 10 ml cada cuatro horas vía oral y 10 ml adicionales inmediatamente después de cada evacuación diarreica.".ToString ();
			Debug.Log ("Seleccionó la respuesta A");
		}else if(ResP1B.isOn) {
			puntos += 0;
			Texto.GetComponent<Text> ().text = "El cuadro clínico del paciente es congruente con una deshidratación leve y tolera la vía oral por lo que la respuesta correcta es la 1.".ToString ();
			Debug.Log ("Seleccionó la respuesta B");
		}
		else if(ResP1C.isOn) {
			puntos += 0;
			Texto.GetComponent<Text> ().text = "El cuadro clínico del paciente es congruente con una deshidratación leve y tolera la vía oral por lo que la respuesta correcta es la 1".ToString ();
			Debug.Log ("Seleccionó la respuesta C");
		}
		else if(ResP1D.isOn) {
			puntos += 0;
			Texto.GetComponent<Text> ().text = "El cuadro clínico del paciente es congruente con una deshidratación leve y tolera la vía oral por lo que la respuesta correcta es la 1".ToString ();
			Debug.Log ("Seleccionó la respuesta D");
		}
		ResP1A.enabled = false;
		ResP1B.enabled = false;
		ResP1C.enabled = false;
		ResP1D.enabled = false;
		ButtonCont.gameObject.SetActive(true);
	}

	public void ActivarPreguntas2(){
		Panel.gameObject.SetActive (false);
		PanelPreg2.gameObject.SetActive (true);
		PanelRetro.gameObject.SetActive (false);
		Texto.GetComponent<Text> ().text = "";
	}

	public void ActivarPreguntas3(){
		PanelPreg2.gameObject.SetActive (false);
		PanelPreg3.gameObject.SetActive (true);
		PanelRetro.gameObject.SetActive (false);
		Texto.GetComponent<Text> ().text = "";
	}

	public void ActiveToggle2(){
		ButtonSend2.gameObject.SetActive (false);
		PanelRetro.gameObject.SetActive (true);
		if (ResP2A.isOn) {
			puntos += 0;
			Texto.GetComponent<Text> ().text = "El cuadro clínico del paciente es congruente con una deshidratación leve y tolera la vía oral por lo que la respuesta correcta es la 1".ToString ();

			Debug.Log ("Seleccionó la respuesta A");
		}else if(ResP2B.isOn) {
			puntos += 0;
			Texto.GetComponent<Text> ().text = "El cuadro clínico del paciente es congruente con una deshidratación leve y tolera la vía oral por lo que la respuesta correcta es la 1.".ToString ();
			Debug.Log ("Seleccionó la respuesta B");
		}
		else if(ResP2C.isOn) {
			puntos += 20;
			Puntuacion.GetComponent<Text> ().text = puntos.ToString();
			Texto.GetComponent<Text> ().text = "Correcto: Suspender loperamina o bismuto.\nContinuar rehidratación oral. Integrar dieta.".ToString (); 			
			Debug.Log ("Seleccionó la respuesta C");
		}
		else if(ResP2D.isOn) {
			puntos += 0;
			Texto.GetComponent<Text> ().text = "El cuadro clínico del paciente es congruente con una deshidratación leve y tolera la vía oral por lo que la respuesta correcta es la 1".ToString ();
			Debug.Log ("Seleccionó la respuesta D");
		}
		ResP2A.enabled = false;
		ResP2B.enabled = false;
		ResP2C.enabled = false;
		ResP2D.enabled = false;
		ButtonCont2.gameObject.SetActive(true);
	}

	public void ActiveToggle3(){
		ButtonSend3.gameObject.SetActive (false);
		PanelRetro.gameObject.SetActive (true);
		if (ResP3A.isOn) {
			puntos += 0;
			Texto.GetComponent<Text> ().text = "Hacer diagnóstico diferencial. Investigar: Leuccocitos en heces. Amiba en fresco. CPS. Biometría hemática y electrolictos séricos. Reacciones febriles.".ToString ();

			Debug.Log ("Seleccionó la respuesta A");
		}else if(ResP3B.isOn) {
			puntos += 20;
			Puntuacion.GetComponent<Text> ().text = puntos.ToString();
			Texto.GetComponent<Text> ().text = "Correcto: Completar esquema de tres días con antimicrobiano.\nContinuar rehidratación. Integrar dieta.".ToString ();
			Debug.Log ("Seleccionó la respuesta B");
		}
		else if(ResP3C.isOn) {
			puntos += 0;
			Texto.GetComponent<Text> ().text = "Hacer diagnóstico diferencial. Investigar: Leuccocitos en heces. Amiba en fresco. CPS. Biometría hemática y electrolictos séricos. Reacciones febriles.".ToString (); 			
			Debug.Log ("Seleccionó la respuesta C");
		}
		else if(ResP3D.isOn) {
			puntos += 0;
			Texto.GetComponent<Text> ().text = "Incorrecto".ToString ();
			Debug.Log ("Seleccionó la respuesta D");
		}
		ResP3A.enabled = false;
		ResP3B.enabled = false;
		ResP3C.enabled = false;
		ResP3D.enabled = false;
		ButtonCont3.gameObject.SetActive(true);
		GuardarScore();
	}

	public void GuardarScore(){
		Debug.Log ("El usuario es "+usuario.text);
		if (System.IO.File.Exists (@"C:/UnityTestFolder/" + usuario.text + ".txt")) {
			Lines = System.IO.File.ReadAllLines(@"C:/UnityTestFolder/"+usuario.text+".txt");
			Debug.Log ("Usuario encontrado" +Lines[3].ToString());
			form = (Lines[0].ToString()+Environment.NewLine+Lines[1].ToString()+Environment.NewLine+Lines[2].ToString()+Environment.NewLine+puntos);
			System.IO.File.WriteAllText(@"C:/UnityTestFolder/"+usuario.text +".txt", form);

		}
	}

	public void CargarNivel(string NombreNivel){
		SceneManager.LoadScene (NombreNivel);
	}
}
