using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UpgradeButtonDisplay : MonoBehaviour {


    public Upgrade upgrade;

    public double AmountOwned;

    public static int HarvestS = 1;
    public static int BeanPrice = 1; 
    public static int SoldS = 1;
    public int b;
    public double a;
    public double UpgradePrice;
    
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
        PriceText.text = UpgradePrice.ToString();
        if (AmountOwned + 1 > 10)
            b = 2;
        if (AmountOwned + 1 < 10)
            b = 1;

    }

    public void OnClicked()
    {
        
        HarvestS += upgrade.HarvestUpgrade;
        BeanPrice += upgrade.PriceUpgrade;
        SoldS += upgrade.SoldUpgrade;

        ClickerControlScript.MoneyAmount -= UpgradePrice;
        
        UpgradePrice = (AmountOwned + 1) * upgrade.price * (AmountOwned + 1) * b; //(Math.Pow(UpgradePrice, a)) * AmountOwned + 1;

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
}
