using UnityEngine.UI;

public class MainMenu : Game
{
    public Text[] texts;
    private void Awake()
    {
        app.ui.mainMenu = gameObject.GetComponent<MainMenu>();
        texts = gameObject.GetComponentsInChildren<Text>();
    }
}
