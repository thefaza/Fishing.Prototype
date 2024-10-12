using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;


#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : ExtendedBehavior
{
    // Start is called before the first frame update
    public TMP_InputField nameField;

    public GameObject validationTxt;
    public GameObject player;
    public GameObject menu;
    private CameraController cameraController;
    public bool isGameActive;
    void Start()
    {
        cameraController = FindObjectInScene<CameraController>("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (validationTxt.activeInHierarchy)
        {
            validationTxt.transform.Rotate(Time.deltaTime * new Vector3(0, 0, 100));
        }

    }
    public void GameOver()
    {
        isGameActive = false;
        menu.SetActive(true);
    }

    public void PlayGame()
    {
        var name = nameField.text;
        if (string.IsNullOrWhiteSpace(name))
        {
            validationTxt.SetActive(true);
            return;
        }
        menu.SetActive(false);
        isGameActive = true;
        cameraController.SetCamera(0);
        player.SetActive(true);
    }

}
