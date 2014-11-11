using UnityEngine;
using System.Collections;


public class ObjectBehavior : MonoBehaviour {
	public float speed;
	public GameObject meteoro;
	private bool _isGameOver;
	private AudioSource audioNota;
	private GameObject destinoMaquina;


	// Use this for initialization
	void Start () {
		_isGameOver = false;
		audioNota = GetComponent<AudioSource> ();
		destinoMaquina = GameObject.FindGameObjectWithTag ("MaquinaGenius");
	
	}
	
	// Update is called once per frame
	void Update () {

		if (_isGameOver) return;
		transform.position += new Vector3 (speed, 0, 0) * Time.deltaTime;
		//isso nao e usado aparetemente
		if (transform.position.x < -4f) {
			meteoro.transform.position = new Vector3(meteoro.transform.position.x, meteoro.transform.position.y, 10); ;
		//Comentando essa linha os objetos passam a nao serem mais criados
		}

	}

	void GameEnd()
	{
		_isGameOver = true;
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.CompareTag("MaquinaGenius"))
		{
		meteoro.SetActive(false);
		}
		if (c.CompareTag("BarraSom"))
		{
			audioNota.Play();
			destinoMaquina.SendMessage ("AtivarMaquina");
		}
}
}