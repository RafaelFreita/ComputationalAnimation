using UnityEngine;

public class SpiralFollower : CircularFollower {

    [SerializeField]
    public int spins = 1;

    public new void Update()
    {
        float currentRadius = radius * (1f - sampleCurve.Evaluate(_t));
        transform.position = Circular.Evaluate(currentRadius, sampleCurve.Evaluate(_t) * spins) + _startingPos;

        IncreaseT();

        // Adding 0.05f to add some space between current position and future position for a more accurate rotation
        float nextRadius = radius * (1f - sampleCurve.Evaluate(_t+0.05f));
        Vector3 nextPos = Circular.Evaluate(nextRadius, sampleCurve.Evaluate(_t+0.05f) * spins) + _startingPos;
        
        transform.LookAt(nextPos);
    }

    protected new void IncreaseT()
    {
        _t += rpm / 60f * Time.deltaTime * 60.0f;
        if (_t >= 1.0f)
        {
            _t -= 1.0f;
        }
    }

}
