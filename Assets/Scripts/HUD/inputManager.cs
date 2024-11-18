using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManager : MonoBehaviour
{
    [SerializeField] GameObject inventoryHUD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("tab")){
            inventoryHUD.SetActive(!inventoryHUD.activeSelf);
        }
    }
}
