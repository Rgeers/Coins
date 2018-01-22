using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour {
    [SerializeField] private Transform _coinPrefab;
    private Vector3 _spawnPosition, _mousePosition;
    private int _coinCounter = 0, _totalCoins = 0;

    private void Start() {
        _coinCounter = 5;
        _spawnPosition = transform.position;
        _spawnPosition.y += 0.3f;
    }

    private void OnMouseDown() {
        if (_totalCoins > 0 && _coinCounter > 0) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.name == "CoinSpawner") {
                    StartCoroutine("CountCoins");
                    PlayerPrefs.SetInt("Player Score", (PlayerPrefs.GetInt("Player Score") - 1));
                    Instantiate(_coinPrefab, hit.point, _coinPrefab.transform.rotation);
                }
            }
        }
    }

    private IEnumerator CountCoins() {
        _coinCounter--;
        yield return new WaitForSeconds(5);
        _coinCounter++;
    }

    private void Update() {
        _totalCoins = PlayerPrefs.GetInt("Player Score");
        PlayerPrefs.SetInt("Coin Counter", _coinCounter);
    }
}