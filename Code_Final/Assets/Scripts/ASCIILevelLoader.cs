using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //Variables 
    public float xoffset;
    public float yoffset;

    public GameObject player;
    public GameObject wall;
    public GameObject obstacle;
    public GameObject goal;

    public GameObject currentPlayer;

    Vector2 startPos;

    public string fileName;

    public int currentLevel = 0;

    public GameObject level;

    public int CurrentLevel
    { 
        get { return currentLevel; }
        set
        {
            currentLevel = value;
            LoadLevel();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadLevel();
    }

    void LoadLevel()
    {
        Destroy(level);

        level = new GameObject("Level");

        string current_file_path = Application.dataPath + "/Resources/" + fileName.Replace("Num", currentLevel + "");

        string[] fileLines = File.ReadAllLines(current_file_path);

        for (int y = 0; y < fileLines.Length; y++)
        {
            string lineText = fileLines[y];

            char[] characters = lineText.ToCharArray();

            for (int x = 0; x < characters.Length; x++)
            {
                char c = characters[x];

                GameObject newObject;

                switch (c)
                {
                    case 'p':
                        newObject = Instantiate<GameObject>(player);
                        if (currentPlayer = null)
                            currentPlayer = newObject;

                        startPos = new Vector2(x + xoffset, y - y + yoffset);
                        break;

                    case 'w':
                        newObject = Instantiate<GameObject>(wall);
                        break;

                    case '*':
                        newObject = Instantiate<GameObject>(obstacle);
                        break;

                    case '&':
                        newObject = Instantiate<GameObject>(goal);
                        break;

                    default:
                        newObject = null; 
                        break;

                }

                if (newObject != null)
                {
                    if (!newObject.name.Contains("Player"))
                    {
                        newObject.transform.parent = level.transform;
                    }

                    newObject.transform.position = new Vector3(x + xoffset, -y + yoffset, 0);
                }
            }
        }
    }
}
