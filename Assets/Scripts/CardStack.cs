using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStack : MonoBehaviour
{
    private List<int> cards;
    //デッキフラグがtrueなら５２枚のトランプを用意
    public bool isGameDeck;

    //デッキが存在するならば
    public bool HasCards
    {
        get { return cards != null && cards.Count > 0; }
    }

    public event CardRemovedEventHandler CardRemoved;

    public int CardCount
    {
        get
        {
            if (cards == null)
            {
                return 0;
            }
            else
            {
                return cards.Count;
            }
        }
    }


    //privateのカードにアクセス
    public IEnumerable<int> GetCards()
    {
        foreach (int i in cards)
        {
            //foreachにreturnを使ってひとつづつ返す
            yield return i;
        }
    }

    //カードをポップする
    public int Pop()
    {
        int temp = cards[0];
        cards.RemoveAt(0);

        if (CardRemoved != null)
        {
            CardRemoved(this, new CardRemovedEventArgs(temp));
        }
        return temp;
    }

    //カードをプッシュする
    public void Push(int card)
    {
        cards.Add(card);
    }

    public void CreateDeck()
    {
        cards.Clear();

        for (int i = 0; i < 52; i++)
        {
            cards.Add(i);
        }
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1); //kは0~nのランダムな数字
            int temp = cards[k]; //k番目のカードをtempに代入する
            cards[k] = cards[n]; //k番目のインデックスにn番目のインデックスを代入
            cards[n] = temp;     //n番目のインデックスにtempを代入
        }
    }

    void Start()
    {
        cards = new List<int>();
        if (isGameDeck)
        {
            CreateDeck();
        }
    }
}
