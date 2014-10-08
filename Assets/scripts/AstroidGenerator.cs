using UnityEngine;
using System.Collections;

public class AstroidGenerator : MonoBehaviour
{
		// fields set in the Unity Inspector pane
		public GameObject anchor;
		public GameObject player;
		public GameObject asteroidPrefab;
		public GameObject heartPrefab;
		public GameObject fruitPrefab;
		public Vector3 asteroidPosMin;
		public Vector3 asteroidPosMax;
		public float asteroidScaleMin = 1;
		public float asteroidScaleMax = 5;
		public float asteroidSpeedMult = 0.5f;
	
		public bool ______________________________;
	
		// fields set dynamically
		public ArrayList asteroidInstances = new ArrayList ();
		public double timeSince = 0;
	
		void FixedUpdate ()
		{
				timeSince += Time.deltaTime;
				if (timeSince >= 3) {
						GameObject asteroid = Instantiate (asteroidPrefab) as GameObject;
						Vector3 cPos = Vector3.zero;

						cPos.x = Random.Range (asteroidPosMin.x, asteroidPosMax.x);
						cPos.y = player.transform.position.y + 40f;

						float scaleU = Random.value;
						float scaleVal = Mathf.Lerp (asteroidScaleMin, asteroidScaleMax, scaleU);

						cPos.y = Mathf.Lerp (asteroidPosMin.y, cPos.y, scaleU);
						cPos.z = 100 - 90 * scaleU;

						asteroid.transform.position = cPos;
						asteroid.transform.localScale = Vector3.one * scaleVal;
						asteroid.transform.parent = anchor.transform;
						asteroidInstances.Add (asteroid);

						timeSince = 0;
			
						if (Camera .main.GetComponent<HealthScript> ().LivesLeft () == 1) {
								GameObject heart = Instantiate (heartPrefab) as GameObject;
				
								cPos.x = Random.Range (asteroidPosMin.x, asteroidPosMax.x);
								cPos.y = Mathf.Lerp (asteroidPosMin.y, cPos.y, scaleU);
								cPos.z = 100 - 90 * scaleU;
				
								heart.transform.position = cPos;
								heart.transform.parent = anchor.transform;
						}
				}
		}
}
