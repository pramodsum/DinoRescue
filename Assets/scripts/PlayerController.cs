using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
		private bool isGrounded = true;
		public Sprite[] sprites;
		SpriteRenderer spriteRenderer;

		// The force which is added when the player jumps
		// This can be changed in the Inspector window
		public Vector2 jumpForce = new Vector2 (0, 1000);

		void Start ()
		{
				spriteRenderer = renderer as SpriteRenderer;
		}

		void FixedUpdate ()
		{
				spriteRenderer.sprite = sprites [0];

				if (Input.GetKey (KeyCode.LeftArrow)) {
						transform.position = new Vector3 (transform.position.x - 0.15f, transform.position.y, 0);
				} else if (Input.GetKey (KeyCode.RightArrow)) {
						transform.position = new Vector3 (transform.position.x + 0.15f, transform.position.y, 0);
				}
				if (Input.GetKey (KeyCode.Space) && isGrounded) {
						spriteRenderer.sprite = sprites [1];
						rigidbody2D.velocity = Vector2.zero;
						rigidbody2D.AddForce (jumpForce);
				} 
		}

		public static float CalculateJumpVerticalSpeed (float targetJumpHeight)
		{
				// From the jump height and gravity we deduce the upwards speed 
				// for the character to reach at the apex.
				return Mathf.Sqrt (2f * targetJumpHeight * Physics2D.gravity.y);
		}
	
		void OnCollisionStay (Collision coll)
		{
				isGrounded = true;
		}
		void OnCollisionExit (Collision coll)
		{
				if (isGrounded) {
						isGrounded = false;   
				}
		}
	

}
