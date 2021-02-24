public class UI : Game
{
    public Info info;
    public Menu menu;
    public FinalMenu finalMenu;
    public MainMenu mainMenu;
    public Rating rating;

    private void Awake()
    {
        app.ui = gameObject.GetComponent<UI>();
    }
    private void Start()
    {
        app.data.finish=true;
        if (app.saveSerial.restart)
        {
            CloseAll();
            app.data.finish = false;
        }
        else
        {
            RatingClose();
            menu.gameObject.SetActive(false);
            FinalMenuClose();
        }
    }
    
    public void MainMenuOpen()
    {
        app.data.finish = true;
        CloseAll();
        mainMenu.gameObject.SetActive(true);
        
    }
    public void MainMenuClose()
    {
        mainMenu.gameObject.SetActive(false);
        app.data.finish = false;
    }
    public void MenuOpen()
    {
        app.data.finish = true;
        CloseAll();
        menu.gameObject.SetActive(true);
        
    }
    public void MenuClose()
    {
        menu.gameObject.SetActive(false);
        app.data.finish=false;
    }
    public void FinalMenuOpen()
    {
        app.data.finish = true;
        finalMenu.gameObject.SetActive(true);
        app.ui.finalMenu.texts[1].text = "Результат:\n" + app.data.timer.ToString("F4") + "\n" + app.data.count + " ходов";
        
    }
    public void FinalMenuClose()
    {
        finalMenu.gameObject.SetActive(false);
    }
    public void RatingOpen()
    {
        rating.gameObject.SetActive(true);
    }
    public void RatingClose()
    {
        rating.gameObject.SetActive(false);
    }
    public void CloseAll()
    {
        mainMenu.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        finalMenu.gameObject.SetActive(false);
        rating.gameObject.SetActive(false);
    }


}
