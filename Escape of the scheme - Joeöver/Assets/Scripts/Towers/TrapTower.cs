using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Towers
{
    class TrapTower : TowerInheritance
    {
        
        private bool _attack;
       
             private void OnTriggerStay2D(Collider2D collision)
        { //by THE component setting select collision continious & never sleeping to make the ontriggerstay act continiously+   
            print(collision.gameObject.name);
            if (collision.CompareTag("Enemy") || collision.CompareTag("Hidden"))
            {

                Debug.Log("Trapped on enemy");
                _enemy = collision.GetComponent<EnemyInheritance>();

                //the boolean makes sure that the startcoroutine isn't constantly activated
                if (!_attack)
                    StartCoroutine(AttackWithCoolDown(_attackCooldown));
            }
        }


        private IEnumerator AttackWithCoolDown(float attackCooldown)
        {
            _attack = true;
            yield return new WaitForSeconds(attackCooldown);
            _enemy.DmgTaken(Dmg);
            _attack = false;
        }




    }
}
