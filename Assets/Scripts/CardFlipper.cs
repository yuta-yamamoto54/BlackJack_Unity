using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlipper : MonoBehaviour
{
    //クラスの参照
    SpriteRenderer spriteRenderer;
    CardModel model;

    public AnimationCurve scaleCurve;
    public float duration = 0.5f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    //SpriteRenderの取得
        model = GetComponent<CardModel>();                  //CardModel.csの取得
    }
    public void FlipCard(Sprite startImage, Sprite endImage, int cardIndex)
    {
        //http://developer.wonderpla.net/entry/blog/engineer/Unity_Co-routine/
        StopCoroutine(Flip(startImage, endImage, cardIndex)); //現在動いてるコルーチンを停止
        StartCoroutine(Flip(startImage, endImage, cardIndex)); //新たにコルーチンを開始
    }

    IEnumerator Flip(Sprite startImage, Sprite endImage, int cardIndex)
    {
        //SpriteRenderでスプライトの最初のイメージ
        spriteRenderer.sprite = startImage;

        float time = 0f;

        while (time <= 1f)
        {
            //時間に対するAnimationCurveグラフでの値を代入(1~0)
            float scale = scaleCurve.Evaluate(time);
            //time=time+(PCの単位時間/duration) https://yumineko.com/time-deltatime/
            time += Time.deltaTime / duration;

            //localScaleというVector3の宣言と現在のtransformlocalScaleの値の代入。
            Vector3 localScale = transform.localScale;
            //localScaleのx成分だけ上で定義したscaleを代入する。
            localScale.x = scale;
            transform.localScale = localScale;

            if (time >= 0.5f)
            {
                spriteRenderer.sprite = endImage;
            }

            yield return new WaitForFixedUpdate(); //コルーチンの機能で一定間隔待って次のwhile処理に移る
        }
        if (cardIndex == -1) 
        {
            model.ToggleFace(false);
        }
        else
        {
            model.cardIndex = cardIndex;
            model.ToggleFace(true);
        }
    }
}
