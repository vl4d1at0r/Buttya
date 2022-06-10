using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Physics : MonoBehaviour
{
    #region Fields
    
    private List<CelestialBody> _bodies;

    #endregion

    #region Constructors

    [Inject]
    public void Construct(List<CelestialBody> bodies)
    {
        _bodies = bodies;
    }

    #endregion

    #region Events

    void FixedUpdate()
    {
        foreach (var body in _bodies)
        {
            Vector3 acceleration = CalculateAcceleration(body.transform.position, body);
            body.UpdateVelocity(acceleration);
        }
    }
    
    #endregion

    #region Private Methods
    
    private Vector3 CalculateAcceleration(Vector3 point, CelestialBody ignoreBody = null)
    {
        Vector3 acceleration = Vector3.zero;
        foreach (var body in _bodies)
        {
            if (body != ignoreBody)
            {
                var position = body.transform.position;
                float sqrDst = (position - point).sqrMagnitude;
                Vector3 forceDir = (position - point).normalized;
                acceleration += forceDir * (Constants.GravitationalConstant * body.mass) / sqrDst;
            }
        }

        return acceleration;
    }
    
    #endregion
}
