using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Core : MonoBehaviour
{
    private Vector3 touchPos1;
    public GameObject Line1;
    public GameObject line;
    public GameObject Canvas1;
    private Color color_dots;
    private bool Start_line = false;
    private bool Step2 = false;
    private bool dest = false;
    public int Distance;
    public float Wight_line;
    public static int count_line;
    public List<Vector2> edges = new List<Vector2>();
    public GameObject Win_trig;
    public int count_dot;


    public Color[] Color_dots = new Color[9];
    public GameObject Dot;
    public int start_Count_dot;
    public GameObject Exit_box;
    //-------------------------------------

    /* public GameObject Dot_start;
     public GameObject Dot_finish;
     public Vector3 distance;
     string napruam;
    public Vector2 nap=new Vector2(0,0);*/

    private void Awake()
    {
        IronSource.Agent.init("16aef9ed5");
    }

    void Start()
    {
        LoadBanner();
        if (PlayerPrefs.GetInt("Music") == 0) { gameObject.GetComponent<AudioSource>().Play(); } else gameObject.GetComponent<AudioSource>().Stop();
        Vibration.Init();
        Application.targetFrameRate = 60;
        if (!GameObject.Find("Dot"))
        {
            for (int i = 0; i < start_Count_dot; i++)
            {
                if (i < 9)
                {
                    int v = Random.Range(1, Canvas1.transform.GetChild(2).childCount);
                    while (Canvas1.transform.GetChild(2).GetChild(v).childCount != 0) { v = Random.Range(1, Canvas1.transform.GetChild(2).childCount); }
                    Dot.GetComponent<Image>().color = Color_dots[i];
                    GameObject Dot1 = Instantiate(Dot, Canvas1.transform.GetChild(2).GetChild(v));
                    Dot1.name = "Dot";
                    while (Canvas1.transform.GetChild(2).GetChild(v).childCount != 0) { v = Random.Range(1, Canvas1.transform.GetChild(2).childCount); }
                    GameObject Dot2 = Instantiate(Dot, Canvas1.transform.GetChild(2).GetChild(v));
                    Dot2.name = "Dot";
                }
                else if (i < 18)
                {
                    int v = Random.Range(1, Canvas1.transform.GetChild(2).childCount);
                    while (Canvas1.transform.GetChild(2).GetChild(v).childCount != 0) { v = Random.Range(1, Canvas1.transform.GetChild(2).childCount); }
                    Dot.GetComponent<Image>().color = Color_dots[i - 8];
                    GameObject Dot1 = Instantiate(Dot, Canvas1.transform.GetChild(2).GetChild(v));
                    Dot1.name = "Dot";
                    while (Canvas1.transform.GetChild(2).GetChild(v).childCount != 0) { v = Random.Range(1, Canvas1.transform.GetChild(2).childCount); }
                    GameObject Dot2 = Instantiate(Dot, Canvas1.transform.GetChild(2).GetChild(v));
                    Dot2.name = "Dot";
                }
                else if (i < 27)
                {
                    int v = Random.Range(1, Canvas1.transform.GetChild(2).childCount);
                    while (Canvas1.transform.GetChild(2).GetChild(v).childCount != 0) { v = Random.Range(1, Canvas1.transform.GetChild(2).childCount); }
                    Dot.GetComponent<Image>().color = Color_dots[i - 17];
                    GameObject Dot1 = Instantiate(Dot, Canvas1.transform.GetChild(2).GetChild(v));
                    Dot1.name = "Dot";
                    while (Canvas1.transform.GetChild(2).GetChild(v).childCount != 0) { v = Random.Range(1, Canvas1.transform.GetChild(2).childCount); }
                    GameObject Dot2 = Instantiate(Dot, Canvas1.transform.GetChild(2).GetChild(v));
                    Dot2.name = "Dot";
                }
            }
        }
        GameObject.Find("Count_Dots").transform.GetComponent<Count_dots>().Count();
        for (int i = 0; i < GameObject.Find("Help").transform.childCount; i++)
        {
            GameObject.Find("Help").transform.GetChild(i).name = "Line";
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Exit_box.SetActive(true);
            }
        }
        if (Input.touchCount > 0)
        {

            Touch touch1 = Input.GetTouch(0);

            touchPos1 = Camera.main.ScreenToWorldPoint(new Vector2(touch1.position.x, touch1.position.y));
            RaycastHit2D hit = Physics2D.Raycast(touchPos1, Vector3.forward);
            //Debug.DrawRay(touchPos1, Vector3.forward, Color.green);
            if (hit.collider != null && hit.collider.tag == "Cell")
            {
                if (hit.transform.childCount == 1 && Start_line == false)
                {
                    if (hit.transform.GetChild(0).name == "Dot")
                    {
                        line = Instantiate(Line1, hit.transform) as GameObject;
                        count_line++;
                        line.name = "Line_" + count_line;
                        line.transform.SetParent(Canvas1.transform, false);
                        line.transform.SetSiblingIndex(Canvas1.transform.childCount + 1);
                        line.GetComponent<LineRenderer>().startWidth = Wight_line;
                        line.GetComponent<LineRenderer>().positionCount = 1;
                        line.GetComponent<LineRenderer>().SetPosition(0, hit.transform.gameObject.GetComponent<RectTransform>().localPosition);
                        if (PlayerPrefs.GetInt("Vibro") == 0) { Vibration.VibratePeek(); }
                        edges.Add(new Vector2(hit.transform.gameObject.GetComponent<RectTransform>().localPosition.x, hit.transform.gameObject.GetComponent<RectTransform>().localPosition.y));
                        hit.transform.name = "Cell_blocked";
                        if (PlayerPrefs.GetInt("Sound") == 0) { hit.transform.GetComponent<AudioSource>().pitch = 1.5f; hit.transform.GetComponent<AudioSource>().Play(); }
                        hit.transform.GetChild(0).name = "Dot_blocked";
                        hit.transform.GetComponent<Animator>().enabled = true;
                        hit.transform.GetComponent<ParticleSystem>().Play();
                        line.GetComponent<LineRenderer>().startColor = hit.transform.GetChild(0).GetComponent<Image>().color;
                        line.GetComponent<LineRenderer>().endColor = hit.transform.GetChild(0).GetComponent<Image>().color;
                        color_dots = hit.transform.GetChild(0).GetComponent<Image>().color;

                        Start_line = true;
                        Step2 = true;
                        dest = false;

                    }
                }
            }
            if (hit.collider != null && hit.collider.name == "Cell" && Step2 == true)
            {
                if (Vector3.Distance(line.GetComponent<LineRenderer>().GetPosition(line.GetComponent<LineRenderer>().positionCount - 1), hit.collider.transform.localPosition) <= Distance)
                {
                    if (hit.transform.childCount == 0)
                    {
                        line.GetComponent<LineRenderer>().positionCount++;
                        line.GetComponent<LineRenderer>().SetPosition(line.GetComponent<LineRenderer>().positionCount - 1, hit.transform.gameObject.GetComponent<RectTransform>().localPosition);
                        if (PlayerPrefs.GetInt("Vibro") == 0) { Vibration.VibratePop(); }
                        edges.Add(new Vector2(hit.transform.gameObject.GetComponent<RectTransform>().localPosition.x, hit.transform.gameObject.GetComponent<RectTransform>().localPosition.y));
                        hit.transform.name = "Cell_blocked";
                        if (PlayerPrefs.GetInt("Sound") == 0) { hit.transform.GetComponent<AudioSource>().pitch = 1; hit.transform.GetComponent<AudioSource>().Play(); }
                        hit.transform.GetComponent<Animator>().enabled = true;
                        hit.transform.GetComponent<ParticleSystem>().Play();
                    }
                    if (hit.transform.childCount == 1)
                    {

                        if (hit.transform.GetChild(0).name == "Dot" && color_dots == hit.transform.GetChild(0).GetComponent<Image>().color)
                        {
                            line.GetComponent<LineRenderer>().positionCount++;
                            line.GetComponent<LineRenderer>().SetPosition(line.GetComponent<LineRenderer>().positionCount - 1, hit.transform.gameObject.GetComponent<RectTransform>().localPosition);
                            if (PlayerPrefs.GetInt("Vibro") == 0) { Vibration.VibratePop(); }
                            edges.Add(new Vector2(hit.transform.gameObject.GetComponent<RectTransform>().localPosition.x, hit.transform.gameObject.GetComponent<RectTransform>().localPosition.y));
                            hit.transform.name = "Cell_blocked";
                            if (PlayerPrefs.GetInt("Sound") == 0) { hit.transform.GetComponent<AudioSource>().pitch = 1; hit.transform.GetComponent<AudioSource>().Play(); }
                            hit.transform.GetComponent<Animator>().enabled = true;
                            hit.transform.GetComponent<ParticleSystem>().Play();
                            hit.transform.GetChild(0).name = "Dot_blocked";
                            count_dot++;
                            Start_line = false;
                            Step2 = false;
                            dest = true;
                            line.GetComponent<EdgeCollider2D>().SetPoints(edges);
                            if (PlayerPrefs.GetInt("Vibro") == 0) { Vibration.VibratePeek(); }
                            line = null;
                            edges.Clear();
                            if (PlayerPrefs.GetInt("Sound") == 0) { hit.transform.GetComponent<AudioSource>().pitch = 1.5f; hit.transform.GetComponent<AudioSource>().Play(); }
                            GameObject.Find("Conect_line").GetComponent<ParticleSystem>().Play();
                            GameObject.Find("Count_Dots").GetComponent<TextMeshProUGUI>().text = System.Convert.ToString(count_dot + "/" + GameObject.Find("Count_Dots").GetComponent<Count_dots>().count_dots / 2);
                            for (int i = 0; i < GameObject.Find("Help").transform.childCount; i++)
                            {
                                if (Mathf.Abs(GameObject.Find("Help").transform.GetChild(i).GetComponent<LineRenderer>().endColor.g - hit.transform.GetChild(0).GetComponent<Image>().color.g) < 0.01f && Mathf.Abs(GameObject.Find("Help").transform.GetChild(i).GetComponent<LineRenderer>().endColor.r - hit.transform.GetChild(0).GetComponent<Image>().color.r) < 0.01f && Mathf.Abs(GameObject.Find("Help").transform.GetChild(i).GetComponent<LineRenderer>().endColor.b - hit.transform.GetChild(0).GetComponent<Image>().color.b) < 0.01f)
                                {
                                    GameObject.Find("Help").transform.GetChild(i).name = "Line_" + count_line;
                                    break;
                                }
                            }
                            for (int i = 0; i < GameObject.Find("Help").transform.childCount; i++)
                            {
                                if (GameObject.Find("Help").transform.GetChild(i).gameObject.activeSelf == true)
                                {
                                    if (GameObject.Find("Help").transform.GetChild(i).gameObject.name == "Line_" + count_line)
                                    {
                                        GameObject.Find("Line_" + count_line).SetActive(false);
                                    }
                                }
                            }
                            if (!GameObject.Find("Dot"))
                            {
                                Win_trig.SetActive(true);
                                if (PlayerPrefs.GetInt("Curent_lvl") <= Application.loadedLevel)
                                {
                                    PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 5 + Application.loadedLevel / 2);
                                    Win_trig.transform.GetChild(1).transform.GetChild(10).GetComponent<TextMeshProUGUI>().text = "+" + System.Convert.ToString(5 + Application.loadedLevel / 2);
                                    PlayerPrefs.SetInt("Curent_lvl", Application.loadedLevel + 1);
                                }
                                if (PlayerPrefs.GetInt("Sound") == 0) { Win_trig.GetComponent<AudioSource>().Play(); }
                            }
                        }
                    }
                }
            }

        }
        if (Input.touchCount == 0 && Step2 == true)
        {
            if (edges.Count == 1) { edges.Add(new Vector2(edges[0].x, edges[0].y - 2)); }
            Start_line = false;
            Step2 = false;
            if (dest == false)
            {
                line.GetComponent<EdgeCollider2D>().SetPoints(edges);
                edges.Clear();
                line.GetComponent<Animator>().enabled = true;
                count_line--;
                if (PlayerPrefs.GetInt("Vibro") == 0) { Vibration.VibrateNope(); }
            }
        }
    }
    private void LoadBanner()
    {
        IronSource.Agent.loadBanner(IronSourceBannerSize.SMART, IronSourceBannerPosition.BOTTOM);
    }
}
