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
    public static Double SoldS = 1;
    public int b;
    public int active = 0;
    public double a;
    public double UpgradePrice;
    public double c;
    public Text NameText;
    public Text DescriptionText, DescriptionText2;
    public Text PriceText;
    public int isMultiple;
    public Button button;

	void Start () {
        NameText.text = upgrade.name;
        DescriptionText.text = upgrade.description;
        DescriptionText2.text = upgrade.description2;
        UpgradePrice = upgrade.price;
        AmountOwned = upgrade.AmountOwned;
        isMultiple = upgrade.isMultiple;



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
        if (active > 0)
            button.interactable = false;

    }

    public void OnClicked()
    {
        
        HarvestS = HarvestS + upgrade.HarvestUpgrade;
        BeanPrice = BeanPrice + upgrade.PriceUpgrade;
        SoldS = SoldS + upgrade.SoldUpgrade;

        ClickerControlScript.MoneyAmount -= UpgradePrice;
        
        UpgradePrice = (AmountOwned + 1) * upgrade.price * (AmountOwned + 1) * b;
        AmountOwned += 1;
        active += isMultiple;
        




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
            PriceText.text = "$" + c.ToString("F2") + "Qt";
        }
        if (UpgradePrice >= 1000000000000000 && UpgradePrice < 1000000000000000000)
        {
            c = (UpgradePrice / 1000000000000000);
            PriceText.text = "$" + c.ToString("F2") + "Q";
        }
        if (UpgradePrice >= 1000000000000 && UpgradePrice < 1000000000000000)
        {
            c = (UpgradePrice / 1000000000000);
            PriceText.text = "$" + c.ToString("F2") + "T";
        }
        if (UpgradePrice >= 1000000000 && UpgradePrice < 1000000000000)
        {
            c = (UpgradePrice / 1000000000);
            PriceText.text = "$" + c.ToString("F2") + "B";
        }
        if (UpgradePrice >= 1000000 && UpgradePrice < 1000000000)
        {
            c = (UpgradePrice / 1000000);
            PriceText.text = "$" + c.ToString("F2") + "M";
        }
        if (UpgradePrice < 1000000)
            PriceText.text = "$" + UpgradePrice.ToString();


    }
}
