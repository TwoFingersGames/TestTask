using UnityEngine.UI;

public class Info : Game
{
    public Text[] texts;
    private void Awake()
    {
        app.ui.info = gameObject.GetComponent<Info>();
        texts = gameObject.GetComponentsInChildren<Text>();
    }
}
