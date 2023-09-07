using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LightSettingPlayer : MonoBehaviour
{
    [SerializeField] PostProcessProfile strandad;
    [SerializeField] PostProcessProfile nightVision;
    [SerializeField] PostProcessVolume myVolume;
    [SerializeField] GameObject nightVisionLayout;
    private bool nightVisionActive=false;
    private bool spotLightEnabled=false;
    [SerializeField] GameObject spotLight;
    
    void Start()
    {
        nightVisionLayout.gameObject.SetActive(false);
        spotLight.gameObject.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        nightView();
        spotLightOn();
        
    }

    void nightView()
    {

        //logic for nightvision
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (nightVisionActive == false)
            {
               
                myVolume.profile = nightVision;
                nightVisionActive = true;
                nightVisionLayout.SetActive(true);

            }
            else
            {
                myVolume.profile = strandad;
                nightVisionActive = false;
                nightVisionLayout.SetActive(false);

            }
        }

    }

    void spotLightOn()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (spotLightEnabled == false)
            {
                spotLightEnabled = true;
                spotLight.SetActive(true);
            }
            else
            {
                spotLightEnabled = false;
                spotLight.SetActive(false);
            }
        }
    }

}
