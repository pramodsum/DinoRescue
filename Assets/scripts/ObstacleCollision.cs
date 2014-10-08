using UnityEngine;
using System.Collections;

public class ObstacleCollision : MonoBehaviour
{
		void OnTriggerEnter2D (Collider2D collider)
		{
				if (collider.gameObject.tag == "Player")
						Camera.main.GetComponent<HealthScript> ().Die ();
		}
}
