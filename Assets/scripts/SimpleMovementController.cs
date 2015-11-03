using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class SimpleMovementController : MonoBehaviour {

    private Rigidbody2D m_Rigidbody;
    private float horizontalInput;
    [SerializeField] private float movementSpeedMultiplier = 20f;
    [SerializeField] private float jumpHeightMultiplier = 30f;

	// Use this for initialization
	void Start () 
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        // Collect inputs here
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            m_Rigidbody.velocity += new Vector2(0, jumpHeightMultiplier);
        }
	}

    // Do physics related operations here
    void FixedUpdate()
    {
        // Now the input values are used for altering the velocity of the rigidbody
        m_Rigidbody.velocity = new Vector3(
            horizontalInput * movementSpeedMultiplier,
            m_Rigidbody.velocity.y,
            0
        );
    }
}
