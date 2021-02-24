using UnityEngine.UI;

public class Rating : Game
{
    public Text[] texts;
    private void Awake()
    {
        app.ui.rating = gameObject.GetComponent<Rating>();
        texts = gameObject.GetComponentsInChildren<Text>();
    }
}
