
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ScoreBonus: MonoBehaviour, Bonus
{
    public void Get()
    {
        FindObjectOfType<Player>().AddScore();
        Destroy(gameObject);
    }
}
