using UnityEngine;
using System.Collections;

public class CameraGenious : MonoBehaviour {

	private Animator cameraJogo;

	// Use this for initialization
	void Start () {
		cameraJogo = GetComponent <Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void paraScore()
	{
		cameraJogo.SetTrigger ("Genious_Score");

	}
}