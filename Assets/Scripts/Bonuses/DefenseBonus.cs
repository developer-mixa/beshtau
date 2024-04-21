
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class DefenseBonus : MonoBehaviour, Bonus
{
    public void Get()
    {
        FindObjectOfType<Player>().TakeDefense(30);
        Destroy(gameObject);
    }
}
