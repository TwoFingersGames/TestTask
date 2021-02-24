public class Menu : Game
{
    private void Awake()
    {
        app.ui.menu = gameObject.GetComponent<Menu>();
    }
}
