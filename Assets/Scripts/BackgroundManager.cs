using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour 
{
	public float speed;
	private float _offSet;

    public Material Default;
    public Material Noite;
    public Material Halloween;

    public GameObject morcego;

    private int bgAtual;

	// Use this for initialization
	void Start()
	{
		_offSet = 0;
        renderer.material.mainTextureOffset = Vector2.zero;

        bgAtual = PlayerPrefs.GetInt("fundo", 0);

        if (bgAtual == 0) {
            renderer.material = Default;
            morcego.SetActive(false);
        }else if(bgAtual == 1){
            renderer.material = Noite;
            morcego.SetActive(false);

        } else if (bgAtual == 2) {
            renderer.material = Halloween;
            morcego.SetActive(true);

        }



	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		_offSet += speed;
		if (_offSet > 1f)   
			_offSet -= 1f;
		
		renderer.material.mainTextureOffset = Vector2.right * _offSet;
	}
}
