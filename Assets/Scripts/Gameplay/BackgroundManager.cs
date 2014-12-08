using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour 
{
	public float speed;
	private float _offSet;

	public ParticleSystem neve;  

    public Material Default;
    public Material Noite;
    public Material Halloween;

    public Material grama, gramaEscura;
    public GameObject grass;


    public GameObject morcego;

    private int bgAtual;

	// Use this for initialization
	void Start()
	{
		_offSet = 0;
        renderer.material.mainTextureOffset = Vector2.zero;

        bgAtual = PlayerPrefs.GetInt("fundo", 0);
		string dig = PlayerPrefs.GetString("dig", "");

		print (dig); 
		if (!dig.Equals("Natal")){
			print ("aqui");
			neve.Stop();
		}

        if (bgAtual == 0) {
            renderer.material = Default;
            grass.renderer.material = grama;
            morcego.SetActive(false);
        }else if(bgAtual == 1){
            renderer.material = Noite;
            grass.renderer.material = gramaEscura;
            morcego.SetActive(false);
            speed = 0;
        } else if (bgAtual == 2) {
            renderer.material = Halloween;
            grass.renderer.material = gramaEscura;
            morcego.SetActive(true);
            speed = 0;
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
