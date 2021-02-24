using UnityEngine;
public class Logic : Game
{
    private int y;
    Vector3 arrowScale = new Vector3(0.2f, 0f, 1f);
    private Vector2 startTouchPosition;
    private float rotationY;
    private Vector3 carRelativePosition;
    private float wayDistance;
    private float _carWayDistance;
    private float carWayDistance;
    private float carDistance;
    private float power;
    private int screenWidth;
    private void Awake()
    {
        app.logic = gameObject.GetComponent<Logic>();
    }
    private void Start()
    {
        screenWidth = Screen.width;
        WayDistance();
        app.ui.info.texts[3].text = "Выполнено ходов: " + app.data.count;
        app.data.stopProgress = false;
    }
    
    private void Timer()
    {
        if (app.data.start && !app.data.finish)
        {
            app.data.timer += Time.deltaTime;
        }
        app.ui.info.texts[0].text = "Время: " + app.data.timer.ToString("F4");
    }
    private void Rating(float timeValue, int stepCount) 
    {

    }
    private void InfoText()
    {
        app.ui.info.texts[2].text = "Сила натяжения: " + app.data.power.ToString("F0") + "%";
    }
    private void WayDistance()
    {
        for (int i = 1; i < 6; i++)
        {
            float x;
            x = Vector3.Distance(app.data.dots[i].position, app.data.dots[i + 1].position);
            wayDistance += x;
        }
    }
    private void CarWayDistance()
    {
        _carWayDistance = 0;
        if (y < 6)
        {
            for (int i = 7 - y; i > 1; i--)
            {
                float x;
                x = Vector3.Distance(app.data.dots[i - 1].position, app.data.dots[i].position);
                _carWayDistance += x;
            }
        }
        else if (y == 6)
        {
            carWayDistance = carDistance;
        }
    }
    private void CarDistance() 
    {
        carDistance = Vector3.Distance(app.data.carRb.position, app.data.dots[y].position);
        carWayDistance = carDistance + _carWayDistance;
        if (!app.data.stopProgress)
        {
            app.data.progress = 100 - (carWayDistance * 100 / wayDistance);
        }
        if (carDistance < 2f)
        {
            y++;
            if (y >= 6) { y = 6; }
            CarWayDistance();
        }
        app.ui.info.texts[1].text = "Пройдено: " + app.data.progress.ToString("F0") + "%";
    }
    

    private void Touch()
    {
        if (Input.touchCount > 0&&Input.GetTouch(0).position.y<Screen.height-350&&!app.data.finish)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
                app.data.start = true;
                app.data.count++;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 finishTouchPosition;
                float touchDistance;
                Vector2 relativePosition;
                finishTouchPosition = touch.position;
                if (finishTouchPosition.y >= startTouchPosition.y) { finishTouchPosition.y = startTouchPosition.y; }
                relativePosition = finishTouchPosition - startTouchPosition;
                carRelativePosition = app.data.carRb.position + new Vector3(relativePosition.x, 0f, relativePosition.y) - app.data.carRb.position;
                rotationY = Mathf.Atan2(relativePosition.y, relativePosition.x) * Mathf.Rad2Deg;
                app.data.carRb.rotation = Quaternion.Euler(0f, -rotationY - app.data.correctionAngle, 0f);
                touchDistance = Vector2.Distance(startTouchPosition, finishTouchPosition);
                app.data.power = (touchDistance * 100) / (screenWidth / 3);
                if (app.data.power > 100f) { app.data.power = 100f; }
                power = (app.data.power * app.data.maxForce)/ 100;
                arrowScale.y = app.data.power / 110f;
            }

            if(touch.phase == TouchPhase.Ended)
            {
                arrowScale = new Vector3(0.2f, 0f, 1f);
                if (app.data.carRb.velocity == Vector3.zero)
                {
                    app.data.respawnPosition = new Vector3(app.data.carRb.position.x, app.data.carRb.position.y, app.data.carRb.position.z);
                    app.data.respawnRotation = new Quaternion(0f, app.data.carRb.rotation.y, 0f, app.data.carRb.rotation.w);
                    Debug.Log("New respawn(x:" + app.data.respawnPosition.x + ", y:" + app.data.respawnPosition.y + ", z:" + app.data.respawnPosition.z + ")");
                }
                if(app.data.power>app.data.deadZone) 
                {
                    app.data.carRb.AddForce(new Vector3(carRelativePosition.x, carRelativePosition.y, carRelativePosition.z).normalized * (-power-app.data.minForce), ForceMode.Impulse); 
                }
                app.data.power = 0;
                app.ui.info.texts[3].text = "Выполнено ходов: " + app.data.count;
            }
        }
    }
    private void Update()
    {
        Touch();
        app.data.arrowTr[1].localScale = arrowScale;
    }
    private void FixedUpdate()
    {
        Timer();
        InfoText();
        CarDistance();
    }
}

