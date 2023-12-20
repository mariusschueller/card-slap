using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardControl : MonoBehaviour
{
    //public GameObject card;
    //private bool stopLoop;
    public GameObject spade;
    public GameObject club;
    public GameObject diamond;
    public GameObject heart;

    public Text cardNumText;

    private int score;
    public Text scoreText;

    private bool guessed;

    private float speed = 1f;
    public Text speedText;

    IEnumerator cardRunner()
    {
        int count = 1;

        card card1 = new card();
        card card2 = new card();
        card card3 = new card();

        while (true)
        {
            card3 = card2;
            card2 = card1;
            card1 = new card();

            setCard(card1);

            /*Debug.Log("Card 1: " + card1.getNum());
            Debug.Log("Card 2: " + card2.getNum());
            Debug.Log("Card 3: " + card3.getNum());*/

            yield return new WaitForSeconds(speed);

            if (guessed)
            {
                if (card1.getNum() == card2.getNum() || card1.getNum() == card3.getNum())
                {
                    /*Debug.Log("card1: " + card1.getNum() + " card2: " + card2.getNum());
                    Debug.Log("card1: " + card1.getNum() + " card3: " + card3.getNum());*/
                    score += 1;
                }
                else
                {
                    score -= 1;
                }

                scoreText.text = "Score: " + score.ToString();
                guessed = false;
            }

            else
            {
                if (count > 2 && (card1.getNum() == card2.getNum() || card1.getNum() == card3.getNum()))
                {
                    score -= 1;
                    scoreText.text = "Score: " + score.ToString();
                }
            }
            count++;
        }
    }

    
    public void guess()
    {
        guessed = true;
    }


    public void setCard(card card1)
    {
        spade.SetActive(false);
        club.SetActive(false);
        heart.SetActive(false);
        diamond.SetActive(false);

        int suit = card1.getSuit();

        if (suit == 1)
        {
            spade.SetActive(true);
            cardNumText.color = Color.black;
        }

        else if (suit == 2)
        {
            club.SetActive(true);
            cardNumText.color = Color.black;
        }

        else if (suit == 3)
        {
            diamond.SetActive(true);
            cardNumText.color = Color.red;
        }

        else
        {
            heart.SetActive(true);
            cardNumText.color = Color.red;
        }

        int cardNum = card1.getNum();

        if (cardNum == 11)
            cardNumText.text = "J";
        else if (cardNum == 12)
            cardNumText.text = "Q";
        else if (cardNum == 13)
            cardNumText.text = "K";
        else if (cardNum == 1)
            cardNumText.text = "A";
        else
            cardNumText.text = cardNum.ToString();
    }

    public void play()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
        guessed = false;
        StartCoroutine("cardRunner");
    }

    public void stop()
    {
        StopCoroutine("cardRunner");
    }

    public void easier()
    {
        speed *= 10;
        speed += 1;
        speed /= 10f;
        speedText.text = "Speed: " + speed.ToString() + "s";
    }

    public void harder()
    {
        if (speed > .1f)
        {
            speed *= 10;
            speed -= 1;
            speed /= 10f;
            speedText.text = "Speed: " + speed.ToString() + "s";
        }
    }
}
