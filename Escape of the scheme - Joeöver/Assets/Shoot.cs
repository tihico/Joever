using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] private GameObject _Bullet;
    [SerializeField] private Transform _BulletSpawn;
    [SerializeField] private float _fireRate;


    void Start()
    {
        InvokeRepeating(nameof(Projectile), 0.0f, _fireRate);
    }

   
    void Projectile()
    {
        Instantiate(_Bullet, transform.position, transform.rotation);
    }
}
