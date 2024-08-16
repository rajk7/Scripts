using UnityEngine;

namespace SPACE.Singleton
{
    public class GameManager : Singleton<GameManager>
    {
        public void Execute()
        {
            Debug.Log("Game Manager executed.");
        }
    }
}