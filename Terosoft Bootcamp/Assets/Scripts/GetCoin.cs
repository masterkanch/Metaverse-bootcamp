using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class GetCoin : MonoBehaviour
{
    public Animator Warn;
    public TMP_Text WarnTX;
    public float coin;
    public string[] Goods;
    public TMP_Text cointTX;
    public string[] bb;

    public string[] bbb;
    float tmr;
    bool warning;
    bool LOCK;
    // Start is called before the first frame update
    void Start()
    {
        WarnTX = GameObject.Find("warnTX").GetComponent<TMP_Text>();
        cointTX = GameObject.Find("coinTX").GetComponent<TMP_Text>();
        Warn= GameObject.Find("warnAni").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (warning)
        {
            if (Time.time - tmr > 3)
            {
                Warn.Play("warnout", 0);
                warning = false;
            }
        }
    }
    IEnumerator Upload2()
    {
        WWWForm form = new WWWForm();
        form.AddField("providerId", "XXXXXXXXXXXXXXXXXXXXX");
        form.AddField("providerName", "phone");
        using (UnityWebRequest www = UnityWebRequest.Post("https://wallet-api.terochain.com/account.balance", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.result);
                Debug.Log(www.downloadHandler.text);
                bb = www.downloadHandler.text.Trim('"', '"').Split(':');
                string[] cc = bb[6].Split(',');
                Debug.Log(cc[0].Trim('"'));
                cointTX.text = cc[0].Trim('"');
                coin = float.Parse(cointTX.text);
                Debug.Log(www.GetRequestHeader("HEAVEX"));
            }

        }
    }
    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("providerId", "XXXXXXXXXXXXXXXXXXX");
        form.AddField("providerName", "phone");
        form.AddField("amount", "5");
        using (UnityWebRequest www = UnityWebRequest.Post("https://wallet-api.terochain.com/token.accumulate", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.result);
                Debug.Log(www.downloadHandler.text);
                

                Warn.Play("warnin",0);
                WarnTX.text = "ได้รับ 5 เหรียญ";
                warning = true;
                tmr = Time.time;
                StartCoroutine(Upload2());

            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
    
        if (other.tag == "Player")
        {
            if (!LOCK)
            {
                transform.position = new Vector3(10000, 10000, 10000);
                transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                
                StartCoroutine(Upload());
                // GetComponent<Rigidbody>().Sleep();
                Debug.Log("======" + other.name);
                LOCK = true;

            }


        }
    }
}
