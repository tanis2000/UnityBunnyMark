using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {
	
	public List<Bunny> bunnies;	
	public static float gravity = 0.5f;
	public static int maxX = 0;
	public static int maxY = 0;
	public static int minX = 0;
	public static int minY = 0;
	public Text fpsLabel;
	public float updateInterval = 0.5f;
	float accum = 0.0f; // FPS accumulated over the interval
	float frames = 0; // Frames drawn over the interval
	float timeleft; // Left time for current interval

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;
		Camera.main.orthographicSize = (float)Screen.height / 2.0f;
		Camera.main.transform.position = new Vector3(Screen.width/2, Screen.height/2, -10);
		bunnies = new List<Bunny>();
		maxX = Screen.width;
		maxY = Screen.height;
		GameObject fpsgo = GameObject.Find("FPS");
		fpsLabel = fpsgo.GetComponent<Text>();
		timeleft = updateInterval;	

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0 || Input.anyKeyDown) {
			addBunnies(1000);
		}

		foreach (var bunny in bunnies) {
			bunny.UpdateMe();
		}
		/*
		foreach (Bunny bunny in bunnies) {
			bunny.posX += bunny.speedX;
			bunny.posY += bunny.speedY;
			bunny.speedY += gravity;
			
			if( bunny.posX > maxX )
			{
				bunny.speedX *= -1;
				bunny.posX = maxX;
			}
			else if( bunny.posX < minX )
			{
				bunny.speedX *= -1;
				bunny.posX = minX;
			}
			
			if( bunny.posY > maxY )
			{
				bunny.speedY *= -0.8f;
				bunny.posY = maxY;
				if( Random.value > 0.5f )
					bunny.speedY -= 3 + Random.value * 4;
			}
			else if( bunny.posY < minY )
			{
				bunny.speedY = 0;
				bunny.posY = minY;
			}
			bunny.transform.position = new Vector2(bunny.posX, bunny.posY);
		}
		*/
		timeleft -= Time.deltaTime;
		accum += Time.timeScale/Time.deltaTime;
		++frames;
		
		// Interval ended - update GUI text and start new interval
		if( timeleft <= 0.0 )
		{
			fpsLabel.text = ("fps: " + (accum/frames).ToString("f2")+"\nBunnies: " + bunnies.Count);
			timeleft = updateInterval;
			accum = 0.0f;
			frames = 0;
		}

	}
	
	public void addBunnies(int count) {
		GameObject bunnyPrefab = Resources.Load("Bunny", typeof(GameObject)) as GameObject;
		Debug.Log (bunnyPrefab);
		for (int i = 0 ; i < count ; i++) {
			GameObject go = Instantiate(bunnyPrefab, new Vector3(0,0,0), Quaternion.identity) as GameObject;
			Debug.Log (go);
			Bunny b = go.GetComponent<Bunny>();
			b.speedX = Random.value * 5;
			b.speedY = Random.value * 5 - 2.5f;
			bunnies.Add(b);
		}
		
	}
}
