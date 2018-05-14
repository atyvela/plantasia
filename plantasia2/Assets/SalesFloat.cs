using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SalesFloat : MonoBehaviour
{

    public Vector2 position;
    public double arvo;
    public Text text;
    // Use this for initialization
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        position.y += 0.5f * Time.deltaTime;
        transform.position = position;
        arvo = UpgradeButtonDisplay.SoldS;
        text.text = "+" + arvo;
    }
}