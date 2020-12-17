using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;

        public PlayerHealth PlayerHealth => GetComponent<PlayerHealth>();

        public PlayerInteract PlayerInteract => GetComponent<PlayerInteract>();

        public Rigidbody PlayerRigidBody => GetComponent<Rigidbody>();

        public MeleeAttack MeleeAttack => GetComponent<MeleeAttack>();

        public RangedAttack RangedAttack => GetComponent<RangedAttack>();

        public PlayerController PlayerController => GetComponent<PlayerController>();

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