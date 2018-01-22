using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    private bool coinRegenDone = false;
    private int respawnTimer = 30;
    void Start()
    {
        //Screen.SetResolution(700, 1000, false);
        PlayerPrefs.SetInt("Player Score", 50);
        StartCoroutine(RespawnCoin(respawnTimer));
    }

    void Update()
    {
       if (coinRegenDone == true)
       {
           StartCoroutine(RespawnCoin(respawnTimer));
           coinRegenDone = false;
       }
    }
    IEnumerator RespawnCoin(int timeUntilDone)
    {
        for (int i = 0; i < timeUntilDone; i++)
        {
            yield return new WaitForSeconds(1);
            PlayerPrefs.SetInt("Coin Regen Time", (timeUntilDone - i));
        }
        AddCoin();
        coinRegenDone = true;
    }
    private void AddCoin()
    {
        PlayerPrefs.SetInt("Player Score", PlayerPrefs.GetInt("Player Score") + 1);
    }
}
