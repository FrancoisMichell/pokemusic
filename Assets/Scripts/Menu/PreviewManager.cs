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

    public GameObject btComprar;
    
    public GameObject grass;
    
    public Material grama;
    public Material gramaEscura;

    private string situacaoNoite = "nao comprado";
    private string situacaoHalloween = "nao comprado";

    private GameObject moeda;
    private int quantMoedas;


    // Use this for initialization
    void Start() {


        situacaoNoite = PlayerPrefs.GetString("noite", "");
        situacaoHalloween = PlayerPrefs.GetString("halloween", "");
        

        quantMoedas = PlayerPrefs.GetInt("moedas", 0);

        block = false;
        materiaisFundo = new Material[3];
        materiaisFundo[0] = Default;
        materiaisFundo[1] = Noite;
        materiaisFundo[2] = Halloween;

        precos = new int[3];
        precos[0] = 00;
        precos[1] = 3300;
        precos[2] = 6600;

        verificaSituacao(0);

        moeda = GameObject.FindGameObjectWithTag("moeda");

        //grass.renderer.material = gramaEscura;
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
                        if (index == 1 && situacaoNoite == "nao comprado") {
                            Comprar(index);
                        } else if (index == 2 && situacaoHalloween == "nao comprado") {
                            Comprar(index);
                        }


                        if (index == 1 && situacaoNoite == "comprado") {
                            PlayerPrefs.SetInt("fundo", 1);
                        } else if (index == 2 && situacaoHalloween == "comprado") {
                            PlayerPrefs.SetInt("fundo", 2);
                        } else if (index == 0) {
                            PlayerPrefs.SetInt("fundo", 0);
                        }

                        Invoke("Unblock", 0.2f);

                        // Apagar essa linha quando a tela de confirmação for implementada, ou a verificação da quantidade de 
                        //moedas
                        

                    }
                }
            }
        }
    }

    private void Comprar(int index) {
        if (quantMoedas >= precos[index]) {
            PlayerPrefs.SetInt("fundo", index);
            alterasituacao(index);
            btComprar.SetActive(false);
            moeda.SendMessage("comprar", precos[index]);
        } else {
            print("nao tem dinheiro");
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

        if (index == 1 || index == 2) {
            grass.renderer.material = gramaEscura;
        } else grass.renderer.material = grama;

        preco.text = precos[index].ToString();
    }
}
