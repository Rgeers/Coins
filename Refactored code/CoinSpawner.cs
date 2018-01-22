using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    public Transform coinPrefab;
    private Vector3 spawnPosition, mousePosition;
    private int coinCounter = 0, totalCoins = 0;
    void Start()
    {
        coinCounter = 5;
        spawnPosition = transform.position;
        spawnPosition.y += 0.3f;
    }

   void OnMouseDown()
    {
       if (totalCoins > 0 && coinCounter > 0)
       {
           RaycastHit hit;
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           if (Physics.Raycast(ray, out hit))
           {
               if (hit.transform.name == "CoinSpawner")
               {
                   StartCoroutine("CountCoins");
                   PlayerPrefs.SetInt("Player Score", (PlayerPrefs.GetInt("Player Score")-1));
                   Instantiate(coinPrefab, hit.point, coinPrefab.transform.rotation);
               }

           }
       }
    }
   IEnumerator CountCoins()
   {
       coinCounter--;
       yield return new WaitForSeconds(5);
       coinCounter++;
   }
    void Update()
   {
       totalCoins = PlayerPrefs.GetInt("Player Score");
       PlayerPrefs.SetInt("Coin Counter", coinCounter);
   }
}
