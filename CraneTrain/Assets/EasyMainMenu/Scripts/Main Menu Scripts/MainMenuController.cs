using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public int NumberOfBacks = 3;

    public GameObject[] goA_allPanels = new GameObject[6];
    private Animator[] aA_allPanels;
    private int[] iA_backArray;

    public string s_openAnim, s_closeAnim;
    private bool b_open, b_close;

    // Use this for initialization
    void Start()
    {
        b_close = false;
        b_open = true;

        iA_backArray = new int[NumberOfBacks];
        aA_allPanels = new Animator[goA_allPanels.Length];
        for (int i = 0; i < goA_allPanels.Length; i++)
        {
            aA_allPanels[i] = goA_allPanels[i].GetComponent<Animator>();
        }

        //currentscreen = mainscreen
        iA_backArray[0] = 0;
    }

    #region panels
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

    public void TestPanel()
    {
        int i_thisPanel = 6;
        PanelManager(i_thisPanel);
    }

    #endregion

    void PanelManager(int panel)
    {
        OpenClose(b_close, iA_backArray[0]);
        OpenClose(b_open, panel);

        UpdateBackArray(true);
        iA_backArray[0] = panel;
    }

    public void Back()
    {
        OpenClose(b_close, iA_backArray[0]);
        OpenClose(b_open, iA_backArray[1]);

        UpdateBackArray(false);
    }

    void UpdateBackArray(bool forward)
    {
        if (forward)
        {
            for (int i = 0; i < iA_backArray.Length - 1; i++)
            {
                iA_backArray[iA_backArray.Length - 1 - i] = iA_backArray[iA_backArray.Length - 2 - i];
            }
        }
        else
        {
            for (int i = 0; i < iA_backArray.Length - 1; i++)
            {
                iA_backArray[i] = iA_backArray[i + 1];
            }
        }
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
}
