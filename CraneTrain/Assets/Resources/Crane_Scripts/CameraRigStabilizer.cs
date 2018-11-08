using UnityEngine;

public class CameraRigStabilizer : MonoBehaviour
{

    private Vector3 InitialPos;
    private Vector3 hmdPos;
    public GameObject HMD;
    public Transform CameraPos;

    void Start()
    {
        InitialPos = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //hmdPos = HMD.transform.position;                         Can't work in world position
        //transform.position = InitialPos - hmdPos;                for some reason
        hmdPos = HMD.transform.localPosition;
        transform.position = CameraPos.position - hmdPos;
    }

}