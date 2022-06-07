using UnityEngine;

public class CelestialBody : MonoBehaviour 
{
    private Rigidbody _rigidbody;

    public float radius;
    public float surfaceGravity;
    public Vector3 initialVelocity;

    public float mass { get; private set; }

    private void Start() 
    {
        mass = surfaceGravity * radius * radius / Universe.GravitationalConstant;
        transform.localScale = Vector3.one * radius;
        
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.mass = mass;
        _rigidbody.velocity = initialVelocity;
    }

    public void UpdateVelocity(Vector3 acceleration) 
    {
        _rigidbody.AddForce(acceleration, ForceMode.Acceleration);
    }
}