using Player;
using UnityEngine;
using UnityEngine.Events;

public class RangedAttack : MonoBehaviour
{
    private Animator anim;
    public GameObject projectile;
    public float chargeUpTime;
    public Vector3 targetPos;
    public bool hasATarget;
    public GameObject ChargeBar;

    public float chargeCounter;
    
    public UnityEvent chargeSound;
    public UnityEvent stopChargeSound;
    public UnityEvent releaseSound;

    private bool chargesoundPlaying;
    
    
    private void Start()
    {
        chargeCounter = chargeUpTime;
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        ChargeAttack();

        if (Input.GetMouseButtonDown(0))
        {
            chargeCounter = chargeUpTime;
        }
    }

    private void ChargeAttack()
    {
        if (Input.GetMouseButton(1))
        {
            if (hasATarget && !PlayerManager.Instance.PlayerController.Agent.hasPath)
            {
                if (!chargesoundPlaying){
                    chargeSound.Invoke();
                    chargesoundPlaying = true;
                    anim.SetTrigger("ToRanged");
                }
                
                ChargeBar.SetActive(true);
                chargeCounter -= Time.deltaTime;
            }
        }
        else
        {
            stopChargeSound.Invoke();
            chargeCounter = chargeUpTime;
            chargesoundPlaying = false;
            hasATarget = false;
        }
        
        if (chargeCounter <= 0)
        {
            releaseSound.Invoke();
            chargesoundPlaying = false;
            ChargeBar.SetActive(false);
            Instantiate(projectile, transform.position, Quaternion.identity);
            transform.LookAt(targetPos);
            hasATarget = false;
            chargeCounter = chargeUpTime;
        }

    }
}