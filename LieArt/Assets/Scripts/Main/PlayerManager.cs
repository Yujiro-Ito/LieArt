using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    private Color alphaMinus = new Color(0, 0, 0, 255f);

    public GameObject[] Zukin;
    public string[] zukinName;
    private GameObject[] participation;
    private string[] pZukinName;

    [HideInInspector]
    public static GameObject[] randAfterParticipation;
    [HideInInspector]
    public static string[] randZukinName;
    // Use this for initialization
    void Start()
    {

    }

    void Awake()
    {
        int count = 0;
        for (int i = 0; i < GameManager.GetInstance().HoodsMember.Length; i++)
        {
            if (GameManager.GetInstance().HoodsMember[i] == true)
            {
                count++;
            }
        }
        participation = new GameObject[count];
        pZukinName = new string[count];
        //====================参加する人、名前を配列に入れる==========================
        int inCount = 0;
        for (int i = 0; i < GameManager.GetInstance().HoodsMember.Length; i++)
        {
            if (GameManager.GetInstance().HoodsMember[i] == true)
            {
                participation[inCount] = Zukin[i];
                pZukinName[inCount] = zukinName[i];
                inCount++;
            }
            Zukin[i].GetComponent<Image>().color -= alphaMinus;
        }
        //======================================================================

        randAfterParticipation = new GameObject[participation.Length];
        randZukinName = new string[pZukinName.Length];
        //====================ランダムに入れ替える==============================
        for (int i = 0; i < randAfterParticipation.Length; i++)
        {
            int rand = (int)Random.Range(0, randAfterParticipation.Length);
            if (randAfterParticipation[rand] == null)
            {
                randAfterParticipation[rand] = participation[i];
                randZukinName[rand] = pZukinName[i];
            }
            else
            {
                i--;
            }
        }
        //======================================================================
    }
}
