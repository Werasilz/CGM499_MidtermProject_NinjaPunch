using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyObjectPool : MonoBehaviour
{
    public int maxPoolSize = 10;
    public int stackDefaultCapacity = 10;
    public GameObject enemyPrefab { get; set; }

    private IObjectPool<Enemy> _pool;

    public IObjectPool<Enemy> Pool
    {
        get
        {
            if (_pool == null)
            {
                _pool = new ObjectPool<Enemy>(CreatedPooledItem,
                                                OnTakeFromPool,
                                                OnReturnedToPool,
                                                OnDestroyPoolObject,
                                                true,
                                                stackDefaultCapacity,
                                                maxPoolSize);
            }

            return _pool;
        }
    }

    private Enemy CreatedPooledItem()
    {
        // GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        // Enemy enemy = go.AddComponent<Enemy>();
        // go.name = "Enemy";
        // enemy.Pool = Pool;

        GameObject go = Instantiate(enemyPrefab);
        Enemy enemy = go.AddComponent<Enemy>();
        go.name = "Enemy";
        enemy.Pool = Pool;

        return enemy;
    }

    private void OnReturnedToPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private void OnTakeFromPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);
    }

    private void OnDestroyPoolObject(Enemy enemy)
    {
        // Call when no more space in pool
        Destroy(enemy.gameObject);
    }

    public void Spawn()
    {
        // for (int i = 0; i < GameManager.Instance.enemyAmount; i++)
        // {
        //     var enemy = Pool.Get();
        //     enemy.transform.position = Random.Range(0, 2) == 0 ? enemy.transform.position + Vector3.right * 5 : enemy.transform.position + Vector3.left * 5;
        // }

        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        int i = 0;
        while (i < GameManager.Instance.enemyAmount && GameManager.Instance.playerHealth > 0)
        {
            yield return new WaitForSeconds(Random.Range(1.5f, 3f));

            i++;
            var enemy = Pool.Get();
            enemy.transform.position = Random.Range(0, 2) == 0 ? GameManager.Instance.spawnPositionLeft.position : GameManager.Instance.spawnPositionRight.position;
            Debug.Log("Spawn Enemy");

            yield return null;
        }

        Debug.Log("Finish Spawn");
    }
}
