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
'*      /Filename:      DBconnect
'*      /Description:   Interface for opening a database connection
'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
Imports NCFramework.My
Imports NCFramework.Framework.Functions
Imports NCFramework.Framework.Module
Imports NCFramework.Framework.Database
Imports Namcore_Studio.Forms.Extension

Namespace Forms
    Public Class DbConnect
        Inherits EventTrigger

        '// Declaration
        ReadOnly _strucCheck As New DbStrucCheck
        '// Declaration

        Private Sub connect_bt_Click(sender As Object, e As EventArgs) Handles connect_bt.Click
            Select Case GlobalVariables.con_operator
                Case 1 'Source connection @live_view
                    GlobalVariables.globChars = New GlobalCharVars()
                    GlobalVariables.globChars.CharacterSets = New List(Of NCFramework.Framework.Module.Character)
                    GlobalVariables.armoryMode = False
                    GlobalVariables.templateMode = False
                    GlobalVariables.con_operator = 0
                    If defaultconn_radio.Checked = True Then
                        If _
                            TestConnection(
                                "server=" & db_address_txtbox.Text & ";Port=" & port_ud.Value.ToString & ";User id=" &
                                userid_txtbox.Text & ";Password=" & password_txtbox.Text & ";Database=" &
                                realmdbname_txtbox.Text) = True Then
                            If _
                                TestConnection(
                                    "server=" & db_address_txtbox.Text & ";Port=" & port_ud.Value.ToString & ";User id=" &
                                    userid_txtbox.Text & ";Password=" & password_txtbox.Text & ";Database=" &
                                    chardbname_txtbox.Text) = True Then
                                GlobalVariables.GlobalConnectionString = "server=" & db_address_txtbox.Text & ";Port=" &
                                                                         port_ud.Value.ToString & ";User id=" &
                                                                         userid_txtbox.Text & ";Password=" &
                                                                         password_txtbox.Text & ";Database=" &
                                                                         chardbname_txtbox.Text &
                                                                         ";Convert Zero Datetime=True"
                                GlobalVariables.GlobalConnectionString_Realm = "server=" & db_address_txtbox.Text &
                                                                               ";Port=" &
                                                                               port_ud.Value.ToString & ";User id=" &
                                                                               userid_txtbox.Text & ";Password=" &
                                                                               password_txtbox.Text & ";Database=" &
                                                                               realmdbname_txtbox.Text &
                                                                               ";Convert Zero Datetime=True"
                                OpenNewMySQLConnection(GlobalVariables.GlobalConnection,
                                                       GlobalVariables.GlobalConnectionString)
                                OpenNewMySQLConnection(GlobalVariables.GlobalConnection_Realm,
                                                       GlobalVariables.GlobalConnectionString_Realm)
                                GlobalVariables.GlobalConnection_Info.ConnectionString = "server=" &
                                                                                         db_address_txtbox.Text &
                                                                                         ";Port=" &
                                                                                         port_ud.Value.ToString &
                                                                                         ";User id=" &
                                                                                         userid_txtbox.Text &
                                                                                         ";Password=" &
                                                                                         password_txtbox.Text &
                                                                                         ";Database=information_schema"
                                _strucCheck.startCheck("trinity", 3, GlobalVariables.GlobalConnection,
                                                       GlobalVariables.GlobalConnection_Realm,
                                                       GlobalVariables.GlobalConnection_Info, chardbname_txtbox.Text,
                                                       realmdbname_txtbox.Text, False) 'todo
                                For Each currentForm As Form In Application.OpenForms
                                    If currentForm.Name = "Live_View" Then
                                        Dim liveview As LiveView = DirectCast(currentForm, LiveView)
                                        liveview.accountview.Items.Clear()
                                        liveview.characterview.Items.Clear()
                                        liveview.loadaccountsandchars()
                                    End If
                                Next
                            Else

                            End If

                        Else

                        End If
                    Else

                    End If
                Case 2 'Target connection @live_view
                    GlobalVariables.con_operator = 0
                    If defaultconn_radio.Checked = True Then
                        If _
                            TestConnection(
                                "server=" & db_address_txtbox.Text & ";Port=" & port_ud.Value.ToString & ";User id=" &
                                userid_txtbox.Text & ";Password=" & password_txtbox.Text & ";Database=" &
                                realmdbname_txtbox.Text) = True Then
                            If _
                                TestConnection(
                                    "server=" & db_address_txtbox.Text & ";Port=" & port_ud.Value.ToString & ";User id=" &
                                    userid_txtbox.Text & ";Password=" & password_txtbox.Text & ";Database=" &
                                    chardbname_txtbox.Text) = True Then
                                GlobalVariables.TargetConnectionString = "server=" & db_address_txtbox.Text & ";Port=" &
                                                                         port_ud.Value.ToString & ";User id=" &
                                                                         userid_txtbox.Text & ";Password=" &
                                                                         password_txtbox.Text & ";Database=" &
                                                                         chardbname_txtbox.Text &
                                                                         ";Convert Zero Datetime=True"
                                GlobalVariables.TargetConnectionString_Realm = "server=" & db_address_txtbox.Text &
                                                                               ";Port=" &
                                                                               port_ud.Value.ToString & ";User id=" &
                                                                               userid_txtbox.Text & ";Password=" &
                                                                               password_txtbox.Text & ";Database=" &
                                                                               realmdbname_txtbox.Text &
                                                                               ";Convert Zero Datetime=True"
                                OpenNewMySQLConnection(GlobalVariables.TargetConnection,
                                                       GlobalVariables.TargetConnectionString)
                                OpenNewMySQLConnection(GlobalVariables.TargetConnection_Realm,
                                                       GlobalVariables.TargetConnectionString_Realm)
                                GlobalVariables.TargetConnRealmDBname = realmdbname_txtbox.Text
                                GlobalVariables.TargetConnCharactersDBname = chardbname_txtbox.Text
                                GlobalVariables.TargetConnection_Info.ConnectionString = "server=" &
                                                                                         db_address_txtbox.Text &
                                                                                         ";Port=" &
                                                                                         port_ud.Value.ToString &
                                                                                         ";User id=" &
                                                                                         userid_txtbox.Text &
                                                                                         ";Password=" &
                                                                                         password_txtbox.Text &
                                                                                         ";Database=information_schema"
                                _strucCheck.startCheck("trinity", 3, GlobalVariables.TargetConnection,
                                                       GlobalVariables.TargetConnection_Realm,
                                                       GlobalVariables.TargetConnection_Info, chardbname_txtbox.Text,
                                                       realmdbname_txtbox.Text, True) 'todo
                                For Each currentForm As Form In Application.OpenForms
                                    If currentForm.Name = "Live_View" Then
                                        Dim liveview As LiveView = DirectCast(currentForm, LiveView)
                                        liveview.target_accounts_tree.Nodes.Clear()
                                        liveview.loadtargetaccountsandchars()
                                    End If
                                Next
                            End If
                        End If
                    End If
            End Select
            Close()
        End Sub

        Private Sub DB_connect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            AddHandler highlighter2.Click, AddressOf highlighter2_Click
            Select Case GlobalVariables.con_operator
                Case 1 : connect_header_label.Text = ResourceHandler.GetUserMessage("connecttosource")
                Case 2 : connect_header_label.Text = ResourceHandler.GetUserMessage("connecttotarget")
            End Select
            If MySettings.Default.server_defaultconn = True Then
                defaultconn_radio.Checked = True
                db_address_txtbox.Text = MySettings.Default.server_address
                port_ud.Value = MySettings.Default.server_port
                userid_txtbox.Text = MySettings.Default.server_login
                password_txtbox.Text = MySettings.Default.server_pass
                chardbname_txtbox.Text = MySettings.Default.server_chardb
                realmdbname_txtbox.Text = MySettings.Default.server_authdb
            Else
                viaserver_radio.Checked = True
                serveraddress_txtbox.Text = MySettings.Default.server_ncremoteaddress
                rmuser_txtbox.Text = MySettings.Default.server_nclogin
            End If
        End Sub

        Private Sub highlighter2_click()
            Close()
        End Sub

        Private Sub savelogin_bt_Click(sender As Object, e As EventArgs) Handles savelogin_bt.Click
            If defaultconn_radio.Checked = True Then
                MySettings.Default.server_defaultconn = True
                MySettings.Default.server_address = db_address_txtbox.Text
                MySettings.Default.server_port = port_ud.Value
                MySettings.Default.server_login = userid_txtbox.Text
                MySettings.Default.server_pass = password_txtbox.Text
                MySettings.Default.server_chardb = chardbname_txtbox.Text
                MySettings.Default.server_authdb = realmdbname_txtbox.Text
                MySettings.Default.Save()
            Else
                MySettings.Default.server_defaultconn = False
                MySettings.Default.server_ncremoteaddress = serveraddress_txtbox.Text
                MySettings.Default.server_nclogin = rmuser_txtbox.Text
                MySettings.Default.Save()
            End If
        End Sub
    End Class
End Namespace