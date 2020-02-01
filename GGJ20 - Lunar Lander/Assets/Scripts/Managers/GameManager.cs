using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mikabrytu.GGJ20.Components;
using Mikabrytu.GGJ20.Events;

namespace Mikabrytu.GGJ20
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private IRocket _rocketComponent;
        [SerializeField] private GameObject _initialMenuUI;
        [SerializeField] private GameObject _gameUI;
        [SerializeField] private GameObject _gameOverUI;
        [SerializeField] private Text _highScoreText;
        [SerializeField] private Text _currentFuel;
        [SerializeField] private Text _currentScore;
        [SerializeField] private List<GameObject> _sceneBlocks;

        private GameStateType gameState;
        private ScoreManager scoreManager;
        private GameObject currentBlock;
        private float spawnPositionX = 20f;
        private int lastStation;

#region Unity Methods

        private void Start()
        {
            scoreManager = GetComponent<ScoreManager>();
            gameState = GameStateType.InitialMenu;

            EventsManager.AddListener<OnLandOnStationEvent>(RocketLanded);
            EventsManager.AddListener<OnRocketCrashEvent>(RocketLanded);

            StartInitialMenu();
        }

        private void Update()
        {
            _currentFuel.text = $"Fuel: {_rocketComponent.GetFuel()}%";
        }

#endregion

#region UI

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

#endregion

#region Game States

        public void StartInitialMenu()
        {
            SetupInitialMenuUI();
        }

        public void StartGame()
        {
            SetupGameUI();
            GenerateLevel();
            InitRocket();
        }

        public void StartGameOver()
        {
            SetupGameOverUI();
            CheckScore();
        }

        public void RestartGame()
        {
            InitRocket();
        }

#endregion

#region Level and Rocket

        public void GenerateLevel()
        {
            GameObject block;
            do
            {
                block = _sceneBlocks[Random.Range(0, _sceneBlocks.Count)];
            } while (block == currentBlock);
            
            block.transform.position = Vector2.right * spawnPositionX;
            spawnPositionX += 20;
            currentBlock = block;
        }

        public void InitRocket()
        {
            _rocketComponent.ResetPosition();
        }

        public void ResetRocket(Vector2 stationPosition)
        {
            _rocketComponent.SetStationPosition(stationPosition);
            _rocketComponent.ResetFuel();
        }

#endregion
        
#region Score

        public void UpdateScore()
        {
            scoreManager.IncreaseScore();
            _currentScore.text = $"Explored: {scoreManager.GetScore()}";
        }

        public void CheckScore()
        {
            scoreManager.SaveScore();
        }

#endregion

#region Events
    
        /// <summary>
        /// Start routine if rocket land on station
        /// </summary>
        private void RocketLanded(OnLandOnStationEvent e)
        {
            if (lastStation == e.stationModel.id)
                return;
            
            UpdateScore();
            ResetRocket(e.stationPosition);
            lastStation = e.stationModel.id;

            if (e.stationModel.isObjective)
                GenerateLevel();
        }
        
        /// <summary>
        /// Start routine if rocket crash on the ground
        /// </summary>
        private void RocketLanded(OnRocketCrashEvent e)
        {
            StartGameOver();
        }
    }

#endregion
}
