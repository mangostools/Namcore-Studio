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
'*      /Filename:      CharacterAchievementHandler
'*      /Description:   Contains functions for extracting information about the character 
'*                      achievements
'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

Imports NCFramework.EventLogging
Imports NCFramework.Basics
Imports NCFramework.GlobalVariables
Imports NCFramework.CommandHandler
Imports NCFramework.Conversions
Public Class CharacterAchievementHandler
    Public Sub GetCharacterAchievement(ByVal characterGuid As Integer, ByVal setId As Integer, ByVal accountId As Integer)
        LogAppend("Loading character Achievement for characterGuid: " & characterGuid & " and setId: " & setId, "CharacterAchievementsHandler_GetCharacterAchievement", True)
        Select Case sourceCore
            Case "arcemu"
                loadAtArcemu(characterGuid, setId, accountId)
            Case "trinity"
                loadAtTrinity(characterGuid, setId, accountId)
            Case "trinitytbc"
                loadAtTrinityTBC(characterGuid, setId, accountId)
            Case "mangos"
                loadAtMangos(characterGuid, setId, accountId)
            Case Else

        End Select

    End Sub
    Private Sub loadAtArcemu(ByVal charguid As Integer, ByVal tar_setId As Integer, ByVal tar_accountId As Integer)
        LogAppend("Loading character Achievement @loadAtArcemu", "CharacterAchievementHandler_loadAtArcemu", False)
        Dim tmpCharacter As Character = GetCharacterSetBySetId(tar_setId)
        Dim tempdt As DataTable = ReturnDataTable("SELECT " & sourceStructure.av_achievement_col(0) & ", `" & sourceStructure.av_date_col(0) & "` FROM " & sourceStructure.character_achievement_tbl(0) &
                                                  "` WHERE " & sourceStructure.av_guid_col(0) & "='" & charguid.ToString() & "'")
        Try
            Dim lastcount As Integer = tempdt.Rows.Count
            Dim count As Integer = 0
            If Not lastcount = 0 Then
                Do
                    Dim tmpAv As New Achievement
                    tmpAv.Id = TryInt((tempdt.Rows(count).Item(0)).ToString)
                    tmpAv.OwnerSet = tar_setId
                    tmpAv.GainDate = (tempdt.Rows(count).Item(1)).ToString
                    tmpCharacter.Achievements.Add(tmpAv)
                    count += 1
                Loop Until count = lastcount
            Else
                LogAppend("No Achievements found!", "CharacterAchievementHandler_loadAtArcemu", True)
            End If
        Catch ex As Exception
            LogAppend("Something went wrong while loading character Achievements! -> skipping -> Exception is: ###START###" & ex.ToString() & "###END###", "CharacterAchievementHandler_loadAtArcemu", True, True)
            Exit Sub
        End Try
        SetCharacterSet(tar_setId, tmpCharacter)
    End Sub
    Private Sub loadAtTrinity(ByVal charguid As Integer, ByVal tar_setId As Integer, ByVal tar_accountId As Integer)
        LogAppend("Loading character Achievement @loadAtTrinity", "CharacterAchievementHandler_loadAtTrinity", False)
        Dim tmpCharacter As Character = GetCharacterSetBySetId(tar_setId)
        Dim tempdt As DataTable = ReturnDataTable("SELECT " & sourceStructure.av_achievement_col(0) & ", `" & sourceStructure.av_date_col(0) & "` FROM " & sourceStructure.character_achievement_tbl(0) &
                                                  "` WHERE " & sourceStructure.av_guid_col(0) & "='" & charguid.ToString() & "'")
        Try
            Dim lastcount As Integer = tempdt.Rows.Count
            Dim count As Integer = 0
            If Not lastcount = 0 Then
                Do
                    Dim tmpAv As New Achievement
                    tmpAv.Id = TryInt((tempdt.Rows(count).Item(0)).ToString)
                    tmpAv.OwnerSet = tar_setId
                    tmpAv.GainDate = (tempdt.Rows(count).Item(1)).ToString
                    tmpCharacter.Achievements.Add(tmpAv)
                    count += 1
                Loop Until count = lastcount
            Else
                LogAppend("No Achievement found!", "CharacterAchievementHandler_loadAtTrinity", True)
            End If
        Catch ex As Exception
            LogAppend("Something went wrong while loading character Achievement! -> skipping -> Exception is: ###START###" & ex.ToString() & "###END###", "CharacterAchievementHandler_loadAtTrinity", True, True)
            Exit Sub
        End Try
        SetCharacterSet(tar_setId, tmpCharacter)
    End Sub
    Private Sub loadAtTrinityTBC(ByVal charguid As Integer, ByVal tar_setId As Integer, ByVal tar_accountId As Integer)

    End Sub
    Private Sub loadAtMangos(ByVal charguid As Integer, ByVal tar_setId As Integer, ByVal tar_accountId As Integer)
        LogAppend("Loading character Achievement @loadAtMangos", "CharacterAchievementHandler_loadAtMangos", False)
        Dim tmpCharacter As Character = GetCharacterSetBySetId(tar_setId)
        Dim tempdt As DataTable = ReturnDataTable("SELECT " & sourceStructure.av_achievement_col(0) & ", `" & sourceStructure.av_date_col(0) & "` FROM " & sourceStructure.character_achievement_tbl(0) &
                                                  "` WHERE " & sourceStructure.av_guid_col(0) & "='" & charguid.ToString() & "'")
        Try
            Dim lastcount As Integer = tempdt.Rows.Count
            Dim count As Integer = 0
            If Not lastcount = 0 Then
                Do
                    Dim tmpAv As New Achievement
                    tmpAv.Id = TryInt((tempdt.Rows(count).Item(0)).ToString)
                    tmpAv.OwnerSet = tar_setId
                    tmpAv.GainDate = (tempdt.Rows(count).Item(1)).ToString
                    tmpCharacter.Achievements.Add(tmpAv)
                    count += 1
                Loop Until count = lastcount
            Else
                LogAppend("No Achievement found!", "CharacterAchievementHandler_loadAtMangos", True)
            End If
        Catch ex As Exception
            LogAppend("Something went wrong while loading character Achievement! -> skipping -> Exception is: ###START###" & ex.ToString() & "###END###", "CharacterAchievementHandler_loadAtMangos", True, True)
            Exit Sub
        End Try
        SetCharacterSet(tar_setId, tmpCharacter)
    End Sub
End Class