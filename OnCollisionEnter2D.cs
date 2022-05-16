using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public Vector3 velocity;
    public AudioSource exp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "asteroid")
        {
            collision.gameObject.SetActive(false);
            exp.Play();
        }
    }
    // test case
    public Slider healthbar;
    public GameObject explosion;
    public AudioSource destroyed;
    public AudioSource hit;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            healthbar.value -= 10;
            hit.Play();
            if (healthbar.value <= 0)
            {
                Instantiate(explosion, this.transform.position, Quaternion.identity);
                Destroy(healthbar.gameObject, 0.1f);
                this.gameObject.GetComponent<Renderer>().enabled = false;
                Destroy(this.gameObject, 2f);
                destroyed.Play();

            }
        }
    }

    // Update is called once per frame
    void Update () {
        
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);
        
        //this.transform.Translate(velocity);
	}
}
