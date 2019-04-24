Imports System
Imports System.Xml

Public Class Form1
    Dim xmlDoc As New XmlDocument

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            xmlDoc.Load("okul.xml")
        Catch ex As Exception
            MsgBox("XML Dosyası Yüklenirken Hata: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim xmlElement = xmlDoc.CreateElement("ogrenci")
            xmlElement.SetAttribute("kimlik", TextBox1.Text)

            Dim tckn As XmlNode = xmlDoc.CreateNode("element", "tckn", "")
            tckn.InnerText = TextBox2.Text
            xmlElement.AppendChild(tckn)

            Dim ad As XmlNode = xmlDoc.CreateNode("element", "ad", "")
            ad.InnerText = TextBox4.Text
            xmlElement.AppendChild(ad)

            Dim ogrVize As XmlNode = xmlDoc.CreateNode("element", "vize", "")
            ogrVize.InnerText = TextBox3.Text
            xmlElement.AppendChild(ogrVize)

            Dim ogrFinal As XmlNode = xmlDoc.CreateNode("element", "final", "")
            ogrFinal.InnerText = TextBox5.Text
            xmlElement.AppendChild(ogrFinal)

            Dim ogrOrt As XmlNode = xmlDoc.CreateNode("element", "ortalama", "")
            ogrOrt.InnerText = (TextBox4.Text * 0.4) + (TextBox5.Text * 0.6)
            xmlElement.AppendChild(ogrOrt)

            MsgBox("Kaydetme Başarılı ! Öğrenci Not Ortalaması: " & ogrOrt.InnerText)

            xmlDoc.DocumentElement.AppendChild(xmlElement)
            xmlDoc.Save("okul.xml")
        Catch ex As Exception
            MsgBox("XML Veri Yazarken Hata: " & ex.Message)
        End Try

    End Sub
End Class
