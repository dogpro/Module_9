using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class SuperManController : MonoBehaviour
{

    [SerializeField] private float _currentForce = 5f;
    [SerializeField] private float _maxForce = 20f;
    [SerializeField] private float _forceRotation = 50f;
    [SerializeField] private float _pushForce = 50f;
    [SerializeField] private Rigidbody _rb;

    private float forceControlV;
    private float forceControlH;

    private void OnCollisionEnter(Collision collision)
    {
        var layer = collision.gameObject.layer;

        if (layer == LayerMask.NameToLayer("BadGuy"))
        {
            ContactPoint contact = collision.contacts[0];
            collision.rigidbody.AddForce(-contact.normal * _pushForce, ForceMode.Impulse);
        }
        else
        {
            _currentForce /= 2f;
        }
    }
    private void Update()
    {
        forceControlV = Input.GetAxis("Vertical");
        forceControlH = Input.GetAxis("Horizontal");

        if (_currentForce < _maxForce)
        {
            _currentForce += 3 * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
       _rb.AddForce(Vector3.forward * _currentForce);
 
        _rb.AddForce(Vector3.up * forceControlV * _forceRotation);
        _rb.AddForce(Vector3.right * forceControlH * _forceRotation);
    }
}
