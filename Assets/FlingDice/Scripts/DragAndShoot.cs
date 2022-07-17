using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    public float shootpowerRotation = 10.0f;
    public float forceMultiplier = 4.0f;
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;

    private bool isShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        Vector3 forceInit = (Input.mousePosition - mousePressDownPos);
        Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, forceInit.magnitude)) * forceMultiplier;
        if (!isShoot)
        {
            DrawTrajectory.Instance.UpdateTrajectory(forceV, rb, transform.position);
        }
    }
    private void OnMouseUp()
    {
        DrawTrajectory.Instance.HideLine();
        mouseReleasePos = Input.mousePosition;
        Shoot(mouseReleasePos-mousePressDownPos);
    }

    void Shoot(Vector3 Force)
    {
        if (isShoot)
        {
            return;
        }
        rb.isKinematic = false;
        rb.AddForce(new Vector3(Force.x, Force.y, Force.magnitude) * forceMultiplier);
        rb.AddTorque(transform.up * shootpowerRotation, ForceMode.Impulse);
        rb.AddTorque(transform.right * shootpowerRotation, ForceMode.Impulse);
        isShoot = true;

    }
}
