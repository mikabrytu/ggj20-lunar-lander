using UnityEngine;

namespace Mikabrytu.GGJ20
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        private const string KEY = "GGJ20-LL-score";
        private int score, highScore;

        protected override void Awake()
        {
            base.Awake();
            highScore = PlayerPrefs.GetInt(KEY, 0);
            score = 0;
        }

        public void IncreaseScore()
        {
            score++;
        }

        public int GetScore()
        {
            return score;
        }

        public int GetHighScore()
        {
            return highScore;
        }

        public void SaveScore()
        {
            PlayerPrefs.SetInt(KEY, score);
        }
    }
}
