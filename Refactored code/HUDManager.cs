using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    private int _totalCoins, _coinCounter;
    private string _coinRegenTime;
    [SerializeField] private Text _coins, _timeLeft;
    [SerializeField] private Transform _pauseButton, _playButton, _exitButton, _exitPopup;
    [SerializeField] private Transform[] _coinTransforms;

    private void Update() {
        _coinRegenTime = PlayerPrefs.GetInt("Coin Regen Time").ToString();
        _totalCoins = PlayerPrefs.GetInt("Player Score");
        _coinCounter = PlayerPrefs.GetInt("Coin Counter");
        _coins.GetComponent<Text>().text = _totalCoins.ToString();
        _timeLeft.GetComponent<Text>().text = _coinRegenTime.ToString();

        for (int i = 0; i <= _coinTransforms.Length-1; i++) {
            _coinTransforms[i].GetComponent<Image>().enabled = (_coinCounter >= i+1);
        }
    }

    public void PauseGame() {
        Time.timeScale = 0;
        _pauseButton.gameObject.SetActive(false);
        _playButton.gameObject.SetActive(true);
    }

    public void ResumeGame() {
        Time.timeScale = 1;
        _pauseButton.gameObject.SetActive(true);
        _playButton.gameObject.SetActive(false);
        _exitPopup.gameObject.SetActive(false);
    }

    public void ClickExit() {
        Time.timeScale = 0;
        _exitPopup.gameObject.SetActive(true);
    }

    public void ExitForSure() {
        Application.Quit();
    }
}