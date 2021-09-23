using UnityEngine;

public class Sausage : MonoBehaviour
{
    [SerializeField] private float _maxForceLaunch;
    [SerializeField] private float _smoothForceValue;
    [SerializeField] private Rigidbody _rigidbodySigment;

    private TouchInput _touchInput;
    private GroundChecker _groundChecker;
    public Vector3 CurrentTrajectory { get; private set; }

    private void Awake()
    {
        _touchInput = FindObjectOfType<TouchInput>();
        _groundChecker = GetComponentInChildren<GroundChecker>();
    }

    private void OnEnable()
    {
        _touchInput.LaunchTrajectory += OnLaunchTrajectory;
    }
    private void OnDisable()
    {
        _touchInput.LaunchTrajectory -= OnLaunchTrajectory;
    }

    private void FixedUpdate()
    {
        if (_groundChecker.IsGrounded)
        {
            if(CurrentTrajectory.y > 0f && !_touchInput.IsDrag)
            {
                 _rigidbodySigment.AddForce(CurrentTrajectory, ForceMode.Impulse);
                CurrentTrajectory = Vector3.zero;
            }
        } 
    }

    private void OnLaunchTrajectory(float force, Vector3 direction)
    {
        CurrentTrajectory = direction * Mathf.Clamp(force / _smoothForceValue, 0f, _maxForceLaunch);
    }
}
