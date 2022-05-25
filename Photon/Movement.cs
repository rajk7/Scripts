using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Movement : MonoBehaviour
{


   PhotonView view;

    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
       view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(view.IsMine) {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        transform.Translate(h, 0, 0);
        }
        
    }
}
