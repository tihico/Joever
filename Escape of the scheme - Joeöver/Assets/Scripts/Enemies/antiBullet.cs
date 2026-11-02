using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
     class antiBullet : EnemyInheritance
    {
        private Bullet _destroyBullet;
        private void OnTriggerStay2D(Collider2D collision)
        { //by THE component setting select collision continious & never sleeping to make the ontriggerstay act continiously+   
            print(collision.gameObject.name);
            if (collision.CompareTag("Bullet"))
            {
                _destroyBullet = collision.GetComponent<Bullet>();
                Debug.Log("Dmged tower");

                //the boolean makes sure that the startcoroutine isn't constantly activated
                if (!_attack)
                    StartCoroutine(Attack(_attackCooldown));
            }



        }



       public override IEnumerator Attack(float attackCooldown)
        {
            _attack = true;
            yield return new WaitForSeconds(attackCooldown);
            _destroyBullet.DestroyBullet();
            _attack = false;
        }



    }
}
