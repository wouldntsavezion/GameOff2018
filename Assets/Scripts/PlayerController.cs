using UnityEngine;

public class PlayerController: MonoBehaviour {
    private Rigidbody rigidBody;
    private float verticalInput;
    private float horizontalInput;

    public float speed;
    public float turnSpeed;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update() {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate() {
        Move();
    }

    private void Move() {
        // TODO : Fix possible Sqrt(2) Speed

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime;
        rigidBody.MovePosition(rigidBody.position + movement);

        movement.Normalize();
        if(movement != Vector3.zero) {
            Quaternion newRotation = Quaternion.LookRotation(movement);
            rigidBody.MoveRotation(Quaternion.Slerp(rigidBody.rotation, newRotation, Time.deltaTime * turnSpeed));
        }
    }
}