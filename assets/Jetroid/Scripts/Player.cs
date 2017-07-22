using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 150f;
	public float jetSpeed = 200f;
	public Vector2 maxVelocity = new Vector2 (60, 100);
	public bool standing;
	public float standingThreshold = 4f;
	public float airSpeedMultiplier = 0.3f;

	private Rigidbody2D body2d;
	private SpriteRenderer renderer2d;
	private Animator animator;
	private PlayerController controller;

	void Awake () {
		body2d = GetComponent<Rigidbody2D> ();
		renderer2d = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
		controller = GetComponent<PlayerController> ();
	}

	void FixedUpdate () {
		var absVelX = Mathf.Abs (body2d.velocity.x);
		var absVelY = Mathf.Abs (body2d.velocity.y);
		var forceX = speed * controller.moving.x;
		var forceY = jetSpeed * controller.moving.y;

		standing = (absVelY <= standingThreshold);

		if (!standing) {
			forceX *= airSpeedMultiplier;
		}

		body2d.AddForce (new Vector2 (forceX, forceY));
	}

	void Update () {
		var absVelY = Mathf.Abs (body2d.velocity.y);

		if (controller.moving.x != 0) {
			renderer2d.flipX = controller.moving.x < 0;
			animator.SetInteger ("AnimState", 1); // walk
		} else {
			animator.SetInteger ("AnimState", 0); // idle
		}

		if (controller.moving.y > 0) {
			animator.SetInteger ("AnimState", 2); // jets on
		} else if (absVelY > 0 && !standing) {
			animator.SetInteger ("AnimState", 3); // jets off
		}
	}
}
