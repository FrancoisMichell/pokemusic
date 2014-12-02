using UnityEngine;
using System.Collections;

public class PlayScript : MonoBehaviour {

    private GameObject cam;

    void Start() {

       // cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButton(0)) {

            Vector2 vetor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] sprites = Physics2D.OverlapPointAll(vetor);

            if (sprites.Length > 0) {
                foreach (Collider2D sprite in sprites) {
                    if (sprite.CompareTag("freemode")) {
                        Application.LoadLevel("Infinity");
                    }
                    if (sprite.CompareTag("Genious")) {
                        Application.LoadLevel("Genius");
                    }
                }
            }
        }
    }
}