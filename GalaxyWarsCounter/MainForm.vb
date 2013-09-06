Imports System
Imports System.Globalization
Imports System.Diagnostics
Imports System.Text.RegularExpressions
Imports System.Xml.Serialization
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

''' <summary>
''' ���C���t�H�[��
''' </summary>
''' <remarks></remarks>
Public Class MainForm
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    Private Declare Function GetSystemMetrics Lib "user32" (ByVal lnIndex As Long) As Long

    Private Const SM_CXFULLSCREEN As Long = 16
    Private Const SM_CYFULLSCREEN As Long = 17

    Private Const COUNTMAX As Long = 999999999
    Private Const COUNTMIN As Long = -999999999



    Public f2 As New Jimaku()
    Public f3 As New Jimaku()
    Public fontDetail

    '�t�H���g��{���
    '�t�H���g�F
    Public BaseFontColor As Color = Color.Transparent
    '�����
    Public BaseFontBorder As Color = Color.Yellow
    '����蕝
    Public BaseFontBorderWidth As Integer = 1
    '�e
    Public BaseFontShade As Color = Color.White
    '�e�L��
    Public BaseFontShadeOn As Boolean = False
    '�A���t�@�l
    Public BaseFontAlpha As Integer = 250

    Public jimakuFlag As Boolean = False


    ''' <summary>
    ''' �R���X�g���N�^
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New()
        ' ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.f2.setFormPair(Me.f3)
        Me.f2.setFormParent(Me)
        Me.f3.setFormPair(Me.f2)
        Me.f3.setFormParent(Me)
        Me.fontDetail = New FontDetail(Me)
        'Me.f2.Show()
        'Me.f3.Show()

        'Me.����()
        'Me.f2.Visible = False
        'Me.f3.Visible = False


    End Sub

    Public Sub ����()

        Dim path As New System.Drawing.Drawing2D.GraphicsPath()
        Dim path2 As New System.Drawing.Drawing2D.GraphicsPath()
        Dim g As Graphics = Me.f2.CreateGraphics()
        Dim gs As Graphics = Me.f3.CreateGraphics()

        Dim brs1 As SolidBrush

        brs1 = New SolidBrush(Me.BaseFontColor)

        Dim brs2 As Pen
        Dim brs3 As SolidBrush = New SolidBrush(Me.BaseFontShade)

        '�t�H���g�I�u�W�F�N�g�̍쐬
        Dim fnt As New Font(Label2.Font.FontFamily, Label2.Size.Height, _
                       Label2.Font.Style, GraphicsUnit.Pixel)
        'StringFormat�I�u�W�F�N�g�̍쐬
        Dim sf As New StringFormat
        Dim stringSize As SizeF = _
        g.MeasureString(Me.Label2.Text, fnt, 65535, sf)
        If stringSize.Height = 0 Or stringSize.Width = 0 Then
            stringSize.Height = 1
            stringSize.Width = 1
        End If

        Dim bBuf As New Bitmap(CInt(stringSize.Width * 2), CInt(stringSize.Height * 2))
        Dim gBuf As Graphics = Graphics.FromImage(bBuf)

        'If Me.BaseAntiAriasFlg Then
        gBuf.SmoothingMode = SmoothingMode.AntiAlias
        'gBuf.PixelOffsetMode = PixelOffsetMode.HighQuality
        'End If



        gBuf.Clear(Color.Transparent)
        'Debug.Print(bBuf.GetPixel(Int(bBuf.Width / 2), 0).ToString)


        If Me.BaseFontShadeOn Then
            path2.AddString(Me.Label2.Text, Label2.Font.FontFamily, _
                       Label2.Font.Style, Label2.Font.Height, New Point(3, 3), _
                       StringFormat.GenericDefault)
            '������̒���h��Ԃ�
            gBuf.FillPath(brs3, path2)
        End If

        path.AddString(Me.Label2.Text, Label2.Font.FontFamily, _
            Label2.Font.Style, Label2.Font.Height, New Point(0, 0), _
            StringFormat.GenericDefault)

        If Me.BaseFontBorderWidth <> 0 Then
            brs2 = New Pen(Me.BaseFontBorder, Me.BaseFontBorderWidth)

            '������̉���`�悷��
            gBuf.DrawPath(brs2, path)
            brs2.Dispose()

        End If

        '������̒���h��Ԃ�
        gBuf.FillPath(brs1, path)

        Dim drawPoint As Point
        'If Me.BaseAlignRightFlg Then
        'drawPoint = New Point(Me.f2.Location.X + Me.f2.Width - stringSize.Width * 2, Me.f2.Location.Y)
        'Else
        drawPoint = New Point(Me.f2.Location.X, Me.f2.Location.Y)
        'End If

        Me.f2.Height = stringSize.Height * 2
        Me.f2.Width = stringSize.Width * 2
        Me.f3.Height = stringSize.Height * 2
        Me.f3.Width = stringSize.Width * 2

        'Debug.Print(stringSize.Height)
        'Debug.Print(stringSize.Width)

        Me.f2.Location = drawPoint
        Me.f3.Location = drawPoint

        g.Clear(Color.White)
        g.DrawImage(bBuf, 0, 0)

        gs.Clear(Color.White)
        gs.DrawImage(bBuf, 0, 0)

        'bBuf.MakeTransparent(Color.White)

        '���\�[�X���J������
        bBuf.Dispose()
        gBuf.Dispose()
        'gp.Dispose()
        g.Dispose()
        brs1.Dispose()
        brs3.Dispose()

        '�t�H�[���̃A���t�@�l��ݒ肷��
        Me.f2.Opacity = BaseFontAlpha / 255
        Me.f3.Opacity = BaseFontAlpha / 255

    End Sub

    Public Sub �����{�^��_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �����{�^��.Click
        If Me.�����{�^��.Text = "�����\��" Then
            Me.f2.Visible = True
            Me.f3.Visible = True
            Me.����()
            Me.�����{�^��.Text = "��������"
            Me.�����{�^��.BackColor = Color.RoyalBlue
        Else
            Me.f2.Visible = False
            Me.f3.Visible = False
            Me.����()
            Me.�����{�^��.Text = "�����\��"
            Me.�����{�^��.BackColor = Color.PaleVioletRed
        End If

    End Sub

    Private Sub �t�H���g�ύX�{�^��_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �t�H���g�ύX�{�^��.Click
        Me.fontDetail.ShowDialog()
    End Sub
End Class
