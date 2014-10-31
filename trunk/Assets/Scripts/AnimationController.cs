using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	private Animator notaMusical;

	// Use this for initialization
	void Start () {
		notaMusical = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void diglettLa(){
		notaMusical.SetTrigger("apertarLa");
	}
	
	void diglettDo(){
		notaMusical.SetTrigger("apertarDo");
	}
	
	void diglettRe(){
		notaMusical.SetTrigger("apertarRe");
	}

	void diglettMi(){
		notaMusical.SetTrigger("apertarMi");
	}
	
	void diglettFa(){
		notaMusical.SetTrigger("apertarFa");
	}

	void diglettSol(){
		notaMusical.SetTrigger("apertarSol");
	}

	void diglettSi(){
		notaMusical.SetTrigger("apertarSi");
	}
}
