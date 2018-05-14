using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopContollerScript : MonoBehaviour {

    public Image image;

    public GameObject ShopPanel;

    private void Start()
    {
       
    }

    public void OpenShop()
    {
        ShopPanel.SetActive(true);
        

    }

    public void CloseShop()
    {
        ShopPanel.SetActive(false);
        

    }


}
