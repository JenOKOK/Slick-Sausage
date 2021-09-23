using UnityEngine;
using UnityEngine.UI;

public class Trajectory : MonoBehaviour
{
    [SerializeField] private int _maxDistance;
    [SerializeField] private Transform _startPosition;

    private Sausage _sausage;
    private LineRenderer _lineRenderer;
    

    private void Awake()
    {
        _sausage = FindObjectOfType<Sausage>();
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
       
        if (_sausage.CurrentTrajectory != Vector3.zero)
        {
            TrajectoryGraphicSetActive(true);
            OnDrawTrajectory();
        }
        else
        {
            TrajectoryGraphicSetActive(false);
        }
    }

    private void TrajectoryGraphicSetActive(bool value)
    {
        _lineRenderer.enabled = value;
    }

    private void OnDrawTrajectory()
    {
        Vector3[] points = new Vector3[_maxDistance];
        _lineRenderer.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.01f;

            points[i] = _startPosition.position + _sausage.CurrentTrajectory * time + Physics.gravity * time * time / 2f;
        }

        _lineRenderer.SetPositions(points);  
    }
  
}
