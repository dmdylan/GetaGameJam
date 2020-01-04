using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 50f;
    [SerializeField] Rigidbody playerBody;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 moveVelocity;

    void Awake()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveDirection.normalized * moveSpeed;
        playerBody.velocity = moveVelocity;
    }
}
