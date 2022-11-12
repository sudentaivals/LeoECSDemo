using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputSystem : IEcsRunSystem
{
    EcsFilter<InputEventComponent> _inputEventFilter = null;
    public void Run()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        foreach (var i in _inputEventFilter)
        {
            ref InputEventComponent inputEvent = ref _inputEventFilter.Get1(i);
            inputEvent._direction = new Vector2(x, y).normalized;
        }
    }
}
