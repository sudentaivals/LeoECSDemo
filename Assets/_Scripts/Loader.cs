using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;
    void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        _systems.Add(new GameInitSystem());
        _systems.Add(new PlayerInputSystem());
        _systems.Add(new MoveSystem());
        _systems.Add(new AnimationCharacterSystem());
        _systems.Add(new FollowSystem());

        _systems.Init();
    }

    // Update is called once per frame
    void Update()
    {
        _systems.Run();
    }

    private void OnDestroy()
    {
        _systems.Destroy();
        _world.Destroy();
    }
}
