using UnityEngine;
using System.Collections;

public class PreviewManager : MonoBehaviour {


    public Material[] materiaisFundo;

    private int index = 0;


    public Material Default;
    public Material Noite;
    public Material Halloween;

    private bool block;

    private string testando;
    
    // Use this for initialization
    void Start() {
        block = false;
        materiaisFundo = new Material[3];
        materiaisFundo[0] = Default;
        materiaisFundo[1] = Noite;
        materiaisFundo[2] = Halloween;

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
                        Invoke("Unblock", 0.2f);
                    }
                }
            }
            print(index);
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
        MudaBg(index);
    }

    private void Unblock() {
        block = false;


    }
    private void MudaBg(int index) {
        renderer.material = materiaisFundo[index];
        

    }
}
    