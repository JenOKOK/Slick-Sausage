using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _distanceGroundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private RaycastHit[] _checkGroundResult = new RaycastHit[1];

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        if (GroundCheck() != 0)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }

    private int GroundCheck()
    {
        return Physics.RaycastNonAlloc(transform.position, Vector3.down, _checkGroundResult, _distanceGroundCheck, _groundLayer);
    }
}
