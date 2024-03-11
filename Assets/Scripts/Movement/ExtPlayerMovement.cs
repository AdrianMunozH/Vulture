using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtPlayerMovement : PlayerMovement
{
    // push collider
    public BoxCollider BoxCollider;


    //für isGrounded
    public GameObject ColliderSpherePrefab;
    public List<GameObject> BottomCollider = new List<GameObject>();
    public List<GameObject> MiddleColliderSphere = new List<GameObject>(); 
    //only for size
    public CapsuleCollider frontCollider;
    private Mesh mesh;
    public CapsuleCollider frictionCollider;
    
    
    
    
    private void Awake()
    {
        
        if (frontCollider == null)
        {
            Debug.Log("frontCollider not found");
            frontCollider = GetComponent<CapsuleCollider>();
        }

        if (mesh == null)
        {
            mesh = GetComponent<MeshFilter>().mesh;
        }

        float radius;
        // capsule collider direction ---- 1 == y //// 2 == z
        if (frontCollider.direction == 1)
        {
            radius = mesh.bounds.center.y;
            // frontcollider.radius;
        } else if (frontCollider.direction == 2)
        {
            radius = mesh.bounds.max.y;
        }
        else
        {
            radius = 0.2f;
            Debug.Log("Check ExtPlayerMovement Z53, capsule collider ausrichtung falsch ?");
        }
        // collider und ihre bounds verwirren mich darum macht der code darüber nicht richtig sinn. mit dem mesh zu arbeiten funkt. aber der mesh ist einfach nur eine box die nicht gut die größe des Objekt beschreibt.

        //Debug.Log(frontCollider.bounds.size.y + " :  " + frontCollider.bounds.center.y);
        //BottomSphere
        // radius  == z
        createEdgeSphereCircle(6, 60f,new Vector3(frontCollider.bounds.center.x,frontCollider.bounds.min.y+ 0.02f,frontCollider.bounds.center.z),radius/2,BottomCollider);
        
        // MidSphere
        //createEdgeSphereCircle(6,60f,caps.bounds.center,0.5f,MiddleColliderSphere );
        middleCollider(frontCollider);
        rotateMiddleCollider();
    }

    

    private void rotateMiddleCollider()
    {
        foreach (var col in MiddleColliderSphere)
        {
            col.transform.rotation = Quaternion.Euler(new Vector3(0,faceAngle,0));
        }
    }
    private void middleCollider(Collider caps)
    {
        
        float div = mesh.bounds.max.y / 4;
        float temp = mesh.bounds.min.y;
        float top = mesh.bounds.max.y - div;
        
        while (top >= temp)
        {
            
            createEdgeSphereCircle(3,60f,new Vector3(caps.bounds.center.x,temp + +0.1f+  caps.bounds.min.y,caps.bounds.max.z), mesh.bounds.center.y/6,MiddleColliderSphere);
            temp += div ;
        }
        
    }
    private GameObject createEdgeSphere(Vector3 pos) 
    {
        GameObject sphere = Instantiate(ColliderSpherePrefab, pos, Quaternion.identity);
        return sphere;
    }

    private void createEdgeSphereCircle(int max, float angle, Vector3 origin, float radius, List<GameObject> team)
    {
        
        float innerAngle = -angle;
        for (int i = 0; i < max; i++) 
        {
            Quaternion rotation = Quaternion.AngleAxis(innerAngle, Vector3.up); 
            Vector3 direction = rotation * Vector3.forward;
            Vector3 position = origin + (direction * radius);
            GameObject newObj = createEdgeSphere(position);
            newObj.transform.parent = this.transform;
            team.Add(newObj);
            innerAngle += angle;
        }
    }


}
