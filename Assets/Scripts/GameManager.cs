using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
}
