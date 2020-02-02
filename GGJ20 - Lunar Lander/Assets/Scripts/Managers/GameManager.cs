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
        [SerializeField] private ICamera _cameraComponent;

        [SerializeField] private GameObject _initialMenuUI;
        [SerializeField] private GameObject _gameUI;
        [SerializeField] private GameObject _gameOverUI;
        [SerializeField] private Slider _currentFuel;
        [SerializeField] private Text _highScoreText;
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
            _currentFuel.value = _rocketComponent.GetFuel();
        }

#endregion

#region UI

        public void SetupInitialMenuUI()
        {
            _initialMenuUI.SetActive(true);
            _gameUI.SetActive(false);
            _gameOverUI.SetActive(false);

            _highScoreText.text = $"High Score: {scoreManager.GetHighScore()}";
            _currentScore.text = scoreManager.GetScore().ToString();
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
            SetupGameUI();
        }

#endregion

#region Level and Components

        public void GenerateLevel()
        {
            GameObject block;
            do
            {
                block = _sceneBlocks[Random.Range(0, _sceneBlocks.Count)];
            } while (block == currentBlock);

            var stations = block.GetComponentsInChildren<IStation>();
            foreach (IStation item in stations)
            {
                item.ActivateEnergyCell(true);
            }
            
            block.transform.position = Vector2.right * spawnPositionX;
            spawnPositionX += 20;
            currentBlock = block;
        }

        public void InitRocket()
        {
            _rocketComponent.ResetPosition();
            _rocketComponent.ResetFuel();
        }

        public void ResetRocket(Vector2 stationPosition)
        {
            _rocketComponent.SetStationPosition(stationPosition);
            _rocketComponent.ResetFuel();
        }

        public void UpdateCameraTargets(Transform nextStation)
        {
            _cameraComponent.UpdateTargets(nextStation);
        }

#endregion
        
#region Score

        public void UpdateScore()
        {
            scoreManager.IncreaseScore();
            _currentScore.text = scoreManager.GetScore().ToString();
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
            if (lastStation == e.model.id)
                return;

            if (e.model.isObjective)
                GenerateLevel();
            
            UpdateScore();
            UpdateCameraTargets(_rocketComponent.GetNextVisibleStation());
            ResetRocket(e.transform.position);

            lastStation = e.model.id;
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
