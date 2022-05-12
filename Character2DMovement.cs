using UnityEngine;

public class Character2DMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 2;
    [SerializeField] float jumpForce = 2;
    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        // rigidbody for jump
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        // Jumping character
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb2D.velocity.y) < 0.001f)
        {

            rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        // Rotation player while moving
        if (!Mathf.Approximately(0, movement))
        {
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
    }
}
