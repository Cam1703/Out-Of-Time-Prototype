using UnityEngine;

public class CameraManager: MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private bool _followPlayer = true;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (_player != null)
        {
            if(_followPlayer) FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        // Actualiza la posición de la cámara para seguir al jugador
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
    }
}
