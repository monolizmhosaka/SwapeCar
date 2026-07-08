using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject itemPrefab;
    GameObject car;

    float span = 5.0f;
    float delta = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        car = GameObject.Find("car_0");
    }

    // Update is called once per frame
    void Update()
    {
        if (car.GetComponent<CarController>().Life <= 0)
        {
            return;
        }

        delta += Time.deltaTime;
        if ( this.delta > this.span )
        {
            this.delta = 0;
            GameObject go = Instantiate(itemPrefab);
            float px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
