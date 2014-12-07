using UnityEngine;
using System.Collections.Generic;

public class ChallangeController : MonoBehaviour {

	public float AlturaAtual;
	
	public GameObject nuvemDo, nuvemRe, nuvemMi, nuvemFa, nuvemSol, nuvemLa, nuvemSi;	
	public List<GameObject> nuvem;
	private List<string> sequencia;
	private GameObject nuvemSeguinte, digglets;
	public GameObject nuvemAtual;
	private int contador;

	
	// Use this for initialization
	void Start () {

		sequencia = new List<string> ();

		sequencia.Add ("diglettSi");
		sequencia.Add ("diglettDo");
		sequencia.Add ("diglettFa");
		sequencia.Add ("diglettSol");
		sequencia.Add ("diglettMi");
		sequencia.Add ("diglettDo");
		sequencia.Add ("diglettSi");
		sequencia.Add ("diglettFa");
		sequencia.Add ("diglettRe");
		digglets = GameObject.FindGameObjectWithTag ("digglets");
		tocarSequencia ();
		Invoke ("enviarSequencia", 1f);
	}
	
	// Update is called once per frame
	void Update () {		// aqui faz a comparaçao e identifica que o ultimo objeto foi lancado
		//metodo finish play faz com que a sequencia nao se repita

	}
	
	void tocarSequencia(){
		foreach (string nome in sequencia) {		 
			digglets.SendMessage("tocar",nome);
		}
	}

	void enviarSequencia(){
		digglets.SendMessage ("receberSequencia", sequencia);
		digglets.SendMessage ("Upall");
	}

	void lancar(string nota){

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
		else if (nota.Equals ("diglettSi")) {
			nuvemAtual = Instantiate (nuvemSi) as GameObject;
		}


		if (contador > 8 && contador < 18) {
			nuvemAtual.transform.position = new Vector3(nuvemAtual.transform.position.x, -1.3f, 10);
		}

		else if (contador > 17 && contador < 26) {
			nuvemAtual.transform.position = new Vector3(nuvemAtual.transform.position.x, -2.9f, 10);
		}
		contador += 1;
	}



}
