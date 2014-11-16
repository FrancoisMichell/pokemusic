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

	public TextMesh Score;
	public TextMesh HiScore;
	private int _score;
	private int _hiscore;


	private int toque;
    private bool pausado;

	private GameObject geniusCamera;
	private GameObject maquinaGenius;
	

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
		geniusCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		//A maquina do modo Genius esta setada com a tag "BarraSom"
		maquinaGenius = GameObject.FindGameObjectWithTag ("BarraSom");
		
		listadiglets.Add (digletDo);
		listadiglets.Add (digletRe);
		listadiglets.Add (digletMi);
		listadiglets.Add (digletFa);
		listadiglets.Add (digletSol);
		listadiglets.Add (digletLa);
		listadiglets.Add (digletSi);

		_hiscore = PlayerPrefs.GetInt ("hiscore", 0);
		HiScore.text = "" + _hiscore;
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
		if (Input.GetMouseButtonDown (0) && touch == true && pausado == false) {
			
			Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Collider2D[] col = Physics2D.OverlapPointAll (pos);		
			
			if (col.Length > 0) {
				foreach (Collider2D c in col) {
					//comparacao para saber se o nome do objeto clicado e igual a string que esta na posicao da sequencia atual
					if (c.name.Equals (sequencia [posicaoSequencia])) {
							posicaoSequencia += 1;
							toque += 1;
							PlayerScored();
						}
					else if (c.CompareTag("BtJogar"))
						{
							Application.LoadLevel (Application.loadedLevel);
						}
					else if (c.CompareTag("BtMenu"))
						{
							Application.LoadLevel("Menu");
						}

					
					//caso nao esteja, sera exibido o "FAIL" e sera gerada uma sequencia do zero novamente
					else {
						barraStatus2.transform.position = new Vector3 (barraStatus1.transform.position.x, barraStatus1.transform.position.y, -5);
						posicaoSequencia = 0;
						//objectController.SendMessage("startPlay");
						//esse 1 significa que ele ira esperar 3 segundos para ser executado
						Invoke ("moverCamera", 1);
						Invoke("desativarMaquina",2);

					}
					Hitdiglet (c.transform);
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

	private void testando(){

		
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
	
	public void pedirSequencia(){
		tamanhoSequencia += 1;
		barraStatus1.transform.position = new Vector3(barraStatus2.transform.position.x, barraStatus2.transform.position.y, 5);
		downDigglets();
		print (tamanhoSequencia);
		objectController.SendMessage("gerarSequencia", tamanhoSequencia);
		toque = 0;
	}
	
	public void pedirSequenciaInicio(){
		barraStatus2.transform.position = new Vector3(barraStatus1.transform.position.x, barraStatus1.transform.position.y, 5);
		downDigglets();
		tamanhoSequencia = 1;
		objectController.SendMessage("gerarSequencia", tamanhoSequencia);
	}

	void PlayerScored(){
		_score++;
		Score.text = "" + _score;
		
		if (_score > _hiscore) {
			_hiscore = _score;
			HiScore.text = "" + _hiscore;
			PlayerPrefs.SetInt ("hiscore", _hiscore);
		}
	}
	void moverCamera() 
	{
		geniusCamera.SendMessage ("paraScore");
	}

    void Pausar(){
        pausado = true;
    }
    void Continuar(){
        pausado = false;
    }
	void desativarMaquina()
	{
		maquinaGenius.SetActive(false);
	}
}