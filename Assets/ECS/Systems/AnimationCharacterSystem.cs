using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharacterSystem : IEcsRunSystem
{
    EcsFilter<AnimationComponent, MovableComponent> _animationSystemFilter = null;
    public void Run()
    {
        foreach (var i in _animationSystemFilter)
        {
            ref AnimationComponent animationComponent = ref _animationSystemFilter.Get1(i);
            ref MovableComponent movableComponent = ref _animationSystemFilter.Get2(i);
            if (movableComponent.isMovable)
            {
                animationComponent.animator.Play(animationComponent.MoveAnimationName);
            }
            else
            {
                animationComponent.animator.Play(animationComponent.IdleAnimationName);
            }
        }
    }
}
