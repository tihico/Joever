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
        [SerializeField] private float _attackCooldown;
        private bool _attack;
       
             private void OnTriggerStay2D(Collider2D collision)
        { //by THE component setting select collision continious & never sleeping to make the ontriggerstay act continiously+   
            print(collision.gameObject.name);
            if (collision.CompareTag("Enemy"))
            {

                Debug.Log("Dmged enemy");

                //the boolean makes sure that the startcoroutine isn't constantly activated
                if (!_attack)
                    StartCoroutine(Attack(_attackCooldown));
            }
        }


        IEnumerator Attack(float attackCooldown)
        {
            _attack = true;
            yield return new WaitForSeconds(attackCooldown);
            _enemy.DmgTaken();
            _attack = false;
        }




    }
}
