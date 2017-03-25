using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {

	public Vector3 speed = new Vector3(5f,0f,0f);
	public Vector3 jumpForce = new Vector3 (0f, 5f, 0f);

	private bool grounded = false;
	private int currentScore = 0;
	private int coin = 0;
	private int highScore = 0;
	private int quangDuong = 0;

	void FixedUpdate() {
		if (grounded) {
			rigidbody.AddForce (speed, ForceMode.Acceleration);
			if (Input.GetMouseButtonDown (0)) {
				rigidbody.AddForce (jumpForce, ForceMode.VelocityChange);	
			}
		}

		if (transform.position.y < -5) {
			Application.LoadLevel("_Start");		
		}
	}

	void OnCollisionEnter (Collision obj) {
		grounded = true;
	}

	void OnCollisionExit (Collision obj) {
		grounded = false;
	}

	void OnTriggerEnter(Collider powerUp) {
		Destroy(powerUp.gameObject);
		audio.Play ();	
		coin += 1;
	}

	void OnGUI() {
		GUI.color = Color.black;
		quangDuong = (int)transform.localPosition.x;
		currentScore = quangDuong + coin*10;
		highScore = PlayerPrefs.GetInt ("highS", 0);

		if (currentScore > highScore) {
			PlayerPrefs.SetInt("highS",currentScore);		
		}
		GUI.Label (new Rect (5, 5, 100, 20), "Score: " + currentScore);
		GUI.Label (new Rect (5, 25, 100, 20), "HighScore: " + highScore);
	}
}
