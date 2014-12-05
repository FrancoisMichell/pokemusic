using UnityEngine;
using System.Collections;

public class coinsControl : MonoBehaviour {
    public TextMesh moedas;

    private int quantMoedas;
	// Use this for initialization
	void Start () {
        quantMoedas = PlayerPrefs.GetInt("moedas", 0);
        moedas.text = "" + quantMoedas;
	}
	
    void comprar(int preco){
        quantMoedas -= preco;
        PlayerPrefs.SetInt("moedas", quantMoedas);
        moedas.text = "" + quantMoedas;
    }
}
