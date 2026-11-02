using UnityEngine;
using UnityEngine.SceneManagement;

class BaseScript : EnitityInheritance
{
    [SerializeField] private string _scene;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _hp--;
            Death();
        }
    }
    public override void Death()
    {
        if (_hp <= 0)

        {
            SceneManager.LoadScene(_scene);
            Destroy(gameObject);
        }
    }
}
