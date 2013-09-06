Namespace Osashimi

    ''' <summary>
    ''' メインサンプルクラス
    ''' </summary>
    ''' <remarks></remarks>
    Public Class MainSample
        Implements IDisposable

        ''' <summary>
        ''' メインフォーム
        ''' </summary>
        Private _form As MainForm = Nothing

        ''' <summary>
        ''' キーボードデバイス
        ''' </summary>
        Private _keyboradDevice As Device = Nothing

        ' 押されたボタンフラグ
        Private _preUpFlag As Boolean = False
        Private _preDownFlag As Boolean = False


        ''' <summary>
        ''' アプリケーションの初期化
        ''' </summary>
        ''' <param name="topLevelForm">トップレベルウインドウ</param>
        ''' <returns>全ての初期化がＯＫなら true, ひとつでも失敗したら false を返すようにする</returns>
        ''' <remarks>
        ''' false を返した場合は、自動的にアプリケーションが終了するようになっている
        ''' </remarks>
        Public Function InitializeApplication(ByVal topLevelForm As MainForm) As Boolean
            ' フォームの参照を保持
            Me._form = topLevelForm

            ' キーボードデバイスの初期化
            Try
                ' キーボードデバイスの作成
                Me._keyboradDevice = New Device(SystemGuid.Keyboard)

                ' 協調レベルの設定
                Me._keyboradDevice.SetCooperativeLevel(topLevelForm, _
                    CooperativeLevelFlags.Background Or CooperativeLevelFlags.NonExclusive)
            Catch ex As DirectXException
                MessageBox.Show(ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try

            Try
                ' キャプチャするデバイスを取得
                Me._keyboradDevice.Acquire()
            Catch
            End Try


            Return True
        End Function

        ''' <summary>
        ''' メインループ処理
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub MainLoop()
            Dim pushKeys As Key() = Nothing
            Try
                ' 押されたキーをキャプチャ
                pushKeys = Me._keyboradDevice.GetPressedKeys()
            Catch
                Try
                    ' キャプチャするデバイスを取得
                    Me._keyboradDevice.Acquire()
                    ' 押されたキーを再度キャプチャ
                    pushKeys = Me._keyboradDevice.GetPressedKeys()
                Catch
                End Try
            End Try

            If pushKeys Is Nothing Then
                ' デバイスをキャプチャできない、またはキーが押されていないとき
                Return
            End If

            ' 文字列を追加していく
            'Dim builder As StringBuilder = New StringBuilder()
            Dim upFlag As Boolean = False
            Dim downFlag As Boolean = False
            For Each i As Key In pushKeys
                'builder.Append(i.ToString() + Environment.NewLine)

                ' ↑キーが押されたらインクリメント
                If "Up" = i.ToString() Then
                    ' 前回押されてなかったら
                    If Not _preUpFlag Then
                        Me._form.Label2.Text = Me._form.Label2.Text + 1
                        Me._form.透過()
                    End If
                    upFlag = True
                End If
                ' ↓キーが押されたらデクリメント
                If "DownArrow" = i.ToString() Then
                    If Not _preDownFlag Then
                        Me._form.Label2.Text = Me._form.Label2.Text - 1
                        Me._form.透過()
                    End If
                    downFlag = True
                End If
                ' Escが押されたらリセット
                If "Escape" = i.ToString() Then
                    Me._form.Label2.Text = 0
                    Me._form.透過()
                End If
            Next
            ' 前回押されていたかどうかを記録
            _preUpFlag = upFlag
            _preDownFlag = downFlag

            ' ラベルに押されているキーを列挙
            'Me._form.InputLabel.Text = builder.ToString()

        End Sub

        ''' <summary>
        ''' リソースの破棄をするために呼ばれる
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Dispose() Implements IDisposable.Dispose
            ' キーボードデバイスの解放
            If Not Me._keyboradDevice Is Nothing Then
                Me._keyboradDevice.Dispose()
            End If
        End Sub
    End Class

End Namespace
