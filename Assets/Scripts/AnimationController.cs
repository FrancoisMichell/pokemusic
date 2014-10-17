using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	private Animator notaMusical;
	public Transform sprite;

	// Use this for initialization
	void Start () {
		notaMusical = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void mudarEstadoDo(){
		notaMusical.SetTrigger("apertarDo");
	}
	
	void mudarEstadoRe(){
		notaMusical.SetTrigger("apertarRe");
	}

	void mudarEstadoMi(){
		notaMusical.SetTrigger("apertarMi");
	}
	
	void mudarEstadoFa(){
		notaMusical.SetTrigger("apertarFa");
	}

	void mudarEstadoSol(){
		notaMusical.SetTrigger("apertarSol");
	}
	
	void mudarEstadoLa(){
		notaMusical.SetTrigger("apertarLa");
	}

	void mudarEstadoSi(){
		notaMusical.SetTrigger("apertarSi");
	}
}
