using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}