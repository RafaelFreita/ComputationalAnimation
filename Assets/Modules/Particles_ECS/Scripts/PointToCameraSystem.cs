using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Particles;

public class PointToCameraSystem : JobComponentSystem
{

    [ComputeJobOptimization]
    struct PointToCameraJob : IJobProcessComponentData<Position, Rotation, ParticleBillboard>
    {
        public float3 camPos;
        public float3 upVec;

        public PointToCameraJob(float3 camPos)
        {
            this.camPos = camPos;
            upVec = Vector3.up;
        }

        public void Execute([ReadOnly] ref Position position, ref Rotation rotation, [ReadOnly] ref ParticleBillboard isBillboard)
        { 
            if (isBillboard.Value > 0f)
            {
                rotation.Value = quaternion.lookRotation(math.normalize(camPos - position.Value), new float3(0f, 1f, 0f));
            }
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        PointToCameraJob pointToCameraJob = new PointToCameraJob { camPos = Camera.main.transform.position };

        JobHandle pointToCameraHandle = pointToCameraJob.Schedule(this, 64, inputDeps);

        return pointToCameraHandle;
    }

}
