
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovementHandle : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] Rigidbody rb;
    [SerializeField] float thrustStrength = 1000f;
    [SerializeField] float rotationStrength = 100f;
    [SerializeField] float inputRotate;
    [SerializeField] Vector3 vector3InputRotate;

    private AudioSource audioSource;
    private void OnEnable()
    {
        EnableInputAction();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        HandleThrust();
        HandleRotation();
    }

    private void HandleThrust()
    {
        if (thrust.IsPressed())
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }    
    }
    private void HandleRotation()
    {
        inputRotate = rotation.ReadValue<float>();
        vector3InputRotate = Vector3.forward * inputRotate;
        if (inputRotate != 0)
        {
            transform.Rotate(vector3InputRotate * -rotationStrength * Time.fixedDeltaTime);
        }
    }
    private void EnableInputAction()
    {
        thrust.Enable();
        rotation.Enable();
    }
}
