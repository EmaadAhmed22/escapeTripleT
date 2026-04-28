using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class DifficultyColorNow : MonoBehaviour
{

    public Text negro = null;

    void Start()
    {
        UnityEngine.ColorUtility.TryParseHtmlString(GameManager.cooolor, out UnityEngine.Color newColor);
        negro.color = newColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
