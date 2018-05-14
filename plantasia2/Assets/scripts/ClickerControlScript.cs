using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerControlScript : MonoBehaviour {

    public Button harvestButton, SellButton, ExitButton;

    public GameObject ShopPanel,HarvestPanel, SalesPanel, UpgradePanel, Menupanel;

    public Text BeansText, MoneyText, BeansStext, MoneyStext;

    public static double MoneyAmount = 1000000000000; // how much money collected 

    public Image image;
    private double d,e;

    public double BeansAmount; //how meany beans harvested 
    public double BeanPrice; // how much money per bean sold
    public double HarvestS; // how many beans harvested per click / or per second with automatic harvest
    public double SoldS; // how many beans sold per click / or per second with automatic sell


	void Start () {
        image.enabled = false;
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


        BeansStext.text = ((HarvestS - 1) - (SoldS - 1)) + " per second";
        MoneyStext.text = ((SoldS -1)* BeanPrice) + " per second";
        //BeansText.text = "Beans:" + BeansAmount.ToString("F0");
        BeanAmountDisplay();
        MoneyAmountDisplay();
        //MoneyText.text = "$" + MoneyAmount.ToString("F0");

    }

    public void IncreaseBeansAmount()
    {
       
        BeansAmount += HarvestS;
    }

    public void IncreaseMoneyAmount()
    {
        
        BeansAmount -= SoldS;
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
        image.enabled = true;
        ShopPanel.gameObject.SetActive (true);
        ExitButton.interactable = true;
        ExitButton.gameObject.SetActive(true);
    }

    public void CloseShop()
    {
        image.enabled = false;
        ShopPanel.gameObject.SetActive (false);
    }


    public void BeansPerSec()
    {
        if ((SoldS ) < BeansAmount)
            BeansAmount = BeansAmount + (((HarvestS - 1)) * 0.1f) - ((SoldS - 1) *0.1f);

        if ((SoldS) == BeansAmount)
            BeansAmount += 0;

        if ((SoldS) > BeansAmount && BeansAmount >= 1) { 
            BeansAmount = BeansAmount - (SoldS * 0.1f);
            if(BeansAmount < 0)
            {
                BeansAmount = BeansAmount + (BeansAmount * -1);
            }
        

        }
                


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
             MoneyText.text =   d.ToString("F3") + " Quintillion Coins";
        }
        if (MoneyAmount >= 1000000000000000 && MoneyAmount < 1000000000000000000)
        {
            d = (MoneyAmount / 1000000000000000);
             MoneyText.text =   d.ToString("F3") + " Quadrillion Coins ";
        }
        if (MoneyAmount >= 1000000000000 && MoneyAmount < 1000000000000000)
        {
            d = (MoneyAmount / 1000000000000);
            MoneyText.text =  d.ToString("F3") + " Trillion Coins";
        }
        if (MoneyAmount >= 1000000000 && MoneyAmount < 1000000000000)
        {
            d = (MoneyAmount / 1000000000);
            MoneyText.text =  d.ToString("F3") + " Billion Coins";
        }
        if (MoneyAmount >= 1000000 && MoneyAmount < 1000000000)
        {
            d = (MoneyAmount / 1000000);
            MoneyText.text =  d.ToString("F3") + " Million Coins";
        }
        if (MoneyAmount < 1000000)
            MoneyText.text = MoneyAmount.ToString("F0") + " Coins";


    }

    void BeanAmountDisplay()
    {

        if (BeansAmount <= 1000000000000000000)
        {
            e = (BeansAmount / 1000000000000000000);
            BeansText.text =   e.ToString("F3") + " Quintillion Beans";
        }
        if (BeansAmount >= 1000000000000000 && BeansAmount < 1000000000000000000)
        {
            e = (BeansAmount / 1000000000000000);
            BeansText.text =  e.ToString("F3") + " Quadrillion Beans";
        }
        if (BeansAmount >= 1000000000000 && BeansAmount < 1000000000000000)
        {
            e = (BeansAmount / 1000000000000);
            BeansText.text =  e.ToString("F3") + " Trillion Beans";
        }
        if (BeansAmount >= 1000000000 && BeansAmount < 1000000000000)
        {
            e = (BeansAmount / 1000000000);
            BeansText.text = e.ToString("F3") + " Billion Beans";
        }
        if (BeansAmount >= 1000000 && BeansAmount < 1000000000)
        {
            e = (BeansAmount / 1000000);
            BeansText.text = e.ToString("F3") + " Million Beans";
        }
        if (BeansAmount < 1000000)
            BeansText.text = BeansAmount.ToString("F0") + " Beans";


    }


}
