using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class ImpactGranade : MonoBehaviour
    {
        [SerializeField] private float radius = 5f;
        [SerializeField] private float force = 700f;
        [SerializeField] private GameObject explosionEffect;
        
        private void OnCollisionEnter(Collision collision) // когда столкнулись
        {
            Explode();
        }

       /* private void OnCollisionExit(Collision other) // когда вышли из столкновения
       {
            
        }

        
        private void OnCollisionStay(Collision collisionInfo) // на каждом кадре после столкновения
        {
            
        }
        */
       
        void Explode()
        {
            Instantiate(explosionEffect, transform.position, transform.rotation); // эффект

            Collider[] colliders = Physics.OverlapSphere(transform.position, radius); // радиус взрыва, получаем все ближ объекты

            foreach (Collider nearbyObject in colliders) // проходим по ближ объектам
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>(); // ищем Rigidbody
                if (rb !=null)
                {
                    rb.AddExplosionForce(force, transform.position, radius); // доб силу направ от гранаты
                }

            }
        
            Destroy((gameObject));
        }
    }
    
}

