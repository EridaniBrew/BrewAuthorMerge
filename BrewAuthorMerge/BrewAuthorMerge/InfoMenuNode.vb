Public Class InfoMenuNode
    Enum MenuNodeType
        MainMenu         ' Constants for nodeType. Also keys for imageList. ToString gives the name
        navBar
        mainDiv         ' <div class="mainDiv">
        ASPif           ' <!--<% } %>-->
        ASPElse
        ASPEnd
        divComment      ' <div style="text-align:left;margin:0">Users see these:</div>
        topItem
        dropMenu
        subMenu
        subItem         ' <div class="subItem"><a href="javascript:;" title="Image multiple targets using an observing plan" onClick="story.displayTiddler(this,'Multiple Objects (Plan)',null,config.options.chkAnimate,false)">Multiple Objects (Plan)</a></div>
        subSubItem      ' <div class="subSubItem"><a href="javascript:;" title="Status and control center for the observatory" onClick="story.displayTiddler(this,'System Status',null,config.options.chkAnimate,false)">System Status Disp.</a></div>
        divTrailer      ' </div>
        ModMainMenu         ' these reflect menu items which have been imported from the OLD file
        ModNavBar
        ModmainDiv         ' <div class="mainDiv">
        ModASPif             ' <!--<% } %>-->
        ModASPElse
        ModASPEnd
        ModdivComment      ' <div style="text-align:left;margin:0">Users see these:</div>
        ModTopItem
        ModDropMenu
        ModSubMenu
        ModsubItem         ' <div class="subItem"><a href="javascript:;" title="Image multiple targets using an observing plan" onClick="story.displayTiddler(this,'Multiple Objects (Plan)',null,config.options.chkAnimate,false)">Multiple Objects (Plan)</a></div>
        ModsubSubItem      ' <div class="subSubItem"><a href="javascript:;" title="Status and control center for the observatory" onClick="story.displayTiddler(this,'System Status',null,config.options.chkAnimate,false)">System Status Disp.</a></div>
        ModdivTrailer      ' </div>
        WarnMainMenu         ' these reflect menu items which have been imported from the OLD file
        WarnNavBar
        WarnmainDiv         ' <div class="mainDiv">
        WarnASPif             ' <!--<% } %>-->
        WarnASPElse
        WarnASPEnd
        WarndivComment      ' <div style="text-align:left;margin:0">Users see these:</div>
        WarnTopItem
        WarnDropMenu
        WarnSubMenu
        WarnsubItem         ' <div class="subItem"><a href="javascript:;" title="Image multiple targets using an observing plan" onClick="story.displayTiddler(this,'Multiple Objects (Plan)',null,config.options.chkAnimate,false)">Multiple Objects (Plan)</a></div>
        WarnsubSubItem      ' <div class="subSubItem"><a href="javascript:;" title="Status and control center for the observatory" onClick="story.displayTiddler(this,'System Status',null,config.options.chkAnimate,false)">System Status Disp.</a></div>
        WarndivTrailer      ' </div>
        Unused              ' used for items we don't process/have already processed
    End Enum

    Protected mName As String
    Protected mNodetype As MenuNodeType


    Public Sub New(name As String, nodeType As MenuNodeType)
        mName = name
        mNodetype = nodeType
    End Sub

    Public Property Name As String
        Get
            Return mName
        End Get
        Set(value As String)
            mName = value
        End Set
    End Property


    Public Property NodeType As MenuNodeType
        Get
            Return mNodetype
        End Get
        Set(value As MenuNodeType)
            mNodetype = value
        End Set
    End Property

    Public Overridable Function TextPart1(encode As Boolean) As String
        ' encode = true means to re-encode everything
        Dim s As String = ""
        s = mName
        Return s
    End Function

    Public Overridable Function TextPart2(encode As Boolean) As String
        ' encode = true means to re-encode everything
        Dim s As String = ""

        Return s
    End Function

End Class



Class InfoMainDiv
    ' MainDiv stuff is combined into a single mainDiv structure, combining the
    '   Name - either from topItem, or ASP name if no mainDiv
    '   (optional) ASPbefore (IF statement),
    '   (optional) CommentBefore
    '   (optional) mainDiv with 4 lines for mainDiv, topItem, dropMenu, and subMenu pieces. 
    '       These will all appear as one entry in the displayed tree
    '   (optional) CommentAfter 
    '   (optional) ASPafter }
    ' Possible configurations:
    '       ASP Only                MainDiv only            Combined ASP+Main
    '   Name = ASP nav 1        Name = Authoring        Name = Authoring
    '   ASPbefore                                       ASPbefore
    '   commentBefore                                   commentBefore
    '                           MainDiv 4 lines         MainDiv 4 lines
    '   CommentAfter                                    CommentAfter
    '   ASPafter                                        ASPafter
    '
    Inherits InfoMenuNode

    Public aspIf As String
    Public commentBefore As String

    Public mainDiv As String
    Public mainDivTrailer As String
    Public topItem As String
    Public dropMenu As String
    Public dropMenuTrailer As String
    Public subMenu As String
    Public subMenuTrailer As String

    Public commentAfter As String
    Public aspBrace As String

    ' Keep a list of SubItem info objects.
    ' When the MainDiv treenode is created, add these subitem nodes as well
    Private subItemList As List(Of InfoMenuNode)

    Public Sub New(name As String, nodeType As MenuNodeType)
        MyBase.New(name, nodeType)

        aspIf = ""
        commentBefore = ""

        mainDiv = ""
        mainDivTrailer = ""
        topItem = ""
        dropMenuTrailer = ""
        dropMenu = ""
        subMenu = ""
        subMenuTrailer = ""

        commentAfter = ""
        aspBrace = ""

        subItemList = New List(Of InfoMenuNode)

    End Sub

    Public Overrides Function TextPart1(encode As Boolean) As String
        ' encode = true means to re-encode everything
        Dim s As String = ""
        If (aspIf <> "") Then
            If (encode) Then
                s = s & aspIf & "\n"
            Else
                s = s & aspIf & vbCrLf
            End If
        End If
        If (commentBefore <> "") Then
            If (encode) Then
                s = s & commentBefore & "\n"
            Else
                s = s & commentBefore & vbCrLf
            End If
        End If
        If (mainDiv <> "") Then
            If (encode) Then
                s = s & mainDiv & "\n" & topItem & "\n" & dropMenu & "\n" & subMenu & "\n"
            Else
                s = s & mainDiv & vbCrLf & topItem & vbCrLf & dropMenu & vbCrLf & subMenu & vbCrLf
            End If
        End If
        If (encode) Then
            s = System.Web.HttpUtility.HtmlEncode(s)
            s = s.Replace("&#39;", "'")
        End If

        Return s
    End Function

    Public Overrides Function TextPart2(encode As Boolean) As String
        ' encode = true means to re-encode everything
        Dim s As String = ""

        If (mainDiv <> "") Then
            If (encode) Then
                s = s & subMenuTrailer & "\n" & dropMenuTrailer & "\n" & mainDivTrailer & "\n"
            Else
                s = s & subMenuTrailer & vbCrLf & dropMenuTrailer & vbCrLf & mainDivTrailer & vbCrLf
            End If
        End If
        If (commentAfter <> "") Then
            If (encode) Then
                s = s & commentAfter & "\n"
            Else
                s = s & commentAfter & vbCrLf
            End If
        End If
        If (aspBrace <> "") Then
            If (encode) Then
                s = s & aspBrace & "\n"
            Else
                s = s & aspBrace & vbCrLf
            End If
        End If

        If (encode) Then
            s = System.Web.HttpUtility.HtmlEncode(s)
            s = s.Replace("&#39;", "'")
        End If

        Return s
    End Function

    Public Sub AddSubItem(info As InfoMenuNode)
        ' Add this subitem to the list
        ' info could be a subitem or an asp piece
        subItemList.Add(info)
    End Sub

    Public Function GetSubList() As List(Of InfoMenuNode)
        Return subItemList
    End Function


End Class



Class InfoSubItem
    Inherits InfoMenuNode

    Public entryText As String         ' line of menu info
    'Public referenceTiddlerKey As String     ' subitem and subSubitem may refer to running this tiddler

    Private subsubItemList As List(Of InfoSubItem)

    Public Sub New(name As String, nodeType As MenuNodeType, theText As String)
        MyBase.New(name, nodeType)

        entryText = theText
        'referenceTiddlerKey = ""
        subsubItemList = New List(Of InfoSubItem)
    End Sub

    Public Overrides Function TextPart1(encode As Boolean) As String
        ' encode = true means to re-encode everything
        Dim s As String = ""

        If (entryText <> "") Then
            If (encode) Then
                s = s & entryText & "\n"
            Else
                s = s & entryText & vbCrLf
            End If
        End If

        If (encode) Then
            s = System.Web.HttpUtility.HtmlEncode(s)
            s = s.Replace("&#39;", "'")
        End If

        Return s
    End Function
    Public Overrides Function TextPart2(encode As Boolean) As String
        ' encode = true means to re-encode everything
        Dim s As String = ""

        Return s
    End Function

    Public Sub AddSubSubItem(info As InfoMenuNode)
        ' Add this item to the list
        ' info could be a subsubitem or an asp piece
        subsubItemList.Add(info)
    End Sub

    Public Function GetSubSubList() As List(Of InfoSubItem)
        Return subsubItemList
    End Function

    Public Sub Copy(src As InfoSubItem)

    End Sub

End Class



Class InfoRootItem
    Inherits InfoMenuNode

    Public mainMenu As String
    Public navBar As String
    Public navBarTrailer As String
    Public mainMenuTrailer As String

    Public Sub New(name As String, nodeType As MenuNodeType)
        MyBase.New(name, nodeType)

        mainMenu = ""
        navBar = ""
        navBarTrailer = ""
        mainMenuTrailer = ""
    End Sub

    Public Overrides Function TextPart1(encode As Boolean) As String
        ' encode = true means to re-encode everything
        Dim s As String = ""
        If (mainMenu <> "") Then
            If encode Then
                ' just encode the last part
                s = s & mainMenu.Replace("<html>", "&lt;html&gt;\n")
            Else
                s = s & mainMenu & vbCrLf
            End If
            If (navBar <> "") Then
                If encode Then
                    s = s & System.Web.HttpUtility.HtmlEncode(navBar) & "\n"
                    s = s.Replace("&#39;", "'")
                Else
                    s = s & navBar & vbCrLf
                End If
            End If

        End If

        Return s
    End Function

    Public Overrides Function TextPart2(encode As Boolean) As String
        ' encode = true means to re-encode everything
        Dim s As String = ""

        If (navBarTrailer <> "") Then
            If (encode) Then
                s = s & System.Web.HttpUtility.HtmlEncode(navBarTrailer) & "\n"
                s = s.Replace("&#39;", "'")
            Else
                s = s & navBarTrailer & vbCrLf
            End If
        End If
        If (mainMenuTrailer <> "") Then
            If (encode) Then
                s = s & System.Web.HttpUtility.HtmlEncode(mainMenuTrailer)
                s = s.Replace("&#39;", "'")
                s = s.Replace(vbCrLf, "\n")
                s = s.Replace("&gt;&gt;\n&lt;/div&gt;", "&gt;&gt;\n</div>")
            Else
                s = s & mainMenuTrailer & vbCrLf
            End If
        End If

        Return s
    End Function

    Public Sub Copy(src As InfoRootItem)
        mainMenu = src.mainMenu
        navBar = src.navBar
        navBarTrailer = src.navBarTrailer
        mainMenuTrailer = src.mainMenuTrailer
    End Sub
End Class
