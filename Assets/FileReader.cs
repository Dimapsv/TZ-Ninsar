using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileReader : MonoBehaviour
{
    
    public List<string> _textLines = new List<string>();
    public char[,] _data = new char[3,3];
    public int x = 0;
    public int y = 0;

    void ReadTextFile(string _filePath)
    {
        StreamReader _inpStm = new StreamReader(_filePath);

        while (!_inpStm.EndOfStream)
        {
            string _inpLn = _inpStm.ReadLine();
            _textLines.Add(_inpLn);
            
        }
        _inpStm.Close();
    }

    public void Start()
    {
        string readFromFilePath = Application.dataPath + "/" + "file" + ".txt";
        ReadTextFile(readFromFilePath);
        x = Random.Range(0, 8);
        y = Random.Range(0, 9);
        Calculate();
        

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            x++;
            Calculate();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            x--;
            Calculate();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            y--;
            Calculate();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            y++;
            Calculate();
        }



    }

    public void Calculate()
    {
        
        Debug.Log("x: " + x);
        Debug.Log("y: " + y);
        Debug.Log("stroke: " + _textLines[x]);

        Debug.Log(_textLines[x].Length);


        int currentIndexX = x;
        int currentIndexY = y;
        int countY = 0;
        int countX = 0;

        for (int i = 0; i < 3; i++)
        {
            if (currentIndexX >= _textLines.Count)
            {
                currentIndexX = 0;
            }
            
            for (int j = 0; j < 3; j++)
            {
                
                if (currentIndexY >= _textLines[currentIndexX].Length)
                {
                    currentIndexY = 0;
                }

                _data[i, j] = _textLines[currentIndexX][currentIndexY];
                countY++;
                currentIndexY++;

                if (countY == 3)
                {
                    countY = 0;
                    currentIndexY = y;

                }

            }

            countX++;
            currentIndexX++;
        }


        for (int i = 0; i < _data.GetLength(0); i++)
        {
            for (int j = 0; j < _data.GetLength(1); j++)
            {
                Debug.Log("Ёлемент[" + i + "," + j + "]: " + _data[i, j]);
            }
        }

    }

    
}
