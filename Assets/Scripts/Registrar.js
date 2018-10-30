//#pragma strict
var Nombre: String;
var UINombre : UI.Text;
var UIPantalla : UI.Text;

function Start () {
	var TextoCapturado: String=PlayerPrefs.GetString("Jugador",Nombre);
	UIPantalla.text="Bienvenido: "+TextoCapturado.ToString();
	Debug.Log("Cargado");
}

function Update () {
	if(Input.GetKeyDown(KeyCode.E)){
		Nombre=UINombre.ToString();
		UIPantalla.text=UINombre.ToString();
		PlayerPrefs.SetString("Jugador",Nombre);
		Debug.Log("Guardado");
	}
}
	
