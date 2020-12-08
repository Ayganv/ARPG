using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;

        public PlayerHealth playerHealth => GetComponent<PlayerHealth>();

        public PlayerInteract playerInteract => GetComponent<PlayerInteract>();

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