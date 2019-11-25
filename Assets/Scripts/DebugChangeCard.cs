using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugChangeCard : MonoBehaviour
{
    //CardModelクラスの参照
    CardModel cardModel;
    int cardIndex = 0;

    public GameObject card;

    void Awake()
    {
        //cardにアタッチされているCardModelを取得
        cardModel = card.GetComponent<CardModel>();
    }

    private void OnGUI()
    {
        //Hit meと書かれているボタンを作って押されたら実行
        if (GUI.Button(new Rect(10, 10, 100, 20),"Hit me!!"))
        {
            if (cardIndex >= cardModel.faces.Length)
            {
                cardIndex = 0;
                cardModel.ToggleFace(false);
            }
            else
            {
                cardModel.cardIndex = cardIndex;
                cardModel.ToggleFace(true);
            }

            cardIndex++;

        }
    }
}
