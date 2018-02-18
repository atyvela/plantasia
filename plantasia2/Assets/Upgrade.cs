using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade")]
public class Upgrade : ScriptableObject
{

    public new string name; //name of the upgrade
    public string description; //description of the upgrade

    public float AmountOwned; //how many of this upgrade already own
    public double price; //  price of the upgrade
    public int PriceUpgrade; // how much money per bean sold
    public int HarvestUpgrade; // how much harvesting is upgraded
    public int SoldUpgrade; // how much selling is upgraded

    
}

