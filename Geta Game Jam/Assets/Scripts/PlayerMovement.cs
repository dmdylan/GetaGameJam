using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerProfile playerProfile;

    void FixedUpdate()
    {
        Move();
        //RotatePlayer();
    }

    void Move()
    {
        float forwardMovement;
        float sideMovement;

        forwardMovement = Input.GetAxisRaw("Vertical") * playerProfile.moveSpeed * Time.deltaTime;
        sideMovement = Input.GetAxisRaw("Horizontal") * playerProfile.moveSpeed * Time.deltaTime;

        transform.Translate(sideMovement, 0, forwardMovement);
    }

    //private void RotatePlayer()
    //{
    //    Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
    //    var camRayLength = 100f;
    //
    //    if (groundPlane.Raycast(cameraRay, out camRayLength))
    //    {
    //        Vector3 pointToLook = cameraRay.GetPoint(camRayLength);
    //        transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
    //    }
    //}
}
