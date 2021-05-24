using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.one.normalized; // direction is (1,1) normalized
        radius = transform.localScale.x / 2;//half the width
        
    }

    // Update is called once per frame
    void Update()
    {
        //bool isRight = true;
        transform.Translate(direction * speed * Time.deltaTime);
        // Bounce off and bottom
        if (transform.position.y < GameManager.bottamLeft.y + radius && direction.y < 0)
        {
            direction.y = -direction.y;
        }

        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }

        //Game Over
        if (transform.position.x < GameManager.bottamLeft.x + radius && direction.x < 0)
        {
            Debug.Log("Right Player Win");

            // for now just freeze time
            Time.timeScale = 0;
            enabled = false;
        }
        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
            Debug.Log("Left Player Win");

            // for now just freeze time
            Time.timeScale = 0;
            enabled = false;
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Paddle")
        {
            bool isRight = other.GetComponent<Paddle>().isRight;

            //if hitting right paddle and moving right, flip direction
            if (isRight == true && direction.x > 0 )
            {
                Debug.Log("it me");
                direction.x = -direction.x;
            }
            //if hitting left paddle and moving right, flip direction
            if (isRight == false && direction.x < 0 )
            {
                Debug.Log("ite not cool");
                direction.x = -direction.x;
            }
        }
    }
}
