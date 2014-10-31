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

		proximaTela.SetTrigger ("Menu1_Menu2");

	}

	void paraMenuUm(){

		proximaTela.SetTrigger ("Menu2_Menu1");
		
	}

	void lojaMenuUm(){
		
		proximaTela.SetTrigger ("Loja_Menu1");
		
	}

	void aboutMenuUm(){
		
		proximaTela.SetTrigger ("About_Menu1");
		
	}

	void paraLoja(){

		proximaTela.SetTrigger ("Menu1_Loja");
		
	}

	void paraAbout(){
		
		proximaTela.SetTrigger ("Menu1_About");
		
	}

}