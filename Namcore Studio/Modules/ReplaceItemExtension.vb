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
'*      /Filename:      ReplaceItemExtension
'*      /Description:   Extension to update an existing item by new id
'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
Imports System.Runtime.CompilerServices
Imports NCFramework.Framework.Functions
Imports NCFramework.Framework.Module

Namespace Modules
    Module ReplaceItemExtension
        ''' <summary>
        '''     Replaces an Item
        ''' </summary>
        <Extension()>
        Public Function ReplaceItem(ByRef sourceItem As Item, ByVal newitemid As Integer) As Item
            Dim itm As Item
            itm = SourceItem
            itm.Id = newitemid
            itm.Name = GetNameOfItem(newitemid.ToString())
            itm.Image = GetIconByItemId(newitemid)
            itm.Rarity = GetRarityByItemId(newitemid)
            Return itm
        End Function
    End Module
End Namespace