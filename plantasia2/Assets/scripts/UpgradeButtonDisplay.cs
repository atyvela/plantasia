using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UpgradeButtonDisplay : MonoBehaviour {


    public Upgrade upgrade;

    public float AmountOwned;

    public static int HarvestS = 1;
    public static int BeanPrice = 1; 
    public static int SoldS = 1;
    public int b;
    public double a;
    public double UpgradePrice;
    public double c;
    public Text NameText;
    public Text DescriptionText;
    public Text PriceText;

    public Button button;

	void Start () {
        NameText.text = upgrade.name;
        DescriptionText.text = upgrade.description;
        UpgradePrice = upgrade.price;
        AmountOwned = upgrade.AmountOwned;
        



    }

    void Update()
    {
        
        EnoughMoneyToBuy();
        PriceRounder();
        //PriceText.text = UpgradePrice.ToString();
        if (AmountOwned + 1 > 10)
            b = 2;
        if (AmountOwned + 1 < 10)
            b = 1;

    }

    public void OnClicked()
    {
        
        HarvestS = HarvestS + upgrade.HarvestUpgrade;
        BeanPrice = BeanPrice + upgrade.PriceUpgrade;
        SoldS = SoldS + upgrade.SoldUpgrade;

        ClickerControlScript.MoneyAmount -= UpgradePrice;
        
        UpgradePrice = (AmountOwned + 1) * upgrade.price * (AmountOwned + 1) * b; 

        AmountOwned += 1;




        Debug.Log(HarvestS);
        Debug.Log(upgrade.HarvestUpgrade);
        Debug.Log(ClickerControlScript.MoneyAmount);
        Debug.Log(UpgradePrice);

    }

    void EnoughMoneyToBuy()
    {
        if (ClickerControlScript.MoneyAmount < UpgradePrice)
            button.interactable = false;
        if (ClickerControlScript.MoneyAmount >= UpgradePrice)
            button.interactable = true;

    }

    void PriceRounder()
    {

        if (UpgradePrice <= 1000000000000000000)
        {
            c = (UpgradePrice / 1000000000000000000);
            PriceText.text = "$" + c.ToString() + "Qt";
        }
        if (UpgradePrice >= 1000000000000000 && UpgradePrice < 1000000000000000000)
        {
            c = (UpgradePrice / 1000000000000000);
            PriceText.text = "$" + c.ToString() + "Q";
        }
        if (UpgradePrice >= 1000000000000 && UpgradePrice < 1000000000000000)
        {
            c = (UpgradePrice / 1000000000000);
            PriceText.text = "$" + c.ToString() + "T";
        }
        if (UpgradePrice >= 1000000000 && UpgradePrice < 1000000000000)
        {
            c = (UpgradePrice / 1000000000);
            PriceText.text = "$" + c.ToString() + "B";
        }
        if (UpgradePrice >= 1000000 && UpgradePrice < 1000000000)
        {
            c = (UpgradePrice / 1000000);
            PriceText.text = "$" + c.ToString() + "M";
        }
        if (UpgradePrice < 1000000)
            PriceText.text = "$" + UpgradePrice.ToString();


    }
}
