using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SCENETYPE
{
    NONE = 0,
    testing = 1,
    training = 2
}

public enum SEEN
{
    NONE = 0,
    YES = 1,
    NO = 2
}

public class DataExport : MonoBehaviour
{
    [SerializeField] private SCENETYPE SceneType = SCENETYPE.NONE;
    [HideInInspector] public SEEN objSeen = SEEN.NONE;

    private FoveInterface cs_FoveInterface;
    public GameLoopManager cs_GameLoopManager;

    private List<string[]> rowData = new List<string[]>();
    private int i_idCount = 0;
    private string[] rowDataTemp;

    [HideInInspector] public float f_reaction = 0.0f;

    // Use this for initialization
    void Start()
    {
        cs_FoveInterface = GameObject.Find("Fove Interface").GetComponent<FoveInterface>();
        CreateDataFormat();

        if (SceneType == SCENETYPE.NONE)
        {
            Debug.LogError("No SceneType has been selected");
        }

        if (SceneType == SCENETYPE.training && cs_GameLoopManager == null)
        {
            Debug.LogError("GameLoopManager has not been assigned");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            SaveData(SceneManager.GetActiveScene().name);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdateData();
        objSeen = SEEN.NONE;
    }

    public void GetData()
    {
        switch (SceneType)
        {
            case SCENETYPE.testing:

                break;
            case SCENETYPE.training:
                SEEN currentSeen;
                currentSeen = cs_GameLoopManager.GetTargData();

                if (currentSeen == SEEN.YES)
                {
                    objSeen = SEEN.YES;
                    f_reaction = cs_GameLoopManager.GetTargTime();
                }
                else
                {
                    objSeen = currentSeen;
                }

                if (cs_GameLoopManager.GetOnOffTarget())
                {
                    rowDataTemp[6] = "Looking at Target";
                }
                else
                {
                    rowDataTemp[6] = "Not looking at Target";
                }
                cs_GameLoopManager.ResetParams();
                break;
        }

        switch (objSeen)
        {
            case SEEN.NONE:
                rowDataTemp[4] = "";
                rowDataTemp[5] = "";
                break;

            case SEEN.NO:
                rowDataTemp[4] = "FALSE";
                rowDataTemp[5] = "";
                break;

            case SEEN.YES:
                rowDataTemp[4] = "TRUE";
                rowDataTemp[5] = f_reaction.ToString();
                break;
        }
    }

    private void CreateDataFormat()
    {
        rowDataTemp = new string[7];
        // Creating First row of titles manually..
        rowDataTemp[0] = "ID (frame)";
        rowDataTemp[1] = "Elapsed Time";
        rowDataTemp[2] = "Angle left eye";
        rowDataTemp[3] = "Angle right eye";
        rowDataTemp[4] = "Block seen";
        rowDataTemp[5] = "Reaction time block";
        rowDataTemp[6] = "On Target";
        rowData.Add(rowDataTemp);
    }

    private void UpdateData()
    {
        rowDataTemp = new string[7];
        rowDataTemp[0] = i_idCount.ToString(); // ID
        rowDataTemp[1] = Time.deltaTime.ToString();

        //handles the data for line 2 and 3
        CheckEyeAngle();

        //handles the data for line 4 and 5
        GetData();

        rowData.Add(rowDataTemp);
        i_idCount += 1;
    }

    public void SaveData(string scene)
    {
        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));

        string s_filePath = s_getPath(scene);
        Debug.Log(s_filePath);

        StreamWriter outStream = System.IO.File.CreateText(s_filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }

    private string s_getPath(string scene)
    {
#if UNITY_EDITOR
        return Application.dataPath + "/CSV/" + "Saved_" + scene + "_data.csv";
#else
        return Application.dataPath +"/"+"Saved" + scene + "_data.csv";
#endif
    }

    private void CheckEyeAngle()
    {
        Debug.Log("Checking eye angle");
        float f_leftEyeAngle = Vector3.Angle(FoveInterface.GetLeftEyeVector_Immediate(), cs_FoveInterface.transform.forward);
        float f_rightEyeAngle = Vector3.Angle(FoveInterface.GetRightEyeVector_Immediate(), cs_FoveInterface.transform.forward);
        if (FoveInterface.CheckEyesClosed() == Fove.Managed.EFVR_Eye.Neither)
        {
            rowDataTemp[2] = f_leftEyeAngle.ToString();
            rowDataTemp[3] = f_rightEyeAngle.ToString();
        }
        else if (FoveInterface.CheckEyesClosed() == Fove.Managed.EFVR_Eye.Both)
        {
            rowDataTemp[2] = "eye closed";
            rowDataTemp[3] = "eye closed";
        }
        else if (FoveInterface.CheckEyesClosed() == Fove.Managed.EFVR_Eye.Left)
        {
            rowDataTemp[2] = "eye closed";
            rowDataTemp[3] = f_rightEyeAngle.ToString();
        }
        else if (FoveInterface.CheckEyesClosed() == Fove.Managed.EFVR_Eye.Right)
        {
            rowDataTemp[2] = f_leftEyeAngle.ToString();
            rowDataTemp[3] = "eye closed";
        }
    }
}
