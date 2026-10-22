using UnityEngine;

public class Bullet : MonoBehaviour

{
    [SerializeField] protected float _SpeedValue = 10f;
    [SerializeField] protected float _DamageValue = 1f;
    [SerializeField] protected float lifetime = 3f;


    protected virtual void Start()
    {
        Destroy(gameObject, lifetime);
    }
    protected virtual void Update()
    {
        Move();
    }
    protected virtual void Move()
    {
        transform.Translate(Vector3.right * _SpeedValue * Time.deltaTime);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            ApplyDamage(other.gameObject);
            DestroyBullet();
        }
    }

    protected virtual void ApplyDamage(GameObject target)
    {
        Debug.Log($"Dealt {_DamageValue} damage to {target.name}");
    }

    protected virtual void DestroyBullet()
    {
        Destroy(gameObject);
    }
}

