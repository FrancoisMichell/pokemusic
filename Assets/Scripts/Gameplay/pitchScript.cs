using UnityEngine;
using System.Collections;

public class pitchScript : MonoBehaviour {

	private Animator animatorPitch;

	// Use this for initialization
	void Start () {

		animatorPitch = GetComponent<Animator> ();
	
	}


	// Update is called once per frame
	void Update () {
	
	}

	void animar(){
		
		animatorPitch.SetTrigger ("ativar");
		
	}

}
