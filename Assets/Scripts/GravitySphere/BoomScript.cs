using UnityEngine;

public class BoomScript : MonoBehaviour
{
    [SerializeField] private float _timeToExplosion = 3f;
    [SerializeField] private float _radius = 3f;
    [SerializeField] private float _power = 3f;
    [SerializeField] private Rigidbody[] _rbs;
    
    void Start()
    {
        
    }

    void Update()
    {
        _timeToExplosion -= Time.deltaTime;

        if (_timeToExplosion <= 0)
        {
            Boom();
        }
    }

    private void Boom()
    {
        foreach (var rb in _rbs)
        {
            if (Vector3.Distance(transform.position, rb.transform.position) < _radius)
            {
                Vector3 direction = rb.transform.position - transform.forward;

                rb.AddForce(direction.normalized * _power * (_radius - Vector3.Distance(
                    transform.position, rb.transform.position)), ForceMode.Impulse);
            }

            _timeToExplosion = 3;
        }
    }
}
