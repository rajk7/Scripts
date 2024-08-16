using UnityEngine;

namespace SPACE.LSP
{
    public class LiskovsSubstitution : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("Liskov's Substitution Principle example started.");
            Debug.Log("Please review 'LiskovsSubstitution.cs' for more information.");
        }
    }

    public abstract class Character
    {
        public abstract void Move(Vector3 direction, float speed);
        
        /*
         * If this method were in this class, it would be against the LSP we used.
         * We leave the common methods of both Player and Bot in our abstract class.
         * Since only the Player will be controlled by the mouse, we implement the InputMouse interface to the Player.
         *
        public void Click(Vector2 mousePosition)
        {
            //Input operation.
        }
        */
    }
    
    public class Player : Character, IMouseClick
    {
        public override void Move(Vector3 direction, float speed)
        {
            //Move operation.
        }

        public void Click(Vector2 mousePosition)
        {
            //Input operation.
        }
    }
    
    public class Bot : Character
    {
        public override void Move(Vector3 direction, float speed)
        {
            //Move operation.
        }
    }

    public interface IMouseClick
    {
        void Click(Vector2 mousePosition);
    }
}