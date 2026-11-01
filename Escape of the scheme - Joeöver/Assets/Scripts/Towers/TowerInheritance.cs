using UnityEngine;

abstract class TowerInheritance : EnitityInheritance
{
    [SerializeField] protected float _dmg;
    [SerializeField] protected int _range;


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
        //_enemy = FindAnyObjectByType<EnemyInheritance>();
    }
    public virtual void Attack(float Dmg)
    {
        //spawn bullet here
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
