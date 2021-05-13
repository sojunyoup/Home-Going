using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    //Stop UI
    [Header("Stop UI")]
    public Image Stop;
    bool isStop = false;
    [Space(10f)]
    public Image Sound;
    public Sprite SoundOn;
    public Sprite SoundOff;
    bool isSound = true;
    [Space(10f)]
    public Image SoundE;
    public Sprite SoundEOn;
    public Sprite SoundEOff;
    bool isSoundE = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //일시정지 ui
    public void OnClickSound()
    {
        isSound = !isSound;
        if (isSound) Sound.sprite = SoundOn;
        else Sound.sprite = SoundOff;
    }
    public void OnClickSoundEffect()
    {
        isSoundE = !isSoundE;
        if (isSoundE) SoundE.sprite = SoundEOn;
        else SoundE.sprite = SoundEOff;
    }
    public void OnClickStop()
    {
        isStop = !isStop;
        Stop.gameObject.SetActive(isStop);
    }
    public void OnClickShop()
    {
        SceneManager.LoadScene("2. Shop");
    }
}
