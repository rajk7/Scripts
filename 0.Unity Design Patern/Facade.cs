using UnityEngine;

namespace SPACE.Facade
{
    public class Facade : MonoBehaviour
    {
        #region Private Fields

        private GameManager _gameManager;

        #endregion
        
        private void Awake()
        {
            Debug.Log("Facade Design Pattern example started.");

            _gameManager = new GameManager();
            
            Debug.Log("Press 'A' to increase score.");
            Debug.Log("Press 'S' to decrease score.");
            Debug.Log("Press 'D' to play sound.");
        }
                
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                _gameManager.IncreaseScore();
            
            if (Input.GetKeyDown(KeyCode.S))
                _gameManager.DecreaseScore();
            
            if (Input.GetKeyDown(KeyCode.D))
                _gameManager.PlaySound();
        }
    }

    public class GameManager
    {
        #region Private Fields

        private ScoreManager _scoreManager;
        private SoundManager _soundManager;

        #endregion

        public GameManager()
        {
            _scoreManager = new ScoreManager();
            _soundManager = new SoundManager();
        }

        public void IncreaseScore()
        {
            _scoreManager.IncraseScore();
        }

        public void DecreaseScore()
        {
            _scoreManager.DecreaseScore();
        }

        public void PlaySound()
        {
            _soundManager.PlaySound();
        }
    }

    public class ScoreManager
    {
        public void IncraseScore()
        {
            Debug.Log("Score increased.");
        }
        
        public void DecreaseScore()
        {
            Debug.Log("Score decreased.");
        }
    }

    public class SoundManager
    {
        public void PlaySound()
        {
            Debug.Log("Sound played.");
        }
    }
}