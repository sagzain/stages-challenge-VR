using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
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
        yield return new WaitForSeconds(_timeToDespawn);
        Destroy(gameObject);
    }

    void PlayDeathHeadshot()
    {
        _animator.SetTrigger("Headshot");
    }

    void PlayDeathBodyshot()
    {
        _animator.SetTrigger("Bodyshot");
    }
}
