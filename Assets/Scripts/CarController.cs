using UnityEngine;

public class CarController : MonoBehaviour
{
    float speed = 0f;
    Vector2 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButtonDown(0))
        {
            this.startPos = Input.mousePosition;
        }
        else if ( Input.GetMouseButtonUp(0)) 
        {
            Vector2 endPos = Input.mousePosition;
            float swipeLenght = endPos.x - startPos.x;

            this.speed = swipeLenght / 2000.0f;
        }

        transform.Translate(this.speed, 0, 0);
        this.speed *= 0.98f;
    }
}


