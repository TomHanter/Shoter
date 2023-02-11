using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrenadeThower : MonoBehaviour
{
    [SerializeField] private float throwForce = 40f;
    [SerializeField] private GameObject grenadePrefab;
    
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowGrenade();
        }

    }

    void ThrowGrenade()
    {
       GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation); // создается граната при нажатии на кнопку
       Rigidbody rb = grenade.GetComponent<Rigidbody>(); // получает бади на гранате
       rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange); // говорим бади приложить силу вперед и задаем велисину силы броска
    }
}
