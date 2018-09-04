using UnityEngine;

public class CircularFollower : MonoBehaviour {

    [SerializeField, Range(0.01f, 10f)]
    public float rpm = 1;
    [SerializeField]
    public float radius = 1.0f;
    public SampleCurve sampleCurve;

    protected Vector3 _startingPos;
    protected Quaternion _startingRot;
    protected float _t = 0.0f;

    private void Start()
    {
        _startingPos = transform.position;
        _startingRot = transform.rotation;
    }

    public void Update()
    {
        transform.position = Circular.Evaluate(radius, sampleCurve.Evaluate(_t)) + _startingPos;
        IncreaseT();
        Vector3 nextPos = Circular.Evaluate(radius, sampleCurve.Evaluate(_t)) + _startingPos;
        transform.rotation = _startingRot * Quaternion.FromToRotation(transform.position, nextPos - transform.position);
    }

    protected void IncreaseT()
    {
        _t += rpm / 60f;
        if(_t >= 1.0f)
        {
            _t -= 1.0f;
        }
    }

}
