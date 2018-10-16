using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class DataExport : MonoBehaviour
{
    public FoveInterface cs_FoveInterface;
    public GameLoopManager cs_GameLoopManager;

    private List<string[]> rowData = new List<string[]>();
    private int i_idCount = 0;
    private string[] rowDataTemp;

    private bool b_seen = false; public bool b_newSeen = false;
    private float f_reaction = 0.0f, f_newReaction;
    
    // Use this for initialization
    void Start ()
    {
        CreateDataFormat();
    }

    void Update()
    {
        GetData();
    }

	// Update is called once per frame
	void LateUpdate ()
	{
        UpdateData();
	    
	    if (Input.GetKeyDown(KeyCode.D))
	    {
            Debug.Log("Saving");
            SaveData();
	    }
	}

    public void GetData()
    {
        cs_GameLoopManager.GetBlockData(b_newSeen, f_reaction);
        VerifyData();
    }

    public void VerifyData()
    {
        if (b_newSeen != b_seen)
        {
            b_seen = b_newSeen;
            f_reaction = f_newReaction;
        }
    }

    private void CreateDataFormat()
    {
        rowDataTemp = new string[4];
        // Creating First row of titles manually..
        rowDataTemp[0] = "ID (frame)";
        rowDataTemp[1] = "Elapsed Time";
        rowDataTemp[2] = "Angle left eye";
        rowDataTemp[3] = "Angle right eye";
        rowDataTemp[5] = "Block seen";
        rowDataTemp[4] = "Reaction time block";
        rowData.Add(rowDataTemp);
    }

    private void UpdateData()
    {
        rowDataTemp = new string[4];
        rowDataTemp[0] = i_idCount.ToString(); // ID
        rowDataTemp[1] = Time.deltaTime.ToString();

        //handles the data for line 2 and 3
        CheckEyeAngle();

        bool blockAlive = false;
        float blockTime = 0;
        rowDataTemp[4] = b_seen.ToString();
        rowDataTemp[5] = f_reaction.ToString();


        rowData.Add(rowDataTemp);
        i_idCount += 1;
    }

    private void SaveData()
    {
        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();

        for(int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));

        string s_filePath = s_getPath();
        Debug.Log(s_filePath);

        StreamWriter outStream = System.IO.File.CreateText(s_filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }

    private string s_getPath()
    {
#if UNITY_EDITOR
        return Application.dataPath +"/CSV/"+"Saved_data.csv";
#else
        return Application.dataPath +"/"+"Saved_data.csv";
#endif
    }

    private void CheckEyeAngle()
    {
        float f_leftEyeAngle = Vector3.Angle(FoveInterface.GetLeftEyeVector_Immediate(), cs_FoveInterface.transform.forward);
        float f_rightEyeAngle = Vector3.Angle(FoveInterface.GetRightEyeVector_Immediate(), cs_FoveInterface.transform.forward);
        if (FoveInterface.CheckEyesClosed() == Fove.Managed.EFVR_Eye.Neither)
        {
            rowDataTemp[2] = f_leftEyeAngle.ToString();
            rowDataTemp[3] = f_rightEyeAngle.ToString();
        }
        else if(FoveInterface.CheckEyesClosed() == Fove.Managed.EFVR_Eye.Both)
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
