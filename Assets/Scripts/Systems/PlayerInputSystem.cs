using Unity.Entities;
using UnityEngine;

[AlwaysSynchronizeSystem]
public partial class PlayerInputSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref PaddleMovementData moveData, in PaddleInputData inputData) =>
        {
            moveData.direction = 0;
            moveData.direction += Input.GetKey(inputData.upKey) ? 1 : 0;
            moveData.direction -= Input.GetKey(inputData.downKey) ? 1 : 0;

        }).Run();
    }
}