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
		var absVelY = Mathf.Abs (body2d.velocity.y);
		var forceX = 0f;
		var forceY = 0f;

		standing = (absVelY <= standingThreshold);

		if (Input.GetKey ("right")) {
			if (absVelX < maxVelocity.x) {
				forceX = standing ? speed : speed * airSpeedMultiplier;
			}
			renderer2d.flipX = false;
		}
		else if (Input.GetKey ("left")) {
			if (absVelX < maxVelocity.x) {
				forceX = standing ? -speed : -speed * airSpeedMultiplier;
			}
			renderer2d.flipX = true;
		}

		if (Input.GetKey ("up")) {
			if (absVelY < maxVelocity.y) {
				forceY = jetSpeed;
			}
		}

		body2d.AddForce (new Vector2 (forceX, forceY));

		if (!standing && Input.GetKey ("up")) {
			animator.SetInteger ("AnimState", 2); // jet
		}
		else if (absVelX > standingThreshold) {
			animator.SetInteger ("AnimState", 1); // walk
		}
		else {
			animator.SetInteger ("AnimState", 0); // idle
		}
	}
}
