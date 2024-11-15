using System;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class BulletControl : MonoBehaviour
{
    public float speed;
    public float destroyTime = 5f;

    private void Update()
    {
        transform.position += Vector3.left * (speed * Time.deltaTime);
        destroyTime -= Time.deltaTime;
        if (destroyTime < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().GetHit();
            Destroy(this.gameObject);
        }
    }
}