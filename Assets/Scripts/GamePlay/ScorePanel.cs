using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private int score = 0;

    private void Start()
    {
        scoreText.text = score.ToString();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == Tag.CUBE_TAG)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }
}
