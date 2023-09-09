using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField] GameObject inventory;
    private bool InventoryVisible = false;

    [SerializeField] GameObject appleImage1;
    [SerializeField] GameObject applebutton2;
    // Start is called before the first frame update
    void Start()
    {
    inventory.SetActive(false);
        InventoryVisible = false;
    Cursor.visible = false;
        appleImage1.gameObject.SetActive(false);
        applebutton2.gameObject.SetActive(false);
    
    
    }

    // Update is called once per frame
    void Update()
    {
        //code for bringing inventory using i 
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryVisible == false)
            {

                inventory.SetActive(true);
                InventoryVisible =true;
                //now we need to stop the world time when we open the inventory so we use the below statement
                Time.timeScale = 0f;
                Cursor.visible = true;
            }
            
            else if (InventoryVisible == true)
            {
                inventory.SetActive(false);
                InventoryVisible =false;
                Time.timeScale = 1f;
                Cursor.visible = false;
            }
        }
        checkInventory();
    }
    void checkInventory()
    {
        if (SaveScript.apple == 1)
        {
            appleImage1.gameObject.SetActive(true);
            applebutton2.gameObject.SetActive(true);
        }
    }
    public void healthUpdate()
    {
        SaveScript.healthBar += 10;
        SaveScript.healthChanged = true;
        SaveScript.apple -= 1;

        appleImage1.gameObject.SetActive(false);
        applebutton2.gameObject.SetActive(false);
    }
}
