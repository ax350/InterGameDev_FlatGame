using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject Player;
    public Button StartButton;
    public GameObject StartText;
    public GameObject HintText;

    public GameObject MikuText;
    public GameObject ObjectText;
    //I acutally will need raycast or collision for this...might as well not use this
    Boolean startflag = false;
    public Boolean talkflag = false;
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartButton.onClick.AddListener(LoadTheGame);
            if (Input.GetKey(KeyCode.Space))
            {
                LoadTheGame();
            }
        }
       else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            MainCamera.transform.position = new Vector3(Player.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
        }
       else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Player.GetComponent<PlayerController>().enabled = false;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Application.Quit();
            }
        }
        if (!startflag)
        {
            Player.GetComponent<PlayerController>().enabled = false;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                startflag = true;
            }
        }
        else
        {
            Player.GetComponent<PlayerController>().enabled = true;
            StartText.GetComponent<TextMeshProUGUI>().SetText("");
            HintText.GetComponent<TextMeshProUGUI>().SetText("When encounter a fellow object, press 'Space' to talk");

            if (counter >= 12)
            {
                Player.GetComponent<Transform>().position = new Vector3(0.11f, -1.21f, 0);
                Player.GetComponent<PlayerController>().enabled = false;
                HintText.GetComponent<TextMeshProUGUI>().SetText("");
                MikuText.GetComponent<TextMeshProUGUI>().SetText("I hear the door openning, he's back!");
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene(2);
                }
            }

            if (!talkflag)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    talkflag = true;
                }
            }
            else
            {
                Player.GetComponent<PlayerController>().enabled = false;
                switch (counter)
                {
                    case 0:
                        MikuText.GetComponent<TextMeshProUGUI>().SetText("Hi, have you seen him going anywhere?");
                        ObjectText.GetComponent<TextMeshProUGUI>().SetText("No, I' just chilling around");
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            counter++;
                        }
                        break;
                    case 1:
                        MikuText.GetComponent<TextMeshProUGUI>().SetText("Ok, thank you anyway.");
                        ObjectText.GetComponent<TextMeshProUGUI>().SetText("");
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            counter++;
                            MikuText.GetComponent<TextMeshProUGUI>().SetText("");
                            Player.GetComponent<PlayerController>().enabled = true;
                            talkflag = false;
                            //yeah..I should've linked the talkflag with the Player...enabled, keep this in mind while working on bigger projects next time
                        }
                        break;
                    case 2:
                        /*
                        MikuText.GetComponent<TextMeshProUGUI>().SetText("");
                        ObjectText.GetComponent<TextMeshProUGUI>().SetText(""); 
                        */
                        MikuText.GetComponent<TextMeshProUGUI>().SetText("Hello, do you know where did he go?");
                        ObjectText.GetComponent<TextMeshProUGUI>().SetText("Hmm, he just dropped me here after he made the tea.");
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            counter++;
                        }
                        break;
                    case 3:
                        MikuText.GetComponent<TextMeshProUGUI>().SetText("Ok, take care.");
                        ObjectText.GetComponent<TextMeshProUGUI>().SetText("");
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            counter++;
                            MikuText.GetComponent<TextMeshProUGUI>().SetText("");
                            Player.GetComponent<PlayerController>().enabled = true;
                            talkflag = false;
                        }
                        break;
                    case 4:
                        MikuText.GetComponent<TextMeshProUGUI>().SetText("Pardon me, do you know where he is?");
                        ObjectText.GetComponent<TextMeshProUGUI>().SetText("Don't know, it's been 3 days since he left me here");
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            counter++;
                        }
                        break;
                    case 5:
                        MikuText.GetComponent<TextMeshProUGUI>().SetText("I'm sorry. I'm sure he'll remember you.");
                        ObjectText.GetComponent<TextMeshProUGUI>().SetText("");
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            counter++;
                            MikuText.GetComponent<TextMeshProUGUI>().SetText("");
                            Player.GetComponent<PlayerController>().enabled = true;
                            talkflag = false;
                        }
                        break;
                    case 6:
                        MikuText.GetComponent<TextMeshProUGUI>().SetText("Excuse me, has he told you where he went?");
                        ObjectText.GetComponent<TextMeshProUGUI>().SetText("Sorry, he didn't. He forgot to bring me with him.");
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            counter++;
                        }
                        break;
                    case 7:
                        MikuText.GetComponent<TextMeshProUGUI>().SetText("I'm pretty sure he will pick you up during the evening workout.");
                        ObjectText.GetComponent<TextMeshProUGUI>().SetText("");
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            counter++;
                            MikuText.GetComponent<TextMeshProUGUI>().SetText("");
                            Player.GetComponent<PlayerController>().enabled = true;
                            talkflag = false;
                        }
                        break;
                    case 8:
                        MikuText.GetComponent<TextMeshProUGUI>().SetText("Sorry to bother you, did you saw which direction he went?");
                        ObjectText.GetComponent<TextMeshProUGUI>().SetText("Sorry, I'm too short to see through that window.");
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            counter++;
                        }
                        break;
                    case 9:
                        MikuText.GetComponent<TextMeshProUGUI>().SetText("He'll put you back up once he's back.");
                        ObjectText.GetComponent<TextMeshProUGUI>().SetText("");
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            counter++;
                            MikuText.GetComponent<TextMeshProUGUI>().SetText("");
                            Player.GetComponent<PlayerController>().enabled = true;
                            talkflag = false;
                        }
                        break;
                    case 10:
                        MikuText.GetComponent<TextMeshProUGUI>().SetText("Hi...");
                        ObjectText.GetComponent<TextMeshProUGUI>().SetText("You're looking for him? He's out buying new pencils.");
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            counter++;
                        }
                        break;
                    case 11:
                        MikuText.GetComponent<TextMeshProUGUI>().SetText("Then he'll be back in no time. Thank you!");
                        ObjectText.GetComponent<TextMeshProUGUI>().SetText("");
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            counter++;
                            MikuText.GetComponent<TextMeshProUGUI>().SetText("");
                            Player.GetComponent<PlayerController>().enabled = true;
                            talkflag = false;
                        }
                        break;
                }
            }
        }
    }
    void LoadTheGame()
    {
        SceneManager.LoadScene(1);
    }
}
