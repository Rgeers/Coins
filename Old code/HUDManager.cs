using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HUDManager : MonoBehaviour {
    private int totalCoins, coinCounter;
    private string coinRegenTime;
    public Text Coins, TimeLeft;
    public Transform PauseButton, PlayButton, ExitButton, ExitPopup;
    public Transform Coin1, Coin2, Coin3, Coin4, Coin5;
	
	void Update () 
    {
        if (Time.timeScale == 0)
        {
            PauseButton.gameObject.SetActive(false);
            PlayButton.gameObject.SetActive(true);
        }
        else
        {
            PauseButton.gameObject.SetActive(true);
            PlayButton.gameObject.SetActive(false);
        }
        coinRegenTime = ""+PlayerPrefs.GetInt("Coin Regen Time");
        totalCoins = PlayerPrefs.GetInt("Player Score");
        coinCounter = PlayerPrefs.GetInt("Coin Counter");
        Coins.GetComponent<Text>().text = totalCoins.ToString();
        TimeLeft.GetComponent<Text>().text = coinRegenTime.ToString();

        if (coinCounter <= 0)
        {
            Coin1.GetComponent<Image>().enabled = false;
            Coin2.GetComponent<Image>().enabled = false;
            Coin3.GetComponent<Image>().enabled = false;
            Coin4.GetComponent<Image>().enabled = false;
            Coin5.GetComponent<Image>().enabled = false;

        }
        else if (coinCounter == 5)
        {
            Coin5.GetComponent<Image>().enabled = true;
            Coin4.GetComponent<Image>().enabled = true;
            Coin3.GetComponent<Image>().enabled = true;
            Coin2.GetComponent<Image>().enabled = true;
            Coin1.GetComponent<Image>().enabled = true;
        }
        else if (coinCounter == 4)
        {
            Coin5.GetComponent<Image>().enabled = false;
            Coin4.GetComponent<Image>().enabled = true;
            Coin3.GetComponent<Image>().enabled = true;
            Coin2.GetComponent<Image>().enabled = true;
            Coin1.GetComponent<Image>().enabled = true;
        }
        else if (coinCounter == 3)
        {
            Coin5.GetComponent<Image>().enabled = false;
            Coin4.GetComponent<Image>().enabled = false;
            Coin3.GetComponent<Image>().enabled = true;
            Coin2.GetComponent<Image>().enabled = true;
            Coin1.GetComponent<Image>().enabled = true;
        }
        else if (coinCounter == 2)
        {
            Coin5.GetComponent<Image>().enabled = false;
            Coin4.GetComponent<Image>().enabled = false;
            Coin3.GetComponent<Image>().enabled = false;
            Coin2.GetComponent<Image>().enabled = true;
            Coin1.GetComponent<Image>().enabled = true;
        }
        else if (coinCounter == 1)
        {
            Coin5.GetComponent<Image>().enabled = false;
            Coin4.GetComponent<Image>().enabled = false;
            Coin3.GetComponent<Image>().enabled = false;
            Coin2.GetComponent<Image>().enabled = false;
            Coin1.GetComponent<Image>().enabled = true;
        }
	}

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        ExitPopup.gameObject.SetActive(false);
    }
    public void ClickExit()
    {
        Time.timeScale = 0;
        ExitPopup.gameObject.SetActive(true);
    }

    public void ExitForSure()
    {
        Application.Quit();
    }
}
