using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerProfile playerProfile;
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
        RotatePlayer();
    }

    void Move()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveDirection.normalized * playerProfile.moveSpeed;
        playerBody.velocity = moveVelocity;
    }

    private void RotatePlayer()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        var camRayLength = 100f;

        if (groundPlane.Raycast(cameraRay, out camRayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(camRayLength);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
}
