using UnityEngine.SceneManagement;

public class Scenes : Game
{
    private void Awake()
    {
        app.scenes = gameObject.GetComponent<Scenes>();
    }
    public void Reload()
    {
        app.saveSerial.restart = true;
        app.saveSerial.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
    public void CloseGame()
    {
        app.saveSerial.restart = false;
        app.saveSerial.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
