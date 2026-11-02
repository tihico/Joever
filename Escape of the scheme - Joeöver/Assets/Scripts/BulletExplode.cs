using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

class BulletExplode : Bullet
{
    [SerializeField] private GameObject _Explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(_Explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}