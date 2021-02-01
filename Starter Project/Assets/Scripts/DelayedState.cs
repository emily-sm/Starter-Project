using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource backgroundMusic = gameObject.GetComponent<AudioSource>();
        backgroundMusic.PlayDelayed(3);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void stopMusic()
    {
        Destroy(gameObject);
    }
}
