using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button startButton; // Drag your button from the Unity Editor into this slot

    void Start()
    {
        Button start = startButton.GetComponent<Button>();
        start.onClick.AddListener(StartOnClick);
    }

    void StartOnClick()
    {
        SceneManager.LoadScene(1);
    }
}
