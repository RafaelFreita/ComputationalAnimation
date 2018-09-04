using UnityEngine;

public class PathFollower : MonoBehaviour {

    [Header("Curve")]

    [SerializeField]
    public float spacing = .5f;
    [SerializeField]
    public float resolution = 1.0f;
    public PathCreator pathCreator;
    public SampleCurve sampleCurve;

    [Header("Follower")]

    [Range(0.01f, 10f), SerializeField]
    public float rpm = 1.0f;

    private float _t;
    private Vector3[] _points;
    protected Quaternion _startingRot;

    private void Start()
    {
        _points = pathCreator.path.CalculateEvenlySpacedPoints(spacing, resolution);

        _startingRot = transform.rotation;
    }

    private void Update()
    {
        int currentIndex = Mathf.CeilToInt((_points.Length * sampleCurve.Evaluate(_t)));
        transform.position = Vector3.Lerp(_points[LoopIndex(currentIndex)], _points[LoopIndex(currentIndex+1)], sampleCurve.Evaluate(_t));
        IncreaseT();

        Vector3 nextPos = Vector3.Lerp(_points[LoopIndex(currentIndex)], _points[LoopIndex(currentIndex + 1)], sampleCurve.Evaluate(_t));
        transform.rotation = _startingRot * Quaternion.FromToRotation(transform.position, nextPos - transform.position);
    }

    private int LoopIndex(int i)
    {
        return (i + _points.Length) % _points.Length;
    }

    private void IncreaseT()
    {
        _t += rpm / 60f;
        if (_t >= 1.0f)
        {
            _t -= 1.0f;
        }
    }

}
