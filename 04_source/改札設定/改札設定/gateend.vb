Imports MySql.Data.MySqlClient

Public Class gateend
    ' Orange Tags Easy APIの定義
    Private Declare Function GetCardIDIndex Lib "OrangeOneStopEasyAPI.dll" (ByRef id As Byte, ByRef length As Integer, ByVal index As Integer) As Integer

    Dim newId As Integer
    Dim stname As String = "高崎"
    Dim endname As String = "新前橋"
    Dim depo As String = ""
    Dim fare As Integer
    Dim connectionString As String = "Database=sotuken242301;Data Source=localhost;User Id=root;Allow Zero Datetime=True"
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Dim id(10) As Byte
        Dim length As Integer

        If GetCardIDIndex(id(0), length, 0) = 0 Then
            Timer1.Enabled = False

            Try

                newId = GetLatestICNo()

                CheckDepoStatus()

                If String.IsNullOrEmpty(depo) Then
                    ProcessEntry()
                Else
                    ProcessExit()
                End If

                Dim nextForm As New gate()
                nextForm.ReceivedId = newId
                nextForm.pay = fare
                nextForm.Show()
                Me.Hide()

            Catch ex As Exception
                MessageBox.Show("エラーが発生しました: " & ex.Message)
                Timer1.Enabled = True
            End Try
        End If
    End Sub

    Private Function GetLatestICNo() As Integer
        Using conn As New MySqlConnection(connectionString)
            conn.Open()
            Dim sql As String = "SELECT MAX(ICno) FROM iccard"
            Using cmd As New MySqlCommand(sql, conn)
                Dim result = cmd.ExecuteScalar()
                Return If(result Is DBNull.Value, 0, Convert.ToInt32(result))
            End Using
        End Using
    End Function

    Private Sub CheckDepoStatus()
        Using conn As New MySqlConnection(connectionString)
            conn.Open()
            Dim sql As String = "SELECT depo FROM iccard WHERE ICno = @id"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@id", newId)
                Dim result = cmd.ExecuteScalar()
                depo = If(result Is DBNull.Value, "", result.ToString())
            End Using
        End Using
    End Sub

    Private Sub ProcessEntry()
        Using conn As New MySqlConnection(connectionString)
            conn.Open()
            Dim sql As String = "UPDATE iccard SET depo = @stname WHERE ICno = @id"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@stname", stname)
                cmd.Parameters.AddWithValue("@id", newId)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub ProcessExit()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Dim isTeikiValid As Boolean = False

                Dim sqlTeiki As String = "SELECT COUNT(*) FROM iccard WHERE ICno = @id " &
                                       "AND CURDATE() <= endday " &
                                       "AND ((depass = @depo AND arpass = @endname) OR " &
                                       "(depass = @endname AND arpass = @depo))"

                Using cmdTeiki As New MySqlCommand(sqlTeiki, conn)
                    cmdTeiki.Parameters.AddWithValue("@id", newId)
                    cmdTeiki.Parameters.AddWithValue("@depo", depo)
                    cmdTeiki.Parameters.AddWithValue("@endname", endname)
                    If Convert.ToInt32(cmdTeiki.ExecuteScalar()) > 0 Then
                        isTeikiValid = True
                    End If
                End Using


                If isTeikiValid Then
                    fare = 0
                Else

                    Dim sqlFare As String = "SELECT f.fare FROM fareusu f " &
                        "INNER JOIN station s1 ON s1.stationname = @depo " &
                        "INNER JOIN station s2 ON s2.stationname = @endname " &
                        "WHERE s1.ruoid = s2.ruoid " &
                        "AND CEILING(ABS(s2.pointkm - s1.pointkm)) BETWEEN f.minkm AND f.maxkm " &
                        "AND f.medium = 1 LIMIT 1"

                    Using cmdFare As New MySqlCommand(sqlFare, conn)
                        cmdFare.Parameters.AddWithValue("@depo", depo)
                        cmdFare.Parameters.AddWithValue("@endname", endname)
                        Dim res = cmdFare.ExecuteScalar()

                        If res IsNot Nothing AndAlso Not IsDBNull(res) Then
                            fare = Convert.ToInt32(res)
                        Else
                            fare = 0
                            Return
                        End If
                    End Using
                End If

                Using cmdUpdate As New MySqlCommand()
                    cmdUpdate.Connection = conn

                    cmdUpdate.CommandText = "UPDATE iccard SET bal = bal - @f WHERE ICno = @id"
                    cmdUpdate.Parameters.AddWithValue("@f", fare)
                    cmdUpdate.Parameters.AddWithValue("@id", newId)
                    cmdUpdate.ExecuteNonQuery()

                    cmdUpdate.CommandText = "INSERT INTO resume(ICno, reday, bos, gos, fare) VALUES (@id, CURDATE(), @bos, @gos, @f)"
                    cmdUpdate.Parameters.Clear()
                    cmdUpdate.Parameters.AddWithValue("@id", newId)
                    cmdUpdate.Parameters.AddWithValue("@bos", depo)
                    cmdUpdate.Parameters.AddWithValue("@gos", endname)
                    cmdUpdate.Parameters.AddWithValue("@f", fare)
                    cmdUpdate.ExecuteNonQuery()

                    cmdUpdate.CommandText = "UPDATE iccard SET depo = '' WHERE ICno = @id"
                    cmdUpdate.Parameters.Clear()
                    cmdUpdate.Parameters.AddWithValue("@id", newId)
                    cmdUpdate.ExecuteNonQuery()
                End Using

            End Using
        Catch ex As Exception
            MessageBox.Show("エラーが発生しました: " & ex.Message)
        End Try
    End Sub
End Class