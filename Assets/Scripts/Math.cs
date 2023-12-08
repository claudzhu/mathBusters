using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Math : MonoBehaviour
{
    public TextMeshProUGUI op1;
    public TextMeshProUGUI op2;
    public TextMeshProUGUI operand;
    public TextMeshProUGUI answer1;
    public TextMeshProUGUI answer2;
    public TextMeshProUGUI answer3;

    private int opt1;
    private int opt2;
    public int correct;
    private int otherFlag;
    private int otherFlag2;
    private TextMeshProUGUI[] shuffleFlag;
    private int[] answers = new int[3];

    void reshuffle(int[] numbers)
    {
        for (int t = 0; t < numbers.Length; t++)
        {
            int tmp = numbers[t];
            int r = Random.Range(t, numbers.Length);
            numbers[t] = numbers[r];
            numbers[r] = tmp;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        opt1 = Random.Range(-50, 51);
        opt2 = Random.Range(-50, 51);
        correct = opt1 + opt2;
        otherFlag = Random.Range(correct - 10, correct + 10);
        if (otherFlag == correct)
        {
            otherFlag += Random.Range(1, 6);
        }
        otherFlag2 = Random.Range(correct - 10, correct + 10);
        if (otherFlag2 == correct)
        {
            otherFlag2 += Random.Range(1, 6);
        }
        shuffleFlag = new TextMeshProUGUI[] { answer1, answer2, answer3 };
        answers = new int[] { otherFlag, correct, otherFlag2 };
        reshuffle(answers);
    }


    // Update is called once per frame
    void Update()
    {
        //string load = "What is" + opt1.ToString() + "+" op2.ToString(); 
        op1.text = opt1.ToString();
        op2.text = opt2.ToString();
        operand.text = "+";
        for (int i = 0; i < 3; i++)
        {
            shuffleFlag[i].text = answers[i].ToString();
        }
        shuffleFlag[0].color = Color.green;
        shuffleFlag[1].color = Color.blue;
        shuffleFlag[2].color = Color.magenta;
    }
}