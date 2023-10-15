using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RretryMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
      
    }
    public void exit()
    {
        //pene de mono
        Application.Quit();
    }
}
