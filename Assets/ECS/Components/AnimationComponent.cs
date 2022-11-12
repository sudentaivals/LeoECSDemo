using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AnimationComponent
{
    public string MoveAnimationName => "Move";
    public string IdleAnimationName => "Idle";

    public Animator animator;
}
