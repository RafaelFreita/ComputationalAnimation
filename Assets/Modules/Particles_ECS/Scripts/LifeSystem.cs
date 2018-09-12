using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class LifeSystem : ComponentSystem
{

    public struct Group
    {
        [ReadOnly]
        public ComponentDataArray<Particles.ParticleLife> ParticlesLife;

        // Sometimes it is necessary to not only access the components
        // but also the Entity ID.
        public EntityArray Entities;

        // The Length can be injected for convenience as well 
        public readonly int Length;
    }

    [Inject] private Group _Group;

    protected override void OnUpdate()
    {
		
		float dt = Time.deltaTime;
		
        // Iterate over all entities matching the declared ComponentGroup required types
        for (int i = 0; i != _Group.Length; i++)
        {
			
			_Group.ParticlesLife[i].lifeTime += dt;
			
            if(_Group.ParticlesLife[i].lifeTime > _Group.ParticlesLife[i].lifeSpan)
            {
                Entity entity = _Group.Entities[i];
                World.Active.GetExistingManager<EntityManager>().DestroyEntity(entity);
            }
        }
    }

}
