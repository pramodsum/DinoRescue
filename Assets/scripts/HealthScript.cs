using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{
		public int lives;
		private int full = 6;
		GameObject lives_text;

		// Use this for initialization
		void Start ()
		{
				lives = full;
				lives_text = GameObject.Find ("lives_text");
		}

		void FixedUpdate ()
		{
				lives_text.guiText.text = lives.ToString ();

				if (lives <= 0) {
						Application.LoadLevel (1); 
				}
		}

		public void Die ()
		{
				--lives;
				lives_text.guiText.text = lives.ToString ();

				Debug.Log ("Pre Score Snapshot: " + Camera.main.GetComponent<ScoreScript> ().score);

				Camera.main.GetComponent<ScoreScript> ().Hit ();
		
				Debug.Log ("Post Score Snapshot: " + Camera.main.GetComponent<ScoreScript> ().score);
		}

		public int LivesLeft ()
		{
				return lives;
		}
	
		public void Heal ()
		{
				lives = full / 2;
		}
}
