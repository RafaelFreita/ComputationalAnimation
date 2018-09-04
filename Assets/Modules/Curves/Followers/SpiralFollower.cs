using UnityEngine;

public class SpiralFollower : CircularFollower {

    [SerializeField]
    public int spins = 1;

    public new void Update()
    {
        float currentRadius = radius * (1f - sampleCurve.Evaluate(_t));
        transform.position = Circular.Evaluate(currentRadius, sampleCurve.Evaluate(_t) * spins) + _startingPos;

        IncreaseT();

        float nextRadius = radius * (1f - sampleCurve.Evaluate(_t));
        Vector3 nextPos = Circular.Evaluate(nextRadius, sampleCurve.Evaluate(_t)) + _startingPos;
        //transform.rotation= _startingRot * Quaternion.FromToRotation(transform.position, nextPos - transform.position);
    }

    protected new void IncreaseT()
    {
        _t += rpm / 60f;
        if (_t >= 1.0f)
        {
            _t -= 1.0f;
        }
    }

}
