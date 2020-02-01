using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.GGJ20
{
    public class GameManager : Singleton<GameManager>
    {
        private GameStateType gameState;

        private void Start()
        {
            gameState = GameStateType.InitialMenu;
        }

        public void SetupInitialMenuUI()
        {

        }

        public void SetupGameUI()
        {

        }

        public void SetupGameOverUI()
        {
            
        }

        public void StartInitialMenu()
        {

        }

        public void StartGame()
        {
            
        }

        public void StartGameOver()
        {

        }

        public void GenerateLevel()
        {

        }

        public void SetupRocket()
        {

        }

        public void RocketLanded(bool isSafeSpot)
        {

        }

        public void UpdateScore()
        {
            
        }

        public void CheckScore()
        {

        }
    }
}
