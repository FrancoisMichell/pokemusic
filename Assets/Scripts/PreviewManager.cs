using UnityEngine;
using System.Collections;

public class PreviewManager : MonoBehaviour {


    public Material[] materiaisFundo;
    public int[] precos;

    private int index = 0;

    public TextMesh preco;

    public Material Default;
    public Material Noite;
    public Material Halloween;

    private bool block;

    private string testando;

    public GameObject btComprar;
    public GameObject grass;

    //private string situacaoDefault = "comprado";
    private string situacaoNoite = "nao comprado";
    private string situacaoHalloween = "nao comprado";

    // Use this for initialization
    void Start() {
        block = false;
        materiaisFundo = new Material[3];
        materiaisFundo[0] = Default;
        materiaisFundo[1] = Noite;
        materiaisFundo[2] = Halloween;

        precos = new int[3];
        precos[0] = 00;
        precos[1] = 20;
        precos[2] = 30;

        situacaoNoite = PlayerPrefs.GetString("noite", "");
        situacaoHalloween = PlayerPrefs.GetString("halloween", "");

        verificaSituacao(0);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(0)) {


            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] col = Physics2D.OverlapPointAll(pos);

            if (col.Length > 0 && block == false) {

                foreach (Collider2D c in col) {
                    if (c.CompareTag("leftFundo")) {
                        block = true;
                        Invoke("mudarBgLeft", 0.1f);
                    }

                    if (c.CompareTag("RightFundo")) {
                        block = true;
                        Invoke("mudarBgRight", 0.1f);
                    }

                    if (c.CompareTag("ComprarFundo")) {
                        block = true;
                        PlayerPrefs.SetInt("fundo", index);
                        alterasituacao(index);
                        Invoke("Unblock", 0.2f);

                        // Apagar essa linha quando a tela de confirmação for implementada, ou a verificação da quantidade de 
                        //moedas
                        btComprar.SetActive(false);

                    }
                }
            }
        }
    }

    private void alterasituacao(int index) {
        if (index == 1) {
            situacaoNoite = "comprado";
            PlayerPrefs.SetString("noite", situacaoNoite);
        } else if (index == 2) {
            situacaoHalloween = "comprado";
            PlayerPrefs.SetString("halloween", situacaoHalloween);
        }

    }

    private void verificaSituacao(int index) {
        if (index == 0) {
            btComprar.SetActive(false);
        } else if (index == 1) {
            if (situacaoNoite == "comprado") {
                btComprar.SetActive(false);
            } else {
                btComprar.SetActive(true);
            }
        } else if (index == 2) {
            if (situacaoHalloween == "comprado") {
                btComprar.SetActive(false);
            } else {
                btComprar.SetActive(true);
            }
        }
    }

    private void mudarBgLeft() {
        if (index == 0) {
            index = 2;
            Invoke("Unblock", 0.2f);
        } else {
            index -= 1;
            Invoke("Unblock", 0.2f);
        }
        verificaSituacao(index);
        MudaBg(index);
    }

    private void mudarBgRight() {
        if (index == 2) {
            index = 0;
            Invoke("Unblock", 0.2f);
        } else {
            index += 1;
            Invoke("Unblock", 0.2f);
        }
        verificaSituacao(index);
        MudaBg(index);
    }

    private void Unblock() {
        block = false;
    }

    private void MudaBg(int index) {
        renderer.material = materiaisFundo[index];

        if (index == 2) {
            grass.SetActive(false);
        } else grass.SetActive(true);

        preco.text = precos[index].ToString();
    }
}
