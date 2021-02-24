using UnityEngine.UI;

public class FinalMenu : Game
{
    public Text[] texts;
    private void Awake()
    {
        app.ui.finalMenu = gameObject.GetComponent<FinalMenu>();
        texts = gameObject.GetComponentsInChildren<Text>();
    }
}
