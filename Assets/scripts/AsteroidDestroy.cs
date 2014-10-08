using UnityEngine;
using System.Collections;

public class AsteroidDestroy : MonoBehaviour
{
		void OnCollisionEnter (Collision collision)
		{
//				if (collision.gameObject.name == "Asteroid") {
				Destroy (collision.gameObject); // destroys the thing this script bumped into
//				}
		
		}
}
