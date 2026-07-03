using UnityEngine;

public class CarController : MonoBehaviour
{
    float speed = 0f;
    public int life = 3;

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
            // マウスの座標をスクリーン座標からワールド座標に変換する
            Vector3 mouseWorldPos = Input.mousePosition;
            mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseWorldPos);

            // マウスの座標と車の座標の差を計算する
            Vector3 v = mouseWorldPos - this.transform.position;
            float sign = Mathf.Sign(v.x);
            this.speed = sign * 0.3f;    //0以上なら1、0未満なら-1を返す

            // 車の向きを変える
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if ( sign >= 0 ) spriteRenderer.flipX = false;
            else spriteRenderer.flipX = true;

            GetComponent<AudioSource>().Play();

        }

        transform.Translate(this.speed, 0, 0);
        this.speed *= 0.98f;
    }

    void OnBecameInvisible()
    {
        // 画面外に出たときの処理
        this.speed *= -1;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = !spriteRenderer.flipX;


    }

}


