using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{

    public GameObject particlePrefab;

    private EntityManager _manager;
    private int _particleCount;

    private void Start()
    {
        _manager = World.Active.GetOrCreateManager<EntityManager>();

        AddParticles(500);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddParticles(1000);
        }

        Debug.Log(_particleCount);
    }

    private void AddParticles(int amount)
    {
        NativeArray<Entity> entities = new NativeArray<Entity>(amount, Allocator.Temp);
        _manager.Instantiate(particlePrefab, entities);

        for (int i = 0; i < amount; i++)
        {
            float xVal = Random.Range(-20f, 20f);
            float zVal = Random.Range(-10f, 10f);
            _manager.SetComponentData(entities[i], new Position { Value = new float3(xVal, 0f, 20f + zVal) });
            _manager.SetComponentData(entities[i], new MoveSpeed { speed = 1f });
            _manager.SetComponentData(entities[i], new Rotation { Value = new quaternion(0f, -1f, 0f, 0f)});
            _manager.SetComponentData(entities[i], new Particles.ParticleBillboard { Value = 1f });
            _manager.SetComponentData(entities[i], new Particles.ParticleDirection { Value = new float3(0f, 1f, 1f) });
        }
        entities.Dispose();

        _particleCount += amount;
    }

}
