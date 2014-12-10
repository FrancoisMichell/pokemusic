using UnityEngine;
using System.Collections;

public class BotaoMute : MonoBehaviour {

	private GameObject botaoON, botaoOFF, minhaCamera;

	// Use this for initialization
	void Start () {
		botaoON = GameObject.FindGameObjectWithTag ("SoundON");
		botaoOFF = GameObject.FindGameObjectWithTag ("SoundOFF");
		minhaCamera = GameObject.FindGameObjectWithTag ("MainCamera");

		botaoON.SetActive (true);
		botaoOFF.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {	
		if (Input.GetMouseButtonDown(0)) {
			Vector2 pos = Vector2.zero;
			
			pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
			Collider2D[] col = Physics2D.OverlapPointAll(pos);
			
			if (col.Length > 0) {
				foreach (Collider2D c in col) {
					if (c.CompareTag("SoundON")){
						botaoON.SetActive(false);
						botaoOFF.SetActive(true);
						minhaCamera.SendMessage("desligaSom");
					}
					if (c.CompareTag("SoundOFF")) {
						botaoON.SetActive(true);
						botaoOFF.SetActive(false);
						minhaCamera.SendMessage("ligaSom");
					}

					
				
			}
		}
	}
}
}
