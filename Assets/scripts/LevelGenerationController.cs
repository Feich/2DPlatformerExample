using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerationController : MonoBehaviour {

    public Transform player;
    public GameObject floor;
    public GameObject[] parts; // level parts used
    public float allowedDistanceUntilEnd = 10f; // if distance from end is lower than this value, moving is triggered 
    public GameObject currentPart;
    private ConnectionPointManager currentConnectionPoints;
    public GameObject nextPart;
    private ConnectionPointManager nextConnectionPoints;

    private int currentPartIndex; // for preventing the use of the same part twice in a row

	// Use this for initialization
	void Start () {
        // find player and floor
        player = GameObject.FindGameObjectWithTag("Player").transform;
        floor = GameObject.FindGameObjectWithTag("Floor");

        // assign the origin level part or block as the current part
        currentPart = floor.transform.FindChild("Origin").gameObject;
        currentConnectionPoints = currentPart.GetComponent<ConnectionPointManager>();

        // pick randomly the next part to be moved to the end of the level
        int nextPartIndex = Random.Range(0, parts.Length);
        nextPart = parts[nextPartIndex];
        nextConnectionPoints = nextPart.GetComponent<ConnectionPointManager>();
        currentPartIndex = nextPartIndex; // cycle indexes
	}
	
	// Update is called once per frame
	void Update () {
        ObservePlayerDistance();
	}

    // move the randomly chosen next part to the end of the level
    // the next part is placed so that it seamlessly joins the previous part
    void MoveNextPart()
    {
        float nextY = currentConnectionPoints.endPoint.position.y - nextConnectionPoints.beginPoint.localPosition.y;
        nextPart.transform.position = new Vector3(currentPart.transform.position.x + 50, nextY, 0);
    }

    void ObservePlayerDistance()
    {
        // if the player is close to the end of the level (or more than allowed)
        if (currentConnectionPoints.endPoint.position.x - player.transform.position.x < allowedDistanceUntilEnd)
        {
            MoveNextPart(); // move next part to the end of the level
            CycleParts(); // assign the moved part to the current part and choose a new next part
        } 
    }

    void CycleParts()
    {
        currentPart = nextPart;
        currentConnectionPoints = nextConnectionPoints;

        // choose a random number and use it as index to pick a new part
        int nextPartIndex = Random.Range(0, parts.Length);
        // prevent the same part from being used twice
        while (nextPartIndex == currentPartIndex)
        {
            nextPartIndex = Random.Range(0, parts.Length);
        }
        nextPart = parts[nextPartIndex];
        currentPartIndex = nextPartIndex; // cycle indexes
        nextConnectionPoints = nextPart.GetComponent<ConnectionPointManager>();
    }
}
