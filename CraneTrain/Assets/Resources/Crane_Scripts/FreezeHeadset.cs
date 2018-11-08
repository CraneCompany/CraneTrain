using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FreezeHeadset : MonoBehaviour
{
    public GameObject FoveInterface;

void Enable()
{
    transform.position = FoveInterface.transform.position;
    FoveInterface.transform.localPosition = Vector3.zero;
}

}