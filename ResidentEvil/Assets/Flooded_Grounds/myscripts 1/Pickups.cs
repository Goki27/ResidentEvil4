using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    RaycastHit hit;

    [SerializeField]float distance = 4.0f;
    [SerializeField] GameObject pickupMessage;
    private float rayDistance;
    private bool canSeePickup = false;
    // Start is called before the first frame update
    void Start()
    {
        pickupMessage.gameObject.SetActive(false);
        rayDistance = distance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward,out hit, rayDistance)) {


            if (hit.transform.tag == "Apple")
            {
                canSeePickup = true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.apple < 6)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.apple += 1;
                    }
                   
                }

            }
            else if (hit.transform.tag == "Battery")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Batteryies < 4)
                    Destroy(hit.transform.gameObject);
                    SaveScript.Batteryies += 1;

                }

            }
            else
                canSeePickup=false;
        
        }
        if (canSeePickup==true)
        {
            pickupMessage.gameObject.SetActive(true);
            rayDistance = 1000f;
        }
        if (canSeePickup == false)
        {
            pickupMessage.gameObject.SetActive(false);
            rayDistance= distance;
        }
    }
}
