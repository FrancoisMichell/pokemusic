using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectController : MonoBehaviour {
	public float AlturaMax;
	public float AlturaMin;
	
	public float rateSpawn;
	private float currentRateSpawn;
	
	public int maxNuvem;

	public GameObject nuvemDo, nuvemRe, nuvemMi, nuvemFa, nuvemSol, nuvemLa, nuvemSi;
	
	public bool _isGameOver, _isPlaying;
	
	public List<GameObject> nuvem;
	private List<string> sequencia;
	
	private GameObject nuvemSeguinte, digglets;
	
	
	// Use this for initialization
	void Start () {
		
		sequencia = new List<string> ();
		digglets = GameObject.FindGameObjectWithTag ("digglets");		
		//ele iniciara a sequencia com apenas uma nuvem
		this.gerarSequencia (1);

	}
	
	void gerarSequencia(int tamanho){
		this.startPlay ();
		maxNuvem = tamanho;

		if (maxNuvem == 1) {
			sequencia = new List<string> ();
		}
						
		
		//o tamanho da nuvem sera informada pelo Diglet Script
		int numero = Random.Range (0, 7);
		if(numero == 0){
			nuvemSeguinte = nuvemDo;
			sequencia.Add("diglettDo");					
		}
		else if(numero == 1){
			nuvemSeguinte = nuvemRe;
			sequencia.Add("diglettRe");
		}
		else if(numero == 2){
			nuvemSeguinte = nuvemMi;
			sequencia.Add("diglettMi");
		}
		else if(numero == 3){
			nuvemSeguinte = nuvemFa;
			sequencia.Add("diglettFa");
		}
		else if(numero == 4){
			nuvemSeguinte = nuvemSol;
			sequencia.Add("diglettSol");
		}
		else if(numero == 5){
			nuvemSeguinte = nuvemLa;
			sequencia.Add("diglettLa");
		}
		else if(numero == 6){
			nuvemSeguinte = nuvemSi;
			sequencia.Add("diglettSi");
		}
		GameObject nuvemAtual = Instantiate (nuvemSeguinte) as GameObject;
		nuvem.Add (nuvemAtual);
		nuvemAtual.SetActive (false);

		//codigo para que o script do diglet receba a sequencia de strings
		digglets.SendMessage("receberSequencia",sequencia);
	}
	
	// Update is called once per frame
	void Update () {
		// aqui faz a comparaçao e identifica que o ultimo objeto foi lancado
		//metodo finish play faz com que a sequencia nao se repita
		if (nuvem [nuvem.Count - 1].transform.position.x < -4f ) {
			this.finishPlay();
			print ("S");
		}
		
		currentRateSpawn += Time.deltaTime;
		if (_isPlaying)
			LancarNuvem ();
		
		
	}
	
	//	}
	private void Spawn() {
		print ("qw" + maxNuvem);		
		float randPosition = Random.Range (AlturaMax, AlturaMin);
		GameObject nuvemAtual = null;
		for (int i=0; i < maxNuvem; i++) {
			if(nuvem[i].activeSelf == false) {
				nuvemAtual = nuvem[i];
				break;
			}
		}

		if (nuvemAtual != null   && _isPlaying == true) {
			nuvemAtual.transform.position = new Vector3(transform.position.x, randPosition, transform.position.y);
			nuvemAtual.SetActive(true);
			
				
		}
	}
	//metodo responsavel por fazer as nuvens serem lançadas espaçadas.
	public void LancarNuvem(){
		if (currentRateSpawn > rateSpawn) {
			if (_isGameOver) return;
			currentRateSpawn = 0;
			Spawn();
			
			
		}
	}
	
	
	
	public void startPlay(){
		_isPlaying = true;
		
	}
	public void finishPlay(){
		this.enviaMensagem();
		_isPlaying = false;	
	}
	
	public bool getPlaying(){
		return _isPlaying;
	}
	
	public void enviaMensagem(){
		digglets.SendMessage ("Upall");
		
		
	}

}