using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DigletScript : MonoBehaviour {

	private Transform digletDo, digletRe, digletMi, digletFa, digletSol, digletLa, digletSi;
	private List<Transform> listadiglets = new List<Transform>();
	private GameObject destinoDo;
	private GameObject destinoRe;
	private GameObject destinoMi;
	private GameObject destinoFa;
	private GameObject destinoSol;
	private GameObject destinoLa;
	private GameObject destinoSi;
	private List<string> sequencia = new List<string> ();
	private bool touch;
	private int posicaoSequencia = 0;
	private GameObject objectController;
	public GameObject barraStatus1;
	public GameObject barraStatus2;
		
	// Use this for initialization
	void Start () {		
		digletDo = transform.FindChild ("diglettDo");
		digletRe = transform.FindChild ("diglettRe");
		digletMi = transform.FindChild ("diglettMi");
		digletFa = transform.FindChild ("diglettFa");
		digletSol = transform.FindChild ("diglettSol");
		digletLa = transform.FindChild ("diglettLa");
		digletSi = transform.FindChild ("diglettSi");

		objectController = GameObject.FindGameObjectWithTag ("Launcher");

//		destinoDo = GameObject.FindGameObjectWithTag ("nuvemDo");
//		destinoRe = GameObject.FindGameObjectWithTag ("nuvemRe");
//		destinoMi = GameObject.FindGameObjectWithTag ("nuvemMi");
//		destinoFa = GameObject.FindGameObjectWithTag ("nuvemFa");
//		destinoSol = GameObject.FindGameObjectWithTag ("nuvemSol");
//		destinoLa = GameObject.FindGameObjectWithTag ("nuvemLa");
//		destinoSi = GameObject.FindGameObjectWithTag ("nuvemSi");


		listadiglets.Add (digletDo);
		listadiglets.Add (digletRe);
		listadiglets.Add (digletMi);
		listadiglets.Add (digletFa);
		listadiglets.Add (digletSol);
		listadiglets.Add (digletLa);
		listadiglets.Add (digletSi);
			
//		Updiglet (listadiglets [Random.Range (0, 6)]);
	}

	// Update is called once per frame
	void Update () {
// codigo usado para visualização na unity

		if (posicaoSequencia == sequencia.Count-1) {
			this.barraStatus2.transform.position = new Vector3(barraStatus2.transform.position.x, barraStatus2.transform.position.y, -5);
			this.downDigglets();
			this.downDigglets();
			posicaoSequencia = 0;
			//objectController.SendMessage("gerarSequencia");
		}

		if (Input.GetMouseButtonDown(0) && touch == true) {
			Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Collider2D[] col = Physics2D.OverlapPointAll (pos);		

			if(col.Length > 0){
				foreach (Collider2D c in col){
					if(c.name.Equals(sequencia[posicaoSequencia])){
						posicaoSequencia +=1;
						Hitdiglet(c.transform);
					}

					else{
						barraStatus1.transform.position = new Vector3(barraStatus1.transform.position.x, barraStatus1.transform.position.y, -5);
						this.downDigglets();
						this.downDigglets();
			
					
					}

				}
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

//		switch (b.name) {
//		case "diglettDo":
//			destinoDo.SendMessage (b.name);	
//			break;
//		case "diglettRe":
//			destinoRe.SendMessage (b.name);	
//				break;
//		case "diglettMi":
//			destinoMi.SendMessage (b.name);	
//				break;
//		case "diglettFa":
//			destinoFa.SendMessage (b.name);	
//				break;
//		case "diglettSol":
//			destinoSol.SendMessage (b.name);	
//				break;
//		case "diglettLa":
//			destinoLa.SendMessage (b.name);	
//				break;
//		case "diglettSi":
//			destinoSi.SendMessage (b.name);	
//				break;

//		}
	}

	public void downDigglets(){
		foreach (Transform i in listadiglets) {
			i.rigidbody2D.gravityScale = 5;
		touch = false;
		}
	}


	public void receberSequencia(List<string> lista){
		this.sequencia = lista; 
		
	}

}