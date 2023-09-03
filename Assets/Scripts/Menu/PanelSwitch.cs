using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelSwitch : MonoBehaviour
{

    public GameObject panelTutorial;
    public GameObject panelGameOver;

    public void enableTutorial()
    {
        panelTutorial.SetActive(true);
    }

    public void enableGameOver()
    {
        panelGameOver.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
