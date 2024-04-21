using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class AddLifeBonus : MonoBehaviour, Bonus
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _addLifeClip;

    private void Awake()
    {
        _audioSource = FindObjectOfType<AudioSource>();
        _addLifeClip = Resources.Load<AudioClip>("Sounds/bonus");
    }

    public void Get()
    {
        _audioSource.PlayOneShot(_addLifeClip);
        FindObjectOfType<Player>().AddHealth();
        Destroy(gameObject);
    }
}
