using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class LightHouseRotate : MonoBehaviour
{


    [SerializeField] GameObject lightHObject;
    [SerializeField] float speed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        lightHObject.transform.Rotate(0.0f, speed, 0.0f, Space.World);
        
    }
}
