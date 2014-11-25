using UnityEngine;
using System.Collections;

public class PreviewDigManager : MonoBehaviour {

    public Material[] materiaisDigs;
    private int index = 0;

    public Material DefaultDig;
    public Material NatalDig;
    public Material HalloweenDig;


    private bool block;
    private int indexDig = 0;


	// Use this for initialization
	void Start () {
        block = false;

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
                }
            }   
        }
        print(index);

	}

 
    private void mudarDigLeft() {
        if (indexDig == 0) {
            indexDig = 2;
            Invoke("Unblock", 0.2f);
        } else {
            indexDig -= 1;
            Invoke("Unblock", 0.2f);
        }
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
        MudaDig(indexDig);
    }   

    private void Unblock() {
        block = false;
    }
   

    private void MudaDig(int index) {
        renderer.material = materiaisDigs[indexDig];

    }
}
