﻿using UnityEngine;
using System.Collections;

public class PreviewDigManager : MonoBehaviour {

    public Material[] materiaisDigs;
    public int[] precos;

    public TextMesh preco;

    public Material DefaultDig;
    public Material NatalDig;
    public Material HalloweenDig;

    private bool block;
    private int indexDig = 0;

    private string situacaoDefaultDig = "comprado";
    private string situacaoNoiteDig = "nao comprado";
    private string situacaoHalloweenDig = "nao comprado";

    public GameObject btComprarDig;

    private int quantMoedas;
    private GameObject moedas;
	public GameObject balaoPobre;
	public GameObject balaoComprado;

    // Use this for initialization
    void Start() {
        block = false;

        situacaoNoiteDig = PlayerPrefs.GetString("noiteDig", "");
        situacaoHalloweenDig = PlayerPrefs.GetString("halloweenDig", "");

        moedas = GameObject.FindGameObjectWithTag("moeda");
        quantMoedas = PlayerPrefs.GetInt("moedas", 0);

        materiaisDigs = new Material[3];
        materiaisDigs[0] = DefaultDig;
        materiaisDigs[1] = NatalDig;
        materiaisDigs[2] = HalloweenDig;

        precos = new int[3];
        precos[0] = 00;
        precos[1] = 3300;
        precos[2] = 6600;
        
        verificaSituacao(0);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(0)) {

            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] col = Physics2D.OverlapPointAll(pos);

            if (col.Length > 0 && block == false) {

                foreach (Collider2D c in col) {

                    if (c.CompareTag("leftDigg")) {
                        block = true;
                        Invoke("mudarDigLeft", 0.1f);
                    }
                    if (c.CompareTag("RightDigg")) {
                        block = true;
                        Invoke("mudarDigRight", 0.1f);
                    }
                    if (c.CompareTag("ComprarDigg")) {
						block = true;
						print (situacaoHalloweenDig);
                        if (indexDig == 1 && situacaoNoiteDig == "nao comprado") {
                            Comprar(indexDig);
                            
                        } else if (indexDig == 2 && situacaoHalloweenDig == "nao comprado") {
                            Comprar(indexDig);
                            
                        }


                        if (indexDig == 1 && situacaoNoiteDig == "comprado") {
                            PlayerPrefs.SetString("dig", "Natal");
                        } else if (indexDig == 2 && situacaoHalloweenDig == "comprado") {
                            PlayerPrefs.SetString("dig", "Halloween");
                        } else if (indexDig == 0) {
                            PlayerPrefs.SetString("dig", "Default");
                        }
                        Invoke("Unblock", 0.2f);
                        // Apagar essa linha quando a tela de confirmação for implementada, ou a verificação da quantidade de 
                        //moedas

                    }
                }
            }
        }

    }

    private void Comprar(int indexDig) {
        if (quantMoedas >= precos[indexDig]) {
            alterasituacao(indexDig);
            btComprarDig.SetActive(false);
			balaoComprado.transform.position = new Vector3(balaoComprado.transform.position.x, balaoComprado.transform.position.y, -1);
            moedas.SendMessage("comprar", precos[indexDig]);
			Invoke("balaoAtras", 2f);
        } else {
			balaoPobre.transform.position = new Vector3(balaoPobre.transform.position.x, balaoPobre.transform.position.y, -1);
			Invoke("balaoAtras", 2f);
            print("nao tem dinheiro");
        }
    }

	public void balaoAtras(){
		balaoPobre.transform.position = new Vector3(balaoPobre.transform.position.x, balaoPobre.transform.position.y, 1);
		balaoComprado.transform.position = new Vector3(balaoComprado.transform.position.x, balaoComprado.transform.position.y, 1);
	
	}

    private void alterasituacao(int index) {
        if (index == 0) {
            situacaoDefaultDig = "comprado";
            PlayerPrefs.SetString("defaultDig", situacaoDefaultDig);
            PlayerPrefs.SetString("dig", "Default");
        } else if (index == 1) {
            situacaoNoiteDig = "comprado";
            PlayerPrefs.SetString("noiteDig", situacaoNoiteDig);
            PlayerPrefs.SetString("dig", "Natal");
        } else if (index == 2) {
            situacaoHalloweenDig = "comprado";
            PlayerPrefs.SetString("halloweenDig", situacaoHalloweenDig);
            PlayerPrefs.SetString("dig", "Halloween");
        }

    }

    private void verificaSituacao(int index) {
        if (index == 0) {
            btComprarDig.SetActive(false);
        } else if (index == 1) {
            if (situacaoNoiteDig == "comprado") {
                btComprarDig.SetActive(false);
            } else {
                btComprarDig.SetActive(true);
            }
        } else if (index == 2) {
            if (situacaoHalloweenDig == "comprado") {
                btComprarDig.SetActive(false);
            } else {
                btComprarDig.SetActive(true);
            }
        }
    }
    private void alteraDigg(int index) {
        if (index == 0) {
            PlayerPrefs.SetString("dig", "Default");
        } else if (index == 1) {
            PlayerPrefs.SetString("dig", "Natal");
        } else if (index == 2) {
            PlayerPrefs.SetString("dig", "Halloween");
        }
    }


    private void mudarDigLeft() {
        if (indexDig == 0) {
            indexDig = 2;
            Invoke("Unblock", 0.2f);
        } else {
            indexDig -= 1;
            Invoke("Unblock", 0.2f);
        }
        verificaSituacao(indexDig);
        MudaDig(indexDig);
    }
    private void mudarDigRight() {
        if (indexDig == 2) {
            indexDig = 0;
            Invoke("Unblock", 0.2f);
        } else {
            indexDig += 1;
            Invoke("Unblock", 0.2f);
        }
        verificaSituacao(indexDig);
        MudaDig(indexDig);
    }

    private void Unblock() {
        block = false;
    }


    private void MudaDig(int index) {
        renderer.material = materiaisDigs[indexDig];
        preco.text = precos[indexDig].ToString();

    }

}
