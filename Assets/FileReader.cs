using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileReader : MonoBehaviour
{
    public string _loadedData;

    

    //public List<string> _textLines = new List<string>();
    public string[] _textLines;
    public char[,] _data = new char[3,3];
    public int x = 0;
    public int y = 0;

    public int maxX = 8;
    public int maxY = 9;
    public int minX = 0;
    public int minY = 0;

    //void ReadTextFile(string _filePath)
    //{
    //    StreamReader _inpStm = new StreamReader(_filePath);

    //    while (!_inpStm.EndOfStream)
    //    {
    //        string _inpLn = _inpStm.ReadLine();
    //        _textLines.Add(_inpLn);

    //    }
    //    _inpStm.Close();
    //}

    //void ReadTextFile()
    //{
    //    TextAsset textFile = Resources.Load<TextAsset>("file");

    //    if (textFile != null)
    //    {
    //        _textLines = textFile.text.Split(new string[] {"\r\n", "\n"}, System.StringSplitOptions.RemoveEmptyEntries);

    //        foreach (string line in _textLines)
    //        {
    //            Debug.Log(line);
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogError("File don't exist");
    //    }

    //}

    void ReadTextFile(string _filePath)
    {
        if (File.Exists(_filePath))
        {
            _textLines = File.ReadAllLines(_filePath);
            foreach (string line in _textLines)
            {
                Debug.Log(line);
            }
        }
    }

    public void Start()
    {
        string readFromFilePath = Path.Combine(Application.streamingAssetsPath, "file.txt");
        ReadTextFile(readFromFilePath);
        x = Random.Range(0, 8);
        y = Random.Range(0, 9);
        Calculate();
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            x--;
            if (x < minX)
            {
                x = maxX;
            }
            if (x > maxX)
            {
                x = minX;
            }
            Calculate();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            x++;
            if (x < minX)
            {
                x = maxX;
            }
            if (x > maxX)
            {
                x = minX;
            }
            Calculate();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            y--;
            if (y < minY)
            {
                y = maxY;
            }
            if (y > maxY)
            {
                y = minY;
            }
            
            Calculate();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            y++;
            if (y < minY)
            {
                y = maxY;
            }
            if (y > maxY)
            {
                y = minY;
            } 
            
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
            if (currentIndexX >= _textLines.Length)
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
