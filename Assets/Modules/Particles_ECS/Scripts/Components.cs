using Unity.Entities;
using Unity.Mathematics;

namespace Particles
{

    public struct ParticleDirection : IComponentData
    {
        public float3 Value;
    }

    public struct ParticleColor : IComponentData
    {
        public UnityEngine.Color value;
    }

    public struct ParticleOpacity : IComponentData
    {
        public float value;
    }

    public struct ParticleLife : IComponentData
    {
        public float lifeTime;
        public float lifeSpan;
    }

    [System.Serializable]
    public struct ParticleBillboard : IComponentData
    {
        public float Value;
    }

}