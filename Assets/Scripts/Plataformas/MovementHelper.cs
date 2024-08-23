using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHelper : MonoBehaviour
{
    public List<Transform> positions;

    public float duration = 1f;

    private int _index = 0;

    [SerializeField]
    private Player player = null;

    private void Start()
    {
        initialPosition = transform.position;
    }

    float time = 0;
    Vector3 initialPosition;

    private void FixedUpdate()
    {
        if (time < duration)
        {
            var nextPosition = Vector3.Lerp(initialPosition, positions[_index].transform.position, (time / duration));

            transform.position = nextPosition;
            time += Time.deltaTime;
        }
        else
        {
            _index++;
            if (_index >= positions.Count) _index = 0;

            time = 0;
            initialPosition = transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        collision.transform.parent = transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        collision.transform.parent = null;
    }
}
