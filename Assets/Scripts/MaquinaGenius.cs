using UnityEngine;
using System.Collections;

public class MaquinaGenius : MonoBehaviour {
	private Animator maquina;

	// Use this for initialization
	void Start () {
		maquina = GetComponent<Animator> ();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void AtivarMaquina()
	{
		maquina.SetTrigger("AtivaMaquina");
	}
}