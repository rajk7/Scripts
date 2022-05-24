using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject car;
    public GameObject camera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = new Vector3(10, 10, 10);
            GameObject c = Instantiate(car, pos, Quaternion.identity);
            camera.GetComponent<SmoothFollow>().target = c.transform;
        }
    }
}
