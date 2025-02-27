using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using WKUIAdditions.MonoBehaviours.Effects;
using TMPro;

namespace WKUIAdditions.MonoBehaviours
{
    public class MainMenu : MonoBehaviour
    {
        const string canvasObj = "GameManager/Canvas";

        const string logoPanel = canvasObj + "/Logo Panel";

        const string mainMenu = canvasObj + "/Main Menu";

        const string playBtn = mainMenu + "/Play Game";
        const string statsBtn = mainMenu + "/Stats";
        const string settingsBtn = mainMenu + "/Settings";
        const string quitBtn = mainMenu + "/Quit";

        const string playMenu = canvasObj + "/Play Menu";

        const string playPanel = playMenu + "/Play Pane";
        RectTransform playPanelCache;

        const string testingLevelBtn = playPanel + "/Play Testing Level";
        const string testingLevelText = testingLevelBtn + "/Text (TMP)";

        const string playPanelCloseBtn = playPanel + "/Back";

        const string scoreScreen = canvasObj + "/Score Screen";
        const string scorePanel = scoreScreen + "/SCORE PANEL";
        const string scorePanelCloseBtn = scorePanel + "/Close (1)";
        RectTransform statsPanelCache;

        const string settingsPanel = canvasObj + "/Settings Menu/SettingsParent/Settings Pane";
        const string settingsPanelCloseBtn = settingsPanel + "/Close";
        RectTransform settingsPanelCache;

        const string verText = canvasObj + "/Version Text";

        const string supportMenu = canvasObj + "/Support Menu";

        const string discordBtn = supportMenu + "/Discord";

        const float timeBetweenMainButtons = 0.3f;
        const float mainButtonsDuration = 0.5f;
        const float mainButtonsXPos = 0;

        public IEnumerator Start()
        {
            // without waiting it bugged out
            yield return new WaitForSecondsRealtime(.5f);

            #region Play Panel stuff
            if (If.Exists(playPanel, out playPanelCache))
            {
                if (If.Exists(playBtn, out Button b2)) b2.onClick.AddListener(OpenPlayMenu);

                if (If.Exists(playPanelCloseBtn, out Button b3)) b3.onClick.AddListener(HidePlayMenu);
            }
            #endregion

            if (If.Exists(scorePanel, out statsPanelCache))
            {
                if (statsPanelCache.TryGetComponent(out UI_LerpOpen opn)) Destroy(opn);
            }

            #region Settings Panel Setup
            if (If.Exists(settingsPanel, out settingsPanelCache))
            {
                if (settingsPanelCache.TryGetComponent(out UI_LerpOpen opn)) Destroy(opn);
                else settingsPanelCache = null;

                if (If.Exists(settingsBtn, out Button b2))
                {
                    b2.onClick.AddListener(OpenSettings);
                }

                if (If.Exists(settingsPanelCloseBtn, out Button b3))
                {
                    b3.onClick.AddListener(HideSettings);
                }
            }
            #endregion

            #region Etc buttons
            if (If.Exists(discordBtn, out GameObject g1))
            {
                g1.AddComponent<RotateSometimes>();
                g1.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 5);
            }

            if (If.Exists(testingLevelBtn, out Button b1))
            {
                b1.onClick.AddListener(LoadPlayground);

                b1.gameObject.SetActive(true);

                if (If.Exists(testingLevelText, out TextMeshProUGUI tmp1))
                    tmp1.text = "Dev Zone | Playground";
            }

            if (If.Exists(quitBtn, out GameObject g2)) g2.AddComponent<ShakeNearCursor>();
            #endregion

            #region Stats panel
            if (statsPanelCache != null)
            {
                if (If.Exists(statsBtn, out Button b4))
                {
                    b4.onClick.AddListener(OpenStats);
                }

                if (If.Exists(scorePanelCloseBtn, out Button b5))
                {
                    b5.onClick.AddListener(HideStats);
                }
            }
            #endregion

            // setting up start positions
            Do.SetAncX(150, verText);
            Do.SetAncX(450, logoPanel);
            Do.SetAncX(-250, playBtn, statsBtn, settingsBtn, quitBtn);
            Do.SetAnc(new Vector2(425, -205), mainMenu);

            // wait for black screen
            yield return new WaitForSecondsRealtime(2f);

            #region Main buttons (DO NOT OPEN! SCARY!!!)
            Do.AncX(playBtn, mainButtonsXPos, mainButtonsDuration, Ease.OutCubic);

            yield return new WaitForSecondsRealtime(timeBetweenMainButtons);

            Do.AncX(statsBtn, mainButtonsXPos, mainButtonsDuration, Ease.OutCubic);

            yield return new WaitForSecondsRealtime(timeBetweenMainButtons);

            Do.AncX(settingsBtn, mainButtonsXPos, mainButtonsDuration, Ease.OutCubic);

            yield return new WaitForSecondsRealtime(timeBetweenMainButtons *3);

            Do.AncX(quitBtn, mainButtonsXPos, mainButtonsDuration, Ease.OutCubic);
            #endregion

            // Version text
            yield return new WaitForSecondsRealtime(1);
            Do.AncX(verText, - 150, 1.25f, Ease.OutCubic);
        }

        public void OpenPlayMenu()
        {
            playPanelCache.DOKill();

            playPanelCache.anchoredPosition = new Vector2(0, 1000);

            playPanelCache.DOAnchorPosY(0, .75f).SetEase(Ease.OutCubic).SetUpdate(true);
        }

        // DOKill is last resort if something interfeers.
        public void HidePlayMenu()
        {
            playPanelCache.DOKill();

            playPanelCache.DOAnchorPosY(-1000, .5f).SetEase(Ease.InCubic).SetUpdate(true);
        }

        public void OpenStats()
        {
            statsPanelCache.DOKill();

            statsPanelCache.anchoredPosition = new Vector2(0, -1000);

            statsPanelCache.DOAnchorPosY(0, 1.5f).SetEase(Ease.OutCubic).SetUpdate(true);
        }

        public void HideStats()
        {
            statsPanelCache.gameObject.SetActive(true);

            statsPanelCache.DOAnchorPosY(-1000, .75f).SetEase(Ease.InCubic).SetUpdate(true);
        }

        public void OpenSettings()
        {
            settingsPanelCache.DOKill();

            settingsPanelCache.anchoredPosition = new Vector2(600, 0);

            settingsPanelCache.DOAnchorPosX(-115, .75f).SetEase(Ease.OutCubic);
        }

        public void HideSettings()
        {
            settingsPanelCache.gameObject.SetActive(true);

            settingsPanelCache.DOKill();

            settingsPanelCache.DOAnchorPosX(600, .5f).SetEase(Ease.InCubic);
        }

        public void LoadPlayground()
        {
            CL_GameManager.gMan.LoadLevel("Playground");
        }
    }
}
