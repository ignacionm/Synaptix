using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caso : MonoBehaviour {
	public GameObject Panel;
	int contador=1;

	public void showPanel(){
		contador++;
		if (contador % 2 == 1) {
			Panel.gameObject.SetActive (false);
		} else {
			Panel.gameObject.SetActive (true);
		}
	}

}
