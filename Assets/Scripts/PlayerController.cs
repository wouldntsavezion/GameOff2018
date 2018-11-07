using UnityEngine;

public class PlayerController: MonoBehaviour {
    private Rigidbody rigidBody;
    private float verticalInput;
    private float horizontalInput;

    public float speed = 10f;
    public float turnSpeed = 1f;

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


    private void Turn() {
        float turn = horizontalInput * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rigidBody.MoveRotation(rigidBody.rotation * turnRotation);
    }
}