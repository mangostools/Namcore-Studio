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
'*      /Filename:      Main
'*      /Description:   Main menu
'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

Imports Namcore_Studio_Framework.GlobalVariables
Imports Namcore_Studio_Framework
Imports System.Net

Public Class Main

    Private Sub highlighter_MouseEnter(sender As Object, e As EventArgs) Handles highlighter1.MouseEnter, highlighter2.MouseEnter, highlighter3.MouseEnter, highlighter4.MouseEnter, highlighter5.MouseEnter
        sender.backgroundimage = My.Resources.highlight
    End Sub

    Private Sub highlighter_MouseLeave(sender As Object, e As EventArgs) Handles highlighter1.MouseLeave, highlighter2.MouseLeave, highlighter3.MouseLeave, highlighter4.MouseLeave, highlighter5.MouseLeave
        sender.backgroundimage = Nothing
    End Sub


    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim controlLST As List(Of Control)
        controlLST = FindAllChildren()
        For Each item_control As Control In controlLST
            item_control.SetDoubleBuffered()
        Next
        Me.Text = "NamCore Studio - Development - " & My.Application.Info.Version.ToString() & " - © megasus 2013"
        version_lbl.Text = "NamCore Studio - Development - " & My.Application.Info.Version.ToString() & " - © megasus 2013"
        lastregion = "main"
        procStatus = New Process_status
        procStatus.Show()
      
        If Namcore_Studio_Framework.My.MySettings.Default.proxy_enabled = True Then
            If Namcore_Studio_Framework.My.MySettings.Default.proxy_detect = True Then
                Dim webnet As New WebConnection
                Dim servername As String = webnet.GetProxyServerName()
                Dim serverport As String = webnet.GetProxyServerPort()
                If serverport Is Nothing Then
                    Namcore_Studio_Framework.My.MySettings.Default.proxy_enabled = False
                Else
                    If servername Is Nothing Then
                        Namcore_Studio_Framework.My.MySettings.Default.proxy_enabled = False
                    Else
                        Namcore_Studio_Framework.My.MySettings.Default.proxy_host = servername
                        Namcore_Studio_Framework.My.MySettings.Default.proxy_port = TryInt(serverport)
                        Namcore_Studio_Framework.My.MySettings.Default.fullproxy = New WebProxy(servername & ":" & serverport)
                    End If
                End If
            End If
        End If
        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.SpecialDirectories.Desktop & "/log.txt") Then
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Desktop & "/log.txt")
        End If
        LogAppend("NamCore Studio " & My.Application.Info.Version.ToString() & " loaded", "Main_Main_Load", False)
        LogAppend("System information:", "Main_Main_Load", False)
        LogAppend("/OS NAME: " & My.Computer.Info.OSFullName, "Main_Main_Load", False)
        LogAppend("/OS VERSION: " & My.Computer.Info.OSVersion, "Main_Main_Load", False)
        LogAppend("/OS LANGUAGE: " & My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName, "Main_Main_Load", False)
        LogAppend("/SYSTEM VERSION: " & System.Environment.Version.ToString(), "Main_Main_Load", False)
        LogAppend("/PROCESSOR COUNT: " & (System.Environment.ProcessorCount).ToString(), "Main_Main_Load", False)
        LogAppend("/AVAILABLE PHYSICAL MEMORY: " & (My.Computer.Info.AvailablePhysicalMemory / 1000000000).ToString() & " GB", "Main_Main_Load", False)
        LogAppend("/SCREEN SIZE: " & Screen.PrimaryScreen.Bounds.Width.ToString & "x" & Screen.PrimaryScreen.Bounds.Height.ToString(), "Main_Main_Load", False)
        LogAppend("/APP STARTUP PATH: " & Application.StartupPath, "Main_Main_Load", False)
    End Sub

    Private Sub highlighter1_Click(sender As Object, e As EventArgs) Handles highlighter1.Click
        Me.Hide()
        Live_View.Show()
    End Sub

    Private Sub highlighter3_Click(sender As Object, e As EventArgs) Handles highlighter3.Click
        Me.Hide()
        Armory_interface.Show()
    End Sub
    Private ptMouseDownLocation As Point
    Private Sub Main_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ptMouseDownLocation = e.Location
        End If
    End Sub

    Private Sub Main_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Location = e.Location - ptMouseDownLocation + Location
        End If
    End Sub

    Private Sub highlighter5_Click(sender As Object, e As EventArgs) Handles highlighter5.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub highlighter4_Click(sender As Object, e As EventArgs) Handles highlighter4.Click
        Application.Exit()
    End Sub

    Private Sub settings_bt_Click(sender As Object, e As EventArgs) Handles settings_bt.Click
        Settings_interface.Show()
    End Sub
End Class