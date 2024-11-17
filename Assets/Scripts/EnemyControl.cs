using System.Collections;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private static readonly int IsWalking = Animator.StringToHash("isWalk");
    private static readonly int IsIdle = Animator.StringToHash("isIdle");
    [SerializeField] private float walkSpeed = 2.5f;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    private Animator _animator;
    public Transform _currentTarget;
    private Rigidbody2D _rb2d;
    private bool _isFlipped;
    public string distance;

    private bool _isFlipping;

    private void Start()
    {
        // Ensure pointA and pointB are not affected by parent
        pointA.SetParent(null);
        pointB.SetParent(null);

        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _currentTarget = pointA;
    }

    private void Update()
    {
        MoveBetweenPoints();
    }

    private void MoveBetweenPoints()
    {
        if (_isFlipping) return;
        _animator.SetTrigger(IsWalking);
        // Calculate movement direction
        Vector2 direction = (_currentTarget.position - transform.position).normalized;

        // Update velocity
        _rb2d.linearVelocity = new Vector2(direction.x * walkSpeed, _rb2d.linearVelocity.y);

        // Check distance to change direction
        if (Vector2.Distance(transform.position, _currentTarget.position) < 0.8f)
        {
            _currentTarget = (_currentTarget == pointA.transform) ? pointB.transform : pointA.transform;
            StartCoroutine(DelayBeforeFlip());
        }

        distance = "Distance: " + Vector2.Distance(transform.position, _currentTarget.position);
    }

    private IEnumerator DelayBeforeFlip()
    {
        if (_isFlipping) yield break;
        _animator.SetTrigger(IsIdle);
        _isFlipping = true;

        yield return new WaitForSeconds(3);

        Flip();
        _isFlipping = false;
    }

    private void Flip()
    {
        // Flip the object by changing its localScale
        _isFlipped = !_isFlipped;
        Vector3 localScale = transform.localScale;
        localScale.x = _isFlipped ? -Mathf.Abs(localScale.x) : Mathf.Abs(localScale.x);
        transform.localScale = localScale;
    }
}