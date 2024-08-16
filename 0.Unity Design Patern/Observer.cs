using UnityEngine;
using System.Collections.Generic;

namespace SPACE.Observer
{
    public class Observer : MonoBehaviour
    {
        #region Private Fields

        private List<BaseObserver> _observers = new();

        #endregion

        private void Awake()
        {
            Debug.Log("Observer Design Pattern example started.");

            AddObserver(new Foo());
            AddObserver(new Bar());

            Debug.Log("Press 'N' to notify all observers.");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
                Notify();
        }

        public void AddObserver(BaseObserver baseObserver)
        {
            _observers.Add(baseObserver);
        }

        public void RemoveObserver(BaseObserver baseObserver)
        {
            _observers.Remove(baseObserver);
        }

        public void Notify()
        {
            _observers.ForEach(baseObserver =>
            {
                baseObserver.Execute();
            });
        }
    }
    
    public abstract class BaseObserver
    {
        public abstract void Execute();
    }
    
    public class Foo : BaseObserver
    {
        public override void Execute()
        {
            Debug.Log("It's foo!");
        }
    }
    
    public class Bar : BaseObserver
    {
        public override void Execute()
        {
            Debug.Log("It's bar!");
        }
    }
}
