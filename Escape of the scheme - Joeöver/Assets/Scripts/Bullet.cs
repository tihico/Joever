using UnityEngine;

 class Bullet : EnitityInheritance //needed it to have the entityInheritance for an anti bullet enemy that deletes bulets

{
    [SerializeField] protected float _speedValue = 10f;
    [SerializeField] protected float _damageValue = 1f;
    [SerializeField] protected float lifetime = 3f;
    
    private EnemyInheritance _enemy;

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
        transform.Translate(Vector3.left * _speedValue * Time.deltaTime);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _enemy = collision.GetComponent<EnemyInheritance>();
            Attack();
           
        }
    }

     public void Attack()
    {
        Debug.Log($"Dealt {_damageValue} ");
        _enemy.DmgTaken(_damageValue);
    }

    public virtual void DestroyBullet()
    {
        base.Death();
    }
}

