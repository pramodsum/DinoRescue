using UnityEngine;
using System.Collections;

public class HeartCollider : MonoBehaviour
{
		void OnTriggerEnter2D (Collider2D collider)
		{
				Destroy (this.gameObject);

				if (collider.gameObject.tag == "Player")
						Camera.main.GetComponent<HealthScript> ().Heal ();
		}
}
