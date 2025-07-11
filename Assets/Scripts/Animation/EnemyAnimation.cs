using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _sprite;

    // Referencias al audio
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _hurtSound; // Sonido que se reproduce al recibir daño.
    [SerializeField] private AudioClip _maleeAttackSound; // Sonido que se reproduce al realizar un ataque cuerpo a cuerpo.

    void Start()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void HurtAnimation()
    {
        // Reproduce el sonido de daño si está configurado.
        if (_hurtSound != null)
        {
            _audioSource.PlayOneShot(_hurtSound); // Reproduce el sonido de daño.
        }
        // Hace un parpadeo del sprite del jugador al recibir daño.
        _sprite.color = new Color(1f, 0.5f, 0.5f, 1f); // Cambia el color del sprite a rojo claro.
        Invoke("ResetSpriteColor", 0.1f); // Llama a ResetSpriteColor después de 0.1 segundos.
    }


    public void MaleeAttackAnimation()
    {
        // Reproduce el sonido del ataque cuerpo a cuerpo si está configurado.
        if (_maleeAttackSound != null)
        {
            _audioSource.PlayOneShot(_maleeAttackSound); // Reproduce el sonido del ataque cuerpo a cuerpo.
        }
        _animator.Play("Attack"); 
    }

    private void ResetSpriteColor()
    {
        // Restaura el color original del sprite del jugador.
        _sprite.color = Color.white; // Cambia el color del sprite a blanco.
    }

    public void SetIdleAnimation()
    {
        _animator.Play("Idle"); // Reproduce la animación de idle.
    }

    public void SetRunAnimation()
    {
        _animator.Play("Run"); // Reproduce la animación de caminar.
    }
}
