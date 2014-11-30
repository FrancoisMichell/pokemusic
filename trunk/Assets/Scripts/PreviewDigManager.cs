using UnityEngine;
using System.Collections;

public class PreviewDigManager : MonoBehaviour {

    public Material[] materiaisDigs;
    

    public Material DefaultDig;
    public Material NatalDig;
    public Material HalloweenDig;


    private bool block;
    private int indexDig = 0;

    private string situacaoDefaultDig;
    private string situacaoNoiteDig;
    private string situacaoHalloweenDig;

    public GameObject btComprarDig;

	// Use this for initialization
	void Start () {
        block = false;

        situacaoDefaultDig = PlayerPrefs.GetString("defaultDig", "");
        situacaoNoiteDig = PlayerPrefs.GetString("noiteDig", "");
        situacaoHalloweenDig = PlayerPrefs.GetString("halloweenDig", "");

        materiaisDigs = new Material[3];
        materiaisDigs[0] = DefaultDig;
        materiaisDigs[1] = NatalDig;
        materiaisDigs[2] = HalloweenDig;
        
	}
	
	// Update is called once per frame
	void Update () {
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
                        alteraDigg(indexDig);
                        alterasituacao(indexDig);
                        Invoke("Unblock", 0.2f);
                    }
                }
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

    }

    private void alterasituacao(int index) {
        if (index == 0) {
            situacaoDefaultDig = "comprado";
            PlayerPrefs.SetString("defaultDig", situacaoDefaultDig);
        } else if (index == 1) {
            situacaoNoiteDig = "comprado";
            PlayerPrefs.SetString("noiteDig", situacaoNoiteDig);
        } else if (index == 2) {
            situacaoHalloweenDig = "comprado";
            PlayerPrefs.SetString("halloweenDig", situacaoHalloweenDig);
        }

    }

    private void verificaSituacao(int index) {
        if (index == 0) {
            if (situacaoDefaultDig == "comprado") {
                btComprarDig.SetActive(false);
            } else {
                btComprarDig.SetActive(true);
            }
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
}
