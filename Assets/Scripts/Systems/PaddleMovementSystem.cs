using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[AlwaysSynchronizeSystem]
public partial class PaddleMovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float yBound = GameManager.instance.yBound;

        Entities.WithoutBurst()
                .ForEach((ref Translation translation, in PaddleMovementData data) =>
        {
            translation.Value.y = math.clamp(translation.Value.y + (data.speed * data.direction * Time.DeltaTime), -yBound, yBound);
        }).Run();
    }
}