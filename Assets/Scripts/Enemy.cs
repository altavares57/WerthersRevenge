using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the enemy
    public int damageAmount = 10; // Amount of damage taken when hit
    public float pushForce = 10f; // Force applied to the enemy when hit

    private int currentHealth; // Current health of the enemy
    private GameObject player; // Reference to the player object

    private void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // Check if the enemy's health has reached zero or below
        if (currentHealth <= 0)
        {
            // Enemy is defeated, perform necessary actions (e.g., play death animation, spawn particles, etc.)
            Defeat();
        }
        else
        {
            // Apply a force to push the enemy back
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 pushDirection = transform.position - player.transform.position;
            rb.AddForce(pushDirection.normalized * pushForce, ForceMode2D.Impulse);
        }

        // Print current health for debugging
        Debug.Log("Enemy health: " + currentHealth);
    }


    private void Defeat()
    {
        // Perform actions when the enemy is defeated (e.g., play death animation, spawn particles, etc.)
        // For example, you can trigger an animation and destroy the GameObject after a delay
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Defeated"); // Assuming you have an animation trigger named "Defeated"

        // Destroy the enemy GameObject after a delay
        float destroyDelay = 1f; // Delay in seconds before destroying the enemy
        Destroy(gameObject, destroyDelay);
    }
}
