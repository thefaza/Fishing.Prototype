using System.Collections;
using System.Collections.Generic;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField nameField;
    public GameObject validationTxt;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (validationTxt.activeInHierarchy)
        {
            validationTxt.transform.Rotate(Time.deltaTime * new Vector3(0, 0, 100));
        }

    }
    public void PlayGame()
    {
        var name = nameField.text;
        if (string.IsNullOrWhiteSpace(name))
        {
            return;
        }
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
