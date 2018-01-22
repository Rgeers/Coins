using UnityEngine;
using System.Collections;


public class TutorialManager : MonoBehaviour {
	void Start () 
    {
        StartCoroutine(Start(4));
	}

    IEnumerator Start(int timesUntilDone)
    {
        for (int i = 0; i < timesUntilDone; i++)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(1);
            this.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(1);
        }
    }
    
}
