using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectController : MonoBehaviour {
	public float AlturaMax;
	public float AlturaMin;

	public float rateSpawn;
	private float currentRateSpawn;

	public int maxNuvem;
	
	public GameObject prefab;

	private bool _isGameOver;

	public List<GameObject> nuvem;


	// Use this for initialization
	void Start () {
		for (int i=0; i < maxNuvem; i++) {
			GameObject tempNuvem = Instantiate(prefab) as GameObject;
			nuvem.Add(tempNuvem);
			tempNuvem.SetActive(false);
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
		GameObject tempNuvem = null;
		for (int i=0; i < maxNuvem; i++) {
			if(nuvem[i].activeSelf == false) {
				tempNuvem = nuvem[i];
				break;
			}
		}
			if (tempNuvem != null) {
			tempNuvem.transform.position = new Vector3(transform.position.x, randPosition, transform.position.y);
				tempNuvem.SetActive(true);



			}
	}
	void GameEnd()
	{
		_isGameOver = true;
	}
}