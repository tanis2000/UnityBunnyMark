using UnityEngine;
using System.Collections;

public class Bunny : MonoBehaviour {

	public float posX = 0;
	public float posY = 0;
	public float speedX = 0;
	public float speedY = 0;
	private Vector2 newPos = new Vector2();
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		posX += speedX;
		posY += speedY;
		speedY += Game.gravity;
		
		if( posX > Game.maxX )
		{
			speedX *= -1;
			posX = Game.maxX;
		}
		else if( posX < Game.minX )
		{
			speedX *= -1;
			posX = Game.minX;
		}
		
		if( posY > Game.maxY )
		{
			speedY *= -0.8f;
			posY = Game.maxY;
			if( Random.value > 0.5f )
				speedY -= 3 + Random.value * 4;
		}
		else if( posY < Game.minY )
		{
			speedY = 0;
			posY = Game.minY;
		}
		newPos.x = posX;
		newPos.y = posY;
		transform.position = newPos;

	}
}
