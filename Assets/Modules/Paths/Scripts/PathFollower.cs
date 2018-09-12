using UnityEngine;

public class PathFollower : MonoBehaviour
{

    [Header("Curve")]

    [SerializeField]
    public float spacing = .5f;
    [SerializeField]
    public float resolution = 1.0f;
    public SampleCurve sampleCurve;
    public PathCreator pathCreator;

    [Header("Follower")]

    [Range(0.01f, 10f), SerializeField]
    public float rpm = 1.0f;

    private Path path;
    private float _t;
    private int currentIdx = 0;
    private Vector3[] currentVertexes;
    private int numSegments;
    //private Vector3[] _points;

    //private void Start()
    //{
    //    _points = pathCreator.path.CalculateEvenlySpacedPoints(spacing, resolution);
    //}

    private void Start()
    {
        path = pathCreator.path;
        numSegments = path.NumSegments;
    }

    private void Update()
    {
        float sampleT = sampleCurve.Evaluate(_t);
        float tOnCurve = CheckCurrentSegment(sampleT);

        float segmentStep = 1f / numSegments;

        sampleT = sampleT.Remap(currentIdx * segmentStep, (currentIdx + 1) * segmentStep, 0f, 1f);

        transform.position = Bezier.EvaluateCubicCurve(
            currentVertexes[0], currentVertexes[1], currentVertexes[2], currentVertexes[3], sampleT);

        IncreaseT();

        sampleT = sampleCurve.Evaluate(_t + 0.05f);
        CheckCurrentSegment(sampleT);
        sampleT = sampleT.Remap(currentIdx * segmentStep, (currentIdx + 1) * segmentStep, 0f, 1f);

        // Adding 0.05f to add some space between current position and future position for a more accurate rotation
        Vector3 lookPos = Bezier.EvaluateCubicCurve(
            currentVertexes[0], currentVertexes[1], currentVertexes[2], currentVertexes[3], sampleT);
        transform.LookAt(lookPos);
    }

    //private int LoopIndex(int i)
    //{
    //    return (i + _points.Length) % _points.Length;
    //}

    // This make zero sense. Fix
    private float CheckCurrentSegment(float t)
    {
        float tOnCurve = t * numSegments;
        int currentIndex = Mathf.FloorToInt(tOnCurve);
        if (currentIndex >= numSegments)
        {
            currentIndex = numSegments - 1;
        }

        currentVertexes = path.GetPointsInSegment(currentIndex);

        Debug.Log(tOnCurve);
        Debug.Log(currentIndex);
        if (currentIndex != currentIdx)
        {
            currentIdx = currentIndex;
            currentVertexes = path.GetPointsInSegment(currentIndex);
        }
        return tOnCurve;
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
