using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ParticleData {

    public Vector3 position;
    public Vector3 direction;

    public float lifeSpan;
    private float lifeTime;
    
    public Color color;
    public float opacity;
    

    ParticleData(Vector3 position, Vector3 direction, float lifeSpan,Color color, float opacity = 1f)
    {
        this.position = position;
        this.direction = direction;

        this.lifeSpan = lifeSpan;
        lifeTime = lifeSpan;

        this.color = color;
        this.opacity = opacity;
    }
}
