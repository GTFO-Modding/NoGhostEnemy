using Enemies;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoGhostEnemy
{
    [HarmonyPatch(typeof(ES_Hitreact), nameof(ES_Hitreact.ActivateState))]
    internal static class Patch_EarlyDeath
    {
        internal static void Prefix(ES_Hitreact __instance, ES_HitreactType hitreactType)
        {
            if (hitreactType == ES_HitreactType.ToDeath)
            {
                var agent = __instance.m_enemyAgent;
                var updateMode = __instance.m_enemyAgent.UpdateMode;

                if (updateMode == NodeUpdateMode.None)
                {
                    EnemyUpdateManager.Current.Register(agent, NodeUpdateMode.Near);
                }
            }
        }
    }

    [HarmonyPatch(typeof(ES_HitreactFlyer), nameof(ES_HitreactFlyer.ActivateState))]
    internal static class Patch_EarlyDeathFlyer
    {
        internal static void Prefix(ES_HitreactFlyer __instance, ES_HitreactType hitreactType)
        {
            if (hitreactType == ES_HitreactType.ToDeath)
            {
                var agent = __instance.m_enemyAgent;
                var updateMode = __instance.m_enemyAgent.UpdateMode;

                if (updateMode == NodeUpdateMode.None)
                {
                    EnemyUpdateManager.Current.Register(agent, NodeUpdateMode.Near);
                }
            }
        }
    }
}
