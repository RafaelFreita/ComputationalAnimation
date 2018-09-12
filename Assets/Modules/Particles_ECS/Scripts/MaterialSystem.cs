using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using Unity.Rendering;

namespace Particles
{
    public class ParticleColorSystem : JobComponentSystem
    {

        //[BurstCompile]
        //struct ParticleColorJob : IJobProcessComponentData<ParticleColor>
        //{
        //    public Material material;

        //    public void Execute(ref ParticleColor color)
        //    {
        //        material.color = color.value;
        //    }
        //}

        
        //protected override JobHandle OnUpdate(JobHandle inputDeps)
        //{
        //    ParticleColorJob particleColorJob = new ParticleColorJob
        //    {
        //        material = renderer.material
        //    };

        //    JobHandle particleColorHandle = particleColorJob.Schedule(this, 64, inputDeps);

        //    return particleColorHandle;
        //}

    }

}