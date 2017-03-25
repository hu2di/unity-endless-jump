using UnityEngine;
using System.Collections;

public class btnPlayScript : MonoBehaviour {
	
	public void LoadScene(string nextScene) {
		Application.LoadLevel (nextScene);
	}
}