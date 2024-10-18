using Godot;
using System;

public static class PlayerStats
{
    public const float HorizontalMoveSpeed = 200f;
    public const float HorizontalBrakeSpeed = 500f;
    public const float HorizontalSlowDownFactor = 0.9f;
    public const float HorizontalMoveSpeedLimit = 100f;

    public const float FlyUpGravity = 330f;
    public const float FlyUpSpeedLimit = -150f;

    public const float DiveGravity = 500f;
    public const float DiveSpeedLimit = 250f;

    public const float FallGravity = 200f;
    public const float FallSpeedLimit = 120f;
    public const float FallLimiter = -50f;

    public const float BrakingPower = 2f;

}
