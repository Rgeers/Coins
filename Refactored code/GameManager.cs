using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    private bool _coinRegenDone = false;
    private int _respawnTimer = 30;

    private void Start() {
        //Screen.SetResolution(700, 1000, false);
        PlayerPrefs.SetInt("Player Score", 50);
        StartCoroutine(RespawnCoin(_respawnTimer));
    }

    private void Update() {
        if (_coinRegenDone) {
            StartCoroutine(RespawnCoin(_respawnTimer));
            _coinRegenDone = false;
        }
    }

    private void AddCoin() {
        PlayerPrefs.SetInt("Player Score", PlayerPrefs.GetInt("Player Score") + 1);
    }

    private IEnumerator RespawnCoin(int timeUntilDone) {
        for (int i = 0; i < timeUntilDone; i++) {
            yield return new WaitForSeconds(1);
            PlayerPrefs.SetInt("Coin Regen Time", (timeUntilDone - i));
        }

        AddCoin();
        _coinRegenDone = true;
    }
}