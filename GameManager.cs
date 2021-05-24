using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;

    public static Vector2 bottamLeft;
    public static Vector2 topRight;

    // Start is called before the first frame update
    void Start()
    {
        //convert Screen point coordinate's into game's coordinate
        bottamLeft  = Camera.main.ScreenToWorldPoint (new Vector2(0,0));
        topRight  = Camera.main.ScreenToWorldPoint (new Vector2(Screen.width, Screen.height));



        Instantiate(ball);
        Paddle paddle1 = Instantiate(paddle) as Paddle;
        Paddle paddle2 = Instantiate(paddle) as Paddle;
        paddle1.Init(true);//right player
        paddle2.Init(false);// left player



    }
    
}
