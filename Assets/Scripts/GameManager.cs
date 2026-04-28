using System.Drawing;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int speed = 25;
    public static int acceleration = 30;
    public Text text;
    public static string cooolor = "4FF106";



    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

    }
    public void LoadGameLevel()
    {
        SceneManager.LoadScene("gameLevel");
    }

    public void LoadStartMenu()
    {
        
        SceneManager.LoadScene("startMenu");
    }

    public void LoadEndScreen()
    {
        SceneManager.LoadScene("endScreen");
    }

    public void LoadWinScreen()
    {
        SceneManager.LoadScene("winScreen");
    }
    public void LoadShopScreen()
    {
        SceneManager.LoadScene("ShopScene");
    }

    public void LoadDiffScreen()
    {
        SceneManager.LoadScene("difficultyMenu");
    }

    public void LoadStartMenuWithDiff(string diff)
    {
        if (diff == "easy")
        {
            speed = 25;
            acceleration = 30;
        }
        if (diff == "medium")
        {
            speed = 35;
            acceleration = 50;

        }
        if (diff == "hard")
        {
            speed = 50;
            acceleration = 80;

        }
        LoadStartMenu();
    }

    public void changeColor(string color) {

        cooolor = color;
 

        
    }

}
