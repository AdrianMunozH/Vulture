using UnityEngine;

namespace Events
{
    public class PlayCutScene : MonoBehaviour
    {
        public GameObject cutScene;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {

                cutScene.SetActive(true);
            }

        }
    }
}
