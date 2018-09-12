using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class MoveSystem : JobComponentSystem
{

    [ComputeJobOptimization]
    struct MovementJob : IJobProcessComponentData<Position, Particles.ParticleDirection, MoveSpeed>
    {
        public float deltaTime;

        public void Execute(ref Position position, [ReadOnly] ref Particles.ParticleDirection direction, [ReadOnly] ref MoveSpeed speed)
        {
            position.Value += deltaTime * speed.speed * direction.Value;
        }
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        MovementJob moveJob = new MovementJob
        {
            deltaTime = Time.deltaTime
        };

        JobHandle moveHandle = moveJob.Schedule(this, 64, inputDeps);

        return moveHandle;
    }

}
