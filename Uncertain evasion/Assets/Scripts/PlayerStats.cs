using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int Health;

    private void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int ammount)
    {
        Health -= ammount;
    }
}
