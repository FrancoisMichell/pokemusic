using UnityEngine;
using System.Collections;

public class MaquinaGenius : MonoBehaviour {
	private Animator maquina;
    public ParticleSystem notas;
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
        notas.Play();
        Invoke("pararFrescura", 0.5f);
	}

    void pararFrescura() {
        notas.Stop();
        notas.Clear();

    }
}