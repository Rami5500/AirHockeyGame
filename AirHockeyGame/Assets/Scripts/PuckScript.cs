using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckScript : MonoBehaviour
{
    public SceneScript ScoreScriptInstance;
    public static bool wasGoal { get; private set; }
    private Rigidbody2D rb;
    public float MaxSpeed;
    public AudioManagerScript audioManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wasGoal = false;   
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(!wasGoal){
            if(other.tag == "AIGoal"){
                ScoreScriptInstance.Increment(SceneScript.Score.PlayerScore);
                wasGoal = true;
                audioManager.PlayGoal();
                StartCoroutine(ResetPuck(true));
            }
            else if(other.tag == "PlayerGoal"){
                ScoreScriptInstance.Increment(SceneScript.Score.AIScore);
                wasGoal = true;
                audioManager.PlayGoal();
                StartCoroutine(ResetPuck(false));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        audioManager.PlayPuckCollision();
    }

    private IEnumerator ResetPuck(bool didAiScore){
        yield return new WaitForSecondsRealtime(1);
        wasGoal = false;
        rb.velocity = rb.position = new Vector2(0,0);

        if(didAiScore){
            rb.position = new Vector2(0,1);
        }
        else{
            rb.position = new Vector2(0,-1);
        }
    }

    private void FixedUpdate(){
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
    }

    public void CenterPuck(){
        rb.position = new Vector2(0, 0);
    }
}

