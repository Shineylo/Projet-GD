using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Text xpText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text hpText;
    [SerializeField] private GameObject hpBar;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("GUI").SetActive(true);
        if (GameObject.Find("ArmoryUI")!= null)
        {
            GameObject.Find("ArmoryUI").SetActive(false);
        }
    }

    private void Awake()
    {
        Assert.IsNotNull(xpText);
        Assert.IsNotNull(levelText);
        Assert.IsNotNull(hpText);
        Assert.IsNotNull(hpBar);
    }

    private void Update()
    {
        updateLevel();
        updateXP();
        updateHP();
    }

    public void updateLevel()
    {
        levelText.text = "Level : " + GameManager.Instance.CurrentPlayer.Lvl.ToString();
    }

    public void updateXP()
    {
        xpText.text = "XP : " + GameManager.Instance.CurrentPlayer.Xp + " / " + GameManager.Instance.CurrentPlayer.RequiredXp;
    }

    public void updateHP()
    {
        hpText.text = GameManager.Instance.CurrentPlayer.Hp.ToString();
        hpBar.GetComponent<Slider>().value = GameManager.Instance.CurrentPlayer.Hp;
        hpBar.GetComponent<Slider>().maxValue = GameManager.Instance.CurrentPlayer.MaxHp;
    }
}
