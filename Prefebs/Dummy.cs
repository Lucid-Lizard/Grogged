﻿using Grogged;
using Grogged.ECS.Components;
using System;
using System.Diagnostics;

public class Dummy : Prefab
{
    public override void Configure(EntityManager entityManager, int entityId)
    {
        Debug.WriteLine($"Configuring entity {entityId} with Dummy prefab");

        // Add the Position and Velocity components
        entityManager.AddComponent<PositionComponent>(entityId, PositionComponent.Create(200,200));

        Debug.WriteLine($"{entityManager.GetComponent<PositionComponent>(entityId).X}");
        entityManager.AddComponent<VelocityComponent>(entityId, new VelocityComponent { X = 0, Y = 0 });

        entityManager.AddComponent<SpriteComponent>(entityId, SpriteComponent.Create(
            null, new(0, 0, 32, 32), Microsoft.Xna.Framework.Color.Beige, 1f, 0f, ""));
    }
}
