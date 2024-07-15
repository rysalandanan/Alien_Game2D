using System.Collections;
using UnityEngine;

public class Bullet_Settings : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private static readonly int State = Animator.StringToHash("state");
    private enum BulletState { Flying, Hit}
    private bool hasHit = false;

    [SerializeField] private float bulletDespawnTime;
    [SerializeField] private float bulletDestroyTime;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        StartCoroutine(bulletDespawn());
        _rb = GetComponent<Rigidbody2D>();
    }
    private IEnumerator bulletDespawn()
    {
        //after 2 seconds of not hitting anything, the bullet will be destroyed//
        yield return new WaitForSecondsRealtime(bulletDespawnTime);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Environment"))
        {
            StartCoroutine(bulletDestroy());
            hasHit = true;
            _rb.velocity = Vector2.zero;
        }
    }
    private void Update()
    {
        BulletAnimation();
        CheckFaceDirection();
    }
    private void BulletAnimation()
    {
        BulletState state;
        if (hasHit)
        {
            state = BulletState.Hit;
        }
        else
        {
            state = BulletState.Flying;
        }
        _animator.SetInteger(State, (int)state);
    }
    private void CheckFaceDirection()
    {
        Vector3 scale = transform.localScale;
        if (_rb.velocity.x < 0)
        {
            scale.x = -1f;
        }
        else if (_rb.velocity.x > 0)
        {
            scale.x = 1f;

        }
        transform.localScale = scale;
    }
    private IEnumerator bulletDestroy()
    {
        yield return new WaitForSecondsRealtime(bulletDestroyTime);
        Destroy(gameObject);
    }
}
