using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField ]
    float speed;
    float height;
    public bool isRight;

    string input;

    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
        
    }

    public void Init(bool isRightPaddle)
    {
        isRight = isRightPaddle;
        Vector2 pos = Vector2.zero;

        if (isRightPaddle)
        {
            // place paddle on the right of Screen
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;// move a bit to the left

            input = "RightPaddle"; 
        }else{
            
            // place paddle on the left of screen
            pos = new Vector2(GameManager.bottamLeft.x, 0);
            pos += Vector2.right * transform.localScale.x; // move a bit to the right

            input = "LeftPaddle";
        }
        transform.position = pos;

        transform.name = input;
    }

    // Update is called once per frame
    void Update()
    {
        // now lets move the paddle

        //// GetAxis is a number between -1 to +1 (-1 for down, for up)
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        //Restrict paddle movement
        //if paddle is too low and user is continuing to move down, stop
        if(transform.position.y < GameManager.bottamLeft.y + height / 2 && move < 0)
        {
            move = 0;
        }
        //if paddle is too low and user is continuing to move down, stop
        if(transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }

        transform.Translate (move * Vector2.up);

    }
}
