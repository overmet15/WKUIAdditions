using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace WKUIAdditions.MonoBehaviours
{
    public class PauseMenu : MonoBehaviour
    {
        static PauseMenu instance;

        const string canvas = "GameManager/Canvas";

        const string pause = canvas + "/Pause";
        const string pauseMenu = pause + "/Pause Menu";

        const string settingsPane = pause + "/Settings Menu/SettingsParent/Settings Pane";
        RectTransform settingsPanelCache;

        const string settingsBtn = pauseMenu + "/Settings";
        const string settingsCloseBtn = settingsPane + "/Close";

        const string restartBtn = pauseMenu + "/Exit/Restart";
        const string mainMenuBtn = pauseMenu + "/Exit/Main Menu (1)";

        RectTransform pauseMenuCache;

        bool settingsOpen;
        bool wasOpen;

        Coroutine closingCoroutine;

        void Awake()
        {
            instance = this;
        }

        public IEnumerator Start()
        {
            yield return new WaitForSecondsRealtime(0.05f);

            if (!If.Exists(pauseMenu, out pauseMenuCache))
            {
                Destroy(gameObject);
                yield break;
            }

            pauseMenuCache.sizeDelta += new Vector2(0, 350);

            if (If.Exists(restartBtn, out Button btn1))
            {
                btn1.gameObject.AddComponent<Effects.ShakeNearCursor>();
            }

            if (If.Exists(mainMenuBtn, out Button btn2))
            {
                btn2.gameObject.AddComponent<Effects.ShakeNearCursor>();
            }

            If.Exists(settingsPane, out settingsPanelCache);

            if (settingsPanelCache != null)
            {
                if (settingsPanelCache.TryGetComponent(out UI_LerpOpen lerp)) Destroy(lerp);

                if (If.Exists(settingsBtn, out Button button1))
                {
                    button1.onClick.AddListener(OpenSettings);
                }
                else
                {
                    settingsPanelCache = null;
                    yield break;
                }

                if (If.Exists(settingsCloseBtn, out Button button2))
                {
                    button2.onClick.AddListener(HideSettings);
                }
                else
                {
                    settingsPanelCache = null;
                    yield break;
                }
            }
        }

        public static void TryOpen()
        {
            if (instance == null) return;

            instance.Open();
        }

        public static void TryClose()
        {
            if (instance == null) return;

            instance.Close();
        }

        public void Close()
        {
            closingCoroutine = StartCoroutine(CloseCoroutine());
        }

        public void Open()
        {
            if (closingCoroutine != null) StopCoroutine(closingCoroutine);

            settingsPanelCache.anchoredPosition = new Vector2(600, 0);

            pauseMenuCache.anchoredPosition = new Vector2(0, -75);
            pauseMenuCache.DOAnchorPosY(0, 0.4f).SetEase(Ease.OutBack).SetUpdate(true);
        }

        IEnumerator CloseCoroutine()
        {
            pauseMenuCache.gameObject.SetActive(true);

            HideSettingsFast();

            pauseMenuCache.DOAnchorPosY(-100, 0.25f).SetEase(Ease.InBack).SetUpdate(true);

            yield return new WaitForSecondsRealtime(0.25f);

            pauseMenuCache.gameObject.SetActive(false);
        }

        public void OpenSettings()
        {
            settingsPanelCache.gameObject.SetActive(true);

            if (settingsOpen)
            {
                HideSettings();
                return;
            }

            settingsOpen = true;

            settingsPanelCache.DOKill();

            settingsPanelCache.DOAnchorPosX(-115, .75f).SetEase(Ease.OutCubic).SetUpdate(true);
        }

        public void HideSettings()
        {
            settingsOpen = false;

            settingsPanelCache.gameObject.SetActive(true);

            settingsPanelCache.DOKill();

            settingsPanelCache.DOAnchorPosX(600, .5f).SetEase(Ease.InCubic).SetUpdate(true);
        }

        public void HideSettingsFast()
        {
            settingsOpen = false;

            settingsPanelCache.gameObject.SetActive(true);

            settingsPanelCache.DOKill();

            settingsPanelCache.DOAnchorPosX(600, .25f).SetEase(Ease.InCubic).SetUpdate(true);
        }
    }
}
