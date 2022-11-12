using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSystem : IEcsRunSystem
{
    EcsFilter<FollowComponent, MovableComponent> _followSystemFilter = null;

    public void Run()
    {
        foreach (var i in _followSystemFilter)
        {
            ref FollowComponent followComponent = ref _followSystemFilter.Get1(i);
            ref MovableComponent movableComponent = ref _followSystemFilter.Get2(i);


            if(((Vector2)followComponent.Target.position - (Vector2)movableComponent.Transform.position).magnitude > followComponent.SearchRadius)
            {
                movableComponent.isMovable = false;
                continue;
            }

            if (movableComponent.Transform.position == followComponent.Target.position)
            {
                movableComponent.isMovable = false;
                continue;
            }

            movableComponent.isMovable = true;
            movableComponent.Transform.position = Vector3.MoveTowards(movableComponent.Transform.position, followComponent.Target.position, movableComponent.speed * Time.deltaTime);


        }
    }
}
