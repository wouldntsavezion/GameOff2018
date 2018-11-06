using UnityEngine;

public class PlayerController: MonoBehaviour {
    private Rigidbody rigidBody;
    private float verticalInput;
    private float horizontalInput;

    public float speed = 12f;
    public float turnSpeed = 180f;

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
        Vector3 movement = (Vector3.forward * verticalInput + Vector3.right * horizontalInput) * speed * Time.deltaTime;
        rigidBody.MovePosition(rigidBody.position + movement);
    }


    private void Turn() {
        float turn = horizontalInput * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rigidBody.MoveRotation(rigidBody.rotation * turnRotation);
    }
}