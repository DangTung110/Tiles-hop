using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuObj, optionObj, rankObj;

    void Start()
    {
        MenuOn();
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
        Game.LEVEL_GAME = lv;
    }
    private void SetStatusMenu(GameObject objOn, GameObject objOff1, GameObject objOff2)
    {
        objOff1.SetActive(false);
        objOff2.SetActive(false);
        objOn.SetActive(true);
    }
}
