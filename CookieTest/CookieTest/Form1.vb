Imports System.Net
Imports HtmlAgilityPack

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CookieMethod()
    End Sub

    Public Sub CookieMethod()
        Dim cookieContainer As CookieContainer = New CookieContainer()
        Dim EUcookie As Cookie = New Cookie("pfg", "b72dd3180b078b96ae537dd5d7c3be82349b7d20be2d8bfaf6d859b952c05bd8%23%7B%22eu_resident%22%3A1%2C%22gdpr_is_acceptable_age%22%3A1%2C%22gdpr_consent_core%22%3A1%2C%22gdpr_consent_first_party_ads%22%3A1%2C%22gdpr_consent_search_history%22%3A1%2C%22exp%22%3A1566668448%2C%22vc%22%3A%22%22%7D%238125014197", "/", ".tumblr.com")
        cookieContainer.Add(EUcookie)
        EUcookie.Expires = Now.AddYears(50)
        Dim request As HttpWebRequest = CType(WebRequest.Create("http://crossingislandnatur.tumblr.com/"), HttpWebRequest)
        request.AllowAutoRedirect = True

        request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36"
        request.CookieContainer = cookieContainer

        Dim response As System.Net.HttpWebResponse = request.GetResponse()
        response.Cookies.Add(EUcookie)
        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
        Dim sourcecode As String = sr.ReadToEnd()
        TextBox1.Text = sourcecode
        TextBox2.Text = response.Headers.ToString
    End Sub

    Public Sub OtherMethod()
    End Sub
End Class
