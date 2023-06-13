using UnityEngine;

public class Orb : MonoBehaviour
{
    public int damageAmount = 1; // Amount of damage inflicted on collision

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the "Enemy" tag
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Get the Enemy script from the collided object
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                // Call the TakeDamage function on the enemy with the damageAmount
                enemy.TakeDamage(damageAmount);
                // Debug log the damage
                Debug.Log("Orb collided with enemy. Damage inflicted: " + damageAmount);
            }
        }
        // Destroy the orb on collision with any object
        Destroy(gameObject);
    }
}

