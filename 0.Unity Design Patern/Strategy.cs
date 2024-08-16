using UnityEngine;

namespace SPACE.Strategy
{
    public class Strategy : MonoBehaviour
    {
        #region Private Fields

        private Character _character;

        #endregion

        private void Awake()
        {
            Debug.Log("Strategy Design Pattern example started.");

            _character = new Character();
        
            Debug.Log("Press 'F' to use ability.");
            Debug.Log("Press 'M' to change character ability to mage.");
            Debug.Log("Press 'W' to change character ability to warrior.");
        }
    
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
                _character.UseAbility();

            if (Input.GetKeyDown(KeyCode.M))
            {
                _character.SetAbility(new MageAbility());
                Debug.Log("Now, your character is mage!");
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                _character.SetAbility(new WarriorAbility());
                Debug.Log("Now, your character is warrior!");
            }
        }
    }

    public class Character
    {
        #region Private Fields

        private ICharacterAbility _characterAbility;

        #endregion
    
        public void UseAbility()
        {
            if (_characterAbility == null)
            {
                Debug.Log("You should set ability");
                Debug.Log("Press 'M' to change character ability to mage.");
                Debug.Log("Press 'W' to change character ability to warrior.");
                return;
            }
        
            _characterAbility.Use();
        }

        public void SetAbility(ICharacterAbility characterAbility)
        {
            _characterAbility = characterAbility;
        }
    }

    public interface ICharacterAbility
    {
        public void Use();
    }

    public class WarriorAbility : ICharacterAbility
    {
        public void Use()
        {
            Debug.Log("Warrior ability used.");
        }
    }

    public class MageAbility : ICharacterAbility
    {
        public void Use()
        {
            Debug.Log("Mage ability used.");
        }
    }
}
