using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemyFactory : Singleton<EnemyFactory>
{
    [SerializeField] private Enemy[] availableEnemys;
    [SerializeField] private float waitTime = 180.0f;
    [SerializeField] private int startingEnemy = 5;
    [SerializeField] private int maxEnemy = 10;
    [SerializeField] private float minRange = 5.0f;
    [SerializeField] private float maxRange = 50.0f;

    private List<Enemy> liveEnemys = new List<Enemy>();
    private Enemy selectedEnemy;
    private Player player;

    public List<Enemy> LiveEnemys
    {
        get { return liveEnemys; }
    }

    public Enemy SelectedEnemy
    {
        get { return selectedEnemy; }
    }

    private void Awake()
    {
        Assert.IsNotNull(availableEnemys);
    }
    void Start()
    {
        player = GameManager.Instance.CurrentPlayer;
        Assert.IsNotNull(player);
        for (int i =0; i < startingEnemy; i++)
        {
            InstanciateEnemy();
        }
        StartCoroutine(GenerateEnemys());
    }

    public void EnemyWasSelected(Enemy enemy)
    {
        selectedEnemy = enemy;
    }

    private IEnumerator GenerateEnemys()
    {
        while (liveEnemys.Count < maxEnemy)
        {
            InstanciateEnemy();
            yield return new WaitForSeconds(waitTime);       
        }
    }

    private void InstanciateEnemy()
    {
        int index = Random.Range(0, availableEnemys.Length);
        float x = player.transform.position.x + GenerateRange(); 
        float z = player.transform.position.z + GenerateRange(); 
        float y = 2;
        liveEnemys.Add(Instantiate(availableEnemys[index], new Vector3(x, y, z), Quaternion.identity));
    }

    private float GenerateRange()
    {
        float randomNum = Random.Range(minRange, maxRange);
        bool ispositive = Random.Range(0, 10) < 5;
        return randomNum * (ispositive ? 1 : -1);
    }
}
