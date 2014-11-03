using UnityEngine;
using System.Collections;

public class SceneTransition : MonoBehaviour {

	private GameObject cam;
	private string atual;
	private bool touch;
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
					atual = sprite.tag;
					cam.SendMessage(sprite.tag);
				}
			}
		}
//
//		Touch myTouch = Input.GetTouch(0);
//		Vector2 pos = Camera.main.ScreenToWorldPoint(myTouch.position);
//		Collider2D[] sprites = Physics2D.OverlapPointAll(pos);
//		if (sprites.Length > 0){
//			foreach(Collider2D sprite in sprites){
//				atual = sprite.tag;
//				cam.SendMessage(sprite.tag);
//			}
//		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			switch(atual){
				case "paraLoja":
					cam.SendMessage("lojaMenuUm");
					break;
				case "paraMenuDois":
					cam.SendMessage("paraMenuUm");
					break;
				case "paraAbout":
					cam.SendMessage("aboutMenuUm");
					break;


			}



//			if (atual == "paraLoja"){
//				cam.SendMessage("lojaMenuUm");
//			}
		}
	}

}
