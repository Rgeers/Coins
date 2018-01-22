using UnityEngine;
using System.Collections;


public class TutorialManager : MonoBehaviour {
    private void Start() {
        StartCoroutine(Start(8));
    }

    private IEnumerator Start(int timesUntilDone) {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        for (int i = 0; i < timesUntilDone; i++) {
            meshRenderer.enabled = !meshRenderer.enabled;
            yield return new WaitForSeconds(1);
        }
    }
}