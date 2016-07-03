
Imports System.Text
Imports System.Xml
Imports System.IO

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim returnStr As String


        ReadStringFromFile(returnStr)
        xmlParser(returnStr)


    End Sub

    Private Sub xmlParser(data As String)

        Dim output As StringBuilder = New StringBuilder()
        Dim xmlString As String = data

        ' Create an XmlReader
        Using reader As XmlReader = XmlReader.Create(New StringReader(xmlString))

            While reader.Read()
                If reader.IsStartElement() Then
                    If reader.IsEmptyElement Then
                        output.AppendLine(reader.Name)
                    Else
                        output.AppendLine(reader.Name)
                        reader.Read() ' Read the start tag.
                        If reader.IsStartElement() Then ' Handle nested elements.
                            output.AppendLine(reader.Name)
                        End If
                        output.AppendLine(reader.ReadString()) 'Read the text content of the element.
                    End If
                End If
            End While


            ' reader.ReadToFollowing("book")
            ' reader.MoveToFirstAttribute()
            ' Dim genre As String = reader.Value
            ' output.AppendLine("The genre value: " + genre)

            ' reader.ReadToFollowing("title")
            ' output.AppendLine("Content of the title element: " + reader.ReadElementContentAsString())
        End Using

        TextBox1.Text = output.ToString()
    End Sub

    Private Sub ReadStringFromFile(ByRef returnStr As String)


        Dim lines As String = File.ReadAllText("D:\Projects - W\2016-012 - W (Extract 3D From Google Earth)\Pollygrammy.kml").ToString
        TextBox2.Text = lines
        returnStr = lines


    End Sub
End Class
