using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject orbPrefab; // Prefab for the orb GameObject
    public float maxChargeLevel = 3f; // Maximum charge level for the orb
    public float chargeSpeed = 1f; // Speed at which the orb charges
    public float orbForce = 10f; // Force applied to the orb upon release

    private GameObject currentOrb; // Reference to the currently charged orb
    private float chargeLevel; // Current charge level of the orb

    private void Update()
    {
        // Check for left mouse button press
        if (Input.GetMouseButtonDown(0))
        {
            // Start charging the orb
            StartCharging();
        }

        // Check for left mouse button release
        if (Input.GetMouseButtonUp(0))
        {
            // Release the orb
            ReleaseOrb();
        }
    }

    private void StartCharging()
    {
        // Calculate the spawn position for the orb
        Vector3 orbSpawnPosition = transform.position + Vector3.up * 0.5f; // Add one unit in the upward direction

        // Instantiate the orb at the calculated spawn position
        currentOrb = Instantiate(orbPrefab, orbSpawnPosition, Quaternion.identity);
        chargeLevel = 0f;
    }

    private void ReleaseOrb()
    {
        // Calculate the direction from player to mouse cursor
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Apply force to the orb in the calculated direction
        Rigidbody2D orbRigidbody = currentOrb.GetComponent<Rigidbody2D>();
        orbRigidbody.AddForce(direction * orbForce, ForceMode2D.Impulse);

        // Clean up variables
        currentOrb = null;
    }

    private void FixedUpdate()
    {
        // Charge the orb while the left mouse button is held down
        if (Input.GetMouseButton(0) && currentOrb != null)
        {
            chargeLevel += chargeSpeed * Time.deltaTime;

            // Scale the orb based on charge level
            float currentScale = Mathf.Clamp(chargeLevel, 0f, maxChargeLevel);
            currentOrb.transform.localScale = Vector3.one * currentScale;
        }
    }
}
