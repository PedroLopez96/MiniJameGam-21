using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;
    public Text interactText;

    private LoopScript loopScript;

    private void Start()
    {
        loopScript = GameObject.Find("GameManager").GetComponent<LoopScript>();
    }
    public void updateHUD()
    {
        scoreText.text = "Score: " + GameManager.scorePoints.ToString();
        if (loopScript.foundDevice)
        {
            timeText.text = "Time Left: YOU ARE OUT OF THE LOOP!";
        } else
        timeText.text = "Time Left: " + (loopScript.loopDuration- loopScript.timeElapsed).ToString();
    }

}
