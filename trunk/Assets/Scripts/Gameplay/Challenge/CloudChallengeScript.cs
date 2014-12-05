using UnityEngine;
using System.Collections;

public class CloudChallengeScript : MonoBehaviour {

	private bool voar;	

	// Use this for initialization
	void Start () {
		voar = true;

	}
	void Update(){

		if (voar == true) {
			this.transform.position = new Vector3(this.transform.position.x+0.11f, this.transform.position.y, 10);
		}
	}

	void OnTriggerEnter2D(Collider2D c)	{
		if(c.CompareTag("Nuvem") && c.transform.position.x > this.transform.position.x){
			voar = false;
		}
		else if(c.CompareTag("RightFundo")){
			voar = false;
		}
	}

}