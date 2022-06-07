using UnityEngine;

public class Physics : MonoBehaviour
{
    private CelestialBody[] _bodies;
    private static Physics _instance;

    void Awake()
    {
        _bodies = FindObjectsOfType<CelestialBody>();
    }

    void FixedUpdate()
    {
        for (int i = 0; i < _bodies.Length; i++)
        {
            Vector3 acceleration = CalculateAcceleration(_bodies[i].transform.position, _bodies[i]);
            _bodies[i].UpdateVelocity(acceleration);
        }
    }

    private static Vector3 CalculateAcceleration(Vector3 point, CelestialBody ignoreBody = null)
    {
        Vector3 acceleration = Vector3.zero;
        foreach (var body in Instance._bodies)
        {
            if (body != ignoreBody)
            {
                var position = body.transform.position;
                float sqrDst = (position - point).sqrMagnitude;
                Vector3 forceDir = (position - point).normalized;
                acceleration += forceDir * (Universe.gravitationalConstant * body.mass) / sqrDst;
            }
        }

        return acceleration;
    }

    static Physics Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Physics>();
            }

            return _instance;
        }
    }
}