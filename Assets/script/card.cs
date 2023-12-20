using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card
{
    private int suit;
    private int num;

    public card()
    {
        suit = Random.Range(1,5); 
        num = Random.Range(1,14); 
    }

    public card(int suit, int num)
    {
        this.suit = suit;
        this.num = num;
    }

    public int getSuit()
    {
        return suit;
    }

    public int getNum()
    {
        return num;
    }
}
