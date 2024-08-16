using UnityEngine;

namespace SPACE.State
{
    public class State : MonoBehaviour
    {
        #region Private Fields

        private Character _character;

        #endregion
        
        private void Awake()
        {
            Debug.Log("State Design Pattern example started.");

            _character = new Character();
            
            Debug.Log("Press 'I' to idle state.");
            Debug.Log("Press 'W' to move forward state.");
            Debug.Log("Press 'S' to move backward state.");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
                _character.UpdateCharacterState(new IdleState());
            
            if (Input.GetKeyDown(KeyCode.W))
                _character.UpdateCharacterState(new MoveForwardState());
            
            if (Input.GetKeyDown(KeyCode.S))
                _character.UpdateCharacterState(new MoveBackwardState());
            
            _character?.Execute();
        }
    }

    public class Character
    {
        #region Private Fields

        private ICharacterState currentCharacterState;

        #endregion

        public void Execute()
        {
            currentCharacterState?.Execute(this);
        }

        public void UpdateCharacterState(ICharacterState currentCharacterState)
        {
            this.currentCharacterState?.Exit(this);
            this.currentCharacterState = currentCharacterState;
        }
    }

    public interface ICharacterState
    {
        void Execute(Character character);
        
        void Exit(Character character);
    }
    
    public class IdleState : ICharacterState
    {
        public void Execute(Character character)
        {
            Debug.Log("Idle.");
        }

        public void Exit(Character character)
        {
            Debug.Log("Exit Idle.");
        }
    }

    public class MoveForwardState : ICharacterState
    {
        public void Execute(Character character)
        {
            Debug.Log("Moving forward.");
        }
        
        public void Exit(Character character)
        {
            Debug.Log("Exit Move Forward.");
        }
    }
    
    public class MoveBackwardState : ICharacterState
    {
        public void Execute(Character character)
        {
            Debug.Log("Moving backward.");
        }
        
        public void Exit(Character character)
        {
            Debug.Log("Exit Backward.");
        }
    }
}
