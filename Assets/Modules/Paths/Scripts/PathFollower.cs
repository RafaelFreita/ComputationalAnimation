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

    private void Start()
    {
        _points = pathCreator.path.CalculateEvenlySpacedPoints(spacing, resolution);
    }

    private void Update()
    {
        float sampleT = sampleCurve.Evaluate(_t);
        Debug.Log(sampleT);
        int currentIndex = Mathf.RoundToInt((_points.Length * sampleT));
        transform.position = Vector3.Lerp(_points[LoopIndex(currentIndex)], _points[LoopIndex(currentIndex+1)], sampleT);
        IncreaseT();

        // Adding 0.05f to add some space between current position and future position for a more accurate rotation
        Vector3 nextPos = Vector3.Lerp(_points[LoopIndex(currentIndex)], _points[LoopIndex(currentIndex + 1)], sampleCurve.Evaluate(_t + 0.05f));
        //transform.rotation = _startingRot * Quaternion.FromToRotation(transform.position, nextPos - transform.position);
        transform.LookAt(nextPos);
    }

    private int LoopIndex(int i)
    {
        return (i + _points.Length) % _points.Length;
    }

    private void IncreaseT()
    {
        _t += rpm / 60f * Time.deltaTime * 60.0f;
        if (_t >= 1.0f)
        {
            _t -= 1.0f;
        }
    }

}
