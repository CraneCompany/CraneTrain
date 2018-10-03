using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    private string[] sa_currentQuestItems;
    private string[] sa_allQuestItems = new string[] { "Hoed,Sjaal,Hakken" };
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void MakeRandomQuest()
    {
        for (int i = 0; i < sa_currentQuestItems.Length; i++)
        {
            int i_rNum = Random.Range(0, sa_allQuestItems.Length);
            sa_currentQuestItems[i] = sa_allQuestItems[i_rNum];

        }
    }
}
