using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class DataExport : MonoBehaviour
{
    public FoveInterface cs_FoveInterface;

    private List<string[]> rowData = new List<string[]>();
    private int i_idCount = 0;

    private string[] rowDataTemp;
    // Use this for initialization
    void Start ()
    {
        CreateDataFormat();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    UpdateData();
	    //Debug.Log(((FoveInterfaceBase) cs_FoveInterface).GetLeftEyeVector_Immediate());
	    float Hoek = Vector3.Angle(FoveInterface.GetLeftEyeVector_Immediate(), Vector3.forward);
        Debug.Log(Hoek);
	    if (Input.GetKeyDown(KeyCode.D))
	    {
            SaveData();
	    }
	}

    private void CreateDataFormat()
    {
        rowDataTemp = new string[3];
        // Creating First row of titles manually..

        rowDataTemp[0] = "ID";
        rowDataTemp[1] = "Frame";
        rowDataTemp[2] = "Elapsed Time";
        //rowDataTemp[3] = "User Position";
        //rowDataTemp[4] = "User Orientation";
        //rowDataTemp[5] = "User left eye data";
        //rowDataTemp[6] = "Degree switch left eye";
        //rowDataTemp[7] = "User right eye data";
        //rowDataTemp[8] = "Degree switch right eye";
        rowData.Add(rowDataTemp);
    }

    private void UpdateData()
    {
        rowDataTemp = new string[3];
        rowDataTemp[0] = i_idCount.ToString(); // ID
        rowDataTemp[1] = "Frame" + i_idCount; // Frame
        rowDataTemp[2] = Time.deltaTime.ToString();
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
}
