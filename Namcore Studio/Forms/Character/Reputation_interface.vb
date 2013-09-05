﻿'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
'* Copyright (C) 2013 Namcore Studio <https://github.com/megasus/Namcore-Studio>
'*
'* This program is free software; you can redistribute it and/or modify it
'* under the terms of the GNU General Public License as published by the
'* Free Software Foundation; either version 2 of the License, or (at your
'* option) any later version.
'*
'* This program is distributed in the hope that it will be useful, but WITHOUT
'* ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
'* FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for
'* more details.
'*
'* You should have received a copy of the GNU General Public License along
'* with this program. If not, see <http://www.gnu.org/licenses/>.
'*
'* Developed by Alcanmage/megasus
'*
'* //FileInfo//
'*      /Filename:      Reputation_interface
'*      /Description:   Provides an interface to display character reputation information
'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

Imports System.Drawing
Imports NCFramework.ResourceHandler
Imports NCFramework.Basics
Imports NCFramework.Conversions
Imports NCFramework.GlobalVariables
Imports NCFramework
Imports System.Resources
Imports System.Net

Public Class Reputation_interface
    Dim panelMaxLength As Integer = 454
    Dim panelMinLength As Integer = 5
    Dim lasttxtvalue As String
    Dim valueisok As Boolean = False

    Public Sub prepareRepInterface(ByVal setId As Integer)
        Dim controlLST As List(Of Control)
        controlLST = FindAllChildren()
        For Each item_control As Control In controlLST
            item_control.SetDoubleBuffered()
        Next
        Dim colorTicker As Integer = 0
        RepLayoutPanel.Controls.Add(addpanel)
        If NCFramework.My.MySettings.Default.language = "de" Then
            'todo
            Dim cnt As Integer = 0
            Do
                'Dim RM as New ResourceManager("NCFramework.UserMessages", System.Reflection.Assembly.GetExecutingAssembly())
                reference_standing_combo.Items.Add(GetUserMessage("standing_" & cnt.ToString))
                cnt += 1
            Loop Until cnt = 8
        Else
            Dim cnt As Integer = 0
            Do
                'Dim RM as New ResourceManager("NCFramework.UserMessages", System.Reflection.Assembly.GetExecutingAssembly())
                reference_standing_combo.Items.Add(GetUserMessage("standing_" & cnt.ToString))
                cnt += 1
            Loop Until cnt = 8
        End If
        Try
            currentViewedCharSet.PlayerReputation.Sort(Function(x, y) System.String.Compare(x.name, y.name, System.StringComparison.Ordinal))
        Catch ex As Exception

        End Try

        For Each pRepu As Reputation In currentViewedCharSet.PlayerReputation
            Dim repPanel As New Panel
            repPanel.Name = "rep" & pRepu.faction.ToString() & "_pnl"
            repPanel.Size = referencePanel.Size
            repPanel.Tag = pRepu
            If colorTicker = 0 Then
                colorTicker = 1
                repPanel.BackColor = Color.FromArgb(110, 149, 190)
            Else
                colorTicker = 0
                repPanel.BackColor = Color.FromArgb(126, 144, 156) 'Color.SaddleBrown
            End If
            Dim repNameLable As New Label
            repNameLable.Name = "rep" & pRepu.faction.ToString() & "_name_lbl"
            repNameLable.Text = pRepu.name
            repNameLable.Tag = pRepu
            repPanel.Controls.Add(repNameLable)
            repNameLable.Location = reference_name_lbl.Location
            Dim sliderBgPanel As New Panel
            sliderBgPanel.Name = "rep" & pRepu.faction.ToString() & "_sliderBg_pnl"
            sliderBgPanel.Size = reference_sliderbg_panel.Size
            sliderBgPanel.BackgroundImage = My.Resources.repbg1
            sliderBgPanel.BackgroundImageLayout = ImageLayout.Stretch
            sliderBgPanel.Tag = pRepu
            Dim progressPanel As New Panel
            progressPanel.Name = "rep" & pRepu.faction.ToString() & "_progress_pnl"
            progressPanel.Size = reference_percentage_panel.Size
            progressPanel.BackColor = Color.Yellow
            progressPanel.Tag = pRepu
            sliderBgPanel.Controls.Add(progressPanel)
            progressPanel.Location = reference_percentage_panel.Location
            repPanel.Controls.Add(sliderBgPanel)
            If pRepu.max = 0 Then pRepu.max = 1
            setPanelPercentage(progressPanel, pRepu.value / pRepu.max)
            sliderBgPanel.Location = reference_sliderbg_panel.Location
            Dim slider As New TrackBar
            slider.Name = "rep" & pRepu.faction.ToString() & "_slider"
            slider.Maximum = pRepu.max
            slider.Value = pRepu.value
            slider.Size = reference_trackbar.Size
            slider.Tag = pRepu
            slider.TickStyle = TickStyle.None
            repPanel.Controls.Add(slider)
            slider.Location = reference_trackbar.Location
            AddHandler slider.Scroll, AddressOf slider_slide '//Use MouseUp event for better performance 
            Dim value_txtbox As New TextBox
            value_txtbox.Name = "rep" & pRepu.faction.ToString() & "_value_txtbox"
            value_txtbox.Size = reference_txtbox.Size
            value_txtbox.Text = pRepu.value
            value_txtbox.Tag = pRepu
            repPanel.Controls.Add(value_txtbox)
            value_txtbox.Location = reference_txtbox.Location
            AddHandler value_txtbox.TextChanged, AddressOf txt_changed
            AddHandler value_txtbox.Enter, AddressOf txt_enter
            AddHandler value_txtbox.Leave, AddressOf txt_left
            Dim valueLbl As New Label
            valueLbl.Name = "rep" & pRepu.faction.ToString() & "_value_lbl"
            valueLbl.Text = pRepu.value.ToString & "/" & pRepu.max.ToString()
            valueLbl.Font = reference_counter_lbl.Font
            valueLbl.ForeColor = reference_counter_lbl.ForeColor
            valueLbl.BackColor = reference_counter_lbl.BackColor
            valueLbl.Tag = pRepu
            valueLbl.AutoSize = True
            repPanel.Controls.Add(valueLbl)
            valueLbl.Location = reference_counter_lbl.Location
            valueLbl.BringToFront()
            RepLayoutPanel.Controls.Add(repPanel)
            Dim standingCombo As New ComboBox
            standingCombo.Name = "rep" & pRepu.faction.ToString() & "_standing_combo"
            standingCombo.Location = reference_standing_combo.Location
            For Each itm As String In reference_standing_combo.Items
                standingCombo.Items.Add(itm)
            Next
            standingCombo.SelectedIndex = pRepu.status
            Select Case pRepu.status
                Case 0 : progressPanel.BackColor = Color.DarkRed
                Case 1 : progressPanel.BackColor = Color.Red
                Case 2 : progressPanel.BackColor = Color.Red
                Case 3 : progressPanel.BackColor = Color.Yellow
                Case 4 : progressPanel.BackColor = Color.Green
                Case 5 : progressPanel.BackColor = Color.Green
                Case 6 : progressPanel.BackColor = Color.Green
                Case 7 : progressPanel.BackColor = Color.LightGreen
            End Select
            standingCombo.Tag = pRepu
            'Dim RM as New ResourceManager("NCFramework.UserMessages", System.Reflection.Assembly.GetExecutingAssembly())
            standingCombo.Text = GetUserMessage("standing_" & pRepu.status.ToString)
            repPanel.Controls.Add(standingCombo)
            AddHandler standingCombo.SelectedIndexChanged, AddressOf StandingChanged
        Next
    End Sub
    Private Sub slider_slide(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim slider As TrackBar = sender
        If Not slider.Value = 0 Then
            For Each pCtrl As Control In RepLayoutPanel.Controls
                If pCtrl.Name.Contains("rep" & slider.Tag.faction.ToString() & "_pnl") Then
                    Dim namectrl() As Control = pCtrl.Controls.Find("rep" & slider.Tag.faction.ToString() & "_value_txtbox", True)
                    Dim aCtrl As Control
                    For Each aCtrl In namectrl
                        DirectCast(aCtrl, TextBox).Text = slider.Value.ToString()
                    Next
                    Dim namectrl2() As Control = pCtrl.Controls.Find("rep" & slider.Tag.faction.ToString() & "_value_lbl", True)
                    Dim aCtrl2 As Control
                    For Each aCtrl2 In namectrl2
                        DirectCast(aCtrl2, Label).Text = slider.Value.ToString() & "/" & slider.Maximum.ToString
                    Next
                    For Each subCtrl As Control In pCtrl.Controls
                        If subCtrl.Name.Contains("rep" & slider.Tag.faction.ToString() & "_sliderBg_pnl") Then
                            For Each subsubCtrl As Control In subCtrl.Controls
                                If subsubCtrl.Name.Contains("rep" & slider.Tag.faction.ToString() & "_progress_pnl") Then
                                    setPanelPercentage(subsubCtrl, slider.Value / slider.Maximum)
                                    Dim loc As Integer = currentViewedCharSet.PlayerReputation.FindIndex(Function(rep) (pCtrl.Tag.Equals(rep)))
                                    pCtrl.Tag.value = slider.Value
                                    pCtrl.Tag = updateReputationStanding(pCtrl.Tag)
                                    If currentEditedCharSet Is Nothing Then currentEditedCharSet = currentViewedCharSet
                                    currentEditedCharSet.PlayerReputation(loc) = pCtrl.Tag
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        Else
            For Each pCtrl As Control In RepLayoutPanel.Controls
                If pCtrl.Name.Contains("rep" & slider.Tag.faction.ToString() & "_pnl") Then
                    Dim namectrl() As Control = pCtrl.Controls.Find("rep" & slider.Tag.faction.ToString() & "_value_txtbox", True)
                    Dim aCtrl As Control
                    For Each aCtrl In namectrl
                        DirectCast(aCtrl, TextBox).Text = slider.Value.ToString()
                    Next
                    Dim namectrl2() As Control = pCtrl.Controls.Find("rep" & slider.Tag.faction.ToString() & "_value_lbl", True)
                    Dim aCtrl2 As Control
                    For Each aCtrl2 In namectrl2
                        DirectCast(aCtrl2, Label).Text = slider.Value.ToString() & "/" & slider.Maximum.ToString
                    Next
                    For Each subCtrl As Control In pCtrl.Controls
                        If subCtrl.Name.Contains("rep" & slider.Tag.faction.ToString() & "_sliderBg_pnl") Then
                            For Each subsubCtrl As Control In subCtrl.Controls
                                If subsubCtrl.Name.Contains("rep" & slider.Tag.faction.ToString() & "_progress_pnl") Then
                                    setPanelPercentage(subsubCtrl, 0)
                                    Dim loc As Integer = currentViewedCharSet.PlayerReputation.FindIndex(Function(rep) (pCtrl.Tag.Equals(rep)))
                                    pCtrl.Tag.value = slider.Value
                                    pCtrl.Tag = updateReputationStanding(pCtrl.Tag)
                                    If currentEditedCharSet Is Nothing Then currentEditedCharSet = currentViewedCharSet
                                    currentEditedCharSet.PlayerReputation(loc) = pCtrl.Tag
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        End If

    End Sub
    Private Sub setPanelPercentage(ByRef RepPanel As Panel, ByVal percentage As Decimal)
        Dim lengthrange As Integer = panelMaxLength - panelMinLength
        RepPanel.Size = New Point(percentage * lengthrange + panelMinLength, RepPanel.Size.Height)
    End Sub
    Private Sub StandingChanged(sender As Object, e As EventArgs)
        Dim combo As ComboBox = sender
        Dim max As Integer
        Dim col As Color
        Select Case combo.SelectedIndex
            Case 0 : col = Color.DarkRed : max = 8400
            Case 1 : col = Color.Red : max = 3000
            Case 2 : col = Color.Red : max = 3000
            Case 3 : col = Color.Yellow : max = 3000
            Case 4 : col = Color.Green : max = 6000
            Case 5 : col = Color.Green : max = 12000
            Case 6 : col = Color.Green : max = 21000
            Case 7 : col = Color.LightGreen : max = 999
        End Select

        For Each pCtrl As Control In RepLayoutPanel.Controls
            If pCtrl.Name.Contains("rep" & combo.Tag.faction.ToString() & "_pnl") Then
                Dim loc As Integer = currentViewedCharSet.PlayerReputation.FindIndex(Function(rep) (pCtrl.Tag.Equals(rep)))
                pCtrl.Tag.value = 0
                pCtrl.Tag.max = max
                pCtrl.Tag.status = combo.SelectedIndex
                pCtrl.Tag = updateReputationStanding(pCtrl.Tag)
                If currentEditedCharSet Is Nothing Then currentEditedCharSet = currentViewedCharSet
                currentEditedCharSet.PlayerReputation(loc) = pCtrl.Tag
                DirectCast(findControl("rep" & combo.Tag.faction.ToString() & "_slider", pCtrl), TrackBar).Value = 0
                DirectCast(findControl("rep" & combo.Tag.faction.ToString() & "_slider", pCtrl), TrackBar).Maximum = max
                DirectCast(findControl("rep" & combo.Tag.faction.ToString() & "_value_lbl", pCtrl), Label).Text = "0/" & max.ToString
                DirectCast(findControl("rep" & combo.Tag.faction.ToString() & "_value_txtbox", pCtrl), TextBox).Text = "0"
                Dim xctrl As Control = findControl("rep" & combo.Tag.faction.ToString() & "_sliderBg_pnl", pCtrl)
                Dim progresspanel As Control = findControl("rep" & combo.Tag.faction.ToString() & "_progress_pnl", xctrl)
                DirectCast(progresspanel, Panel).BackColor = col
                setPanelPercentage(progresspanel, 0)
            End If
        Next


    End Sub
    Private Sub txt_enter(sender As Object, e As EventArgs)
        lasttxtvalue = sender.text
    End Sub
    Private Sub txt_changed(sender As Object, e As EventArgs)
        valueisok = False
        Dim txtbox As TextBox = sender
        If Not txtbox.Text.Length < 1 Then
            Dim int As Integer = TryInt(txtbox.Text)
            If Not int = 0 OrElse txtbox.Text = "0" Then
                For Each pCtrl As Control In RepLayoutPanel.Controls
                    If pCtrl.Name.Contains("rep" & txtbox.Tag.faction.ToString() & "_pnl") Then
                        If int <= pCtrl.Tag.max And int >= 0 Then
                            Dim loc As Integer = currentViewedCharSet.PlayerReputation.FindIndex(Function(rep) (pCtrl.Tag.Equals(rep)))
                            DirectCast(findControl("rep" & pCtrl.Tag.faction.ToString() & "_slider", pCtrl), TrackBar).Value = int
                            DirectCast(findControl("rep" & pCtrl.Tag.faction.ToString() & "_value_lbl", pCtrl), Label).Text = int.ToString() & "/" & pCtrl.Tag.max.ToString
                            Dim xctrl As Control = findControl("rep" & pCtrl.Tag.faction.ToString() & "_sliderBg_pnl", pCtrl)
                            Dim progresspanel As Control = findControl("rep" & pCtrl.Tag.faction.ToString() & "_progress_pnl", xctrl)
                            setPanelPercentage(progresspanel, int / pCtrl.Tag.max)
                            pCtrl.Tag.value = int
                            valueisok = True
                            If currentEditedCharSet Is Nothing Then currentEditedCharSet = currentViewedCharSet
                            currentEditedCharSet.PlayerReputation(loc) = pCtrl.Tag
                        End If
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub txt_left(sender As Object, e As EventArgs)
        Dim txtbox As TextBox = sender
        If Not valueisok Then
            txtbox.Text = lasttxtvalue
        End If
    End Sub
    Private Function findControl(ByVal controlname As String, ByVal repuControl As Control) As Control
        Dim namectrl() As Control = repuControl.Controls.Find(controlname, True)
        Return namectrl(0)
    End Function
    Private Sub reference_trackbar_Scroll(sender As Object, e As EventArgs) Handles reference_trackbar.Scroll

    End Sub

    Private Sub Reputation_interface_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub




    Private Sub reference_txtbox_TextChanged(sender As Object, e As EventArgs) Handles reference_txtbox.TextChanged

    End Sub

    Private Sub add_pic_Click(sender As Object, e As EventArgs) Handles add_pic.Click
        Dim retnvalue As Integer = TryInt(InputBox("Enter faction id: ", "Add faction", "0"))
        Userwait.Show()
        Application.DoEvents()
        If Not retnvalue = 0 Then
            Dim client As New WebClient
            client.CheckProxy()
            Try
                If Not client.DownloadString("http://wowhead.com/faction=" & retnvalue.ToString()).Contains("<div id=""inputbox-error"">This faction doesn't exist.</div>") Then
                    For Each opRepu As Reputation In currentViewedCharSet.PlayerReputation
                        If opRepu.faction = retnvalue Then
                            Dim RM2 As New ResourceManager("NCFramework.UserMessages", System.Reflection.Assembly.GetExecutingAssembly())
                            MsgBox(RM2.GetString("factionalreadypresent"), MsgBoxStyle.Critical, "Error")
                            Userwait.Close()
                            Exit Sub
                        End If
                    Next
                    Dim pRepu As New Reputation
                    With pRepu
                        .faction = retnvalue
                        .flags = 1
                        .name = splitString(client.DownloadString("http://wowhead.com/faction=" & retnvalue.ToString()), "<title>", " - Faction - World")
                        .max = 3000
                        .standing = 0
                        .status = 3
                        .value = 0
                    End With
                    Dim repPanel As New Panel
                    repPanel.Name = "rep" & pRepu.faction.ToString() & "_pnl"
                    repPanel.Size = referencePanel.Size
                    repPanel.Tag = pRepu
                    repPanel.BackColor = Color.Silver
                    Dim repNameLable As New Label
                    repNameLable.Name = "rep" & pRepu.faction.ToString() & "_name_lbl"
                    repNameLable.Text = pRepu.name
                    repNameLable.Tag = pRepu
                    repPanel.Controls.Add(repNameLable)
                    repNameLable.Location = reference_name_lbl.Location
                    Dim sliderBgPanel As New Panel
                    sliderBgPanel.Name = "rep" & pRepu.faction.ToString() & "_sliderBg_pnl"
                    sliderBgPanel.Size = reference_sliderbg_panel.Size
                    sliderBgPanel.BackgroundImage = My.Resources.repbg1
                    sliderBgPanel.BackgroundImageLayout = ImageLayout.Stretch
                    sliderBgPanel.Tag = pRepu
                    Dim progressPanel As New Panel
                    progressPanel.Name = "rep" & pRepu.faction.ToString() & "_progress_pnl"
                    progressPanel.Size = reference_percentage_panel.Size
                    progressPanel.BackColor = Color.Yellow
                    progressPanel.Tag = pRepu
                    sliderBgPanel.Controls.Add(progressPanel)
                    progressPanel.Location = reference_percentage_panel.Location
                    repPanel.Controls.Add(sliderBgPanel)
                    setPanelPercentage(progressPanel, pRepu.value / pRepu.max)
                    sliderBgPanel.Location = reference_sliderbg_panel.Location
                    Dim slider As New TrackBar
                    slider.Name = "rep" & pRepu.faction.ToString() & "_slider"
                    slider.Maximum = pRepu.max
                    slider.Value = pRepu.value
                    slider.Size = reference_trackbar.Size
                    slider.Tag = pRepu
                    slider.TickStyle = TickStyle.None
                    repPanel.Controls.Add(slider)
                    slider.Location = reference_trackbar.Location
                    AddHandler slider.Scroll, AddressOf slider_slide '//Use MouseUp event for better performance 
                    Dim value_txtbox As New TextBox
                    value_txtbox.Name = "rep" & pRepu.faction.ToString() & "_value_txtbox"
                    value_txtbox.Size = reference_txtbox.Size
                    value_txtbox.Text = pRepu.value
                    value_txtbox.Tag = pRepu
                    repPanel.Controls.Add(value_txtbox)
                    value_txtbox.Location = reference_txtbox.Location
                    AddHandler value_txtbox.TextChanged, AddressOf txt_changed
                    AddHandler value_txtbox.Enter, AddressOf txt_enter
                    AddHandler value_txtbox.Leave, AddressOf txt_left
                    Dim valueLbl As New Label
                    valueLbl.Name = "rep" & pRepu.faction.ToString() & "_value_lbl"
                    valueLbl.Text = pRepu.value.ToString & "/" & pRepu.max.ToString()
                    valueLbl.Font = reference_counter_lbl.Font
                    valueLbl.ForeColor = reference_counter_lbl.ForeColor
                    valueLbl.BackColor = reference_counter_lbl.BackColor
                    valueLbl.Tag = pRepu
                    valueLbl.AutoSize = True
                    repPanel.Controls.Add(valueLbl)
                    valueLbl.Location = reference_counter_lbl.Location
                    valueLbl.BringToFront()
                    RepLayoutPanel.Controls.Add(repPanel)
                    RepLayoutPanel.Controls.SetChildIndex(RepLayoutPanel.Controls(RepLayoutPanel.Controls.Count - 1), 1)
                    Dim standingCombo As New ComboBox
                    standingCombo.Name = "rep" & pRepu.faction.ToString() & "_standing_combo"
                    standingCombo.Location = reference_standing_combo.Location
                    For Each itm As String In reference_standing_combo.Items
                        standingCombo.Items.Add(itm)
                    Next
                    standingCombo.SelectedIndex = pRepu.status
                    Select Case pRepu.status
                        Case 0 : progressPanel.BackColor = Color.DarkRed
                        Case 1 : progressPanel.BackColor = Color.Red
                        Case 2 : progressPanel.BackColor = Color.Red
                        Case 3 : progressPanel.BackColor = Color.Yellow
                        Case 4 : progressPanel.BackColor = Color.Green
                        Case 5 : progressPanel.BackColor = Color.Green
                        Case 6 : progressPanel.BackColor = Color.Green
                        Case 7 : progressPanel.BackColor = Color.LightGreen
                    End Select
                    standingCombo.Tag = pRepu
                    'Dim RM as New ResourceManager("NCFramework.UserMessages", System.Reflection.Assembly.GetExecutingAssembly())
                    standingCombo.Text = GetUserMessage("standing_" & pRepu.status.ToString)
                    repPanel.Controls.Add(standingCombo)
                    AddHandler standingCombo.SelectedIndexChanged, AddressOf StandingChanged
                    If currentEditedCharSet Is Nothing Then currentEditedCharSet = currentViewedCharSet
                    currentEditedCharSet.PlayerReputation.Add(pRepu)
                    MsgBox(GetUserMessage("factionadded"), , "Info")
                Else
                    'Dim RM as New ResourceManager("NCFramework.UserMessages", System.Reflection.Assembly.GetExecutingAssembly())
                    MsgBox(GetUserMessage("invalidrepid"), MsgBoxStyle.Critical, "Error")
                End If
            Catch ex As Exception
                'Dim RM as New ResourceManager("NCFramework.UserMessages", System.Reflection.Assembly.GetExecutingAssembly())
                MsgBox(GetUserMessage("invalidrepid"), MsgBoxStyle.Critical, "Error")
            End Try

        Else
            'Dim RM as New ResourceManager("NCFramework.UserMessages", System.Reflection.Assembly.GetExecutingAssembly())
            MsgBox(GetUserMessage("invalidrepid"), MsgBoxStyle.Critical, "Error")
        End If
        Userwait.Close()
    End Sub

    Private ptMouseDownLocation As Point
    Private Sub me_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ptMouseDownLocation = e.Location
        End If
    End Sub

    Private Sub me_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Location = e.Location - ptMouseDownLocation + Location
        End If
    End Sub
    Private Sub highlighter_MouseEnter(sender As Object, e As EventArgs) Handles highlighter1.MouseEnter, highlighter2.MouseEnter
        sender.backgroundimage = My.Resources.highlight
    End Sub

    Private Sub highlighter_MouseLeave(sender As Object, e As EventArgs) Handles highlighter1.MouseLeave, highlighter2.MouseLeave
        sender.backgroundimage = Nothing
    End Sub

    Private Sub highlighter2_Click(sender As Object, e As EventArgs) Handles highlighter2.Click
        Me.Close()
    End Sub

    Private Sub highlighter1_Click(sender As Object, e As EventArgs) Handles highlighter1.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub header_MouseDown(sender As Object, e As MouseEventArgs) Handles header.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ptMouseDownLocation = e.Location
        End If
    End Sub


    Private Sub header_MouseMove(sender As Object, e As MouseEventArgs) Handles header.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Location = e.Location - ptMouseDownLocation + Location
        End If
    End Sub

    Private Sub header_Paint(sender As Object, e As PaintEventArgs) Handles header.Paint

    End Sub

    Private Sub RepLayoutPanel_Paint(sender As Object, e As PaintEventArgs) Handles RepLayoutPanel.Paint

    End Sub
End Class