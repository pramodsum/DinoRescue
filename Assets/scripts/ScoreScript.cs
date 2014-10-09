using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour
{
		public static int score;
		GameObject score_text;

		// Use this for initialization
		void Start ()
		{
//				if (Application.loadedLevel == 0)
				score = 0;
				score_text = GameObject.Find ("score");
//				DontDestroyOnLoad (this);
		}

		void FixedUpdate ()
		{
				if (Application.loadedLevel == 0) {
						++score;
						score_text.guiText.text = "Score: " + score.ToString ();
				}
		}

		public int getScore ()
		{
				return score;
		}

		public void Hit ()
		{
				if (score > 100) 
						score -= 100;
				else
						score = 0;
		}
}
