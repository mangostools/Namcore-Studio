﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Dieser Code wurde von einem Tool generiert.
'     Laufzeitversion:4.0.30319.17929
'
'     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
'     der Code erneut generiert wird.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'Diese Klasse wurde von der StronglyTypedResourceBuilder automatisch generiert
    '-Klasse über ein Tool wie ResGen oder Visual Studio automatisch generiert.
    'Um einen Member hinzuzufügen oder zu entfernen, bearbeiten Sie die .ResX-Datei und führen dann ResGen
    'mit der /str-Option erneut aus, oder Sie erstellen Ihr VS-Projekt neu.
    '''<summary>
    '''  Eine stark typisierte Ressourcenklasse zum Suchen von lokalisierten Zeichenfolgen usw.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Public Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Gibt die zwischengespeicherte ResourceManager-Instanz zurück, die von dieser Klasse verwendet wird.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Public ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("libnc.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Überschreibt die CurrentUICulture-Eigenschaft des aktuellen Threads für alle
        '''  Ressourcenzuordnungen, die diese stark typisierte Ressourcenklasse verwenden.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Public Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die avid;avname;avdesc;avcat
        '''6;Stufe 10;Erreicht Stufe 10.;92;
        '''7;Stufe 20;Erreicht Stufe 20.;92;
        '''8;Stufe 30;Erreicht Stufe 30.;92;
        '''9;Stufe 40;Erreicht Stufe 40.;92;
        '''10;Stufe 50;Erreicht Stufe 50.;92;
        '''11;Stufe 60;Erreicht Stufe 60.;92;
        '''12;Stufe 70;Erreicht Stufe 70.;92;
        '''13;Stufe 80;Erreicht Stufe 80.;92;
        '''15;Jede Menge Haustiere;Sammelt 15 einzigartige Haustiere.;15118;
        '''16;Hat jemand ein Veilchen bestellt?;Erreicht eine unbewaffnete Fertigkeit von 400.;81;
        '''31;Alltägliches;Schließt an fünf aufeinander f [Rest der Zeichenfolge wurde abgeschnitten]&quot;; ähnelt.
        '''</summary>
        Public ReadOnly Property av_de() As String
            Get
                Return ResourceManager.GetString("av_de", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die catid;catmainid;catname
        '''1;-1;Statistiken
        '''21;1;Spieler gegen Spieler
        '''81;-1;Heldentaten
        '''92;-1;Allgemein
        '''95;-1;Spieler gegen Spieler
        '''96;-1;Quests
        '''97;-1;Erkundung
        '''122;1;Tode
        '''123;122;Arenen
        '''124;122;Schlachtfelder
        '''125;122;Dungeons
        '''126;122;Welt
        '''127;122;Wiederbelebung
        '''128;1;Siege
        '''130;1;Charakter
        '''131;1;Körpersprache
        '''132;1;Fertigkeiten
        '''133;1;Quests
        '''134;1;Reise
        '''135;128;Kreaturen
        '''136;128;Ehrenhafte Siege
        '''137;128;Todesstöße
        '''140;130;Vermögen
        '''141;1;Kampf
        '''145;130;Verbrauchsgüter
        '''147;130;Ruf
        '''152;2 [Rest der Zeichenfolge wurde abgeschnitten]&quot;; ähnelt.
        '''</summary>
        Public ReadOnly Property avcat_de() As String
            Get
                Return ResourceManager.GetString("avcat_de", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die effectid;effectname
        '''1;Felsbeißer 3
        '''2;Frostbrand
        '''3;Flammenzunge 3
        '''4;Flammenzunge 2
        '''5;Flammenzunge
        '''6;Felsbeißer 2
        '''7;Tödliches Gift
        '''8;Tödliches Gift II
        '''9;Gift (15 Schaden)
        '''10;Gift (20 Schaden)
        '''11;Gift (25 Schaden)
        '''12;Frostbrand 2
        '''13;Geschärft (+3 Schaden)
        '''14;Geschärft (+4 Schaden)
        '''15;Verstärkt (+8 Rüstung)
        '''16;Verstärkt (+16 Rüstung)
        '''17;Verstärkt (+24 Rüstung)
        '''18;Verstärkt (+32 Rüstung)
        '''19;Beschwert (+2 Schaden)
        '''20;Beschwert (+3 Schaden)
        '''21;Beschwert (+4 Schaden)
        '''22;Verkrüppelungsgift
        '''23; [Rest der Zeichenfolge wurde abgeschnitten]&quot;; ähnelt.
        '''</summary>
        Public ReadOnly Property enchant_name_de() As String
            Get
                Return ResourceManager.GetString("enchant_name_de", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die effectid;effectname
        '''1;Rockbiter 3
        '''2;Frostbrand
        '''3;Flametongue 3
        '''4;Flametongue 2
        '''5;Flametongue
        '''6;Rockbiter 2
        '''7;Deadly Poison
        '''8;Deadly Poison II
        '''9;Poison (15 Dmg)
        '''10;Poison (20 Dmg)
        '''11;Poison (25 Dmg)
        '''12;Frostbrand 2
        '''13;Sharpened (+3 Damage)
        '''14;Sharpened (+4 Damage)
        '''15;Reinforced (+8 Armor)
        '''16;Reinforced (+16 Armor)
        '''17;Reinforced (+24 Armor)
        '''18;Reinforced (+32 Armor)
        '''19;Weighted (+2 Damage)
        '''20;Weighted (+3 Damage)
        '''21;Weighted (+4 Damage)
        '''22;Crippling Poison
        '''23;Mind-numbing Poison II
        '''24; [Rest der Zeichenfolge wurde abgeschnitten]&quot;; ähnelt.
        '''</summary>
        Public ReadOnly Property enchant_name_en() As String
            Get
                Return ResourceManager.GetString("enchant_name_en", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die &lt;entry&gt;2&lt;/entry&gt;&lt;spell&gt;52084&lt;/spell&gt;&lt;entry2&gt;2&lt;/entry2&gt;&lt;spell2&gt;52084&lt;/spell2&gt;
        '''&lt;entry&gt;21&lt;/entry&gt;&lt;spell&gt;12320&lt;/spell&gt;&lt;entry2&gt;21&lt;/entry2&gt;&lt;spell2&gt;12320&lt;/spell2&gt;
        '''&lt;entry&gt;22&lt;/entry&gt;&lt;spell&gt;12297&lt;/spell&gt;&lt;entry2&gt;22&lt;/entry2&gt;&lt;spell2&gt;12297&lt;/spell2&gt;
        '''&lt;entry&gt;61&lt;/entry&gt;&lt;spell&gt;46831&lt;/spell&gt;&lt;entry2&gt;61&lt;/entry2&gt;&lt;spell2&gt;46831&lt;/spell2&gt;
        '''&lt;entry&gt;81&lt;/entry&gt;&lt;spell&gt;52084&lt;/spell&gt;&lt;entry2&gt;81&lt;/entry2&gt;&lt;spell2&gt;52084&lt;/spell2&gt;
        '''&lt;entry&gt;82&lt;/entry&gt;&lt;spell&gt;52085&lt;/spell&gt;&lt;entry2&gt;82&lt;/entry2&gt;&lt;spell2&gt;52085&lt;/spell2&gt;
        '''&lt;entry&gt;101&lt;/entry&gt;&lt;spell&gt;0&lt;/spell&gt; [Rest der Zeichenfolge wurde abgeschnitten]&quot;; ähnelt.
        '''</summary>
        Public ReadOnly Property glyphproperties_335() As String
            Get
                Return ResourceManager.GetString("glyphproperties_335", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die &lt;entry&gt;161&lt;/entry&gt;&lt;spell&gt;54810&lt;/spell&gt;&lt;entry2&gt;161&lt;/entry2&gt;&lt;spell2&gt;54810&lt;/spell2&gt;
        '''&lt;entry&gt;162&lt;/entry&gt;&lt;spell&gt;54811&lt;/spell&gt;&lt;entry2&gt;162&lt;/entry2&gt;&lt;spell2&gt;54811&lt;/spell2&gt;
        '''&lt;entry&gt;163&lt;/entry&gt;&lt;spell&gt;54812&lt;/spell&gt;&lt;entry2&gt;163&lt;/entry2&gt;&lt;spell2&gt;54812&lt;/spell2&gt;
        '''&lt;entry&gt;164&lt;/entry&gt;&lt;spell&gt;54813&lt;/spell&gt;&lt;entry2&gt;164&lt;/entry2&gt;&lt;spell2&gt;54813&lt;/spell2&gt;
        '''&lt;entry&gt;165&lt;/entry&gt;&lt;spell&gt;54815&lt;/spell&gt;&lt;entry2&gt;165&lt;/entry2&gt;&lt;spell2&gt;54815&lt;/spell2&gt;
        '''&lt;entry&gt;166&lt;/entry&gt;&lt;spell&gt;54818&lt;/spell&gt;&lt;entry2&gt;166&lt;/entry2&gt;&lt;spell2&gt;54818&lt;/spell2&gt;
        '''&lt;entry&gt;167&lt;/entry&gt;&lt;s [Rest der Zeichenfolge wurde abgeschnitten]&quot;; ähnelt.
        '''</summary>
        Public ReadOnly Property glyphproperties_434() As String
            Get
                Return ResourceManager.GetString("glyphproperties_434", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die TalentId;Rang1;Rang2;Rang3;Rang4;Rang5
        '''27;11078;11080;0;0;0
        '''1141;18459;18460;54734;0;0
        '''26;11069;12338;12339;12340;12341
        '''34;11119;11120;12846;12847;12848
        '''2212;54747;54749;0;0;0
        '''31;11108;12349;12350;0;0
        '''28;11100;12353;0;0;0
        '''30;11103;12357;12358;0;0
        '''29;11366;0;0;0;0
        '''23;11083;12351;0;0;0
        '''25;11095;12872;12873;0;0
        '''24;11094;13043;0;0;0
        '''1639;29074;29075;29076;0;0
        '''1730;31638;31639;31640;0;0
        '''33;11115;11367;11368;0;0
        '''32;11113;0;0;0;0
        '''1731;31641;31642;0;0;0
        '''35;11124;12378;12398;12399;12400
        '''1733;34293 [Rest der Zeichenfolge wurde abgeschnitten]&quot;; ähnelt.
        '''</summary>
        Public ReadOnly Property talent() As String
            Get
                Return ResourceManager.GetString("talent", resourceCulture)
            End Get
        End Property
    End Module
End Namespace