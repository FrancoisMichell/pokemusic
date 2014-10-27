using UnityEngine;
using System.Collections;

public class Levels : MonoBehaviour{

	private GameObject Launcher, Player;

	// Use this for initialization
	void Start () {
		Launcher = GameObject.FindGameObjectsWithTag("Launcher");
		Player = GameObject.FindGameObjectsWithTag("diglet");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
