using Script;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{

    public class Weapon : MonoBehaviour

    {
        // SerializeField - говорит о том что переменную можно редачить в юнити
        [SerializeField] private float force = 4; // сила выстрела
        [SerializeField] private float damage = 1; // урон выстрела
        [SerializeField] private GameObject impactPrefab; // префаб эффекта попадания
        [SerializeField] private Transform shootPoint; // точка откуда идет выстрел
        [SerializeField] private float spreadConfig = 0.1f;

        private void Update() // стандартный юнити метод Update - вызывает каждый кадр
        {
            
            
            if (Input.GetMouseButtonDown(0)) // если нажимаем левую (0) кнопку мыши
            {
                
                var randomX = Random.Range(-spreadConfig / 2, spreadConfig / 2);
                var randomY = Random.Range(-spreadConfig / 2, spreadConfig / 2);
                var spread = new Vector3(randomX,randomY, 0f);
                Vector3 direction = shootPoint.forward + spread;

                if (Physics.Raycast(shootPoint.position,direction, out var hit)) // выпускаем физич луч (Raycast) trans.pos позиция игрока, forw направление взгляда,
                {

                    print(hit.transform.gameObject.name); // выводим название объекта куда попали 

                    Instantiate(impactPrefab, hit.point,Quaternion.LookRotation(hit.normal, Vector3.up)); // созд префаб эффекта попадания
                    
                    var destructible = hit.transform.GetComponent<DestruclibleObject>(); // пытаемся получить из объекта куда попали DestruclibObj
                    if (destructible != null)
                    {
                        destructible.ReceiveDamage(damage); // нанести урон
                    }

                    var rigidbody = hit.transform.GetComponent<Rigidbody>(); // пытаемся получить из объекта куда Rigigbody
                    if (rigidbody != null) // если Rigidbody есть то
                    {

                        rigidbody.AddForce(shootPoint.forward * force, ForceMode.Impulse); // добавить отбрасывание
                        // вызываем AddForce в который нужно передать
                        // 1) направл силы: shootPoint.forward (куда смотрит наше оружие)
                        // умножение на force (силу)
                        // 2) ForceMode.Impulse - говорит о том, что мы учит вес обхекта к котор доб силу
                    }
                }
            }
        }
        
        
        
        
        private void OnDrawGizmos() // юнити метод который рисует графику для редактора
            // в нем можно обращ к классу Гизмо
            // так же вызыв на каждом кадре. даже когда игра не запущ
        {

            Gizmos.color = Color.red; // префаб эффекта попадания
            
            Gizmos.DrawRay(shootPoint.position,shootPoint.transform.forward * 999); // рисуем луч идущий из позиции нашего объекта shootPoint. направленный в shootpoint forward(длинаа луча 999)
        }
    }
}