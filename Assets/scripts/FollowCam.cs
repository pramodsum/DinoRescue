﻿using UnityEngine;
using System.Collections;


public class FollowCam : MonoBehaviour
{
		static public FollowCam S; // a FollowCam Singleton
	
		// fields set in the Unity Inspector pane
		public float easing = 0.05f;
		public bool ____________________________;
	
		// fields set dynamically
		public GameObject poi;
		public Vector2 minXY;
		public float camZ;
	
		void Awake ()
		{
				S = this;
				camZ = this.transform.position.z;
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				Vector3 destination = poi.transform.position;
				//Limit the Y to minimum values
				destination.x = 0.0f;
				destination.y = Mathf.Max (minXY.y, destination.y);
				//Interpolate from the current Camera position toward destination
				destination = Vector3.Lerp (transform.position, destination, easing);
				// Retain a destination.z of camZ
				destination.z = camZ;
				// Set the camera to the destination
				transform.position = destination;	
				// Set the orthographicSize of the Camera to keep Ground in view
				this.camera.orthographicSize = 7;
		}
}