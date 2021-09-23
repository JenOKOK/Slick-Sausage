using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TouchInput : MonoBehaviour, IDragHandler, IDropHandler
{
    private RectTransform _pointerLaunch;
    private Canvas _mainCanvas;
    private GroundChecker _groundChecker;
    private Vector2 _startPointerPosition;

    public event UnityAction<float, Vector3> LaunchTrajectory;
    public bool IsDrag { get; private set; }

    private Vector2 _endPosition;

    private void Awake()
    {
        _mainCanvas = GetComponentInParent<Canvas>();
        _pointerLaunch = GetComponentInChildren<RectTransform>();
        _groundChecker = FindObjectOfType<GroundChecker>();
        _startPointerPosition = _pointerLaunch.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_groundChecker.IsGrounded)
        {
            IsDrag = true;
            _pointerLaunch.position += (Vector3)eventData.delta;
            Debug.Log(_mainCanvas.scaleFactor);
            _endPosition = _pointerLaunch.position / _mainCanvas.scaleFactor + (Vector3)eventData.delta / _mainCanvas.scaleFactor;
            LaunchTrajectory?.Invoke(ForceLaunch(), -DistanceBetween().normalized);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        ResetLaunch();
    }

    private float ForceLaunch()
    {
        return DistanceBetween().magnitude;
    }

    private Vector2 DistanceBetween()
    {
         return _endPosition - _startPointerPosition;
    }

    private void ResetLaunch()
    {
        IsDrag = false;
        _pointerLaunch.position = _startPointerPosition;
        _endPosition = Vector2.zero;
    }
}
