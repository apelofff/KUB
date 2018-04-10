using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;


public class MusicStateMachine : MonoBehaviour
{

    private void Start()
    {
        State_Level_1();
        Map1 = true;
    }

    private enum States { s_Level1, s_Level2, s_Level3, s_Level4, s_Level5, s_Level6, s_Level7, s_Level8, s_Level9, s_Level10, s_Level11, s_Level12, s_Level13, s_Level14, s_Level15,
    s_Level16, s_Level17, s_Level18, s_Level19, s_Level20}

    private States myState;

    public PlayerControllers playerControllerScript;

    public static MusicStateMachine instance;

    public SFX[] sfx;


    private bool Map1;
    private bool Map2;
    private bool Map3;
    private bool Map4;
    private bool Map5;
    private bool Map6;
    private bool Map7;
    private bool Map8;
    private bool Map9;
    private bool Map10;
    private bool Map11;
    private bool Map12;
    private bool Map13;
    private bool Map14;
    private bool Map15;
    private bool Map16;
    private bool Map17;
    private bool Map18;
    private bool Map19;
    private bool Map20;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (SFX s in sfx)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.reverbZoneMix = s.reverb;
        }

    }

    public void PlaySFX(string name)
    {
        if (sfx == null)
        {
            Debug.Log("Sound: " + name + " is not found");
            return;
        }
        SFX s = System.Array.Find(sfx, sfx => sfx.name == name);
        if (!s.source.isPlaying)
        {
            s.source.Play();
        }
    }

    private void Update()
    {
        ChangeState();
    }


    void ChangeState()
    {
        print(myState);
        

        if      (myState == States.s_Level1)             { State_Level_1();  }
        else if (myState == States.s_Level2)             { State_Level_2();  } 
        else if (myState == States.s_Level3)             { State_Level_3();  }
        else if (myState == States.s_Level4)             { State_Level_4();  }
        else if (myState == States.s_Level5)             { State_Level_5();  }
        else if (myState == States.s_Level6)             { State_Level_6();  }
        else if (myState == States.s_Level7)             { State_Level_7();  }
        else if (myState == States.s_Level8)             { State_Level_8();  }
        else if (myState == States.s_Level9)             { State_Level_9();  }
        else if (myState == States.s_Level10)            { State_Level_10(); }
        else if (myState == States.s_Level11)            { State_Level_11(); }
        else if (myState == States.s_Level12)            { State_Level_12(); }
        else if (myState == States.s_Level13)            { State_Level_13(); }
        else if (myState == States.s_Level14)            { State_Level_14(); }
        else if (myState == States.s_Level15)            { State_Level_15(); }
        else if (myState == States.s_Level16)            { State_Level_16(); }
        else if (myState == States.s_Level17)            { State_Level_17(); }
        else if (myState == States.s_Level18)            { State_Level_18(); }
        else if (myState == States.s_Level19)            { State_Level_19(); }
        else if (myState == States.s_Level20)            { State_Level_20(); }
    }

    public void State_Level_1()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlaySFX("Level1");
        }
    }

    public void State_Level_2()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlaySFX("Level2");
        }
    }

    public void State_Level_3()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            PlaySFX("Level3");
        }
    }


    public void State_Level_4()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            PlaySFX("Level3");
        }
    }

    public void State_Level_5()
    {
    }

    public void State_Level_6()
    {
    }

    public void State_Level_7()
    {
    }


    public void State_Level_8()
    {
    }


    public void State_Level_9()
    {
    }


    public void State_Level_10()
    {
    }


    public void State_Level_11()
    {
    }


    public void State_Level_12()
    {
    }


    public void State_Level_13()
    {
    }


    public void State_Level_14()
    {
    }


    public void State_Level_15()
    {
    }


    public void State_Level_16()
    {
    }


    public void State_Level_17()
    {
    }


    public void State_Level_18()
    {
    }


    public void State_Level_19()
    {
    }


    public void State_Level_20()
    {
    }

}
