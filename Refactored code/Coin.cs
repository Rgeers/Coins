using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
    private void OnCollisionEnter(Collision other) {
        if (other.transform.gameObject.name == "CoinLost") {
            StartCoroutine("CoinKiller");
            this.GetComponent<BoxCollider>().enabled = false;
        }
        if (other.transform.gameObject.name == "CoinWon") {
            PlayerPrefs.SetInt("Player Score", (PlayerPrefs.GetInt("Player Score") + 1));
            StartCoroutine("CoinKiller");
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }

    IEnumerator CoinKiller() {
        yield return new WaitForSeconds(3);
        Destroy(this);
    }
}