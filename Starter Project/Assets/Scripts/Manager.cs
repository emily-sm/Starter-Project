using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    public SpriteRenderer[] animals; 

    private int animalSelect;

    public Text condition;

    public float stayLit; 
    private float stayLitCounter; 

    public float waitTime;
    private float waitCounter;
    private bool beLit;
    private bool beDark; 

    public List<int> activeSequence;
    private int position;

    private bool gameActive;
    private int inputSequence; 

    public AudioSource correct;
    public AudioSource incorrect;

    public AudioSource winner;

    private DelayedState bgMusic;

    // Start is called before the first frame update
    void Start()
    {
        bgMusic = FindObjectOfType<DelayedState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(beLit)
        {
            stayLitCounter -= Time.deltaTime;

            if(stayLitCounter < 0)
                {
                    animals[activeSequence[position]].color = new Color(animals[activeSequence[position]].color.r, animals[activeSequence[position]].color.g, animals[activeSequence[position]].color.b, 1f);
                    beLit = false;

                    beDark = true;
                    waitCounter = waitTime;

                    position++;

                    condition.text = "";
                }
        }
    if(beDark)
        {
            waitCounter -= Time.deltaTime;

            if(position >= activeSequence.Count)
            {
                beDark = false;
                gameActive = true;
            }
            
            else 
            {
                if (waitCounter < 0)
                {
                    stayLitCounter = stayLit;
                    beLit = true; 
                    beDark = false;

                    animals[activeSequence[position]].color = new Color(animals[activeSequence[position]].color.r, animals[activeSequence[position]].color.g, animals[activeSequence[position]].color.b, 0.5f);
                }
            }
        }
    }
    public void StartGame()
    {
        activeSequence.Clear();
       
        position = 0;
        inputSequence = 0;
        
        animalSelect = Random.Range(0, 4);

        activeSequence.Add(animalSelect);

        stayLitCounter = stayLit;
        beLit = true; 

        animals[activeSequence[position]].color = new Color(animals[activeSequence[position]].color.r, animals[activeSequence[position]].color.g, animals[activeSequence[position]].color.b, 0.5f);
    }

    public void AnimalClicked(int whichAnimal)
    {
        if(gameActive)
        {
        
            if(activeSequence[inputSequence] == whichAnimal)
            {

                correct.Play();

                inputSequence++;

                if(inputSequence >= activeSequence.Count)
                {
                     position = 0;
                     inputSequence = 0;
                    
                     animalSelect = Random.Range(0, 4);

                     activeSequence.Add(animalSelect);

                     stayLitCounter = stayLit;
                     beLit = true; 

                     animals[activeSequence[position]].color = new Color(animals[activeSequence[position]].color.r, animals[activeSequence[position]].color.g, animals[activeSequence[position]].color.b, 0.5f);
                     gameActive = false;
                        
                
                }
                    if(inputSequence >= 4)
                        {
                            condition.text = "You win!";
                            gameActive = false;
                            bgMusic.stopMusic();
                            winner.Play();

                        }
            }

         else
            {
                incorrect.Play();
                condition.text = "You lose!";
                gameActive = false;
            }
        }
    }
}