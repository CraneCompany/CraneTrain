using UnityEngine;

public class GazeableObject : MonoBehaviour
{
    private FoveInterfaceBase foveInterface;

    private Collider my_collider;
    private bool b_onTarget, b_eyesClosed;
    void Start()
    {
        my_collider = GetComponent<Collider>();
        foveInterface = GameObject.FindGameObjectWithTag("FIB").GetComponent<FoveInterfaceBase>();
    }

    void Update()
    {
        //Checks whether or not the user gazes at this object
        if (foveInterface.Gazecast(my_collider))
        {
            //Causes it to be a execute the code 1 time instead of every frame
            if (!b_onTarget)
            {
                b_onTarget = true;
            }
        }
        else
        {
            //Causes it to be a execute the code 1 time instead of every frame
            if (b_onTarget)
            {
                b_onTarget = false;
            }
        }
        //Checks if the user has its eyes closed
        if (foveInterface != null)
        {
            if (foveInterface.CheckEyesClosed() == Fove.Managed.EFVR_Eye.Both)
            {
                b_eyesClosed = true;
            }
            else
            {
                b_eyesClosed = false;
            }
        }
    }

    //Public methods with just a bool to return
    public bool OnTarget()
    {
        return b_onTarget;
    }
    public bool EyesClosed()
    {
        return b_eyesClosed;
    }
}
