﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour {
	public GameObject username;
	public GameObject email;
	public GameObject password;
	public GameObject confPassword;
	public Text mensaje;
	private string Username;
	private string Email;
	private string Password;
	private string ConfPassword;
	private string form;

	private bool insigNeurona=false;
	private bool insigInvestigador=false;
	private bool insigInternista=false;
	private bool insigVara=false;

	private long Scorm;

	private bool EmailValid = false;
	private string[] Characters = {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
								   "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
								   "1","2","3","4","5","6","7","8","9","0","_","-"};
	
	public void RegisterButton(){
		bool UN = false;
		bool EM = false;
		bool PW = false;
		bool CPW = false;
		mensaje.text = "";
		if (Username != ""){
			if (!System.IO.File.Exists(@"C:/UnityTestFolder/"+Username+".txt")){
				UN = true;
			} else {
				Debug.LogWarning("Username Taken");
			}
		} else {
			Debug.LogWarning("Username field Empty");
			mensaje.text+="Escribir nombre de usuario \n";
		}
		if (Email != ""){
			EmailValidation();
			if (EmailValid){
				if(Email.Contains("@")){
					if(Email.Contains(".")){
						EM = true;
					} else {
						Debug.LogWarning("Email is Incorrect");
						mensaje.text+="Email incorrecto \n";
					}
				} else {
					Debug.LogWarning("Email is Incorrect");
					mensaje.text+="Email incorrecto \n";
				}
			} else {
				Debug.LogWarning("Email is Incorrect");
				mensaje.text+="Email incorrecto \n";
			}
		} else {
			Debug.LogWarning("Email Field Empty");
			mensaje.text+="Escribir su email \n";
		}
		if (Password != ""){
			if(Password.Length > 5){
				PW = true;
			} else {
				Debug.LogWarning("Password Must Be atleast 6 Characters long");
				mensaje.text+="La contraseña debe tener mínimo 6 caracteres \n";
			}
		} else {
			Debug.LogWarning("Password Field Empty");
			mensaje.text+="Escribir contraseña \n";
		}
		if (ConfPassword != ""){
			if (ConfPassword == Password){
				CPW = true;
			} else {
				Debug.LogWarning("Passwords Don't Match");
				mensaje.text+="No son iguales las contraseñas \n";
			}
		} else {
			Debug.LogWarning("Confirm Password Field Empty");
			mensaje.text+="Confirmar contraseña \n";
		}
		if (UN == true&&EM == true&&PW == true&&CPW == true){
			bool Clear = true;
			int i = 1;
			foreach(char c in Password){
				if (Clear){
					Password = "";
					Clear = false;
				}
				i++;
				char Encrypted = (char)(c * i);
				Password += Encrypted.ToString();
			}
			form = (Username+Environment.NewLine+Email+Environment.NewLine+Password+Environment.NewLine+Scorm+Environment.NewLine+"neurona: "+insigNeurona+Environment.NewLine+"investigador: " +insigInvestigador+Environment.NewLine+"internista: "+insigInternista+Environment.NewLine+"vara: "+insigVara);
			System.IO.File.WriteAllText(@"C:/UnityTestFolder/"+Username+".txt", form);
			username.GetComponent<InputField>().text = "";
			email.GetComponent<InputField>().text = "";
			password.GetComponent<InputField>().text = "";
			confPassword.GetComponent<InputField>().text = "";
			print ("Registration Complete");
			mensaje.text+="Usuario Registrado \n";
			SceneManager.LoadScene ("Login");
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab)){
			if (username.GetComponent<InputField>().isFocused){
				email.GetComponent<InputField>().Select();
			}
			if (email.GetComponent<InputField>().isFocused){
				password.GetComponent<InputField>().Select();
			}
			if (password.GetComponent<InputField>().isFocused){
				confPassword.GetComponent<InputField>().Select();
			}
		}
		if (Input.GetKeyDown(KeyCode.Return)){
			if (Password != ""&&Email != ""&&Password != ""&&ConfPassword != ""){
				RegisterButton();
			}
		}
		Username = username.GetComponent<InputField>().text;
		Email = email.GetComponent<InputField>().text;
		Password = password.GetComponent<InputField>().text;
		ConfPassword = confPassword.GetComponent<InputField>().text;
		Scorm = 0;

	}

	void EmailValidation(){
		bool SW = false;
		bool EW = false;
		for(int i = 0;i<Characters.Length;i++){
			if (Email.StartsWith(Characters[i])){
				SW = true;
			}
		}
		for(int i = 0;i<Characters.Length;i++){
			if (Email.EndsWith(Characters[i])){
				EW = true;
			}
		}
		if(SW == true&&EW == true){
			EmailValid = true;
		} else {
			EmailValid = false;
		}

	}

	public void CargarNivel(string NombreNivel){
		SceneManager.LoadScene (NombreNivel);
	}
}
