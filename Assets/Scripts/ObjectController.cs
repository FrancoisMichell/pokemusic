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

	private List<int> ordem = new List<int>();
	private int numero;

	private GameObject nuvemSeguinte;



	
	// Use this for initialization
	void Start () {


		this.startPlay ();
				
				for (int i=0; i<maxNuvem; i++) {
						numero = Random.Range (0, 7);
						ordem.Add (numero);
				}
				for (int i=0; i<maxNuvem; i++) {
						switch (ordem [i]) {
						case 0:
								nuvemSeguinte = nuvemDo;
								break;
						case 1:
								nuvemSeguinte = nuvemRe;
								break;
						case 2:
								nuvemSeguinte = nuvemMi;
								break;
						case 3:
								nuvemSeguinte = nuvemFa;
								break;
						case 4:
								nuvemSeguinte = nuvemSol;
								break;
						case 5:
								nuvemSeguinte = nuvemLa;
								break;
						case 6:
								nuvemSeguinte = nuvemSi;
								break;
						default:
								break;
						}
						GameObject nuvemAtual = Instantiate (nuvemSeguinte) as GameObject;
						nuvem.Add (nuvemAtual);
						nuvemAtual.SetActive (false);
				}
		}
	// Update is called once per frame
	void Update () {
		// aqui faz a comparaçao e identificax que o ultimo objeto foi lancado
		//metodo finish play faz com que a sequencia nao se repita
		if (nuvem [nuvem.Count - 1].activeSelf == true) {
			print(nuvem[nuvem.Count-1].name);
			this.finishPlay();
		}

			


		currentRateSpawn += Time.deltaTime;
		LancarNuvem ();

	
	}
	private void Spawn() {

		float randPosition = Random.Range (AlturaMax, AlturaMin);
		GameObject nuvemAtual = null;
		for (int i=0; i < maxNuvem; i++) {
			if(nuvem[i].activeSelf == false) {
				nuvemAtual = nuvem[i];
				break;
			}
		}
			if (nuvemAtual != null && _isPlaying == true) {
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
		_isPlaying = false;
	}
	public bool getPlaying(){
		return _isPlaying;
	}

}