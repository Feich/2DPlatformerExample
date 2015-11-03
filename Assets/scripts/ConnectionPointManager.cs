using UnityEngine;
using System.Collections;

public class ConnectionPointManager : MonoBehaviour {

    public Transform beginPoint;
    public Transform endPoint;

	// Use this for initialization
	void Start () {
        Transform[] points = GetComponentsInChildren<Transform>();
        foreach (Transform point in points)
        {
            if (point.tag.Equals("Begin Point"))
            {
                beginPoint = point;
            }
            if (point.tag.Equals("End Point"))
            {
                endPoint = point;
            }
        }
	}
}
