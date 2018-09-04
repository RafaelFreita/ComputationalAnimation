using UnityEngine;

public class CircularFollower : MonoBehaviour {

    [SerializeField, Range(0.01f, 10f)]
    public float rpm = 1;
    [SerializeField]
    public float radius = 1.0f;
    public SampleCurve sampleCurve;

    protected Vector3 _startingPos;
    protected float _t = 0.0f;

    private void Start()
    {
        _startingPos = transform.position;
    }

    public void Update()
    {
        transform.position = Circular.Evaluate(radius, sampleCurve.Evaluate(_t)) + _startingPos;
        IncreaseT();

        // Adding 0.05f to add some space between current position and future position for a more accurate rotation
        Vector3 nextPos = Circular.Evaluate(radius, sampleCurve.Evaluate(_t+0.05f)) + _startingPos;
        transform.LookAt(nextPos);
    }

    protected void IncreaseT()
    {
        _t += rpm / 60f * Time.deltaTime * 60.0f;
        if(_t >= 1.0f)
        {
            _t -= 1.0f;
        }
    }

}
