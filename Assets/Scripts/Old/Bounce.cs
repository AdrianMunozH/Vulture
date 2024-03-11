using UnityEngine;

namespace Old
{
    public class Bounce : MonoBehaviour
    {
        public float factor;
        public void Update()
        {
            Vector3 moveDirection = new Vector3();

            var position = transform.parent.position;
            moveDirection = new Vector3(position.x, position.y +  Mathf.Sin(Time.time*2)*factor, position.z);
            transform.position =  moveDirection;
       
        }
    }
}
