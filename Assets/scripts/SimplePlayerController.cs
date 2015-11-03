using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class SimplePlayerController : MonoBehaviour {

    public Rigidbody2D myRigidbody { get; private set; }
    [SerializeField] private LayerMask floorLayer;
    
    private IState currentState;
    private Dictionary<string, IState> states;
    public static string IdleState = "Idle";
    public static string RunState = "Run";
    public static string JumpState = "Jump";

    private float horizontalInput; // by default, A and D keys
    private float movement; // the actual movement, movementSpeed multiplied by horizontalInput
    public float movementSpeed = 20f; // the speed multiplier
    public float jumpVelocity = 30f; // the velocity value that is added to the current velocity vector when player jumps

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();

        // instantiate dictionary and add states
        states = new Dictionary<string, IState>();
        states.Add(IdleState, new PlayerIdleState());
        states.Add(RunState, new PlayerRunState());
        states.Add(JumpState, new PlayerJumpState());

        if (floorLayer == 0) // if floor layer has not been set in the inspector, set it to layer named Floor
        {
            floorLayer = LayerMask.GetMask("Floor");
        }

        // set the current state to Idle
        currentState = states[IdleState];
        currentState.OnEnter(this);
	}
	
	// Update is called once per frame
	void Update () {
        horizontalInput = Input.GetAxis("Horizontal"); // collect horizontal Input
        if (currentState is PlayerRunState) // multiply movementSpeed with horizontalInput if Running
        {
            movement = movementSpeed * horizontalInput;
        }
        currentState.OnUpdate(this); // state update
	}

    void FixedUpdate()
    {
        myRigidbody.velocity = new Vector2(movement, myRigidbody.velocity.y);
    }

    public void Transition(string nextState)
    {
        IState endState = states[nextState];
        endState.OnEnter(this);
        currentState.OnExit(this);
        currentState = endState;
    }

    // check if player is on ground
    public bool IsGrounded()
    {
        // cast a 2D ray downwards with distance of 2f, accept collision only if the object is on floor layer
        if (Physics2D.Raycast(transform.position, Vector2.down, 2f, floorLayer)) 
        {
            Debug.Log("Is on ground");
            return true;
        }
        return false;
    }

    // called from outside the controller, from the jump state (when entered)
    public void Jump()
    {
        myRigidbody.velocity += new Vector2(0, jumpVelocity);
    }
}
