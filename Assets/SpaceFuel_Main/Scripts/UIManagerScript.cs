using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
	public Image takeImage;
	static public Image redCharge;
	static public float waitTime = 30.0f;

	private void Start()
	{
		redCharge = takeImage;
		waitTime = 30.0f;
		redCharge.fillAmount = 0.99f;
	}
	void Update()
	{
		redCharge.fillAmount -= 1.0f / waitTime * Time.deltaTime;
		//Debug.Log(redCharge.fillAmount);

		if(redCharge.fillAmount <= 0)
        {
			ShipMove.noBoost();
        }

		if (redCharge.fillAmount > 0.99f)
		{
			redCharge.fillAmount = 0.99f;
		}
	}

	static public void pickBoost()
    {
		redCharge.fillAmount += 0.15f;
	}
	static public void retryMenu()
    {
        SceneManager.LoadScene("RetryScene");
    }
}
