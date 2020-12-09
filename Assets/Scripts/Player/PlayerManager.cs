using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;

        public PlayerHealth PlayerHealth => GetComponent<PlayerHealth>();

        public PlayerInteract PlayerInteract => GetComponent<PlayerInteract>();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }
    }
}