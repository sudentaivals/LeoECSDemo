using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitSystem : IEcsInitSystem
{
    EcsWorld _world = null;
    public void Init()
    {
        //player
        var player = _world.NewEntity();
        ref var inputComponent = ref player.Get<InputEventComponent>();
        ref var movableComponent = ref player.Get<MovableComponent>();
        ref var animationComponent = ref player.Get<AnimationComponent>();

        var playerObject = GameObject.Instantiate(PlayerInitData.LoadFromAssets.PlayerPrefab, Vector3.zero, Quaternion.identity);

        animationComponent.animator = playerObject.GetComponent<Animator>();
        movableComponent.speed = PlayerInitData.LoadFromAssets.Speed;
        movableComponent.Transform = playerObject.transform;
        //enemy
        for (int i = 0; i < 5; i++)
        {
            var spawnPoint = new Vector2(UnityEngine.Random.Range(-3f, 3f), UnityEngine.Random.Range(-3f, 3f));
            CreateEnemy(spawnPoint, playerObject.transform);
        }

    }

    private void CreateEnemy(Vector3 startPos, Transform player)
    {
        var enemy = _world.NewEntity();
        ref var enemyMovableComponent = ref enemy.Get<MovableComponent>();
        ref var enemyAnimationComponent = ref enemy.Get<AnimationComponent>();
        ref var enemyFollowComponent = ref enemy.Get<FollowComponent>();

        var enemyObject = GameObject.Instantiate(EnemyInitData.LoadFromAssets.EnemyPrefab, startPos, Quaternion.identity);
        enemyMovableComponent.speed = EnemyInitData.LoadFromAssets.Speed;
        enemyMovableComponent.Transform = enemyObject.transform;
        enemyAnimationComponent.animator = enemyObject.GetComponent<Animator>();
        enemyFollowComponent.Target = player;
        enemyFollowComponent.SearchRadius = EnemyInitData.LoadFromAssets.SearchRadius;
    }
}
