using UnityEngine;

public class BilliardBallController : MonoBehaviour
{
    [SerializeField] private float _force = 50f;
    [SerializeField] private Rigidbody _rb;
   
    void Start()
    {
        _rb.AddForce(transform.forward * _force, ForceMode.Impulse);
    }
}
