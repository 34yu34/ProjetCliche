using NaughtyAttributes;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    [InputAxis]
    [SerializeField] 
    private string _horizontalInput;
    
    [InputAxis]
    [SerializeField] 
    private string _verticalInput;


    private Rigidbody2D _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        var movement = _movementSpeed * new Vector2(Input.GetAxis(_horizontalInput), Input.GetAxis(_verticalInput));
        
        _rb.velocity = movement;
    }
}
