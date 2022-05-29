using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{

    public TextAsset WeaponImages;
    
    [System.Serializable]
    public class Player
    {
        public string name;
        public int health;
        public int mana;
    }

    [System.Serializable]
    public class PlayerList
    {
        public Player[] Player;
    }

    public PlayerList myPlayerList = new PlayerList();

    void Start()
    {
        myPlayerList = JsonUtility.FromJson<PlayerList>(WeaponImages.text);
        
    }
}