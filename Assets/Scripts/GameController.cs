using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameController
{
    private static int collectableCount;
    public static bool gameEnded = false;
    public static bool playerWon = false;
    public static float finalTime = 0f;

    public static bool gameOver
    {
        get { return collectableCount <= 0; }
    }

    public static void Init(int count)
    {
        collectableCount = count;
        gameEnded = false;
        Time.timeScale = 1f;

        // Tenta desativar o painel de Game Over no início
        GameObject panel = GameObject.Find("GameOverPanel");
        if (panel != null)
        {
            panel.SetActive(false);
        }

        Debug.Log("Jogo iniciado com " + collectableCount + " coletáveis.");
    }

    public static void Collect()
    {
        if (gameEnded) return;

        collectableCount--;
        Debug.Log("Coletável coletado. Restam: " + collectableCount);

        if (gameOver)
        {
            Debug.Log("Todos os coletáveis foram coletados!");
        }
    }

    public static void EndGame(){
        if (gameEnded) return;

        gameEnded = true;
        finalTime = Time.timeSinceLevelLoad; // armazena o tempo da partida
        Debug.Log("Carregando cena de Game Over...");
        SceneManager.LoadScene("GameOver");
    }

    public static void WinGame(){
        if (gameEnded) return;

        gameEnded = true;
        playerWon = true;
        Time.timeScale = 0f;
        Debug.Log("🎉 Vitória! Jogo vencido!");
    }


}
