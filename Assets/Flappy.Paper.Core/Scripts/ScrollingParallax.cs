using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingParallax : MonoBehaviour
{
	public float parallaxSpeed = 1f;
	private Rigidbody2D rb2d;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed * parallaxSpeed, 0);
	}

	void Update()
	{
		if (GameControl.instance.gameOver == true)
		{
			rb2d.velocity = Vector2.zero;
		}
	}
}
