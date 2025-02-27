using HarmonyLib;
namespace WKUIAdditions.Patches
{
    [HarmonyPatch(typeof(CL_GameManager))]
    public class CL_GameManager_Patches
    {
        // I had buttons overriden but i was lazy to bind the keybinds.

        [HarmonyPatch(nameof(CL_GameManager.Pause))]
        [HarmonyPostfix]
        public static void Pause_Post(CL_GameManager __instance)
        {
            MonoBehaviours.PauseMenu.TryOpen();
        }

        [HarmonyPatch(nameof(CL_GameManager.UnPause))]
        [HarmonyPostfix]
        public static void UnPause_Post(CL_GameManager __instance)
        {
            MonoBehaviours.PauseMenu.TryClose();
        }
    }
}
