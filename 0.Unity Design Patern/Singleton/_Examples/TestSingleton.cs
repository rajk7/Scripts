using UnityEngine;

namespace SPACE.Singleton
{
    public class TestSingleton : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("Singleton Design Pattern example started.");
            Debug.Log("Press 'E' to execute Game Manager.");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
                GameManager.Instance.Execute();
        }
    }
}
