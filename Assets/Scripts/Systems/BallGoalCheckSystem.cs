using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Mathematics;

public partial class BallGoalCheckSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.TempJob);

        Entities
            .WithAll<BallTag>()
            .ForEach((Entity entity, ref Translation translation) => 
        {

            float3 pos = translation.Value;
            float xBound = GameManager.instance.xBound;

            if (pos.x >= xBound)
            {
                GameManager.instance.OnPlayerScore(0);
                ecb.DestroyEntity(entity);
            }
            else if (pos.x <= -xBound)
            {
                GameManager.instance.OnPlayerScore(1);
                ecb.DestroyEntity(entity);
            }

        });

        ecb.Playback(EntityManager);
        ecb.Dispose();
    }
}
