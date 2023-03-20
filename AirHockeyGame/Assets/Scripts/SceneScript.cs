using UnityEngine;
using UnityEngine.UI;

public class SceneScript : MonoBehaviour
{
    public enum Score{
        AIScore, PlayerScore
    }

    public Text AIScoreText, PlayerScoreText;

    public UIManager uiManager;
    
    public int MaxScore;

    private int aiScore,playerScore;

    private int AiScore{
        get {return aiScore; }
        set{
            aiScore = value;
            if(value == MaxScore){
                uiManager.ShowRestartCanvas(true);
            }
        }
    }

    private int PlayerScore{
        get {return playerScore; }
        set{
            playerScore = value;
            if(value == MaxScore){
                uiManager.ShowRestartCanvas(false);
            }
        }
    }

    public void Increment(Score whichScore){
        if (whichScore == Score.AIScore){
            AIScoreText.text = (++AiScore).ToString();
        }
        else{
            PlayerScoreText.text = (++PlayerScore).ToString();
        }
    }

    public void ResetScores(){
        AiScore = PlayerScore = 0;
        AIScoreText.text = PlayerScoreText.text = "0";
    }
}
