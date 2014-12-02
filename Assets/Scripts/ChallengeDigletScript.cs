using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChallengeDigletScript : MonoBehaviour {
	
	private Transform digletDo, digletRe, digletMi, digletFa, digletSol, digletLa, digletSi;
	private List<Transform> listadiglets = new List<Transform>();
	private GameObject objectController;
	private List<string> sequencia = new List<string>();
	private int posicaoSequencia = 0;
	public GameObject barraStatus1, barraStatus2, barraStatus3;
	private bool touch;
	private bool liberado; 
	
	// Use this for initialization
	void Start () {	
		digletDo = transform.FindChild ("diglettDo");
		digletRe = transform.FindChild ("diglettRe");
		digletMi = transform.FindChild ("diglettMi");
		digletFa = transform.FindChild ("diglettFa");
		digletSol = transform.FindChild ("diglettSol");
		digletLa = transform.FindChild ("diglettLa");
		digletSi = transform.FindChild ("diglettSi");

		sequencia.Add ("");
		objectController = GameObject.FindGameObjectWithTag("Launcher");
		
		listadiglets.Add (digletDo);
		listadiglets.Add (digletRe);
		listadiglets.Add (digletMi);
		listadiglets.Add (digletFa);
		listadiglets.Add (digletSol);
		listadiglets.Add (digletLa);
		listadiglets.Add (digletSi);
	}
	
	// Update is called once per frame
	void Update () {

		//codigo que eu inseri para que ele nao saia nunca do eixo, se cometarem esse trecho verao que eles estao sempre
		//saindo do eixo, recomendo copiarem esse trecho pros outros scripts de diglet
		foreach (Transform d in listadiglets){
			Quaternion angulo = new Quaternion();
			angulo.Set(0f,0f,0f,0f);
			d.rotation = angulo;
			
		}
		if (posicaoSequencia == sequencia.Count) {
			this.barraStatus3.transform.position = new Vector3 (barraStatus3.transform.position.x, barraStatus3.transform.position.y, 10);
		}
			
			
			// codigo usado para visualização na unity
		if (Input.GetMouseButtonDown(0) && touch == true) {
			Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Collider2D[] col = Physics2D.OverlapPointAll (pos);		
			if(col.Length > 0){
				foreach (Collider2D c in col){				
					Hitdiglet(c.transform);

					print (sequencia[posicaoSequencia]);
					if (c.name.Equals(sequencia[posicaoSequencia])) {
						lancarNuvem();
						posicaoSequencia += 1;
					}
					else if(posicaoSequencia == sequencia.Count -1){
						this.barraStatus1.transform.position = new Vector3(barraStatus1.transform.position.x, barraStatus1.transform.position.y, 10);
							
					}						
					else{
						this.barraStatus2.transform.position = new Vector3(barraStatus2.transform.position.x, barraStatus2.transform.position.y, 10);
							
					}

				}
			}
		}
		//Codigo para multitoque. Esta comentado, pois so funciona no smartphone 
		
		//		Touch myTouch = Input.GetTouch(0);
		//	Vector2 p = Camera.main.ScreenToWorldPoint(myTouch.position);
		//	Collider2D[] myTouches = Physics2D.OverlapPointAll(p);
		//	if (myTouches.Length > 0 && touch == true){
		//		foreach(Collider2D c in myTouches){
		//			Hitdiglet(c.transform);
		
		//	}
		//	}
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
	
	void Hitdiglet(Transform b) {
		tocar (b.name);
		b.rigidbody2D.velocity = Vector3.down * 10;
	}
	
	//usei essa estrategia para que eu possa executar os sons mesmo de outro script
	public void tocar(string nome){
		Transform b = transform.FindChild (nome);
		b.audio.Play();
	}
	
	
	public void downDigglets(){
		foreach (Transform i in listadiglets) {
			i.rigidbody2D.gravityScale = 5;
			touch = false;
		}
	}
	
	public void receberSequencia(List<string> lista) {	
		this.sequencia = lista;
	}
	
	public void lancarNuvem(){		
		objectController.SendMessage("lancar",sequencia[posicaoSequencia]);		
	}
	
	
	
}