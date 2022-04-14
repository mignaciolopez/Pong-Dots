using Unity.Entities;
using UnityEngine;

public partial class PlayerInputSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref PaddleMovementData moveData, ref PaddleInputData inputData) =>
        {
            moveData.direction = 0;
            moveData.direction += Input.GetKey(inputData.upKey) ? 1 : 0;
            moveData.direction -= Input.GetKey(inputData.downKey) ? 1 : 0;

        });
    }
}