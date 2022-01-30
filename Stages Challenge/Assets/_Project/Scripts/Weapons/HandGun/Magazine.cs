using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Magazine : MonoBehaviour
{
    [Range(0,6)]
    public int bullets;
    [Range(2,10)]
    [SerializeField] private int _timeToDespawn;

    public void DespawnMagazine()
    {
        StartCoroutine(Despawn());
    }
 
    IEnumerator Despawn()
    {
        //Código DOTween para hacer animación de salida
        Sequence tweenSequence = DOTween.Sequence();
        tweenSequence.Append(transform.DOScale(Vector3.zero, _timeToDespawn));
        
        yield return tweenSequence.Play().WaitForCompletion();

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.gameObject.name == "Floor")
        {
            transform.SetParent(null);
            StartCoroutine(Despawn());
        }
    }
}
