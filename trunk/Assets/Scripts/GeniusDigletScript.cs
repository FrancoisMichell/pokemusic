using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeniusDigletScript : MonoBehaviour {

	private Transform digletDo, digletRe, digletMi, digletFa, digletSol, digletLa, digletSi;
	private List<Transform> listadiglets = new List<Transform>();
	//sequencia de strings enviadas pelo objectController 
	private List<string> sequencia = new List<string> ();
	private bool touch;
	//o indice da lista de sequencias que esta sendo usado atualmente
	private int posicaoSequencia = 0;
	private int tamanhoSequencia = 1;
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
		// codigo usado para visualização na unity
		
		//caso o indice da sequencia que esta sendo considerada neste momento for igual ao tamanho da lista de sequencias
		//entao ele vai mostrar o "bom trabalho" e pedir uma nova sequencia
		if (posicaoSequencia == sequencia.Count) {
			this.barraStatus1.transform.position = new Vector3(barraStatus2.transform.position.x, barraStatus2.transform.position.y, -5);
			posicaoSequencia = 0;

			//objectController.SendMessage("startPlay");
			//esse 3 significa que ele ira esperar 3 segundos para ser executado
			Invoke("pedirSequencia",1f);
		}
		
		if (Input.GetMouseButtonDown(0) && touch == true) {
			Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Collider2D[] col = Physics2D.OverlapPointAll (pos);		
			
			if(col.Length > 0){
				foreach (Collider2D c in col){
					//comparacao para saber se o nome do objeto clicado e igual a string que esta na posicao da sequencia atual
					if(c.name.Equals(sequencia[posicaoSequencia])){
						posicaoSequencia +=1;
						//Implementar a pontuaçao aqui!!
						Hitdiglet(c.transform);
					}
					
					//caso nao esteja, sera exibido o "FAIL" e sera gerada uma sequencia do zero novamente
					else{
						barraStatus2.transform.position = new Vector3(barraStatus1.transform.position.x, barraStatus1.transform.position.y, -5);
						posicaoSequencia = 0;
						//objectController.SendMessage("startPlay");
						//esse 3 significa que ele ira esperar 3 segundos para ser executado
						Invoke("pedirSequenciaInicio",3);
						
						
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
		print ("su");
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
	}
	
	public void downDigglets(){
		print ("down");
		foreach (Transform i in listadiglets) {
			i.rigidbody2D.gravityScale = 5;
			touch = false;
		}
	}
	
	
	public void receberSequencia(List<string> lista){
		this.sequencia = lista; 
		
	}
	
	public void pedirSequencia(){
		tamanhoSequencia += 1;
		this.barraStatus1.transform.position = new Vector3(barraStatus2.transform.position.x, barraStatus2.transform.position.y, 5);
		this.downDigglets();
		print (tamanhoSequencia);
		objectController.SendMessage("gerarSequencia", tamanhoSequencia);
		
	}
	
	public void pedirSequenciaInicio(){
		this.barraStatus2.transform.position = new Vector3(barraStatus1.transform.position.x, barraStatus1.transform.position.y, 5);
		this.downDigglets();
		tamanhoSequencia = 1;
		objectController.SendMessage("gerarSequencia", tamanhoSequencia);
		Application.LoadLevel ("Genius");
		
	}

}