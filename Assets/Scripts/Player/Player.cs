using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask Ground = 8;
    [SerializeField] private Transform spawn;
    
    private const float CheckRadius = 0.4f;
    private const int DefaultLife = 3;
    private int _maxLife = DefaultLife;
    private Rigidbody2D _rig;
    private int _life = DefaultLife;
    private bool _isDefense = false;
    private int _score = 0;
    private bool _isDoubleScore;
    
    private Coroutine _defenseCoroutine;
    private Coroutine _doubleScoreCoroutine;

    [NonSerialized] public bool isOnGround;
    
    public event Action<bool> OnUp;
    public event Action OnFinish;
    public event Action OnAddHeart;
    public event Action<int> OnLifeChanged;
    public event Action<int> OnDefenseChanged;
    public event Action<int> OnScoreChanged;
    public event Action<int> OnDoubledScoreTime;
    

    private void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        gameObject.transform.position = spawn.position;
    }

    private void Update()
    {
        OnUp?.Invoke(Vector3.Dot(_rig.velocity, Vector3.up) > 1);
        CheckingGround();
    }

    private void CheckingGround()
    {
        isOnGround = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, Ground);
    }

    public void TakeDefense(int timeDefense)
    {
        if (_defenseCoroutine != null) StopCoroutine(_defenseCoroutine);
        
        _defenseCoroutine = StartCoroutine(TakeDefenseCoroutine(timeDefense));
;    }

    private IEnumerator TakeDefenseCoroutine(int timeDefense)
    {
        _isDefense = true;
        var second = new WaitForSeconds(1f);
        for (int i = timeDefense; i >= 0; i--)
        {
            OnDefenseChanged?.Invoke(i);
            yield return second;
        }
        _isDefense = false;
    }

    public void DoubleScore(int timeDouble)
    {
        if(_doubleScoreCoroutine != null) StopCoroutine(_doubleScoreCoroutine);

        _doubleScoreCoroutine = StartCoroutine(DoubleScoreCoroutine(timeDouble));
    }
    private IEnumerator DoubleScoreCoroutine(int timeDouble)
    {
        _isDoubleScore = true;
        var second = new WaitForSeconds(1f);
        for (int i = timeDouble; i >= 0; i--)
        {
            OnDoubledScoreTime?.Invoke(i);
            yield return second;
        }
        _isDoubleScore = false;
    }
    public void AddScore(int added = 1)
    {
        var addedValue = added * (_isDoubleScore ? 2 : 1);
        _score += addedValue;
        OnScoreChanged?.Invoke(_score);
    }

    public void AddHealth()
    {
        if (_life + 1 <= _maxLife)
        {
            _life++;
            OnLifeChanged?.Invoke(_life);
        }
    }

    public void AddHeart()
    {
        _maxLife += 1;
        _life++;
        OnAddHeart?.Invoke();
    }

    public void IncreaseHealth()
    {
        if(_isDefense) return;
        if(_life - 1 > 0)
        {
            _life--;
            OnLifeChanged?.Invoke(_life);
        }
        else
        {
            OnFinish?.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var bonus = other.GetComponent<Bonus>();
        if(bonus == null) return;
        bonus.Get();
        var go = Instantiate(other.gameObject, other.gameObject.transform.parent);
        StartCoroutine(MoveUpCoroutine(go));
    }
    
    //If I make it in time, I'll transfer it to another layer
    IEnumerator MoveUpCoroutine(GameObject go)
    {
        var speed = 4;
        var duration = 4;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + Vector3.up * speed;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            go.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        go.transform.position = endPosition;
        Destroy(go);
    }
    
}
