using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace NoGhostEnemy
{
    [BepInPlugin("NoGhostEnemy", "NoGhostEnemy", "1.0.0")]
    public class EntryPoint : BasePlugin
    {
        // The method that gets called when BepInEx tries to load our plugin
        public override void Load()
        {
            // Creates a new harmony instance to allow for patching into methods
            m_Harmony = new Harmony("NoGhostEnemy");
            // Apply all patches in the current assembly
            m_Harmony.PatchAll();

            // Log to the console that we have applied all patches
            //NoGhostEnemyLogger.Verbose($"Applied all patches!");
        }

        private Harmony m_Harmony;
    }
}
