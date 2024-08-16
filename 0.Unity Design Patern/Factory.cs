using UnityEngine;

namespace SPACE.Factory
{
    public class Factory : MonoBehaviour
    {
        #region Private Fields

        private CarCreator _carCreator;
        private HelicopterCreator _helicopterCreator;

        #endregion
        
        private void Awake()
        {
            Debug.Log("Factory Design Pattern example started.");

            _carCreator = new CarCreator();
            _helicopterCreator = new HelicopterCreator();

            Debug.Log("Press 'D' to create car.");
            Debug.Log("Press 'F' to create helicopter.");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
                _carCreator.CreateVehicle();
            
            if (Input.GetKeyDown(KeyCode.F))
                _helicopterCreator.CreateVehicle();
        }
    }
    
    public abstract class Creator
    {
        public abstract IVehicle CreateVehicle();
    }

    public class CarCreator : Creator
    {
        public override IVehicle CreateVehicle()
        {
            return new Car();
        }
    }
    
    public class HelicopterCreator : Creator
    {
        public override IVehicle CreateVehicle()
        {
            return new Helicopter();
        }
    }

    public interface IVehicle
    {
        public void Execute();
    }

    public class Car : IVehicle
    {
        public Car()
        {
            Debug.Log("Car created.");
            Execute();
        }

        public void Execute()
        {
            Debug.Log("Hey it's a car!");
        }
    }

    public class Helicopter : IVehicle
    {
        public Helicopter()
        {
            Debug.Log("Helicopter created.");
            Execute();
        }

        public void Execute()
        {
            Debug.Log("Hey it's a helicopter!");
        }
    }
}
