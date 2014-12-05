using UnityEngine;
using System.Collections;

public class notaDo : MonoBehaviour {
	private Animator notaMusical;
	// Use this for initialization
	void Start () {
		notaMusical = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void diglettDo(){
		notaMusical.SetTrigger("apertarDo");
	}
}
