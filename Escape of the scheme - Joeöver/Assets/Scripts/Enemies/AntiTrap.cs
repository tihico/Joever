using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
     class AntiTrap : EnemyInheritance
    {
        private void OnTriggerStay2D(Collider2D collision)
        { //by THE component setting select collision continious & never sleeping to make the ontriggerstay act continiously+   
            print(collision.gameObject.name);
            if (collision.CompareTag("Bullet"))
            {
                _tower = collision.GetComponent<TowerInheritance>();
                Debug.Log("Dmged tower");

                //the boolean makes sure that the startcoroutine isn't constantly activated
                if (!_attack)
                    StartCoroutine(Attack(_attackCooldown));
            }      
        }
        
    }
}
