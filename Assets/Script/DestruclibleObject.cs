using UnityEngine;

namespace Script
{
    public class DestruclibleObject : MonoBehaviour
    {
        // текущ здоровье
        [SerializeField] private float hpCurrent = 100;
        
        
        public void ReceiveDamage(float damage) // написанный нами кастомный метод( не юнити метод)
                                                  // void ничего не возвращ
                                                    // float damage принимает некое дробное число
        {
            
            hpCurrent -= damage; // вычитаем из текущ ХП урон
            // или так написать hpCurrent = hpCurrent - 1f;
            
            if (hpCurrent <0f) // если хп уменьш меньше нуля то
            {
                
                Destroy(gameObject); // уничтожить все
            }
        }
    }
    
}