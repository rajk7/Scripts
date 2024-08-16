using UnityEngine;

namespace SPACE.Builder
{
    public class Builder : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("Builder Design Pattern example started.");
            Debug.Log("Press 'A' to generate level.");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                LevelBuilder createdLevel = new LevelBuilder()
                    .SetName("Sample Level")
                    .SetBonusCurrency(5)
                    .SetPlayerCapacity(10)
                    .SetPlayersCanJump(true);
                
                createdLevel.PrintDetails();
            }
        }
    }

    public class LevelBuilder
    {
        #region Private Fields

        private string _name;
        private int _bonusCurrency;
        private int _playerCapacity;
        private bool _playersCanJump;

        #endregion

        public LevelBuilder() {}

        public LevelBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public LevelBuilder SetBonusCurrency(int bonusCurrency)
        {
            _bonusCurrency = bonusCurrency;
            return this;
        }
        
        public LevelBuilder SetPlayerCapacity(int playerCapacity)
        {
            _playerCapacity = playerCapacity;
            return this;
        }

        public LevelBuilder SetPlayersCanJump(bool playersCanJump)
        {
            _playersCanJump = playersCanJump;
            return this;
        }

        public void PrintDetails()
        {
            Debug.Log("Level Created.");
            Debug.Log($"Name : {_name}");
            Debug.Log($"Bonus Currency : {_bonusCurrency}");
            Debug.Log($"Player Capacity : {_playerCapacity}");
            Debug.Log($"Players Can Jump : {_playersCanJump}");
        }
    }
}