using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSceneManager : GeoRpgSceneManager
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void playerTapped(GameObject player)
    {
    }

    public override void enemyTapped(GameObject enemy)
    {
        List<GameObject> list = new List<GameObject>();
        list.Add(enemy);
        //GameManager.Instance.CurrentPlayer.AddEnemy(enemy);
        Debug.Log(enemy);
        SceneTransitionManager.Instance.GoToScene(GeoRpgConstant.SCENE_FIGHT, list);
    }
}
 