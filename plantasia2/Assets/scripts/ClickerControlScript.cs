using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerControlScript : MonoBehaviour {

    public Button harvestButton, SellButton, ExitButton;

    public GameObject ShopPanel,HarvestPanel, SalesPanel, UpgradePanel, Menupanel;

    public Text BeansText, MoneyText, BeansStext, MoneyStext;

    public static double MoneyAmount = 100; // how much money collected 

    private double d;

    public double BeansAmount; //how meany beans harvested 
    public double BeanPrice; // how much money per bean sold
    public double HarvestS; // how many beans harvested per click / or per second with automatic harvest
    public double SoldS; // how many beans sold per click / or per second with automatic sell


	void Start () {

        Menupanel.gameObject.SetActive(false);
        SellButton.interactable = true;
        
        ShopPanel.gameObject.SetActive(false);
        SalesPanel.gameObject.SetActive(false);
        UpgradePanel.gameObject.SetActive(false);
        InvokeRepeating("BeansPerSec", 1.0f, 0.1f);
        InvokeRepeating("MoneyPerSec", 1.0f, 0.1f);


    }
	

	void Update () {

        HarvestS = UpgradeButtonDisplay.HarvestS;
        SoldS = UpgradeButtonDisplay.SoldS;
        BeanPrice = UpgradeButtonDisplay.BeanPrice;
        
        EnoughBeansToSell();


        BeansStext.text = "Net:" + ((HarvestS - 1) - (SoldS - 1));
        MoneyStext.text = "Cps:" + ((SoldS -1)* BeanPrice);
        BeansText.text = "Beans:" + BeansAmount.ToString("F0");
        MoneyAmountDisplay();
        //MoneyText.text = "$" + MoneyAmount.ToString("F0");

    }

    public void IncreaseBeansAmount()
    {
       
        BeansAmount = BeansAmount + HarvestS;
    }

    public void IncreaseMoneyAmount()
    {
        
        BeansAmount -= 1;
        MoneyAmount = MoneyAmount + BeanPrice * SoldS;
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


    public void BeansPerSec()
    {
        if ((SoldS - 1) <= BeansAmount)
            BeansAmount = BeansAmount + (((HarvestS - 1)) * 0.1f) - ((SoldS - 1) *0.1f);

    }
    public void MoneyPerSec()
    {
        if((SoldS -1) <= BeansAmount)
            MoneyAmount = MoneyAmount + ((SoldS -1) * BeanPrice * 0.1f);
            
       
        if((SoldS -1) > BeansAmount)
            MoneyAmount = MoneyAmount + ((HarvestS -1) * BeanPrice * 0.1f);
        
    }

    void MoneyAmountDisplay()
    {

        if (MoneyAmount <= 1000000000000000000)
        {
            d = (MoneyAmount / 1000000000000000000);
             MoneyText.text = "$" +  d.ToString("F3") + "Qt";
        }
        if (MoneyAmount >= 1000000000000000 && MoneyAmount < 1000000000000000000)
        {
            d = (MoneyAmount / 1000000000000000);
             MoneyText.text = "$" +  d.ToString("F3") + "Q";
        }
        if (MoneyAmount >= 1000000000000 && MoneyAmount < 1000000000000000)
        {
            d = (MoneyAmount / 1000000000000);
            MoneyText.text = "$" + d.ToString("F3") + "T";
        }
        if (MoneyAmount >= 1000000000 && MoneyAmount < 1000000000000)
        {
            d = (MoneyAmount / 1000000000);
            MoneyText.text = "$" + d.ToString("F3") + "B";
        }
        if (MoneyAmount >= 1000000 && MoneyAmount < 1000000000)
        {
            d = (MoneyAmount / 1000000);
            MoneyText.text = "$" + d.ToString("F3") + "M";
        }
        if (MoneyAmount < 1000000)
            MoneyText.text = "$" + MoneyAmount.ToString("F0");


    }

    
}
