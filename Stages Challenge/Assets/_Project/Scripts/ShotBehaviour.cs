using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(AudioSource))]
public class ShotBehaviour : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AudioClip _sound;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private VisualEffect _visualEffect;

    [Header("Settings")]
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private int _timeToDespawn = 5;
    
    private bool _isFired;
    private Rigidbody _rigidbody;
    private AudioSource _audioSource;

    void Awake()
    {
        _isFired = false;
        _visualEffect.Stop();
        _audioSource = GetComponent<AudioSource>();
            
        try{_rigidbody = GetComponent<Rigidbody>();}catch{}
       
    }
    
    void Update()
    {
        if(_isFired) 
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
        }
    }

    public void Fire()
    {
        transform.SetParent(null);
        if(_bullet) _bullet.SetActive(false);
        if(_sound) _audioSource.PlayOneShot(_sound);
        _visualEffect.Play();
        _isFired = true;
        if(_rigidbody) _rigidbody.isKinematic = false;
        
        StartCoroutine(Despawn());
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(_timeToDespawn);
        Destroy(gameObject);
    }
    
    private void OnCollisionEnter(Collision other) 
    {
        GameObject go = other.collider.gameObject;
        Enemy enemy = go.GetComponentInParent<Enemy>();

        if(go.layer == 9 | go.layer == 10)
        {
            enemy.Death(go.layer);
            Destroy(gameObject);
        }
    }
}

