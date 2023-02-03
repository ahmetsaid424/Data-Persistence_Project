using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class StartManager : MonoBehaviour
{
    public static StartManager instance;

    public GameObject letsPlayButtonParent;

    public TMP_InputField inputField;
    public static string userName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        inputField.onValueChanged.AddListener(delegate { UserInput(inputField.text); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UserInput(string input) {
        GameObject letsPlayButton = letsPlayButtonParent.transform.GetChild(0).gameObject;
        if (input.Length > 0)
        {
           userName = input;
            letsPlayButton.SetActive(true);
        }
        else
        {
            letsPlayButton.SetActive(false);
        }

    }

    public void StartGame()
    {
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }

    public void SaveHighscore(int score)
    {
        SaveData data = new();
        data.userName = userName;
        data.highestScore = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    [System.Serializable]

    public class  SaveData
    {
        public string userName;
        public int highestScore;
    }
}
