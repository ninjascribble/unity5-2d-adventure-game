using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

	public Debris debris;
	public int totalDebris = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D collision) {
		OnTriggerEnter2D (collision.collider);
	}

	void OnTriggerEnter2D (Collider2D target) {
		if (target.gameObject.tag == "Deadly") {
			OnExplode ();
		}
	}

	void OnExplode () {
		var t = gameObject.transform;

		for (int i = 0; i < totalDebris; i++) {
			gameObject.transform.TransformPoint (0, -100, 0);
			var clone = Instantiate (debris, t.position, Quaternion.identity) as Debris;
			var body2d = clone.GetComponent<Rigidbody2D> ();

			body2d.AddForce (Vector3.right * Random.Range (-1000, 1000));
			body2d.AddForce (Vector3.up * Random.Range (500, 2000));
		}

		Destroy (gameObject);
	}
}
