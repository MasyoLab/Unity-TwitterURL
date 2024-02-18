using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 参考 : https://qiita.com/bm0521/items/39ae81e2ba01c9d3e0bd
/// </summary>

public class TestModel : MonoBehaviour
{
    [SerializeField]
    private Button m_test = null;

    private string LF_CODE = "%0d";

    // Start is called before the first frame update
    private void Awake()
    {
        m_test.onClick.AddListener(OnTest5);
    }

    /// <summary>
    /// 基本のき
    /// </summary>
    private void OnTest()
    {
        OpenURL("https://twitter.com/intent/tweet");
    }

    /// <summary>
    /// text(ツイート内容を設定する)
    /// </summary>
    private void OnTest2()
    {
        OpenURL("https://twitter.com/intent/tweet?text=Hello%20world%0d改行も可能");
    }

    /// <summary>
    /// url(URLを設定する)
    /// </summary>
    private void OnTest3()
    {
        OpenURL("https://twitter.com/intent/tweet?url=https://qiita.com/\r\n");
    }

    /// <summary>
    /// hashtags(ハッシュタグを設定する)
    /// </summary>
    private void OnTest4()
    {
        OpenURL("https://twitter.com/intent/tweet?hashtags=qiita,twitter,html");
    }

    /// <summary>
    /// ツイート画面を開く
    /// </summary>
    /// <param name="text">テキスト</param>
    /// <param name="url">URL</param>
    /// <param name="hashtags">ハッシュタグ</param>
    private void IntentTweet(string text, string url = "", string hashtags = "")
    {
        string str = $"text={text}";
        if (url != string.Empty)
        {
            str += $"{LF_CODE}&url={url}";
        }
        if (hashtags != string.Empty)
        {
            str += $"{LF_CODE}&hashtags={hashtags}";
        }
        OpenURL($"https://twitter.com/intent/tweet?{str}");
    }

    private void OnTest5()
    {
        IntentTweet($"テストツイート{LF_CODE}Unityでテスト", "https://twitter.com/home", "Unity");
    }

    /// <summary>
    /// URLを開くやつ
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    private bool OpenURL(string url)
    {
        try
        {
            Application.OpenURL(url);
        }
        catch
        {
            Debug.LogError("Could not open URL. Please check your network connection and ensure the web address is correct.");
            return false;
        }
        return true;
    }
}
