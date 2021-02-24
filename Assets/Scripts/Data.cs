using UnityEngine;

public class Data : Game
{
    [Header("INFO:")]
    public float timer;
    public float progress;
    public bool stopProgress;
    public float power;
    public int count;
    public int id;
    [Header("MOVE")]
    public float minForce;
    public float maxForce;
    [Header("TOUCH")]
    public float correctionAngle;
    public float deadZone;
    [Header("TIMER")]
    public bool start;
    public bool finish;
    [Header("PROGRESS")]
    public Transform[] dots;
    [Header("COMPONENTS:")]
    public Rigidbody carRb;
    public Transform[] arrowTr;
    public Vector3 respawnPosition;
    public Quaternion respawnRotation;
    public Vector3 respawnVelocity = new Vector3(0f, 0f, 0f);


    private void Awake()
    {
        app.data = gameObject.GetComponent<Data>();
    }
}
