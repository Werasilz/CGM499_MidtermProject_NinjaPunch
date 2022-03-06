using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour
{
    public IObjectPool<Enemy> Pool { get; set; }

    public float _currentHealth;
    public GameObject target;

    private PlayerController _playerController;
    private Animator animator;

    public bool isDead { get; private set; }
    private float maxHealth = 1f;
    private bool isArrive;

    private void Start()
    {
        _currentHealth = maxHealth;
        target = GameObject.FindGameObjectWithTag("EnemyTarget");
        animator = GetComponent<Animator>();
        _playerController = (PlayerController)FindObjectOfType(typeof(PlayerController));
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        ResetEnemy();
    }

    private void Update()
    {
        if (!isDead && _currentHealth > 0f)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 2.5f)
            {
                Vector3 direction = target.transform.position - transform.position;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 5 * Time.deltaTime);
                transform.Translate(0, 0, Time.deltaTime * 5f);
            }
            else
            {
                if (!isArrive)
                {
                    isArrive = true;
                    animator.SetTrigger("Idle");

                    if (GameManager.Instance.playerHealth > 0)
                    {
                        Invoke(nameof(Attack), 0.5f);
                    }
                }
            }
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Punch");
        _playerController.HurtPlayer();
    }

    private void ResetEnemy()
    {
        _currentHealth = maxHealth;
        isDead = false;
        isArrive = false;
        GetComponent<Animator>().enabled = true;
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;

        if (_currentHealth <= 0f)
        {
            _currentHealth = 0;
            isDead = true;
            CancelInvoke();
            GameManager.Instance.currentEnemyAmount -= 1;
            GetComponent<Animator>().enabled = false;
            StartCoroutine(ReturnToPool());
        }
    }

    IEnumerator ReturnToPool()
    {
        yield return new WaitForSeconds(3);
        PoolRelease();
    }

    public void PoolRelease()
    {
        Pool.Release(this);
    }
}
