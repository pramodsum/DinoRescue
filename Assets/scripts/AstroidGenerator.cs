using UnityEngine;
using System.Collections;

public class AstroidGenerator : MonoBehaviour
{
		// fields set in the Unity Inspector pane
		public int numAsteroids = 40;
		public GameObject[] asteroidPrefabs;
		public Vector3 asteroidPosMin;
		public Vector3 asteroidPosMax;
		public float asteroidScaleMin = 1;
		public float asteroidScaleMax = 5;
		public float asteroidSpeedMult = 0.5f;
	
		public bool ______________________________;
	
		// fields set dynamically
		public GameObject[] cloudInstances;
	
		void Awake ()
		{
				cloudInstances = new GameObject[numClouds];
				GameObject anchor = GameObject.Find ("AstroidAnchor");
				GameObject cloud;
				for (int i = 0; i < numClouds; i++) {
						int prefabNum = Random.Range (0, cloudPrefabs.Length - 1);
						cloud = Instantiate (cloudPrefabs [prefabNum]) as GameObject;
						Vector3 cPos = Vector3.zero;
						cPos.x = Random.Range (cloudPosMin.x, cloudPosMax.x);
						cPos.y = Random.Range (cloudPosMin.y, cloudPosMax.y);
						float scaleU = Random.value;
						float scaleVal = Mathf.Lerp (cloudScaleMin, cloudScaleMax, scaleU);
						cPos.y = Mathf.Lerp (cloudPosMin.y, cPos.y, scaleU);
						cPos.z = 100 - 90 * scaleU;
						cloud.transform.position = cPos;
						cloud.transform.localScale = Vector3.one * scaleVal;
						cloud.transform.parent = anchor.transform;
						cloudInstances [i] = cloud;
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
				foreach (GameObject cloud in cloudInstances) {
						float scaleVal = cloud.transform.localScale.x;
						Vector3 cPos = cloud.transform.position;
						cPos.x -= scaleVal * Time.deltaTime * cloudSpeedMult;
						if (cPos.x <= cloudPosMin.x) {
								cPos.x = cloudPosMax.x;
						}
						cloud.transform.position = cPos;
				}
		}
}
