using UnityEngine;
using System.Collections;

public class ObjectBehavior : MonoBehaviour {
	public float speed;
	public GameObject meteoro;
	private bool _isGameOver;


	// Use this for initialization
	void Start () {
		_isGameOver = false;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (_isGameOver) return;
		transform.position += new Vector3 (speed, 0, 0) * Time.deltaTime;
		if (transform.position.x < -10f) {
			meteoro.SetActive(false);

	
	}
	}

	void GameEnd()
	{
		_isGameOver = true;
	}
}