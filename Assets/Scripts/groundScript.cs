using UnityEngine;
using System.Collections;

public class groundScript : MonoBehaviour {

	public GameObject prefab;
	public GameObject powerUp;

	public int numberOfObjects = 10;
	public Vector3 startPosition = new Vector3(0f,0f,0f);

	public float minGapX;
	public float maxGapX;
	public float minGapY;
	public float maxGapY;

	public float minY;
	public float maxY;

	public float minScale;
	public float maxScale;

	private GameObject[] ground;
	private Vector3 nextPosition;
	private int front = 0;

	// Use this for initialization
	void Start () {
		ground = new GameObject[numberOfObjects];
		for (int i = 0; i < numberOfObjects; i++) {
			GameObject temp = Instantiate(prefab,startPosition,Quaternion.identity) as GameObject;
			ground[i] = temp;
		}

		nextPosition = startPosition;

		for (int i = 0; i < numberOfObjects; i++) {
			rePosition(i);		
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tempPos = Camera.main.WorldToViewportPoint (ground[front].transform.position);
		if (tempPos.x < -1) {
			rePosition(front);		
		}
	}

	private void rePosition(int index) {
		GameObject tempGround = ground [index];
		tempGround.transform.position = nextPosition;

		float newXscale = Random.Range(minScale,maxScale);
		Vector3 newScale = new Vector3 (newXscale,tempGround.transform.localScale.y,tempGround.transform.localScale.z);

		tempGround.transform.localScale = newScale;

		float newX = nextPosition.x + tempGround.transform.localScale.x + Random.Range (minGapX, maxGapX);
		float newY = nextPosition.y + tempGround.transform.localScale.y + Random.Range (minGapY, maxGapY);
		if (newY < minY) {
			newY = minY;		
		}
		if (newY > maxY) {
			newY = maxY;		
		}

		nextPosition = new Vector3 (newX, newY, 0f);
		front += 1;
		if (front > numberOfObjects - 1) {
			front = 0;		
		}

		if (Random.Range (1, 5) > 2) {
			Instantiate(powerUp, new Vector3(newX, newY+1, 0),Quaternion.identity);		
		}
	}
}
