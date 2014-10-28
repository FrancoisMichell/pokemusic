using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DigletScript : MonoBehaviour {

	private Transform digletDo, digletRe, digletMi, digletFa, digletSol, digletLa, digletSi;
	private List<Transform> listadiglets = new List<Transform>();
	private GameObject destino;
	private bool touch;


		
	// Use this for initialization
	void Start () {		
		digletDo = transform.FindChild ("diglettDo");
		digletRe = transform.FindChild ("diglettRe");
		digletMi = transform.FindChild ("diglettMi");
		digletFa = transform.FindChild ("diglettFa");
		digletSol = transform.FindChild ("diglettSol");
		digletLa = transform.FindChild ("diglettLa");
		digletSi = transform.FindChild ("diglettSi");

		destino = GameObject.FindGameObjectWithTag ("nuvem");


		listadiglets.Add (digletDo);
		listadiglets.Add (digletRe);
		listadiglets.Add (digletMi);
		listadiglets.Add (digletFa);
		listadiglets.Add (digletSol);
		listadiglets.Add (digletLa);
		listadiglets.Add (digletSi);
			

//		Upall ();
//		Updiglet (listadiglets [Random.Range (0, 6)]);
	}

	// Update is called once per frame
	void Update () {
// codigo usado para visualização na unity
		if (Input.GetMouseButton(0) && touch == true) {
			Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Collider2D[] col = Physics2D.OverlapPointAll (pos);		

			if(col.Length > 0)
				foreach (Collider2D c in col){

					Hitdiglet(c.transform);

				}
			}

		//Codigo para multitoque. Esta comentado, pois so funciona no smartphone 

//		Touch myTouch = Input.GetTouch(0);
//		Vector2 pos = Camera.main.ScreenToWorldPoint(myTouch.position);
//		Collider2D[] myTouches = Physics2D.OverlapPointAll(pos);
//		if (myTouches.Length > 0 && touch == true){
//			foreach(Collider2D c in myTouches){
//					Hitdiglet(c.transform);
//
//			}
//		}
	}

	public void Upall() {
		foreach (Transform i in listadiglets){
			Updiglet (i);
			touch = true;
		}
	}

	void Updiglet(Transform a){
		a.rigidbody2D.gravityScale = -5;
	}

	void Hitdiglet(Transform b){
		b.audio.Play ();
		b.rigidbody2D.velocity = Vector3.down * 10;
		//destino.SendMessage(b.name);
	}

	public void downDigglets(){
		foreach (Transform i in listadiglets) {
			i.rigidbody2D.gravityScale = 5;
			touch = false;
		}
	}
}