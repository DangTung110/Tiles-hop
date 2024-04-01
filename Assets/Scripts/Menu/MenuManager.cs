using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuObj, optionObj, rankObj;
    public TMP_Text             score1Text, score2Text, score3Text;
    public static MenuManager   instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        MenuOn();
        SetTextRank();
    }
    public void MenuOn()
    {
        SetStatusMenu(menuObj, optionObj, rankObj);
    }
    public void OptionsOn()
    {
        SetStatusMenu(optionObj, menuObj, rankObj);
    }
    public void RankOn()
    {
        SetStatusMenu(rankObj, menuObj, optionObj);
    }
    public void PlayGame(int lv)
    {
        SceneManager.LoadScene(Scene.GAME_SCENE);
        Game.MAP = lv;
    }
    private void SetStatusMenu(GameObject objOn, GameObject objOff1, GameObject objOff2)
    {
        objOff1.SetActive(false);
        objOff2.SetActive(false);
        objOn.SetActive(true);
    }
    private void SetTextRank()
    {
        score1Text.text = Rank.RANK_SCORE1.ToString();
        score2Text.text = Rank.RANK_SCORE2.ToString();
        score3Text.text = Rank.RANK_SCORE3.ToString();
    }
}
