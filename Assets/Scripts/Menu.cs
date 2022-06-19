using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartButton_OnClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}