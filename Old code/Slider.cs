using UnityEngine;
using System.Collections;

public class Slider : MonoBehaviour {
    private Vector3 upPos, downPos;
    private bool target;
	// Use this for initialization
	void Start () {
        upPos = transform.position;
        downPos = transform.position;
        downPos.x += 0.4f;
        target = true;
	}
	
	// Update is called once per frame
	void Update () {
	    if (target == true)
        {
            if (Vector3.Distance(transform.position, downPos) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, downPos, 0.2f* Time.deltaTime);
            }
            else
            {
                target = false;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, upPos) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, upPos, 0.2f * Time.deltaTime);
            }
            else
            {
                target = true;
            }
        }
	}
}
