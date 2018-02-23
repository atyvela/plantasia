using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopControllerScript : MonoBehaviour {

    public Button HarvestUpgradeButton, SalesUpgradeButton, UpgradeUpgradeButtin;

    public GameObject HarvestPanel, SalesPanel, UpgradePanel;

    void Start()
    {
        //SalesPanel.gameObject.SetActive(false);
        //UpgradePanel.gameObject.SetActive(false);
;
    }

    public void OpenHarvest()
    {
        HarvestPanel.gameObject.SetActive(true);
        SalesPanel.gameObject.SetActive(false);
        UpgradePanel.gameObject.SetActive(false);

    }

    public void OpenSales()
    {
        SalesPanel.gameObject.SetActive(true);
        HarvestPanel.gameObject.SetActive(false);
        UpgradePanel.gameObject.SetActive(false);

    }

    public void OpenUpgrades()
    {
        UpgradePanel.gameObject.SetActive(true);
        HarvestPanel.gameObject.SetActive(false);
        SalesPanel.gameObject.SetActive(false);

    }


}
