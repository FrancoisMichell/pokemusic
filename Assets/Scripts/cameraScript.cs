using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {

	private Animator proximaTela;

	// Use this for initialization
	void Start () {

		proximaTela = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void paraMenuDois(){

		proximaTela.SetTrigger ("subir");
		proximaTela.SetTrigger ("paraMenu2");

	}

	void paraMenuUm(){

		proximaTela.SetTrigger ("indoEsquerda");
		proximaTela.SetTrigger ("paraMenu1");
		
	}

	void paraLoja(){

		proximaTela.SetTrigger ("indoDireita");
		proximaTela.SetTrigger ("paraLoja");
		
	}

}