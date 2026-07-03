using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject car;
    bool waitDestroyFlag = false;
    float arrowSpeed = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        car = GameObject.Find("car_0");
        arrowSpeed = Random.Range(0.1f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if ( waitDestroyFlag ) { return; }

        transform.Translate(0, -arrowSpeed, 0);

        if ( transform.position.y < -5.0f )
        {
            Destroy(gameObject);
        }

        Vector2 p1 = transform.position;
        Vector2 p2 = car.transform.position;

        // 円の衝突判定
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.4f;
        float r2 = 0.8f;

        if (d < r1 + r2)
        {
            car.GetComponent<CarController>().life--;

            // 1. 画像とスクリプトを止める（見た目上は消えたように見える）
            if (TryGetComponent<SpriteRenderer>(out var sprite)) sprite.enabled = false;
            if (TryGetComponent<Collider2D>(out var col)) col.enabled = false;

            // 2. 音を再生する（オブジェクトがまだ残っているので綺麗に鳴ります）
            GetComponent<AudioSource>().Play();

            // 3. 1.0秒後（音が鳴り終わる頃）にこのオブジェクトを完全に消去する
            Destroy(gameObject, 1.0f);

            waitDestroyFlag = true;
        }
    }
}
