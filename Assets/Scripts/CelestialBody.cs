using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CelestialBody : MonoBehaviour 
{
    #region Fields

    private Rigidbody _rigidbody;

    public float radius;
    public float surfaceGravity;
    public Vector3 initialVelocity;

    public float mass { get; private set; }
    
    #endregion

    #region Constructors
    
    [Inject]
    public void Construct(List<CelestialBody> bodies)
    {
        bodies.Add(this);
    }

    #endregion

    #region Events

    private void Start() 
    {
        mass = surfaceGravity * radius * radius / Constants.GravitationalConstant;
        transform.localScale = Vector3.one * radius;
        
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.mass = mass;
        _rigidbody.velocity = initialVelocity;
    }
    
    #endregion

    #region Public Methods

    public void UpdateVelocity(Vector3 acceleration) 
    {
        _rigidbody.AddForce(acceleration, ForceMode.Acceleration);
    }
    
    #endregion
}
