using UnityEngine;
using System.Collections;

public class AsteroidDestroy : MonoBehaviour
{
		public string colliderName = "";
		void OnTriggerEnter2D (Collider2D collider)
		{
				colliderName = collider.gameObject.name;
				Destroy (this.gameObject);
		}
}
