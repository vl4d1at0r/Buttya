using UnityEngine;

[ExecuteAlways]
[RequireComponent (typeof (Rigidbody))]
public class CelestialBody : MonoBehaviour 
{
    private Rigidbody _rigidbody;

    public float radius;
    public float surfaceGravity;
    public Vector3 initialVelocity;

    public float mass { get; private set; }
    void Awake () 
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.mass = mass;
        _rigidbody.velocity = initialVelocity;
    }

    public void UpdateVelocity (Vector3 acceleration) 
    {
        _rigidbody.AddForce(acceleration, ForceMode.Acceleration);
    }

    void OnValidate () 
    {
        mass = surfaceGravity * radius * radius / Universe.gravitationalConstant;
        transform.localScale = Vector3.one * radius;
    }
}