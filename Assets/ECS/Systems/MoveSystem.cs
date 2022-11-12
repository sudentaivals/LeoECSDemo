using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : IEcsRunSystem
{
    EcsFilter<MovableComponent, InputEventComponent> _movableEventFilter = null;
    public void Run()
    {
        foreach (var i in _movableEventFilter)
        {
            ref MovableComponent movableComponent = ref _movableEventFilter.Get1(i);
            ref InputEventComponent inputComponent = ref _movableEventFilter.Get2(i);

            movableComponent.Transform.position += (Vector3)inputComponent._direction * Time.deltaTime * movableComponent.speed;
            movableComponent.isMovable = inputComponent._direction.sqrMagnitude > 0;
        }
    }
}
