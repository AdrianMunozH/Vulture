using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class StopMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private static Vector3 _vector3= new Vector3(0.3f, 0.3f, 0.3f);
    
    void Start()
    {
        GameObject.Find("Vulture").GetComponent<VisualEffect>().SetVector3("Movement",_vector3);
    }
    
    public static void stop(VisualEffect vulture)
    {
        vulture.SetVector3("Movement",_vector3);
    }

    public static void setVector3(Vector3 vec)
    {
        _vector3 = vec;
    }
}
