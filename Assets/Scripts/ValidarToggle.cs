using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidarToggle : MonoBehaviour {
	public Toggle ResP1A;
	public Toggle ResP1B;
	public Toggle ResP1C;
	public Toggle ResP1D;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void validaA(){
		if (ResP1A.isOn == true) {
			ResP1B.isOn = false;
			ResP1C.isOn = false;
			ResP1D.isOn = false;
		}
	}

	public void validaB(){
		if (ResP1B.isOn == true) {
			ResP1A.isOn = false;
			ResP1C.isOn = false;
			ResP1D.isOn = false;
		}
	}

	public void validaC(){
		if (ResP1C.isOn == true) {
			ResP1A.isOn = false;
			ResP1B.isOn = false;
			ResP1D.isOn = false;
		}
	}

	public void validaD(){
		if (ResP1D.isOn == true) {
			ResP1A.isOn = false;
			ResP1B.isOn = false;
			ResP1C.isOn = false;
		}
	}




}
