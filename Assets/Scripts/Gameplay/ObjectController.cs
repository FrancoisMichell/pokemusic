using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectController : MonoBehaviour {
	public float AlturaMax;
	public float AlturaMin;
	
	public float rateSpawn;
	private float currentRateSpawn;
	
	public int maxNuvem;
	private int contagem;

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
		startPlay ();
		maxNuvem = tamanho;

		if (maxNuvem == 1) {
			sequencia = new List<string> ();
		}
						
		
		//o tamanho da nuvem sera informada pelo Diglet Script
		int numero = Random.Range (0, 7);

        switch (numero) {
            case 0:
			    nuvemSeguinte = nuvemDo;
			    sequencia.Add("diglettDo");					
                break;
            case 1:
			    nuvemSeguinte = nuvemRe;
			    sequencia.Add("diglettRe");
                break;
            case 2:
			    nuvemSeguinte = nuvemMi;
			    sequencia.Add("diglettMi");
                break;
            case 3:
			    nuvemSeguinte = nuvemFa;
			    sequencia.Add("diglettFa");
                break;
            case 4:
			    nuvemSeguinte = nuvemSol;
			    sequencia.Add("diglettSol");
                break;
            case 5:
			    nuvemSeguinte = nuvemLa;
			    sequencia.Add("diglettLa");
                break;
            case 6:
			    nuvemSeguinte = nuvemSi;
			    sequencia.Add("diglettSi");
                break;
           
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
		if (nuvem [nuvem.Count - 1].transform.position.x < -10f) {
			this.finishPlay ();

		}
		currentRateSpawn += Time.deltaTime;
		if (_isPlaying) {
			LancarNuvem ();

		}
		
		
	}
	
		
	private void Spawn() {
		float randPosition = Random.Range (AlturaMax, AlturaMin);
		GameObject nuvemAtual = null;
		for (int i=0; i < maxNuvem; i++) {
			if(nuvem[i].activeSelf == false) {
				if (contagem <= maxNuvem){
					nuvemAtual = nuvem[i];
					contagem += 1;
				break;
				}

				else {
					contagem = 0; 
					break;
				}
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
		foreach(GameObject i in nuvem){
			i.SetActive(false);

		}
	}
	
	public bool getPlaying(){
		return _isPlaying;
	}
	
	public void enviaMensagem(){
		digglets.SendMessage ("Upall");
		
		
	}

}