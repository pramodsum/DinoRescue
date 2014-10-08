using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
		private bool isGrounded = true;
		public Sprite[] sprites;
		SpriteRenderer spriteRenderer;

		void Start ()
		{
				spriteRenderer = renderer as SpriteRenderer;
		}

		void FixedUpdate ()
		{
				spriteRenderer.sprite = sprites [0];

				if (Input.GetKey (KeyCode.LeftArrow)) {
						transform.position = new Vector3 (transform.position.x - 0.5f, transform.position.y, 0);
				} else if (Input.GetKey (KeyCode.RightArrow)) {
						transform.position = new Vector3 (transform.position.x + 0.5f, transform.position.y, 0);
				}
				if (Input.GetKey (KeyCode.Space) && isGrounded) {
						spriteRenderer.sprite = sprites [1];
						rigidbody2D.AddForce (Vector3.up * 2.0f, ForceMode2D.Impulse);
				} 
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
