using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour{
    public TextMeshProUGUI finalTimeText;

    void Start(){
        if (finalTimeText != null)
        {
            float time = GameController.finalTime;
            finalTimeText.text = "Você durou " + time.ToString("F1") + " segundos!";
        }
        else
        {
            Debug.LogWarning("⚠️ Texto de tempo final não está conectado!");
        }
    }
    void Update(){}

    public void LoadGameScene(){SceneManager.LoadScene("Jogo");}
    public void LoadMenuScene(){SceneManager.LoadScene("MainMenu");}

}
