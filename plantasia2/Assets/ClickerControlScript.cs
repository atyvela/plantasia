using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerControlScript : MonoBehaviour {

    public Button harvestButton, SellButton, ExitButton;

    public GameObject ShopPanel;

    public Text BeansText, MoneyText;

    public static double MoneyAmount; // how much money collected 

    
    public int BeansAmount; //how meany beans harvested 
    public int BeanPrice; // how much money per bean sold
    public int HarvestS; // how many beans harvested per click / or per second with automatic harvest
    public int SoldS; // how many beans sold per click / or per second with automatic sell


	void Start () {
        
        SellButton.interactable = true;
        ShopPanel.gameObject.SetActive(false);
        

    }
	

	void Update () {

        HarvestS = UpgradeButtonDisplay.HarvestS;
        SoldS = UpgradeButtonDisplay.SoldS;
        BeanPrice = UpgradeButtonDisplay.BeanPrice;
        
        EnoughBeansToSell();   
        
        BeansText.text = "Beans:" + BeansAmount;
        MoneyText.text = "Money:" + MoneyAmount;
        
    }

    public void IncreaseBeansAmount()
    {
       
        BeansAmount += HarvestS;
    }

    public void IncreaseMoneyAmount()
    {
        
        BeansAmount -= 1;
        MoneyAmount += BeanPrice * SoldS;
    }


    void EnoughBeansToSell()
    {
        if (BeansAmount <SoldS)
            SellButton.interactable = false;
        if (BeansAmount >= SoldS)
            SellButton.interactable = true;
           
    }

    public void OpenShop()
    {
        ShopPanel.gameObject.SetActive (true);
        ExitButton.interactable = true;
        ExitButton.gameObject.SetActive(true);
    }

    public void CloseShop()
    {
        
        ShopPanel.gameObject.SetActive (false);
    }

}
