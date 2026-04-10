using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<string> keys = new List<string>();
    public Text legacyText;

    
    public void AddKey(string keyName)
    {
        keys.Add(keyName);
        Debug.Log("Collected key: " + keyName);
        legacyText.text = keys.Count.ToString();
    }

    public bool HasKey(string keyName)
    {
        return keys.Contains(keyName);
    }
}