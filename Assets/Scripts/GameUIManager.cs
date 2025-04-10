using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public TextMeshProUGUI timerText, scoreText, finalTimeText, finalTimeTextGameOver;
    public GameObject winPanel;

    private float timeElapsed, timeLimit = 30f;
    private int score;
    private bool winShown = false;

    void Start(){
        GameObject gameOverPanel = GameObject.Find("GameOverPanel");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }

        timeElapsed = 0f;
        score = 0;
        UpdateScoreText();

        if (timerText == null || scoreText == null)
            Debug.LogError("⚠️ UI não está conectada corretamente no GameUIManager!");
    }

    void Update(){
        if (GameController.gameEnded)
        {
            return;
        }

        if (GameController.gameOver && !winShown)
        {
            winShown = true;
            GameController.WinGame(); // agora controlamos vitória separadamente
            ShowWinPanel();
            return;
        }

        if (timeElapsed >= timeLimit){
            GameController.EndGame(); // derrota
            ShowGameOverPanel();
            return;
        }

        timeElapsed += Time.deltaTime;
        UpdateTimerText();
    }

    void UpdateTimerText(){
        timerText.text = "Tempo: " + timeElapsed.ToString("F1") + "s";
    }

    void UpdateScoreText(){
        scoreText.text = "Pontos: " + score;
    }

    public void AddPoint(){
        score++;
        UpdateScoreText();
    }

    public void LoadGameScene(){
        SceneManager.LoadScene("Jogo");
    }

    void ShowWinPanel(){
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            if (finalTimeText != null)
            {
                finalTimeText.text = "Time: " + timeElapsed.ToString("F1") + " s!";
            }
        }
        else
        {
            Debug.LogWarning("⚠️ winPanel não está atribuído no Inspector.");
        }
    }

    void ShowGameOverPanel(){
        GameObject panel = GameObject.Find("GameOverPanel");
        if (panel != null)
        {
            panel.SetActive(true);

            if (finalTimeTextGameOver != null)
            {
                finalTimeTextGameOver.text = "Você durou " + timeElapsed.ToString("F1") + " segundos!";
            }
        }
        else
        {
            Debug.LogWarning("⚠️ GameOverPanel não encontrado!");
        }
    }


}
