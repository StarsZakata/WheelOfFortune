using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    public Text CommonText;
    public Text CurrentText;

    public void InitView(int commonScore) {
        CommonText.text = commonScore.ToString();
        CurrentText.text = "0";
    }

    public void UpdateCurrentView(int score) {
        CurrentText.text = score.ToString();
    }
}
