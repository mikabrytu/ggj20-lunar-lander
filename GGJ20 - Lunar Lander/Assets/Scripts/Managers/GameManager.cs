using UnityEngine;
using UnityEngine.UI;

namespace Mikabrytu.GGJ20
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private GameObject _initialMenuUI;
        [SerializeField] private GameObject _gameUI;
        [SerializeField] private GameObject _gameOverUI;
        [SerializeField] private Text _highScoreText;

        private GameStateType gameState;
        private ScoreManager scoreManager;

        private void Start()
        {
            scoreManager = GetComponent<ScoreManager>();
            gameState = GameStateType.InitialMenu;

            StartInitialMenu();
        }

        public void SetupInitialMenuUI()
        {
            _initialMenuUI.SetActive(true);
            _gameUI.SetActive(false);
            _gameOverUI.SetActive(false);

            _highScoreText.text = $"High Score: {scoreManager.GetScore()}";
        }

        public void SetupGameUI()
        {
            _initialMenuUI.SetActive(false);
            _gameUI.SetActive(true);
            _gameOverUI.SetActive(false);
        }

        public void SetupGameOverUI()
        {
            _initialMenuUI.SetActive(false);
            _gameUI.SetActive(false);
            _gameOverUI.SetActive(true);
        }

        public void StartInitialMenu()
        {
            SetupInitialMenuUI();
        }

        public void StartGame()
        {
            SetupGameUI();
            GenerateLevel();
        }

        public void StartGameOver()
        {
            SetupGameOverUI();
        }

        public void GenerateLevel()
        {
            Debug.Log("Generating Level...");
        }

        public void SetupRocket()
        {

        }

        public void RocketLanded(bool isSafeSpot)
        {

        }

        public void UpdateScore()
        {
            scoreManager.IncreaseScore();
        }

        public void CheckScore()
        {

        }
    }
}
