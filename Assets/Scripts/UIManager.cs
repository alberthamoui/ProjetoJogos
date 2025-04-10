using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (GameController.gameOver)
        {
            gameOverPanel.SetActive(true);
        }
    }
}
