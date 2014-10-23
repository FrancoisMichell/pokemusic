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

	private bool _isGameOver;

	public List<GameObject> nuvem;

	private List<int> ordem = new List<int>();
	private int numero;

	private GameObject nuvemSeguinte;

	
	// Use this for initialization
	void Start () {

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



		currentRateSpawn += Time.deltaTime;
		if (currentRateSpawn > rateSpawn) {
						if (_isGameOver) return;
						currentRateSpawn = 0;
						Spawn();
				}
	
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
			if (nuvemAtual != null) {
			nuvemAtual.transform.position = new Vector3(transform.position.x, randPosition, transform.position.y);
				nuvemAtual.SetActive(true);



			}
	}


	void GameEnd()
	{
		_isGameOver = true;
	}
}