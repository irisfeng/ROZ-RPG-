using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void LateUpdate () {
		transform.position = player.transform.position;
	}
}
