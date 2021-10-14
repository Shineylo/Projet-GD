using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class FightSceneManager : GeoRpgSceneManager
{
    [SerializeField] private Text pvPlayerText;
    [SerializeField] private Text pvEnemyText;
    [SerializeField] private GameObject staminaPlayerBar;
    [SerializeField] private GameObject hpPlayerBar;
    [SerializeField] private GameObject staminaEnemyBar;
    [SerializeField] private GameObject hpEnemyBar;

    private void Awake()
    {
        Assert.IsNotNull(pvPlayerText);
        Assert.IsNotNull(pvEnemyText);
        Assert.IsNotNull(staminaPlayerBar);
        Assert.IsNotNull(hpPlayerBar);
        Assert.IsNotNull(staminaEnemyBar);
        Assert.IsNotNull(hpEnemyBar);
    }
    public override void enemyTapped(GameObject enemy)
    {
        print("FightSceneManager.enemyTapped activated");
    }

    public override void playerTapped(GameObject player)
    {
        print("CaptureSceneManager.playerTapped activated");
    }

    // Start is called before the first frame update
    void Start()
    {
        hpPlayerBar.GetComponent<Slider>().maxValue = GameManager.Instance.CurrentPlayer.MaxHp;
        //hpEnemyBar.GetComponent<Slider>().maxValue = GameManager.Instance.;
        //debug.PlayerPrefs.GetString("list");
    }

    private void Update()
    {
        updateHP();
    }

    public void escape()
    {
        SceneTransitionManager.Instance.GoToScene(GeoRpgConstant.SCENE_WORLD, new List<GameObject>());
    }

    public void updateHP()
    {
        pvPlayerText.text = GameManager.Instance.CurrentPlayer.Hp.ToString() + " / " + GameManager.Instance.CurrentPlayer.MaxHp;
        hpPlayerBar.GetComponent<Slider>().value = GameManager.Instance.CurrentPlayer.Hp;
        
    }
}
