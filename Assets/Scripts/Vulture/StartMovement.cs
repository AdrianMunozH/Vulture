using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class StartMovement : MonoBehaviour
{
    private static Vector3 _vector3= new Vector3(0.3f, 0.3f, 0.3f);

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Vulture").GetComponent<VisualEffect>().SetVector3("Movement",new Vector3(0.7f,0.7f,0.7f));
    }

    public static void start(VisualEffect vulture)
    {
        vulture.SetVector3("Movement",new Vector3(0.7f,0.7f,0.7f));
    }

    public static void setVector3(Vector3 vec)
    {
        _vector3 = vec;
    }
}
