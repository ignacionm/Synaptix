using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginPHP : MonoBehaviour
{
	public GameObject username;
	public GameObject password;

	private string Username;
	private string Password;

	public Text mensaje;

	public void iniciarSesion()
	{
		StartCoroutine(Login());
	}

	IEnumerator Login()
	{
		Debug.Log("Usuario: " + Username + "Clave: " + Password);
		WWW conexion = new WWW("www.arevolution.com.mx/synaptix/login.php?uss=" + Username + "&pss=" + Password);
		yield return (conexion);
		Debug.Log(conexion.text);
		if (conexion.text == "bien")
		{
			SceneManager.LoadScene("Menu");
		}
		else
		{
			Debug.Log("Verificar los datos");
			mensaje.text += "Verificar nombre Usuario \n";
		}
	}
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			if (username.GetComponent<InputField>().isFocused)
			{
				password.GetComponent<InputField>().Select();
			}
		}
		if (Input.GetKeyDown(KeyCode.Return))
		{
			if (Password != "" && Password != "")
			{
				iniciarSesion();
			}
		}
		Username = username.GetComponent<InputField>().text;
		Password = password.GetComponent<InputField>().text;
		Username = username.GetComponent<InputField>().text;
		Password = password.GetComponent<InputField>().text;
	}
}
