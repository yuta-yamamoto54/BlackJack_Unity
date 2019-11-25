using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Deck))]

public class DeckView : MonoBehaviour
{
    Deck deck;

    public Vector3 start;
    public float cardOffset; //カードをずらす幅
    public GameObject cardPrefabs;

    private void Start()
    {
        deck = GetComponent<Deck>();
        ShowCards();
    }

    void ShowCards()
    {
        int cardCount = 0;
        //foreachとyield return で随時カードを生成する
        foreach (int i in deck.GetCards())
        {
            float co = cardOffset * cardCount; //オフセット幅の計算

            //カードプレファブのコピー
            GameObject cardCopy = (GameObject)Instantiate(cardPrefabs);

            Vector3 temp = start + new Vector3(co, 0f);
            cardCopy.transform.position = temp;

            //コピーしたカードプレファブのCardModelクラスを取得
            CardModel cardModel = cardCopy.GetComponent<CardModel>();

            cardModel.cardIndex = i;
            //表表示
            cardModel.ToggleFace(true);

            cardCount++;
        }
        
    }
}
