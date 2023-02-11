using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Grenade : MonoBehaviour
{
     [SerializeField] private float delay = 3f; // задержка перед взрывом
     [SerializeField] private float radius = 5f;
     [SerializeField] private float force = 700f;
     [SerializeField] private GameObject explosionEffect;
     
     private float countdown;
     private bool hasExploded = false;
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime; //  Time.deltaTime- время прошедшее после вып пред кадра, отнимает от countdown время 1 сек
        if (countdown <= 0f && !hasExploded) // !hasExp можно записать как hasExp == false. Вызов Explode если его не было
        {
            Explode();
            hasExploded = true;
        }
    }

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
