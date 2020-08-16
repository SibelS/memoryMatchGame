using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour
{
    public AudioSource Theme;
    public AudioSource Effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void PlayTheme()
    {
        Theme.Play();

    }
    public void PlayEffect()
    {
        Effect.Play();

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
