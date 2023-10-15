using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CanvasScript : MonoBehaviour
{
 
    public void playButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void controlls()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void exit()
    {

        Application.Quit();
    }

}
