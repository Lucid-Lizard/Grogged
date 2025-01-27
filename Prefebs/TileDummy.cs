using Grogged.ECS.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grogged.Prefebs
{
    public abstract class TileDummy : Dummy
    {

        public abstract void SetTileDefaults(TileComponent tileComponent);

        public override void Configure(EntityManager entityManager, int entityId)
        {
            entityManager.AddComponent<TileComponent>(entityId, new(){});

            SetTileDefaults(entityManager.GetComponent<TileComponent>(entityId));
        }
    }
}
