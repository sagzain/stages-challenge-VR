using System.Collections;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour, ISpawnable
{
    [SerializeField] private int _points;
    [Range(2,10)]
    [SerializeField] private int _timeToDespawn;

    protected bool _isDead;
    protected Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _isDead = false;
    }

    public void Death(int layer)
    {
        switch(layer)
        {
            case 9:
                PlayDeathBodyshot();
            break;
            case 10:
                PlayDeathHeadshot();
            break;
            default:
            break;
        }

        _isDead = true;
        StartCoroutine(Despawn());
    }

    IEnumerator Despawn()
    {
        //Código DOTween para hacer animación de salida
        Sequence tweenSequence = DOTween.Sequence();
        tweenSequence.Append(transform.DOScale(Vector3.zero, _timeToDespawn));
        
        yield return tweenSequence.Play().WaitForCompletion();

        PoolManager.Instance.Despawn(this.gameObject);
    }

    void PlayDeathHeadshot()
    {
        _animator.SetTrigger("Headshot");
    }

    void PlayDeathBodyshot()
    {
        _animator.SetTrigger("Bodyshot");
    }

    // Implementations of the methods from ISpawneable

    public void OnSpawn()
    {
        //Codigo DOTween para hacer animación de entrada
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 1f).OnComplete(() => transform.localScale = Vector3.one);
    }

    public void OnDespawn()
    {
        //  Manda el evento para sumar puntos
    }
}
