using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    GameObject car;
    float span = 1.0f;
    float delta = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        car = GameObject.Find("car_0");
    }

    // Update is called once per frame
    void Update()
    {
        if ( car.GetComponent<CarController>().life <= 0)
        {
            return;
        }

        delta += Time.deltaTime;
        if ( this.delta > this.span )
        {
            this.delta = 0;
            GameObject go = Instantiate(arrowPrefab);
            float px = Random.Range(-9, 10);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
