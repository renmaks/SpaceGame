using UnityEngine;

/// <summary>
/// Эффект параллакса для задника
/// </summary>
public class Parallax : MonoBehaviour
{
    [SerializeField] private GameObject _playerShip;
    [SerializeField] private GameObject[] _starfieldFacegrounds;
    
    private const float _scrollSpeed = -10f;
    private const float _motionMultiplier = 0.2f; //скорость реакции задника на перемещение корабля игрока

    private float _facegroundHeight;
    private float _facegroundDepth; // pos.y
    private Rigidbody _playerRigidbody;

    private void Start()
    {
        _playerRigidbody = _playerShip.GetComponent<Rigidbody>();

        _facegroundHeight = _starfieldFacegrounds[0].transform.localScale.y;
        _facegroundDepth = _starfieldFacegrounds[0].transform.position.y;

        _starfieldFacegrounds[0].transform.position = new Vector3(0, _facegroundDepth, 0);
        _starfieldFacegrounds[1].transform.position = new Vector3(0, _facegroundDepth, 0);
    }

    private void Update()
    {
        float xPosition = 0;
        float yPosition = Time.time * _scrollSpeed % _facegroundHeight + (_facegroundHeight * 0.5f);

        if (_playerShip != null)
        {
            xPosition = -_playerRigidbody.position.x * _motionMultiplier;
        }

        _starfieldFacegrounds[0].transform.position = new Vector3(xPosition, _facegroundDepth, yPosition);
        _starfieldFacegrounds[1].transform.position = yPosition >= 0 ? new Vector3(xPosition, _facegroundDepth, yPosition - _facegroundHeight) 
            : new Vector3(xPosition, _facegroundDepth, yPosition + _facegroundHeight);
    }
}
