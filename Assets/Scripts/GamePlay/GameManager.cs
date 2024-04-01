using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header ("Backgrounds")]
    [SerializeField] private GameObject[]   backgrounds;
    [Header("Materials")]
    [SerializeField] private Material       roadMat;
    [Header("Animations")]
    [SerializeField] private Animation fadeAnim;
    [Header("Game Object")]
    [SerializeField] private GameObject buttonStart;
    [SerializeField] private GameObject cube;
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        Time.timeScale = 0f;
    }
    private void Start()
    {
        SetMapGame();
    }
    private void SetMapGame()
    {
        int indexBg = Random.Range(0, backgrounds.Length);
        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (i != indexBg)
                backgrounds[i].gameObject.SetActive(false);
            else
                backgrounds[i].gameObject.SetActive(true);
        }
    }
    public void GameStart()
    {
        Game.IS_START = true;
        Time.timeScale = 1.0f;
        buttonStart.SetActive(false);
        Destroy(cube, 7f);
    }
    public IEnumerator EndGame()
    {
        fadeAnim.Play();
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(Scene.MENU_SCENE);
    }
}
