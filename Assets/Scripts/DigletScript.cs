using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DigletScript : MonoBehaviour {

	private Transform digletDo, digletRe, digletMi, digletFa, digletSol, digletLa, digletSi;
	private List<Transform> listadiglets = new List<Transform>();
	private GameObject destino;

		
	// Use this for initialization
	void Start () {		
		digletDo = transform.FindChild ("diglett-do");
		digletRe = transform.FindChild ("diglett-re");
		digletMi = transform.FindChild ("diglett-mi");
		digletFa = transform.FindChild ("diglett-fa");
		digletSol = transform.FindChild ("diglett-sol");
		digletLa = transform.FindChild ("diglett-la");
		digletSi = transform.FindChild ("diglett-si");

		destino = GameObject.FindGameObjectWithTag ("notaMusical");

		listadiglets.Add (digletDo);
		listadiglets.Add (digletRe);
		listadiglets.Add (digletMi);
		listadiglets.Add (digletFa);
		listadiglets.Add (digletSol);
		listadiglets.Add (digletLa);
		listadiglets.Add (digletSi);
			

		Upall ();
		//Updiglet (listadiglets [Random.Range (0, 6)]);
	}
	

	
	// Update is called once per frame
	void Update () {
// codigo usado para visualização na unity
		if (Input.GetMouseButton(0)) {

			Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Collider2D[] col = Physics2D.OverlapPointAll (pos);

			if(col.Length > 0)
				foreach (Collider2D c in col){
					/*if (c.CompareTag("digletDo")){
						Hitdiglet(c.transform);
						destino.SendMessage("mudarEstadoDo");
												
					}*/
					Hitdiglet(c.transform);

					if(c.CompareTag("digletRe")){
						Hitdiglet(c.transform);
						destino.SendMessage("mudarEstadoRe");
				
					}

					else if(c.CompareTag("digletMi")){
						Hitdiglet(c.transform);
						destino.SendMessage("mudarEstadoMi");
							
					}

					else if(c.CompareTag("digletFa")){
						Hitdiglet(c.transform);
						destino.SendMessage("mudarEstadoFa");
						
					}

					else if(c.CompareTag("digletSol")){
						Hitdiglet(c.transform);
						destino.SendMessage("mudarEstadoSol");
						
					}

					else if(c.CompareTag("digletLa")){
						Hitdiglet(c.transform);
						destino.SendMessage("mudarEstadoLa");
						
					}
					else if(c.CompareTag("digletSi")){
						Hitdiglet(c.transform);
						destino.SendMessage("mudarEstadoSi");
						
					}	
				}
			}

		//Codigo para multitoque. Esta comentado, pois so funciona no smartphone, no emulador do unity nao faz nada. 

		/*Touch myTouch = Input.GetTouch(0);
		Vector2 pos = Camera.main.ScreenToWorldPoint(myTouch.position);
		Collider2D[] myTouches = Physics2D.OverlapPointAll(pos);
		if (myTouches.Length > 0){
			foreach(Collider2D c in myTouches){
				if (c.CompareTag("digletDo")){
					Hitdiglet(c.transform);
					destino.SendMessage("mudarEstadoDo");
					
				}
				
				else if(c.CompareTag("digletRe")){
					Hitdiglet(c.transform);
					destino.SendMessage("mudarEstadoRe");
					
				}
				
				else if(c.CompareTag("digletMi")){
					Hitdiglet(c.transform);
					destino.SendMessage("mudarEstadoMi");
					
				}
				
				else if(c.CompareTag("digletFa")){
					Hitdiglet(c.transform);
					destino.SendMessage("mudarEstadoFa");
					
				}
				
				else if(c.CompareTag("digletSol")){
					Hitdiglet(c.transform);
					destino.SendMessage("mudarEstadoSol");
					
				}
				
				else if(c.CompareTag("digletLa")){
					Hitdiglet(c.transform);
					destino.SendMessage("mudarEstadoLa");
					
				}
				else if(c.CompareTag("digletSi")){
					Hitdiglet(c.transform);
					destino.SendMessage("mudarEstadoSi");
					
				}
			}
		}*/
	}

	void Upall() {
		foreach (Transform i in listadiglets){
			print(i);
			Updiglet (i);
		}
	}

	void Updiglet(Transform a){
		a.rigidbody2D.gravityScale = -5;
	}

	void Hitdiglet(Transform b){
		b.audio.Play ();
		b.rigidbody2D.velocity = Vector3.down * 10;
		destino.SendMessage(b.name);


	}
}