using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header ("Backgrounds")]
    [SerializeField] private GameObject[] backgrounds;

    [SerializeField] private Material roadMat;

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
}
