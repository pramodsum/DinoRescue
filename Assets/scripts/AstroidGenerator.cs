using UnityEngine;
using System.Collections;

public class AstroidGenerator : MonoBehaviour
{
		// fields set in the Unity Inspector pane
		public int numAsteroids = 40;
		public GameObject asteroidPrefab;
		public Vector3 asteroidPosMin;
		public Vector3 asteroidPosMax;
		public float asteroidScaleMin = 1;
		public float asteroidScaleMax = 5;
		public float asteroidSpeedMult = 0.5f;
	
		public bool ______________________________;
	
		// fields set dynamically
		public GameObject[] asteroidInstances;
	
		void Awake ()
		{
				asteroidInstances = new GameObject[numAsteroids];
				GameObject anchor = GameObject.Find ("AstroidAnchor");
				GameObject asteroid;
				for (int i = 0; i < numAsteroids; i++) {
						asteroid = Instantiate (asteroidPrefab) as GameObject;
						Vector3 cPos = Vector3.zero;
						cPos.x = Random.Range (asteroidPosMin.x, asteroidPosMax.x);
						cPos.y = Random.Range (asteroidPosMin.y, asteroidPosMax.y);
						float scaleU = Random.value;
						float scaleVal = Mathf.Lerp (asteroidScaleMin, asteroidScaleMax, scaleU);
						cPos.y = Mathf.Lerp (asteroidPosMin.y, cPos.y, scaleU);
						cPos.z = 100 - 90 * scaleU;
						asteroid.transform.position = cPos;
						asteroid.transform.localScale = Vector3.one * scaleVal;
						asteroid.transform.parent = anchor.transform;
						asteroidInstances [i] = asteroid;
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
				foreach (GameObject asteroid in asteroidInstances) {
						float scaleVal = asteroid.transform.localScale.x;
						Vector3 cPos = asteroid.transform.position;
						cPos.x -= scaleVal * Time.deltaTime * asteroidSpeedMult;
						if (cPos.x <= asteroidPosMin.x) {
								cPos.x = asteroidPosMax.x;
						}
						asteroid.transform.position = cPos;
				}
		}
}
