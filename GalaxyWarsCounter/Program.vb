Imports System.Threading

Namespace Osashimi

    ''' <summary>
    ''' アプリケーション開始クラス
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Program

        ''' <summary>
        ''' アプリケーションのメイン エントリ ポイントです。
        ''' </summary>
        ''' <remarks></remarks>
        <STAThread()> _
        Shared Sub Main()
            ' コントロール等を Windows XP のスタイルにします。
            ' はずしてもかまいません。
            Application.EnableVisualStyles()

            ' GDI+ を使用してコントロールのテキストを描画します。
            ' はずしてもかまいません。
            Application.SetCompatibleTextRenderingDefault(False)

            ' フォームとメインサンプルクラスを作成
            ' Using で作成されたリソースは End Using を外れると自動的に破棄される
            ' ここでは frm と sample が対象
            Using frm As MainForm = New MainForm()
                Using sample As MainSample = New MainSample()
                    ' アプリケーションの初期化
                    If sample.InitializeApplication(frm) Then
                        ' メインフォームを表示
                        frm.Show()

                        frm.f2.Show()
                        frm.f3.Show()
                        frm.透過()
                        frm.f2.Visible = False
                        frm.f3.Visible = False

                        ' フォームが作成されている間はループし続ける
                        While frm.Created
                            ' メインループ処理を行う
                            sample.MainLoop()

                            ' ＣＰＵがフル稼働しないようにちょっとだけ制限をかける。
                            ' パフォーマンスを最大限にあげるなら「0」を指定、
                            ' または「Thread.Sleep」をはずす。
                            Thread.Sleep(1)

                            ' イベントがある場合はその処理する
                            Application.DoEvents()
                        End While
                    Else
                        ' 初期化に失敗
                    End If
                End Using
            End Using
        End Sub

    End Class

End Namespace
