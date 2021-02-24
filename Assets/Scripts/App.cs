using UnityEngine;
public class Game : MonoBehaviour
{
    // Gives access to the application and all instances.
    public App app { get { return GameObject.FindObjectOfType<App>(); } }
}
public class App : MonoBehaviour
{
    
    public SaveSerial saveSerial;
    public Data data;
    public Logic logic;
    public UI ui;
    public Scenes scenes;

    [Header("OBJECTS")]
    public Car car;
    public Way way;
    public void Exit()
    {
        Application.Quit();
    }
}
