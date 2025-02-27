using System.Collections;
using UnityEngine;

namespace WKUIAdditions.MonoBehaviours
{
    public class PlayMode : MonoBehaviour
    {
        const string canvas = "GameManager/Canvas/";

        // Pause, i planned gaving more stuff but.. eh.
        public IEnumerator Start()
        {
            yield return new WaitForSecondsRealtime(.5f);

            if (!If.Exists(canvas, out GameObject c)) yield break;

            GameObject settingsMenu = new GameObject("WKUIAdditions-SettingsMenu");
            settingsMenu.transform.parent = c.transform;
            settingsMenu.AddComponent<PauseMenu>();
        }
    }
}
