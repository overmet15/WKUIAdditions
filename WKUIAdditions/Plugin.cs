using BepInEx;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using WKUIAdditions.MonoBehaviours;

namespace WKUIAdditions
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    public class Plugin : BaseUnityPlugin
    {
        public const string myGUID = "com.overmet15.WKUIAdditions";
        public const string pluginName = "WKUIAdditions";
        public const string versionString = "1.0.0";

        private static readonly Harmony Harmony = new Harmony(myGUID);

        private void Awake()
        {
            Logger.LogInfo($"{pluginName} v{versionString} is loading...");

            Harmony.PatchAll();

            SceneManager.sceneLoaded += OnSceneLoaded;

            Logger.LogInfo($"{pluginName} v{versionString} is loaded.");
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log("Test");
            switch (scene.name)
            {
                case "Intro": SceneManager.LoadScene("Main-Menu"); break;
                case "Main-Menu": new GameObject("WKUIAdditions-MainMenu", typeof(MainMenu)); break;
            }

            if (If.Exists("CL_Player", out GameObject player))
            {
                new GameObject("WKUIAdditions-PlayMode",  typeof(PlayMode));
            }
        }

        public static void Log(string message) => Debug.Log("WKUIAdditions: " + message);
    }
}
