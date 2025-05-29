using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class SuperManController : MonoBehaviour
{

    [SerializeField] private float _forwardSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 50f;
    [SerializeField] private float _pushForce = 50f;
    [SerializeField] private Rigidbody _rb;


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
            transform.Rotate(Vector3.forward * -90 * _rotationSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * _forwardSpeed * Time.deltaTime);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.forward * -horizontal * _rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right * -vertical * _rotationSpeed * Time.deltaTime);
    }
}
