using Assets.Scripts.Towers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class TowerInheritance : EnitityInheritance
{
    [SerializeField] protected float _dmg;
    [SerializeField] protected int _range;
    private BulletSpawner _spawner;
    private bool _attack = false;
    [SerializeField] protected float _attackCooldown;

    protected EnemyInheritance _enemy;
    public float Dmg
    {
        get
        {
            return _dmg;
        }
    }


    public void Start()
    {
        _spawner = GetComponent<BulletSpawner>();
    }
    public void SpawnBullet()
    {
        _spawner.SpawnBullet();
    }
    private void OnTriggerStay2D(Collider2D collision)
    { //by THE component setting select collision continious & never sleeping to make the ontriggerstay act continiously+   
        print(collision.gameObject.name);
        if (collision.CompareTag("Enemy") || collision.CompareTag("Hidden"))
        {
            _enemy = collision.GetComponent<EnemyInheritance>();
            Debug.Log("Dmged tower");

            //the boolean makes sure that the startcoroutine isn't constantly activated
            if (!_attack)
                StartCoroutine(Spawn(_attackCooldown));
        }
    }

    private IEnumerator Spawn(float attackCooldown)
    {
        _attack = true;
        yield return new WaitForSeconds(attackCooldown);
        SpawnBullet();
        _attack = false;
    }

    public virtual void DmgTaken(float Dmg)
    {
        _hp -= Dmg;
    }

    public void Update()
    {
        Death();
    }
  
}
//make the target prioritisation of the towers based off of who is first through a list and adque (adque might not be it but it's simular)
