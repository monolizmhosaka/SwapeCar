using TMPro;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    GameObject car;
    GameObject lifeText;

    bool isGameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.car = GameObject.Find("car_0");
        this.lifeText = GameObject.Find("lifeText");
    }

    // Update is called once per frame
    void Update()
    {
        CarController carController = this.car.GetComponent<CarController>();

        if (carController.life > 0 )
        { 
            string lifeString = "";
            for (int i = 0; i < carController.life; i++)
            {
                lifeString += "■";
            }
            this.lifeText.GetComponent<TextMeshProUGUI>().text = lifeString;
        }
        else {
            if ( !isGameOver )
            {
                GetComponent<AudioSource>().Play();
                isGameOver = true;
            }
            this.lifeText.GetComponent<TextMeshProUGUI>().text = "GameOver";
        }
    }
}
