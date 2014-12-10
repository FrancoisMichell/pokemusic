using UnityEngine;
using System.Collections;

public class CloudInfinityScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	}
	void Update(){

		this.transform.position = new Vector3(this.transform.position.x+0.1f, this.transform.position.y, 2);
		this.transform.localScale = new Vector3(this.transform.localScale.x+0.0027f, this.transform.localScale.y+0.0027f, 1);
		if (this.transform.position.x > 40) {
				Destroy (this.gameObject);
		}
	}

}
