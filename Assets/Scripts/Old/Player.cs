using UnityEngine;

namespace Old
{
    public class Player : MonoBehaviour
    {

    
        public float moveSpeed;
        private CharacterController characterController;
        // public float jumpForce;
        private Vector3 moveDirection;
        public float gravityScale;

        private void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            //Bewegung 
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, moveDirection.z);

            //Springen nicht gewünscht
            /*
        if (characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }*/

            moveDirection.y = (moveDirection.y + (Physics.gravity.y * 0.1f * Time.deltaTime));
            if (transform.position.x > 0.971 && Input.GetAxis("Horizontal") < 0 )
            {
                characterController.Move(moveDirection * Time.deltaTime);
            }
            else if( transform.position.x <= 0.971 && Input.GetAxis("Horizontal") > 0 ) 
            {
                characterController.Move(moveDirection * Time.deltaTime);
            }
            characterController.Move(moveDirection * Time.deltaTime);

        }
    }
}