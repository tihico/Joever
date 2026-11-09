using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

class BulletExplode : Bullet
{
    [SerializeField] private GameObject _Explosion;

    private new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Hidden"))
        {
            Instantiate(_Explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}