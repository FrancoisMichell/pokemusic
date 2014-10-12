using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectController : MonoBehaviour {
	public float maxHeight;
	public float minHeight;

	public float rateSpawn;
	private float currentRateSpawn;

	public int maxMeteoro;
	
	public GameObject prefab;

	private bool _isGameOver;

	public List<GameObject> meteoro;


	// Use this for initialization
	void Start () {
		for (int i=0; i < maxMeteoro; i++) {
			GameObject tempMeteoro = Instantiate(prefab) as GameObject;
			meteoro.Add(tempMeteoro);
			tempMeteoro.SetActive(false);
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

		float randPosition = Random.Range (minHeight, maxHeight);
		GameObject tempMeteoro = null;
		for (int i=0; i < maxMeteoro; i++) {
			if(meteoro[i].activeSelf == false) {
				tempMeteoro = meteoro[i];
				break;
			}
		}
			if (tempMeteoro != null) {
			tempMeteoro.transform.position = new Vector3(transform.position.x, randPosition, transform.position.y);
				tempMeteoro.SetActive(true);



			}
	}
	void GameEnd()
	{
		_isGameOver = true;
	}
}