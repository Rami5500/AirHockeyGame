using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject CanvasGame;
    public GameObject CanvasRestart;

    [Header("CanvasRestart")]
    public GameObject WinTxt;
    public GameObject LossTxt;
    
    [Header("Other")]
    public AudioManagerScript audioManager;

    public SceneScript sceneScript;

    public PuckScript puckScript;
    public PlayerMovement playerMovement;
    public AIScript aiScript;

    public void ShowRestartCanvas(bool didAiWin){
        Time.timeScale = 0;

        CanvasGame.SetActive(false);
        CanvasRestart.SetActive(true);

        if (didAiWin){
            audioManager.PlayLostGame();
            WinTxt.SetActive(false);
            LossTxt.SetActive(true);
        }
        else{
            audioManager.PlayWonGame();
            WinTxt.SetActive(true);
            LossTxt.SetActive(false);
        }
    }

    public void RestartGame(){
        Time.timeScale = 1;

        CanvasGame.SetActive(true);
        CanvasRestart.SetActive(false);

        sceneScript.ResetScores();
        puckScript.CenterPuck();

        playerMovement.ResetPosition();
        aiScript.ResetPosition();
    }
}
 