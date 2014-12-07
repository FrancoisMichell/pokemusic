using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	public GameObject nuvemDo, nuvemRe, nuvemMi, nuvemFa, nuvemSol, nuvemLa, nuvemSi;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void lancar(string nota){

		GameObject nuvemAtual;

		if (nota.Equals ("diglettDo")) {
			nuvemAtual = Instantiate (nuvemDo) as GameObject;
		}
		else if (nota.Equals ("diglettRe")) {
			nuvemAtual = Instantiate (nuvemRe) as GameObject;
		}
		else if (nota.Equals ("diglettMi")) {
			nuvemAtual = Instantiate (nuvemMi) as GameObject;
		}
		else if (nota.Equals ("diglettFa")) {
			nuvemAtual = Instantiate (nuvemFa) as GameObject;
		}
		else if (nota.Equals ("diglettSol")) {
			nuvemAtual = Instantiate (nuvemSol) as GameObject;
		}
		else if (nota.Equals ("diglettLa")) {
			nuvemAtual = Instantiate (nuvemLa) as GameObject;
		}
		else{
			nuvemAtual = Instantiate (nuvemSi) as GameObject;
		}
		print (nuvemAtual);

	}
}