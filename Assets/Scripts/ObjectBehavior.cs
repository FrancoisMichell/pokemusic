using UnityEngine;
using System.Collections;


public class ObjectBehavior : MonoBehaviour {
	public float speed;
	public GameObject meteoro;
	private bool _isGameOver;
	private AudioSource audioNota;
	private int teste;
	private GameObject digglets;
	private int controle = 0;
	private int currentSpeed;


	// Use this for initialization
	void Start () {
		_isGameOver = false;
		audioNota = GetComponent<AudioSource>();
	
		GameObject go = GameObject.Find ("digglets");
		ObjectController speedController = go.GetComponent <ObjectController> ();
		currentSpeed = speedController.maxNuvem;

	}
	
	// Update is called once per frame
	void Update () {

		if (_isGameOver) return;
			transform.position += new Vector3 (speed, 0, 0) * Time.deltaTime;
		if (transform.position.x < -10f) {
			meteoro.SetActive(false);
			//Comentando essa linha os objetos passam a nao serem mais criados
		
	}
//		if (controle == currentSpeed){
//			digglets.SendMessage("Upall");
// 
//		}
	}

	void GameEnd()
	{
		_isGameOver = true;
	}
	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.CompareTag("BarraSom"))
		{
			audioNota.Play();

		}
		if (c.CompareTag("BarraSom2"))
		{
			audioNota.Play();
					
		}

}
}