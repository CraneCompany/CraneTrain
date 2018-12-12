using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoardToCamera : MonoBehaviour
{

    public GameObject go_trainingBoardLinks;
    public GameObject go_trainingBoardRechts;
    public GameObject go_trainingBoard;
    public GameObject foveInterface;
    public GameObject TBParent;

    private GlobalParameterScript cs_globalParameterScript;

    void Start()
    {
        cs_globalParameterScript = GameObject.Find("_GlobalGameObject").GetComponent<GlobalParameterScript>();
        if (cs_globalParameterScript.b_leftSided)
        {
            go_trainingBoard = go_trainingBoardLinks;
        }
        else
        {
            go_trainingBoard = go_trainingBoardRechts;
        }
        go_trainingBoard.SetActive(true);

        foveInterface = GameObject.Find("Fove Interface");
        AddBoardToCam();
    }

    void AddBoardToCam()
    {
        if (foveInterface)
        {
            // this.transform.position = new Vector3(0, 0, 0);
            go_trainingBoard.transform.SetParent(foveInterface.transform);
            go_trainingBoard.transform.position = foveInterface.transform.position;
            go_trainingBoard.transform.rotation = foveInterface.transform.rotation;

            go_trainingBoard.transform.localPosition += new Vector3(-1.3f, 0, 6.5f);
        }
    }

    public void RemoveBoardFromCam()
    {
        go_trainingBoard.transform.parent = null;
        go_trainingBoard.transform.SetParent(TBParent.transform);
    }

}
