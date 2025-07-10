using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Referencia al componente Animator para controlar las animaciones del jugador.
    private Animator _animator;
    private SpriteRenderer _sprite;
    
    // Referencias al animador
    private const string _horizontal = "Horizontal"; // Nombre del par�metro horizontal en el Animator.
    private const string _vertical = "Vertical"; // Nombre del par�metro vertical en el Animator.
    private const string _lastHorizontal = "LastHorizontal"; // Nombre del par�metro de �ltima direcci�n horizontal en el Animator.
    private const string _lastVertical = "LastVertical"; // Nombre del par�metro de �ltima direcci�n vertical en el Animator.

    // Referencias al audio
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _hurtSound; // Sonido que se reproduce al recibir da�o.
    [SerializeField] private AudioClip _maleeAttackSound; // Sonido que se reproduce al realizar un ataque cuerpo a cuerpo.
    [SerializeField] private AudioClip _shootingSound; // Sonido que se reproduce al disparar.

    void Start()
    {
        // Obtiene el componente Animator asociado al GameObject.
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void WalkAnimation(Vector2 movement)
    {
        // Actualiza los par�metros del Animator para controlar las animaciones del jugador.
        _animator.SetFloat(_horizontal, movement.x);
        _animator.SetFloat(_vertical, movement.y);

        // Si el jugador se est� moviendo, actualiza la �ltima direcci�n de movimiento.
        if (movement != Vector2.zero)
        {
            _animator.SetFloat(_lastHorizontal, movement.x);
            _animator.SetFloat(_lastVertical, movement.y);
        }

    }

    public void HurtAnimation()
    {
        // Hace un parpadeo del sprite del jugador al recibir da�o.
        if (_hurtSound != null)
        {
            _audioSource.PlayOneShot(_hurtSound); // Reproduce el sonido de da�o.
        }
        _sprite.color = new Color(1f, 0.5f, 0.5f, 1f); // Cambia el color del sprite a rojo claro.
        Invoke("ResetSpriteColor", 0.1f); // Llama a ResetSpriteColor despu�s de 0.1 segundos.
    }

    public void MaleeAttackAnimation()
    {
        // Reproduce el sonido del ataque cuerpo a cuerpo.
        if (_maleeAttackSound != null)
        {
            _audioSource.PlayOneShot(_maleeAttackSound); // Reproduce el sonido del ataque cuerpo a cuerpo.
        }
        // Activa la animaci�n de ataque
        _animator.Play("Stabing");
    }

    public void ShootAnimation()
    {
        // Reproduce el sonido de disparo.
        if (_shootingSound != null)
        {
            _audioSource.PlayOneShot(_shootingSound); // Reproduce el sonido de disparo.
        }
        // Activa la animaci�n de disparo
        _animator.Play("Shooting");
    }

    private void ResetSpriteColor()
    {
        // Restaura el color original del sprite del jugador.
        _sprite.color = Color.white; // Cambia el color del sprite a blanco.
    }
}
