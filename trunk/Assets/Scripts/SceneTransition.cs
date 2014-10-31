using UnityEngine;
using System.Collections;

public class SceneTransition : MonoBehaviour {

	private GameObject cam;

	// Use this for initialization
	void Start () {

		cam = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButton(0)) {
			Vector2 vetor = cam.camera.ScreenToWorldPoint(Input.mousePosition);
			Collider2D[] sprites = Physics2D.OverlapPointAll(vetor);
			
			if(sprites.Length > 0){
				foreach(Collider2D sprite in sprites){
					print (sprite.tag);
					cam.SendMessage(sprite.tag);
				}
			}
		}
	}

}
