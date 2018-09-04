using UnityEngine;

public class LinearFollower : MonoBehaviour {

    [SerializeField, Range(0.01f, 10f)]
    public float rpm = 1;
    [SerializeField, HideInInspector]
    public Vector3 dstPoint;
    public SampleCurve sampleCurve;

    private Vector3 _startingPos;
    private float _t = 0.0f;
    private Quaternion _startingRot;

    void Start () {
        _startingPos = transform.position;
        _startingRot = transform.rotation;
    }
	
	void Update () {
        transform.position = Vector3.Lerp(_startingPos, dstPoint, sampleCurve.Evaluate(_t));
        transform.LookAt(dstPoint);
        IncreaseT();
    }

    protected void IncreaseT()
    {
        _t += rpm / 60f;
        if (_t >= 1.0f)
        {
            _t -= 1.0f;
        }
    }
}
