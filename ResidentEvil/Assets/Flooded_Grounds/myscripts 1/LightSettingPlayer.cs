using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        if (SaveScript.BATTERYPower > 0.0f)
        {
            //logic for nightvision
            if (Input.GetKeyDown(KeyCode.N))
            {
                if (nightVisionActive == false)
                {

                    myVolume.profile = nightVision;
                    nightVisionActive = true;
                    nightVisionLayout.SetActive(true);
                    SaveScript.NVisonLightON = true;

                }
                else
                {
                    myVolume.profile = strandad;
                    nightVisionActive = false;
                    nightVisionLayout.SetActive(false);
                    SaveScript.NVisonLightON = false;
                }
            }

        }
    }

    void spotLightOn()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (spotLightEnabled == false)
            {
                spotLightEnabled = true;
                spotLight.SetActive(true);
                SaveScript.flashlightON = true;
            }
            else
            {
                spotLightEnabled = false;
                spotLight.SetActive(false);
                SaveScript.flashlightON=false;
            }
        }
        if (SaveScript.BATTERYPower <= 0.0f)
        {
            myVolume.profile = strandad;
            nightVisionActive = false;
            nightVisionLayout.SetActive(false);
            SaveScript.NVisonLightON = false;
            spotLightEnabled = false;
            spotLight.SetActive(false);
            SaveScript.flashlightON = false; 


        }
    }
    
}
