using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class PaddleMovementSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        float yBound = GameManager.instance.yBound;

        Entities.ForEach((ref Translation translation, ref PaddleMovementData data) =>
        {
            translation.Value.y = math.clamp(translation.Value.y + (data.speed * data.direction * Time.DeltaTime), -yBound, yBound);
        });
    }
}