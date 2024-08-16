using UnityEngine;

namespace SPACE.Decorator
{
    public class Decorator : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("Decorator Design Pattern example started.");

            Debug.Log("Press 'A' to use health potion.");
            Debug.Log("Press 'S' to use speed potion.");
            Debug.Log("Press 'D' to use mixed potion.");
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                IPotion healthPotion = new HealthPotionDecorator(new BasePotion());
                healthPotion.Use();
            }
            
            if (Input.GetKeyDown(KeyCode.S))
            {
                IPotion speedPotion = new SpeedPotionDecorator(new BasePotion());
                speedPotion.Use();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                IPotion mixedPotion = new HealthPotionDecorator(new SpeedPotionDecorator(new BasePotion()));
                mixedPotion.Use();
            }
        }
    }
    
    public interface IPotion
    {
        void Use();
    }
    
    public class BasePotion : IPotion
    {
        public void Use() {}
    }

    public abstract class PotionDecorator : IPotion
    {
        private IPotion _potion;

        protected PotionDecorator(IPotion potion)
        {
            _potion = potion;
        }

        public virtual void Use()
        {
            _potion.Use();
        }
    }

    public class SpeedPotionDecorator : PotionDecorator
    {
        public SpeedPotionDecorator(IPotion potion) : base(potion) {}

        public override void Use()
        {
            Debug.Log("Speed Potion used.");
            base.Use();
        }
    }
    
    public class HealthPotionDecorator : PotionDecorator
    {
        public HealthPotionDecorator(IPotion potion) : base(potion) {}

        public override void Use()
        {
            Debug.Log("Health Potion used.");
            base.Use();
        }
    }
}