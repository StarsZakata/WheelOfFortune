using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class WheelOfFortune : MonoBehaviour
{
    public Data dataGame;

    [Header("Buttons")]
    public Button Spin;
    public Button Exit;
    public Button DeleteSaves;

    [Header("Type")]
    public Wheel Wheel;
    public View View;

    private void Start()
    {
        dataGame = SaveSystem.instance.LoadPlayerScoreWithPlayerPrefs();
        View.InitView(dataGame.CommonCount);
        Wheel.InitWheel();
        Spin.interactable = true;
    }

    private void OnEnable()
    {
        Wheel.WheelStoped += AddScore;
    }
    private void OnDisable()
    {
        Wheel.WheelStoped -= Close;
    }

    private void AddScore(int score) {
        dataGame.CurrentCount += score;
        View.UpdateCurrentView(dataGame.CurrentCount);
        Spin.interactable = true;
    }

    private void Close(int score) {
        Debug.Log("That All");
    }

    // TODO Button Spin
    public void StartSpin()
    {
        Spin.interactable = false;
        Wheel.StartSpinWheele();
    }

    //TODO Button ExitSessiea
    public void ExitGame() {
        SaveSystem.instance.SavePlayerScoreWithPlayerPrefs(dataGame);
        SceneManager.LoadScene("MenuScene");
    }

    //TODO Button DeletePlayerData
    public void DeletPlayerData() {
        PlayerPrefs.DeleteAll();
        dataGame = SaveSystem.instance.LoadPlayerScoreWithPlayerPrefs();
        View.InitView(dataGame.CommonCount);
    }

}