//using Unity.Collections;
//using Unity.Entities;
//using Unity.Jobs;
//using Unity.Mathematics;
//using Unity.Transforms;

//public class LifeSystem : ComponentSystem
//{

//    //public struct Group
//    //{
//    //    [ReadOnly]
//    //    public ComponentDataArray<Position> Positions;

//    //    // Sometimes it is necessary to not only access the components
//    //    // but also the Entity ID.
//    //    public EntityArray Entities;

//    //    // The Length can be injected for convenience as well 
//    //    [ReadOnly] public int Length;
//    //}

//    //[Inject] private Group m_Group;

//    //protected override void OnUpdate()
//    //{
//    //    // Iterate over all entities matching the declared ComponentGroup required types
//    //    for (int i = 0; i != m_Group.Length; i++)
//    //    {
//    //        if(m_Group.Positions[i].Value.y > 5.0f)
//    //        {

//    //            Entity entity = m_Group.Entities[i];
//    //            World.Active.GetExistingManager<EntityManager>().DestroyEntity(entity);
//    //        }
//    //    }
//    //}

//}