using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuActions : MonoBehaviour
{
    public void StartGame()
    {
        int count = GameObject.FindGameObjectsWithTag("Coletavel").Length;
        GameController.Init(count);
        SceneManager.LoadScene("Jogo"); // 1
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu"); // 0
    }

}

