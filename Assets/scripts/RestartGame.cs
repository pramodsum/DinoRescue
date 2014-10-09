using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour
{
		// Update is called once per frame
		void FixedUpdate ()
		{
				if (Input.GetKeyDown (KeyCode.Return)) {
						Application.LoadLevel (0);
				}
		}
}
