using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour
{
		public int score = 0;
		GameObject score_text;

		// Use this for initialization
		void Start ()
		{
				score_text = GameObject.Find ("score");
		}

		void FixedUpdate ()
		{
				++score;
				score_text.guiText.text = "Score: " + score.ToString ();
		}

		public void Hit ()
		{
				if (score > 100) 
						score -= 100;
				else
						score = 0;
		}
}
