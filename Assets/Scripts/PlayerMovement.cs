using UnityEngine;

/// <summary>
/// Управление кораблем
/// </summary>
public class PlayerMovement : MonoBehaviour
{
     private const float _speed = 35;
     private const float _pitchMupltiplier = 20; // Угол наклона
     private const float _rollMultiplier = 20;
    
    private Rigidbody _rigidbody;
    private float _xAxis, _zAxis;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _xAxis = Input.GetAxis("Horizontal");
        _zAxis = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Передвижение корабля
    /// </summary>
    private void Move()
    {
        Vector3 velocity = _rigidbody.velocity;
        velocity = new Vector3(_xAxis * _speed, velocity.y, velocity.z);
        velocity = new Vector3(velocity.x, velocity.y, _zAxis * _speed);
        _rigidbody.velocity = velocity;
        
        //поворот/наклон
        _rigidbody.rotation = Quaternion.Euler(_zAxis * _pitchMupltiplier, _xAxis * _rollMultiplier, 0);
    }
}
