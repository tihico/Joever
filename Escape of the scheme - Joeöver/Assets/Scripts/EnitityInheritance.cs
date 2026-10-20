using UnityEngine;

abstract class EnitityInheritance : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] protected int _hp;
    [SerializeField] protected string _name;
    [SerializeField] protected string _desc;
    [SerializeField] private GameObject _gameObject;

    public void death()
    {
        if(_hp <= 0)
        {
            Destroy (gameObject);
        }
    }
}
