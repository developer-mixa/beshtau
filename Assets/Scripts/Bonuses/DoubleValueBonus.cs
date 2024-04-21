using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class DoubleValueBonus : MonoBehaviour, Bonus
{
    public void Get()
    {
        FindObjectOfType<Player>().DoubleScore(30);
        Destroy(gameObject);
    }
}
