using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 150f;
	public Vector2 maxVelocity = new Vector2 (60, 100);

	private Rigidbody2D body2d;
	private SpriteRenderer renderer2d;
	private Animator animator;

	void Awake () {
		body2d = GetComponent<Rigidbody2D> ();
		renderer2d = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var absVelX = Mathf.Abs (body2d.velocity.x);
		var forceX = 0f;
		var forceY = 0f;

		if (Input.GetKey ("right")) {
			if (absVelX < maxVelocity.x) {
				forceX = speed;
			}
			renderer2d.flipX = false;
			animator.SetInteger ("AnimState", 1);
		}
		else if (Input.GetKey ("left")) {
			if (absVelX < maxVelocity.x) {
				forceX = -speed;
			}
			renderer2d.flipX = true;
			animator.SetInteger ("AnimState", 1);
		}
		else {
			animator.SetInteger ("AnimState", 0);
		}

		body2d.AddForce (new Vector2 (forceX, forceY));
	}
}
