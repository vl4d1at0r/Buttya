using UnityEngine;

public class Physics : MonoBehaviour
{
    #region Fields
    
    private CelestialBody[] _bodies;
    private static Physics _instance;
    
    #endregion

    #region Events

    void Start()
    {
        _bodies = FindObjectsOfType<CelestialBody>();
    }

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