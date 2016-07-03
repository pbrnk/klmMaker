
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

        Dim reader As XmlTextReader = New XmlTextReader("D:\Projects - W\2016-012 - W (Extract 3D From Google Earth)\Pollygrammy.kml")

        Do While (reader.Read())
                Select Case reader.NodeType
                    Case XmlNodeType.Element 'Display beginning of element.
                    output.Append("<" + reader.Name)
                    If reader.HasAttributes Then 'If attributes exist
                            While reader.MoveToNextAttribute()
                            'Display attribute name and value.
                            output.Append(reader.Name + "=" + reader.Value)
                        End While
                        End If
                    output.AppendLine(">")
                Case XmlNodeType.Text 'Display the text in each element.
                    output.AppendLine(reader.Value)
                Case XmlNodeType.EndElement 'Display end of element.
                    output.Append("</" + reader.Name)
                    output.AppendLine(">")
            End Select
            Loop
            Console.ReadLine()


        ' reader.ReadToFollowing("book")
        ' reader.MoveToFirstAttribute()
        ' Dim genre As String = reader.Value
        ' output.AppendLine("The genre value: " + genre)

        ' reader.ReadToFollowing("title")
        ' output.AppendLine("Content of the title element: " + reader.ReadElementContentAsString())


        TextBox1.Text = output.ToString()
    End Sub

    Private Sub ReadStringFromFile(ByRef returnStr As String)


        Dim lines As String = File.ReadAllText("D:\Projects - W\2016-012 - W (Extract 3D From Google Earth)\Pollygrammy.kml").ToString
        TextBox2.Text = lines
        returnStr = lines


    End Sub
End Class
