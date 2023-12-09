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
    public GameObject correctFlag;
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
        // Generate random math problem
        opt1 = Random.Range(-50, 51);
        opt2 = Random.Range(-50, 51);
        correct = opt1 + opt2; // initialize correct answer
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
        // Update UI text
        op1.text = opt1.ToString();
        op2.text = opt2.ToString();
        operand.text = "+";
        Color[] colors = { Color.green, Color.blue, Color.magenta };
        for (int i = 0; i < 3; i++)
        {
            shuffleFlag[i].text = answers[i].ToString();
            shuffleFlag[i].color = colors[i];
            // store the correct flag's game object for game logic
            if (answers[i] == correct)
            {
                if (i == 0)
                    correctFlag = GameObject.Find("Green Flag");
                else if (i == 1)
                    correctFlag = GameObject.Find("Blue Flag");
                else
                    correctFlag = GameObject.Find("Pink Flag");
            }
        }
    }
}