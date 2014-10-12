using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour 
{
	public float speed;
	private float _offSet;
	
	// Use this for initialization
	void Start()
	{
		_offSet = 0;
		renderer.material.mainTextureOffset = Vector2.zero;
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
