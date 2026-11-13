using UnityEngine;

abstract class EnitityInheritance : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] protected float _hp;
    [SerializeField] protected string _name;
    [SerializeField] protected string _desc;
    [SerializeField] protected GameObject _gameObject;

    private void Start()
    {
        
    }
    public virtual void Death()
    {
        if (_hp <= 0)
        {
            Destroy(gameObject);

        }
    }

}
