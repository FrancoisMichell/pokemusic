using UnityEngine;
using System.Collections;

public class notaFa : MonoBehaviour {
	private Animator notaMusical;
	// Use this for initialization
	void Start () {
		notaMusical = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void diglettFa(){
		notaMusical.SetTrigger("apertarFa");
	}
}
