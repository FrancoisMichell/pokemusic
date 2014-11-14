using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {


    private bool _paused;
    private GameObject digglets;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1f;
        _paused = false;

        digglets = GameObject.FindGameObjectWithTag("digglets");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
						Application.LoadLevel("Menu");
				}
        if (Input.GetKeyDown(KeyCode.P)){
            if (!_paused){
                Pause();
            }else{
                Continue();
            }
        }
	}

    void Pause(){
        _paused = true;
        Time.timeScale = 0f;
        digglets.SendMessage("Pausar");
    }
    void Continue(){
        _paused = false;
        Time.timeScale = 1f;
        digglets.SendMessage("Continuar");
    }
}
