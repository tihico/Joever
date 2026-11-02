using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Towers
{
    internal class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private List<Transform> _GameObjectSpawnLocation = new List<Transform>();
       public void SpawnBullet()
        {
            foreach (Transform location in _GameObjectSpawnLocation)
            {
                Instantiate(_bullet, location.position, location.rotation);
                Debug.Log("spawned");
            }
        }
            

                

            
    }
}



