using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public GameObject[] goA_allPanels = new GameObject[6];
    private Animator[] aA_allPanels;

    public string s_openAnim, s_closeAnim;
    private bool b_open, b_close;

    private int i_currentPannel, i_previousPannel;

    // Use this for initialization
    void Start()
    {
        b_close = false;
        b_open = true;

        i_currentPannel = 0;
        i_previousPannel = 0;

        aA_allPanels = new Animator[goA_allPanels.Length];
        for (int i = 0; i < goA_allPanels.Length; i++)
        {
            aA_allPanels[i] = goA_allPanels[i].GetComponent<Animator>();
        }
    }

    public void MainPanel()
    {
        int i_thisPanel = 0;
        PanelManager(i_thisPanel);  
    }

    public void StartPanel()
    {
        int i_thisPanel = 1;
        PanelManager(i_thisPanel);
    }

    public void OptionsPanel()
    {
        int i_thisPanel = 2;
        PanelManager(i_thisPanel);
    }

    public void TrainerPanel()
    {
        int i_thisPanel = 3;
        PanelManager(i_thisPanel);
    }

    public void ClientPanel()
    {
        int i_thisPanel = 4;
        PanelManager(i_thisPanel);
    }

    public void TrainingPanel()
    {
        int i_thisPanel = 5;
        PanelManager(i_thisPanel);
    }

    void PanelManager(int panel)
    {
        OpenClose(b_open, panel);
        i_previousPannel = i_currentPannel;
        i_currentPannel = panel;
        OpenClose(b_close, i_previousPannel);
    }

    public void Back()
    {
        OpenClose(b_close, i_currentPannel);
        OpenClose(b_open, i_previousPannel);
        i_currentPannel = i_previousPannel;

        i_previousPannel = 0;                           //TODO: Make backing up dynamic
    }

    void OpenClose(bool open, int ArrayPos)
    {
        if (open)
        {
            aA_allPanels[ArrayPos].Play(s_openAnim);
        }
        else
        {
            aA_allPanels[ArrayPos].Play(s_closeAnim);
        }
    }

    //    public void openOptions()
    //    {
    //        //enable respective panel
    //        MainOptionsPanel.SetActive(true);
    //        StartGameOptionsPanel.SetActive(false);

    //        //play anim for opening main options panel
    //        anim.Play("buttonTweenAnims_on");

    //        //play click sfx
    //        playClickSound();

    //        //enable BLUR
    //        //Camera.main.GetComponent<Animator>().Play("BlurOn");

    //    }

    //    public void openStartGameOptions()
    //    {
    //        //enable respective panel
    //        MainOptionsPanel.SetActive(false);
    //        StartGameOptionsPanel.SetActive(true);

    //        //play anim for opening main options panel
    //        anim.Play("buttonTweenAnims_on");

    //        //play click sfx
    //        playClickSound();

    //        //enable BLUR
    //        //Camera.main.GetComponent<Animator>().Play("BlurOn");

    //    }

    //    public void openOptions_Game()
    //    {
    //        //enable respective panel
    //        GamePanel.SetActive(true);
    //        ControlsPanel.SetActive(false);
    //        GfxPanel.SetActive(false);
    //        LoadGamePanel.SetActive(false);

    //        //play anim for opening game options panel
    //        anim.Play("OptTweenAnim_on");

    //        //play click sfx
    //        playClickSound();

    //    }
    //    public void openOptions_Controls()
    //    {
    //        //enable respective panel
    //        //GamePanel.SetActive(false);
    //        ControlsPanel.SetActive(true);
    //        GfxPanel.SetActive(false);
    //        LoadGamePanel.SetActive(false);

    //        //play anim for opening game options panel
    //        anim.Play("OptTweenAnim_on");

    //        //play click sfx
    //        playClickSound();

    //    }
    //    public void openOptions_Gfx()
    //    {
    //        //enable respective panel
    //        //GamePanel.SetActive(false);
    //        ControlsPanel.SetActive(false);
    //        GfxPanel.SetActive(true);
    //        LoadGamePanel.SetActive(false);

    //        //play anim for opening game options panel
    //        anim.Play("OptTweenAnim_on");

    //        //play click sfx
    //        playClickSound();

    //    }

    //    public void openContinue_Load()
    //    {
    //        //enable respective panel
    //        //GamePanel.SetActive(false);
    //        ControlsPanel.SetActive(false);
    //        GfxPanel.SetActive(false);
    //        LoadGamePanel.SetActive(true);

    //        //play anim for opening game options panel
    //        anim.Play("OptTweenAnim_on");

    //        //play click sfx
    //        playClickSound();

    //    }

    //    public void newGame()
    //    {
    //        if (!string.IsNullOrEmpty(newGameSceneName))
    //            SceneManager.LoadScene(newGameSceneName);
    //        else
    //            Debug.Log("Please write a scene name in the 'newGameSceneName' field of the Main Menu Script and don't forget to " +
    //                "add that scene in the Build Settings!");
    //    }



    //    public void back_options()
    //    {
    //        //simply play anim for CLOSING main options panel
    //        anim.Play("buttonTweenAnims_off");

    //        //disable BLUR
    //       // Camera.main.GetComponent<Animator>().Play("BlurOff");

    //        //play click sfx
    //        playClickSound();
    //    }

    //    public void back_options_panels()
    //    {
    //        //simply play anim for CLOSING main options panel
    //        anim.Play("OptTweenAnim_off");

    //        //play click sfx
    //        playClickSound();

    //    }

    //    public void Quit()
    //    {
    //        Application.Quit();
    //    }



    //    public void playHoverClip()
    //    {

    //    }

    //    void playClickSound() {

    //    }

}
