using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

    public static SpawnManager _instance;

    public EnemySpawn[] monsterSpawnArray;

    public EnemySpawn[] bossSpawnArray;

    public List<GameObject> enemyList = new List<GameObject>();

    public AudioClip victoryClip;

    void Awake()
    {
        _instance = this;
    }

	// Use this for initialization
	void Start () {

        StartCoroutine(Spawn());
	}

    IEnumerator Spawn()
    {
        foreach (EnemySpawn s in monsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }

        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }

        foreach (EnemySpawn s in monsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }

        yield return new WaitForSeconds(0.5f);

        foreach (EnemySpawn s in monsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }

        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }

        foreach (EnemySpawn s in monsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }

        yield return new WaitForSeconds(0.5f);

        foreach (EnemySpawn s in monsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }

        yield return new WaitForSeconds(0.5f);

        foreach (EnemySpawn s in bossSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }

        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);

        }

        AudioSource.PlayClipAtPoint(victoryClip, transform.position, 1f);

    }

}
