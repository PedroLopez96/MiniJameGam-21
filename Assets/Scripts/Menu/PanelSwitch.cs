using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelSwitch : MonoBehaviour
{

    public GameObject panelTutorial;
    public GameObject panelGameOver;
    public GameObject panelLevel2;
    public void enableTutorial()
    {
        panelTutorial.SetActive(true);
    }

    public void enableGameOver()
    {
        panelGameOver.SetActive(true);
    }

    public void enableLevel2()
    {
        panelLevel2.SetActive(true);

    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
    }
}
