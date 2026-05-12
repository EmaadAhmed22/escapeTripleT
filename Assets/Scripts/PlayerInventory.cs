using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int keys;
    public Text legacyText;
    public Text NumOfCoins;


    public List<string> powerUps = new List<string>();

    public int coins = 0; 
    
    public void AddKey()
    {
        keys++;
        Debug.Log("Collected key");
        legacyText.text = keys.ToString();
    }

    public bool HasKey()
    {
        return keys >= 1;
    }
    public void CoinAdd()
    {
        coins++;
        NumOfCoins.text = coins.ToString();

    }
    /*public int HasCoin(string keyName)
    {
        return coins;
    }*/
}