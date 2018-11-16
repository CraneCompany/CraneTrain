using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoardToCamera : MonoBehaviour
{

    public GameObject trainingBoard;
    public GameObject foveInterface;
    public GameObject TBParent;

    private void Start()
    {
        foveInterface = GameObject.Find("Fove Interface");
        AddBoardToCam();
    }

    private void AddBoardToCam()
    {
        if (foveInterface)
        {
            // this.transform.position = new Vector3(0, 0, 0);
            trainingBoard.transform.SetParent(foveInterface.transform);
            trainingBoard.transform.position = new Vector3(-1.3f, 0, 6.5f);
        }
    }

    public void RemoveBoardFromCam()
    {
        trainingBoard.transform.parent = null;
        trainingBoard.transform.SetParent(TBParent.transform);
    }

}
