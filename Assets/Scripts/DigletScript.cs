using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DigletScript : MonoBehaviour {

	private Transform digletDo, digletRe, digletMi, digletFa, digletSol, digletLa, digletSi;
	private List<Transform> listadiglets = new List<Transform>();


	// Use this for initialization
	void Start () {
		digletDo = transform.FindChild ("diglett-do");
		digletRe = transform.FindChild ("diglett-re");
		digletMi = transform.FindChild ("diglett-mi");
		digletFa = transform.FindChild ("diglett-fa");
		digletSol = transform.FindChild ("diglett-sol");
		digletLa = transform.FindChild ("diglett-la");
		digletSi = transform.FindChild ("diglett-si");

		listadiglets.Add (digletDo);
		listadiglets.Add (digletRe);
		listadiglets.Add (digletMi);
		listadiglets.Add (digletFa);
		listadiglets.Add (digletSol);
		listadiglets.Add (digletLa);
		listadiglets.Add (digletSi);

		Upall ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Collider2D[] col = Physics2D.OverlapPointAll (pos);

			if(col.Length > 0)
				foreach (Collider2D c in col)
					if (c.CompareTag("diglet")){
						Hitdiglet(c.transform);
					}
		}
	
		//Codigo para multitoque. Esta comentado, pois so funciona no smartphone, no emulador do unity nao faz nada. 
//
//		Touch myTouch = Input.GetTouch(0);
//		Vector2 pos = Camera.main.ScreenToWorldPoint(myTouch.position);
//		Collider2D[] myTouches = Physics2D.OverlapPointAll(pos);
//		if (myTouches.Length > 0){
//			foreach(Collider2D c in myTouches){
//				if(c.CompareTag("diglet")){
//					Hitdiglet(c.transform);
//				}
//			}
//		}
	}

	void Upall() {
		foreach (Transform i in listadiglets){
			print (i);
			Updiglet (i);
		}
	}

	void Updiglet(Transform a){
		a.rigidbody2D.gravityScale = -5;
	}

	void Hitdiglet(Transform b){
		b.rigidbody2D.velocity = Vector3.down*10;
		b.audio.Play ();
	}
}
