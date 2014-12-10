using UnityEngine;
using System.Collections;

public class CameraInfinity : MonoBehaviour {
	private GameObject minhaCamera;

	// Use this for initialization
	void Start () {
		minhaCamera = GameObject.FindGameObjectWithTag ("MainCamera");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void ligaSom() {
		minhaCamera.audio.volume = 1;
}
	void desligaSom() {
		minhaCamera.audio.volume = 0;
	}
}
