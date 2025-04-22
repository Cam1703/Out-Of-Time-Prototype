using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 2f;
    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 vector2 = _player.transform.position - transform.position;
        vector2.Normalize();
        _rb.MovePosition((Vector2)transform.position + vector2 * _speed * Time.deltaTime);
    }


}
