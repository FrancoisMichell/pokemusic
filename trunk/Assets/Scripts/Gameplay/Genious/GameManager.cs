using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {


    private bool _paused;
    private GameObject digglets;
    public GameObject btPausa, btPlay, telaPausa;

    // Use this for initialization
    void Start() {
        Time.timeScale = 1f;
        _paused = false;

        telaPausa.SetActive(false);

        digglets = GameObject.FindGameObjectWithTag("digglets");

        btPausa = GameObject.FindGameObjectWithTag("btPause");
        btPlay = GameObject.FindGameObjectWithTag("btPlay");

        //btPlay.SetActive(false);

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.LoadLevel("Menu");
        }

        if (Input.GetMouseButtonDown(0)) {
            Vector2 pos = Vector2.zero;

            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D[] col = Physics2D.OverlapPointAll(pos);

            if (col.Length > 0) {
                foreach (Collider2D c in col) {
                    if (c.CompareTag("colPausa"))
                        if (!_paused) {
                            Pause();
                        } else {
                            Continue();
                        }

                }
            }
        }
    }

    void Pause() {
        _paused = true;
        telaPausa.SetActive(true);
        btPausa.SetActive(false);
        Time.timeScale = 0f;
        digglets.SendMessage("Pausar");
    }
    void Continue() {
        btPausa.SetActive(true);
        telaPausa.SetActive(false);
        _paused = false;
        Time.timeScale = 1f;
        digglets.SendMessage("Continuar");
    }
}
