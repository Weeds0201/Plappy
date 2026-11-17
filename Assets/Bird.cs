using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Bird : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    [SerializeField] private float _bay = 2f;
    [SerializeField] private float _quaydau = 5f;
    [SerializeField] private TMP_Text _scoreText;
    private int _score = 0;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame || Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            _rb.linearVelocity = Vector2.up * _bay;
        }
    }

    private void FixedUpdate()
    {
       
        float angle = Mathf.Clamp(_rb.linearVelocity.y * _quaydau, -90f, 35f);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ScoreZone"))
        {
            _score++;
            _scoreText.text = "Score: " + _score.ToString();
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Time.timeScale = 0f;
        Debug.Log("Game Over!");
    }
}