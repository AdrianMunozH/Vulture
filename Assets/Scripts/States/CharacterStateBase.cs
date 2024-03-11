using UnityEngine;

namespace States
{
    public class CharacterStateBase : StateMachineBehaviour
    {
        private PlayerMovement _playerMovement;
        private ExtPlayerMovement _extPlayerMovement;
        private Collider[] arrColliders;
        public PlayerMovement GetPlayerMovement(Animator animator)
        {
            if(_playerMovement == null)
                _playerMovement = animator.GetComponentInParent<PlayerMovement>();
        
            return _playerMovement;
        }
        public ExtPlayerMovement GetExtPlayerMovement(Animator animator)
        {
            if(_extPlayerMovement == null)
                _extPlayerMovement = animator.GetComponentInParent<ExtPlayerMovement>();
        
            return _extPlayerMovement;
        }
        // 0 = Vulture | 1 = Ratte | 2 = MoleBoy
        public int PlayerSoundNumber(Animator animator)
        {
            if (animator.gameObject.name == "Vulture")
            {
                return 0;
            } else if(animator.gameObject.name == "RatModel2")
            {
                return 1;
            } else
            {
                return 2;
            }
        }
        public bool IsGrounded()
        {
            
            if (_extPlayerMovement.Rigidbody.velocity.y <= 0f && _extPlayerMovement.Rigidbody.velocity.y > -0.01f)
            {
                return true;
            }
        
            
        
            // nur wenn man fällt
            if (_extPlayerMovement.Rigidbody.velocity.y < 0f)
            {
                foreach (GameObject gameObject in _extPlayerMovement.BottomCollider )
                {
                    Debug.DrawRay(gameObject.transform.position,Vector3.down *0.2f, Color.red);
                    RaycastHit hit;
                    // maxDistance muss noch getestet werden ob sie zu hoch ist.
                    if (Physics.Raycast(gameObject.transform.position, Vector3.down, out hit, 0.2f))
                    {
                        Debug.DrawRay(gameObject.transform.position,Vector3.down *0.2f, Color.green);
                        return true;
                    }
                }
            }
        
        
            return false;
        }
        public int IsPushing()
        {
            Vector3 dir = Vector3.right;
        
            foreach (GameObject gameObject in _extPlayerMovement.MiddleColliderSphere )
            {
                if (_extPlayerMovement.MoveLeft)
                {
                    Debug.DrawRay(gameObject.transform.position,Vector3.left *0.3f, Color.yellow);
                    dir = Vector3.left;
                }
                else if(_extPlayerMovement.MoveRight)
                {
                    Debug.DrawRay(gameObject.transform.position,Vector3.right *0.3f, Color.yellow);
                    dir = Vector3.right;
                }
                
           
                RaycastHit hit;
                // maxDistance muss noch getestet werden ob sie zu hoch ist.
                if (Physics.Raycast(gameObject.transform.position, dir, out hit, 0.3f))
                {
                    if (isPushable(hit.collider.gameObject))
                    {
                        Debug.DrawRay(gameObject.transform.position,dir *0.3f, Color.blue);
                        return 1;
                    }
                    if (isLadder(hit.collider.gameObject))
                    {
                        Debug.DrawRay(gameObject.transform.position,dir *0.3f, Color.blue);
                        return 2;
                    }

                }

                arrColliders = Physics.OverlapSphere(gameObject.transform.position, 0.01f);
                if (checkOverlap())
                {
                    return 1;
                }
            }
            return 0;
        }

        public bool isPushable(GameObject gameObject)
        {
            return gameObject.tag == "isPushable";
        }
        public bool isLadder(GameObject gameObject)
        {
            return gameObject.tag == "isLadder";
        }

        public bool checkOverlap()
        {
            foreach (Collider c in arrColliders)
            {
                if (isPushable(c.gameObject))
                {
                    return true;
                }
            }
            return false;
        }
    
    }
}
