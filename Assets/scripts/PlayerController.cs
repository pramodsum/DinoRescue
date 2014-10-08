using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
		private bool isGrounded = true;
		public Sprite[] sprites;
		SpriteRenderer spriteRenderer;
		float PlayerSpeed = 10.0f;

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

				//Amount to move
				// Input.GetAxis MAKES MOOVEMENT LEFT TO RIGHT WITH SMOOTHING
				float amountToMove = Input.GetAxis ("Horizontal") * PlayerSpeed * Time.deltaTime;
		
				//When Players reaches desired (L/R)possition make him stop
				if (transform.position.x <= -8.25f)
						transform.position = new Vector3 (-8.25f, transform.position.y, transform.position.z);
				else if (transform.position.x >= 8.0f)
						transform.position = new Vector3 (8.0f, transform.position.y, transform.position.z);
		
				//Move the Player
				transform.Translate (Vector3.right * amountToMove);

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
