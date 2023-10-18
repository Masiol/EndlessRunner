using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
[System.Serializable]

public enum SIDE { Left, Mid, Right }

public class Movement : MonoBehaviour
{
    public SIDE m_Side = SIDE.Mid;
    float newXPos = 0f;
    public bool SwipeLeft, SwipeRight, SwipeDown, SwipeUp;
    public float XValue;
    private CharacterController m_char;
    private Animator m_anim;
    private float x;
    public float SpeedDogde;
    public float JumpPower = 7f;
    public float Speed = 4f;
    private float y;
    public bool inJump;
    public bool inRoll;
    private float ColHeight;
    private float ColRadius;
    private float ColCenterY;
    public float jumptime;
    public SpawnManager spawnManager;
    public Obstacles obstacles;
    //public GameObject particle;
    public AudioSource audio;
    //public Transform targ;
    public bool shield;
    public Transform parent;
    private GameObject go;
    public static bool death;
    public ParticleSystem shieldParticle;
    public ParticleSystem shieldParticle2;
    public ParticleSystem shoesParticle;
    public bool touchshield;
    public float speed2;
    public bool shoes;
    private float shieldtime;
    public Image ShoesImg;
    public Image ShieldImg;
    public CanvasGroup turnoff;
    void Start()
    {
        turnoff = GameObject.Find("DeathMenu").GetComponent<CanvasGroup>();
        ShoesImg = GameObject.Find("Shoes").GetComponent<Image>();
        ShieldImg = GameObject.Find("Shield").GetComponent<Image>();
        GameObject g = GameObject.Find("ObstacleSpawner");
        GameObject h = GameObject.Find("RoadSpawner");
        spawnManager = h.GetComponent<SpawnManager>();
        obstacles = g.GetComponent<Obstacles>();
        m_char = GetComponent<CharacterController>();
        m_anim = GetComponent<Animator>();
        ColHeight = m_char.height;
        ColRadius = m_char.radius;
        ColCenterY = m_char.center.y;
        shield = true;
        go = GameObject.FindWithTag("shield");
        death = false;
        touchshield = true;
        shoes = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Speed);
        if (Speed > 0.2f)
            Speed = 0.2f;
        if(Speed > 0)
        {
            turnoff.gameObject.SetActive(false);
        }
        if (Speed <= 0)
        {
            turnoff.gameObject.SetActive(true);
        }


        SwipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        SwipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        SwipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        SwipeDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
        if (Mobile.Instance.SwipeLeft && !inRoll && !death)
        {
            if (m_Side == SIDE.Mid)
            {
                newXPos = -XValue;
                m_Side = SIDE.Left;
                m_anim.Play("Left");
            }
            else if (m_Side == SIDE.Right)
            {
                newXPos = 0;
                m_Side = SIDE.Mid;
                m_anim.Play("Left");
            }
        }
        else if (Mobile.Instance.SwipeRight && !inRoll && !death)
        {
            if (m_Side == SIDE.Mid)
            {
                newXPos = XValue;
                m_Side = SIDE.Right;
                m_anim.Play("Right");
            }
            else if (m_Side == SIDE.Left)
            {
                newXPos = 0;
                m_Side = SIDE.Mid;
                m_anim.Play("Right");
            }
        }
        Vector3 moveVector = new Vector3(x - transform.position.x, y * Time.deltaTime, Speed);
        Jump();
        Roll();
        jumptime -= Time.deltaTime;
        if (jumptime < 0)
            jumptime = 0;

        x = Mathf.Lerp(x, newXPos, Time.deltaTime * SpeedDogde);
        m_char.Move(moveVector);
        ShoesImg.fillAmount -= 0.07f * Time.deltaTime;
            if(ShoesImg.fillAmount == 0)
            {
                JumpPower = 1;
            }
        
        if(shield)
        {
            ShieldImg.fillAmount = 100f;
        }
        if (!shield)
        {
            ShieldImg.fillAmount = 0f;
        }
    }
    void Jump()
    {

        if (Mobile.Instance.SwipeUp && jumptime <= 0)
        {
            y = JumpPower * 2.1f;
            m_anim.Play("Jump");
            inJump = true;
            jumptime = 0.5f;
        }
        else
        {
            y -= JumpPower * Time.deltaTime *8;
            inJump = false;

        }

        go = GameObject.FindWithTag("shield");
        Shield();

    }
    internal float RollCounter;
    public void Roll()
    {
        RollCounter -= Time.deltaTime;
        if (RollCounter <= 0f)
        {
            RollCounter = 0f;
            m_char.center = new Vector3(0, ColCenterY, 0);
            m_char.height = ColHeight;
            inRoll = false;
        }
        if (Mobile.Instance.SwipeDown && RollCounter == 0)
        {
            jumptime = 0;
            RollCounter = 0.3f;
            y -= 10f;
            m_anim.CrossFadeInFixedTime("Roll", 0.1f);
            m_char.center = new Vector3(0, ColCenterY / 5, 0);
            m_char.height = ColHeight / 2f;
            inRoll = true;
            inJump = false;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpawnTrigger")
        {
            spawnManager.SpawnTriggerEntered();
                Speed += 0.0003f;
            obstacles.SpawnObstacles();

        }
        if (other.tag == "Rubins")
        {
            //Destroy(other.gameObject);
            audio.Play();
        }
        if (other.tag == "Obstacle" && !shield)
        {
            death = true;
            m_anim.Play("Death");
            //Destroy(particle);
            Speed = 0;
        }
        if (other.tag == "Obstacle" && shield)
        {
            shieldParticle.Play();
            Destroy(go);
            //DeffTime();
            touchshield = false;

        }

        if (other.tag == "shield" && !shield)
        {
            go.transform.parent = parent.transform;
            go.transform.localPosition = new Vector3(-0.0032f, -0.0043f, 0.0001f);
            shieldParticle2.Play();

        }
        if(other.tag == "Shoes")
        {
            ShoesImg.fillAmount = 100f;
            shoesParticle.Play();
            JumpPower = 2.2f;
        }
    }
    public void Shield()
    {
        if (parent.transform.childCount > 1)
        {
            shield = true;
        }
        if (parent.transform.childCount == 1)
        {
            shield = false;
        }
    }
}