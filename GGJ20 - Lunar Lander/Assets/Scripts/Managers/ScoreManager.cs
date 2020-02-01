using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.GGJ20
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        private const string KEY = "GGJ20-LL-score";
        private int score;

        private void Start()
        {
            score = PlayerPrefs.GetInt(KEY, 0);
        }

        public void IncreaseScore()
        {
            score++;
        }

        public int GetScore()
        {
            return score;
        }

        public void SaveScore()
        {
            PlayerPrefs.SetInt(KEY, score);
        }
    }
}
