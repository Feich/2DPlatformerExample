using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {

    private Camera controlledCamera;
    private Transform player;
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () 
    {
        controlledCamera = GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (player != null)
        {
            Vector3 point = controlledCamera.WorldToViewportPoint(player.position);
            Vector3 delta = player.position - controlledCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
	}

    void FixedUpdate()
    {

    }
}
