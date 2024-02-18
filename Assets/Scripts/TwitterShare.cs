
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 参考 : https://nekojara.city/unity-imgur-twitter-share
/// </summary>
public static class TwitterShare
{
    /// <summary>
    /// Twitterシェアウィンドウを開く
    /// </summary>
    /// <param name="text">ツイート文言</param>
    public static void Share(string text)
    {
        string str = Uri.EscapeDataString(text);
        var tweetURL = $"https://twitter.com/intent/tweet?text={str}";
        // ツイート画面を新しいウィンドウで開く
        OpenWindow(tweetURL, 600, 300);
    }

    // 新しいウィンドウでURLを開く
#if !UNITY_EDITOR && UNITY_WEBGL
    // WebGLビルドで有効になる
    [DllImport("__Internal")]
    private static extern void OpenWindow(string url, int width, int height);
#else
    // UnityエディタやWebGL以外のプラットフォームで有効になる
    private static void OpenWindow(string url, int width, int height) => Application.OpenURL(url);
#endif
}
