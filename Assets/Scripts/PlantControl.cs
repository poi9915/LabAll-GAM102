using UnityEngine;
using UnityEngine.Serialization;

public class PlantControl : MonoBehaviour
{
    private static readonly int IsTarget = Animator.StringToHash("isTarget");
    private static readonly int Countdown = Animator.StringToHash("isCooldown");

    public GameObject bullet;
    public Transform bulletPosition;
    public float cooldownSet = 5;
    private float _timer = 0;
    public float raycastRanger = 8.5f;
    private Animator _animator;
    [SerializeField] private string countdownStatus;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FireDetection();
    }

    public void FireDetection()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            bulletPosition.position,
            -transform.right,
            raycastRanger,
            LayerMask.GetMask("Player")
        );

        Debug.DrawRay(bulletPosition.position, -transform.right * raycastRanger, Color.red);
        if (hit.collider is not null)
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
                countdownStatus = "Plant Cooldown : " + _timer;
                _animator.SetTrigger(Countdown);
            }
            else
            {
                _animator.SetTrigger(IsTarget);
                _timer = cooldownSet;
            }
        }
    }

    public void Shoot()
    {
        Debug.Log("Shoot some shit !!!");
        Instantiate(bullet, bulletPosition.position , Quaternion.identity);
    }
}