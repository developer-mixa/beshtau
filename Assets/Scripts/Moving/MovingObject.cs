
using System.Collections;
using UnityEngine;

public class MovingObject : MonoBehaviour
{

    [SerializeField] private Vector2 startPosition;
    [SerializeField] private Vector2 endPosition;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float duration = 1.0f;

    void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    IEnumerator MoveCoroutine()
    {
        while (true)
        {
            float elapsedTime = 0;

            while (elapsedTime < duration)
            {
                transform.position = Vector2.Lerp(startPosition, endPosition, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            
            (startPosition, endPosition) = (endPosition, startPosition);
        }
    }
}
