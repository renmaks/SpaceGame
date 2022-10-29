using UnityEngine;

/// <summary>
/// Управление кораблем
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private const float _speed = 35;
    private const float _pitchMupltiplierX = 15; // Угол наклона
    private const float _pitchMultiplierY = 15;
    private const float _pitchMultiplierZ = 5;
    
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
        _rigidbody.velocity = new Vector3(_xAxis * _speed, 0, _zAxis * _speed);
        
        //поворот/наклон
        _rigidbody.rotation = Quaternion.Euler(_zAxis * _pitchMupltiplierX, _xAxis * _pitchMultiplierY, -_xAxis * _pitchMultiplierZ);
    }
}
