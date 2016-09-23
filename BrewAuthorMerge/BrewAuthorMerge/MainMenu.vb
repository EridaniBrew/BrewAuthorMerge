Public Class MainMenu
    ' This class parses the MainMenu tiddler, putting it into a TreeView control for display
    ' The TreeView also serves as the data structure for merging MainMenus from two files
    '
    ' The tiddler breaks down into something like
    '
    '<div tiddler = "MainMenu" modifier="YourName" modified="201509231709" created="200609122139" tags="UserContent systemContent"><html>
    '<div Class="navbar">
    '	<!--<% if(false) { %>-->
    '	<div Class="mainDiv">
    '		<div Class="topItem" >Authoring</div>
    '		<div Class="dropMenu" >
    '			<div Class="subMenu" style="display:none;">
    '				<div Class="subItem"><a href="javascript:;" title="Authoring welcome and contents" onClick="story.displayTiddler(this,'Authoring System',null,config.options.chkAnimate,false)">Welcome</a></div>
    '				<div Class="subItem"><a href="javascript:;" title="Critical settings before authoring" onClick="story.displayTiddler(this,'Authoring Setup',null,config.options.chkAnimate,false)">Setup</a> (Of required)</div>
    '				<div Class="subItem"><a href="javascript:;" title="Overview of the authoring process" onClick="story.displayTiddler(this,'Authoring Roadmap',null,config.options.chkAnimate,false)">Roadmap</a></div>
    '				<div Class="subItem"><a href="javascript:;" title="Markup for text styles" onClick="story.displayTiddler(this,'Basic Formatting',null,config.options.chkAnimate,false)">Basic Formatting</a></div>
    '				<div Class="subItem"><a href="javascript:;" title="Practice formatting here" onClick="story.displayTiddler(this,'Sandbox',null,config.options.chkAnimate,false)">Sandbox</a> (Of practice area)</div>
    '				<div Class="subItem"><a href="javascript:;" title="Headings, images, lists, links, etc." onClick="story.displayTiddler(this,'Item Level Structure',null,config.options.chkAnimate,false)">Item Level Structure</a></div>
    '				<div Class="subItem"><a href="javascript:;" title="The many ways tables can be made" onClick="story.displayTiddler(this,'Formatting Tables',null,config.options.chkAnimate,false)">Formatting Tables</a></div>
    '				<div Class="subItem"><a href="javascript:;" title="Tags classify items by type" onClick="story.displayTiddler(this,'Tag Usage',null,config.options.chkAnimate,false)">Tag Usage</a></div>
    '				<div Class="subItem"><a href="javascript:;" title="Macros greatly expand the possibilities" onClick="story.displayTiddler(this,'Macros',null,config.options.chkAnimate,false)">Macros</a></div>
    '				<div Class="subItem"><a href="javascript:;" title="Using jQuery" onClick="story.displayTiddler(this,'Using jQuery',null,config.options.chkAnimate,false)">Using jQuery</a></div>
    '				<div Class="subItem"><a href="javascript:;" title="Save and restore custom items" onClick="story.displayTiddler(this,'Importing and Exporting Items',null,config.options.chkAnimate,false)">Importing &amp; Exporting</a></div>
    '			</div>
    '		</div>
    '	</div>
    '	<div style = "text-align:left;margin:0" > Users see these:</div>
    '	<!--<% } %>-->
    '	<div Class="mainDiv">
    '		<div Class="topItem">Live Observing</div>
    '		<div Class="dropMenu" >
    '			<div Class="subMenu" style="display:none;">
    '				<div Class="subItem">Single Object Imaging</div>
    '				<div Class="subSubItem"><a href="javascript:;" title="Acquire a single image" onClick="story.displayTiddler(this,'Acquire a Single Image',null,config.options.chkAnimate,false)">Single Image</a></div>
    '    . . .
    '
    '    <div Class="mainDiv">
    '		<div Class="topItem" >Toolbox</div>
    '		<div Class="dropMenu" >
    '			<div Class="subMenu" style="display:none;">
    '				<div Class="subItem"><a href="javascript:;" title="Various observatory tasks and tests" onClick="story.displayTiddler(this,'Utility Tasks',null,config.options.chkAnimate,false)">Utility Tasks</a></div>
    '				<div Class="subItem"><a href="javascript:;" title="Pre-compile and check an observing plan" onClick="story.displayTiddler(this,'Check Observing Plan',null,config.options.chkAnimate,false)">Obs. Plan Checker</a></div>
    '				<!--<% if(User.IsAdministrator) { %>-->
    '				<div Class="subItem"><a href="author.html" title="Make changes to web content">Authoring System</a></div>
    '				<!--<% } %>-->
    '			</div>
    '		</div>
    '	</div>
    '</div>           <-- end of navBar
    '</html>         <--- 3 lines are end of tiddler
    '<<XPMenu>>
    '</div>
    '
    ' Notes on the MainMenu structure:
    ' 1. The leading whitespace is vbTab characters
    ' 2. The entire tiddler is one string. The pieces are delimited by a 2 character string "\n".
    ' 3. The string is encoded to replace "<" with "&gt;", for example. I have decoded the string for easier working with

    Enum MMIconSource
        OldFile
        NewFile
    End Enum

    Private mUnnamedCount As Integer = 1        ' If we get items needing names, use this counter to make names unique

    Private mTv As TreeView             ' from main form


    Public Sub New(tv As TreeView)
        mTv = tv
    End Sub

    Public Function GetTree() As TreeView
        ' returns the TreeView control
        Return mTv
    End Function

    Public Function GetTVNode(key As String) As TreeNode
        ' find the specified node in the Treeview
        ' returns Nothing if not found

        Dim nodes As TreeNode() = GetTVNodeArr(key)

        If (nodes.Count > 0) Then
            Return nodes(0)
        End If

        Return Nothing
    End Function

    Public Function GetTVNodeArr(key As String) As TreeNode()
        ' find the specified node(s) in the Treeview
        ' returns empty nodes array if none found

        Dim nodes As TreeNode() = mTv.Nodes.Find(key, True)     ' true to search all children

        Return nodes
    End Function


    Public Function BuildMainMenuTiddler() As String
        ' Put the Main Menu pieces in the mTv TreeView back together to form the tiddler
        Dim s As String = ""
        For Each node As TreeNode In mTv.Nodes
            s = s & BuildPart1ForTiddler(node, True)
            BuildTiddlerChildren(node, s)
            s = s & BuildPart2ForTiddler(node, True)
        Next

        Return s
    End Function

    Private Sub BuildTiddlerChildren(node As TreeNode, ByRef tiddler As String)

        For Each child As TreeNode In node.Nodes
            tiddler = tiddler & BuildPart1ForTiddler(child, True)
            BuildTiddlerChildren(child, tiddler)
            tiddler = tiddler & BuildPart2ForTiddler(child, True)
        Next
    End Sub

    Private Function BuildPart1ForTiddler(node As TreeNode, encode As Boolean) As String
        Dim info As InfoMenuNode = node.Tag
        Dim s As String = ""

        If (encode) Then
            s = info.TextPart1(encode)
        Else
            s = info.TextPart1(encode)
        End If
        Return s
    End Function

    Private Function BuildPart2ForTiddler(node As TreeNode, encode As Boolean) As String
        Dim info As InfoMenuNode = node.Tag
        Dim s As String = ""

        If (encode) Then
            s = info.TextPart2(encode)
        Else
            s = info.TextPart2(encode)
        End If
        Return s
    End Function


    Public Sub MergeMainMenu(oldAuth As AuthorData, newAuth As AuthorData)
        ' At each level of nodes, the following map indicates keys within the Custom and ACP menu, and what the
        ' merged result should be.
        ' There is no date or author information for each menu entry, so we have to take each entry from either
        ' the Custom file or the ACP file. If an entry is in both, take the ACP version (it may have been updated).
        ' In the following table, lower case c means take the entry from the custom file
        ' Lower a means use the ACP entry
        '    Custom key     ACP key      Merged key
        '    X              A            Xc
        '    A              Z            Aa  Replace from new?
        '    C              P            Za  Add from new, Sibling is A from ACP
        '    D              D            Cc
        '    P              Y            Da  Replace from new?
        '                                Ya  Add from new, Sibling is D from ACP
        '                                Pa  replace from new?
        '

        '
        Dim oldTV As TreeView = oldAuth.GetMainMenu.GetTree()
        Dim newTV As TreeView = newAuth.GetMainMenu.GetTree()
        ' mTV is the Merge treeview we are building
        mTv.Nodes.Clear()
        Dim mrgNode As TreeNode
        Dim mrgNodeArr() As TreeNode
        Dim acpNodeArr() As TreeNode

        ' copy Old root node to MTv
        Dim oldRoot As TreeNode = oldTV.Nodes(0)
        Dim rootInfo As InfoRootItem = oldRoot.Tag
        Dim mrgRootInfo As InfoRootItem = New InfoRootItem(rootInfo.Name, InfoMenuNode.MenuNodeType.ModMainMenu)
        mrgRootInfo.Copy(rootInfo)
        Dim mrgRootNode As TreeNode = New TreeNode
        mrgRootNode.Tag = mrgRootInfo
        mrgRootNode.Name = mrgRootInfo.Name
        mrgRootNode.Text = mrgRootInfo.Name
        mrgRootNode.ImageIndex = mrgRootInfo.NodeType
        mrgRootNode.SelectedImageIndex = mrgRootInfo.NodeType
        mTv.Nodes.Add(mrgRootNode)

        ' Loop through the oldNodes looking for mainDiv nodes. These are the children of the root node 
        ' If the mainDiv is not in merge, then add it
        For Each oldNode As TreeNode In oldRoot.Nodes
            Dim info As InfoMainDiv = oldNode.Tag
            If (info.NodeType = InfoMenuNode.MenuNodeType.ModmainDiv) Then
                ' clone the mainDiv nodes to mTv
                mrgNode = oldNode.Clone()
                mrgRootNode.Nodes.Add(mrgNode)
            End If
        Next

        ' loop through New mainDiv, look for divisions not in Merge yet (customize removed these, or New addition to menu)
        Dim ACPRoot As TreeNode = newTV.Nodes(0)
        For Each ACPNode As TreeNode In ACPRoot.Nodes
            Dim info As InfoMainDiv = ACPNode.Tag
            If (info.NodeType = InfoMenuNode.MenuNodeType.mainDiv) Then
                mrgNode = GetTVNode(info.Name)
                If (IsNothing(mrgNode)) Then
                    ' Need to add this to merge
                    mrgNode = ACPNode.Clone()
                    mrgRootNode.Nodes.Add(mrgNode)
                End If
            End If
        Next

        ' look for subitem, subsubitems in ACP tree but not in mrg tree. Add them to mrg
        ' If item is in both, but the contents are different, flag with a red icon
        Dim ACPnodeList As SortedList(Of String, TreeNode) = GetTreeNodesList(newTV)
        For Each acpNode In ACPnodeList.Values
            Dim info As InfoMenuNode = acpNode.Tag
            Select Case info.NodeType
                Case InfoMenuNode.MenuNodeType.subItem, InfoMenuNode.MenuNodeType.subSubItem
                    mrgNodeArr = GetTVNodeArr(info.Name)
                    acpNodeArr = newAuth.GetMainMenu.GetTVNodeArr(info.Name)
                    If (mrgNodeArr.Count = 0) Then
                        ' not here.
                        AddThisItemToMrg(info, mrgRootNode, newTV, acpNode)
                    Else
                        ' Acp node is in merge.  Note - could be multiple entries in mrg or acp lists
                        '  mrg 1 entry   acp 1 entry    check the two
                        '  mrg 1         acp 2          ? check 1->1 and 1->2
                        '  mrg 2         acp 1          compare acp to both mrg 1->1, 2->1
                        '  mrg 2         acp 2          compare 1 ->1, 2->2
                        If ((mrgNodeArr.Count = 1) And (acpNodeArr.Count = 1)) Then
                            CompareMrgACPNode(mrgNodeArr(0), acpNodeArr(0))
                        ElseIf ((mrgNodeArr.Count = 1) And (acpNodeArr.Count = 2)) Then
                            If (Not CompareMrgACPNode(mrgNodeArr(0), acpNodeArr(0))) Then
                                CompareMrgACPNode(mrgNodeArr(0), acpNodeArr(1))
                            End If
                        ElseIf ((mrgNodeArr.Count = 2) And (acpNodeArr.Count = 1)) Then
                            If (Not CompareMrgACPNode(mrgNodeArr(0), acpNodeArr(0))) Then
                                CompareMrgACPNode(mrgNodeArr(1), acpNodeArr(0))
                            End If
                        ElseIf ((mrgNodeArr.Count = 2) And (acpNodeArr.Count = 2)) Then
                            CompareMrgACPNode(mrgNodeArr(0), acpNodeArr(0))
                            CompareMrgACPNode(mrgNodeArr(1), acpNodeArr(1))
                        End If
                    End If

                Case Else

            End Select
        Next
    End Sub



    Public Sub AddMainMenu(tiddler As String, iconSource As MMIconSource)
        Dim name As String = ""           ' becomes info.name
        Dim tEnc As String = Web.HttpUtility.HtmlDecode(tiddler)
        tEnc = tEnc.Replace("\n", "~")
        Dim pieces() As String = tEnc.Split("~")
        Dim pCount As Integer = pieces.Count
        Dim lastSubItemNode As TreeNode
        Dim subItemInfo As InfoSubItem = Nothing
        Dim subSubItemInfo As InfoSubItem = Nothing
        Dim mainNode As TreeNode                    ' The current mainDiv node in the tree
        Dim mainInfo As InfoMainDiv = Nothing       ' current mainDiv info being filled in
        Dim iconOffset As Integer = 0
        Dim SpaceToNum As String = "               "

        If (iconSource = MainMenu.MMIconSource.OldFile) Then
            iconOffset = InfoMenuNode.MenuNodeType.ModMainMenu
        End If

        ' step through pieces, figure out what type each one is.
        ' Add the pieces to the TreeView using the info classes

        ' first piece is Root Node
        mTv.Nodes.Clear()
        'Dim fixedS As String = pieces(0).Replace("<html>", "&lt;html&gt;")      ' Last part should not be decoded
        Dim info As InfoRootItem = New InfoRootItem("MainMenu", InfoMenuNode.MenuNodeType.MainMenu + iconOffset)
        info.mainMenu = pieces(0)
        info.navBar = pieces(1)     ' navbar
        ' put last 3 lines into trailer
        If (pCount > 6) Then
            ' the </html><<XpMenu>> pieces should not be decoded
            info.mainMenuTrailer = pieces(pCount - 3) & vbCrLf & pieces(pCount - 2) & vbCrLf & pieces(pCount - 1)
            info.navBarTrailer = pieces(pCount - 4)
        End If
        Dim root As TreeNode = New TreeNode(info.Name, info.NodeType, info.NodeType)
        root.Tag = info
        mTv.Nodes.Add(root)

        lastSubItemNode = root    ' for compiling only

        Dim parent As TreeNode = root
        Dim i As Integer
        Dim ntype As InfoMenuNode.MenuNodeType
        For i = 2 To pCount - 5      'Note that last 4 lines are last part of root. Skip MainMenu and navbar, they are already in root
            Dim testWhite As String = pieces(i).Replace(vbTab, "")
            If (Not (Trim(testWhite) = "")) Then           ' skipping blank lines
                Try
                    ntype = GetPieceType(pieces(i))
                Catch ex As Exception
                    Throw New Exception("GetPieceType failed with err " & ex.Message & vbCrLf & " for piece " & pieces(i))
                End Try
                Select Case ntype
                    Case InfoMenuNode.MenuNodeType.mainDiv
                        If (Not IsNothing(mainInfo)) Then
                            If (mainInfo.mainDiv <> "") Then
                                ' we already have a main, we are done with it
                                mainNode = AttachMainDiv(root, mainInfo)
                                subItemInfo = Nothing
                                subSubItemInfo = Nothing
                                mainInfo = New InfoMainDiv("temp", InfoMenuNode.MenuNodeType.mainDiv + iconOffset)     ' temp name filled in when we hit topItem
                            End If
                        Else
                            mainInfo = New InfoMainDiv("temp", InfoMenuNode.MenuNodeType.mainDiv + iconOffset)     ' temp name filled in when we hit topItem
                        End If

                        mainInfo.mainDiv = pieces(i)

                    Case InfoMenuNode.MenuNodeType.subItem
                        name = GetSubItemName(pieces(i))
                        'Dim referenceTiddlerKey As String = GetSubItemTiddlerKey(pieces(i))
                        subItemInfo = New InfoSubItem(name, InfoMenuNode.MenuNodeType.subItem + iconOffset, pieces(i))
                        ' SubItems get added to the current mainDiv
                        If (Not IsNothing(mainInfo)) Then
                            mainInfo.AddSubItem(subItemInfo)
                        End If

                    Case InfoMenuNode.MenuNodeType.subSubItem
                        name = GetSubItemName(pieces(i))
                        subsubItemInfo = New InfoSubItem(name, InfoMenuNode.MenuNodeType.subSubItem + iconOffset, pieces(i))

                        ' Add to the lasts subItemInfo
                        If (Not IsNothing(subItemInfo)) Then
                            subItemInfo.AddSubSubItem(subSubItemInfo)
                        End If


                    Case InfoMenuNode.MenuNodeType.divComment
                        ' comment could be before MainDiv, after MainDiv, or before next MainDiv
                        If (IsNothing(mainInfo)) Then
                            ' prev maininfo was done, the comment is first in new mainDiv
                            mainInfo = New InfoMainDiv("temp", InfoMenuNode.MenuNodeType.mainDiv + iconOffset)     ' temp name filled in when we hit topItem
                            mainInfo.commentBefore = pieces(i)
                        ElseIf (mainInfo.mainDiv <> "") Then
                            ' after comment
                            mainInfo.commentAfter = pieces(i)
                        ElseIf ((mainInfo.mainDiv = "") And (mainInfo.aspIf <> "")) Then
                            ' Existing info created by ASPIf, no mainDiv yet
                            mainInfo.commentBefore = pieces(i)
                        Else
                            MsgBox("Comment - dont know where it goes " & vbCrLf & pieces(i),, "Comment Error")
                        End If

                    Case InfoMenuNode.MenuNodeType.ASPif
                        If (InSubItemMode(mainInfo)) Then
                            name = GetASPifName(pieces(i)) & SpaceToNum & i
                            subItemInfo = New InfoSubItem(name, InfoMenuNode.MenuNodeType.ASPif + iconOffset, pieces(i))
                            ' ASP get added to the current mainDiv 
                            If (Not IsNothing(mainInfo)) Then
                                mainInfo.AddSubItem(subItemInfo)
                            End If
                        Else
                            If (Not IsNothing(mainInfo)) Then
                                ' we have an existing mainInfo - this ASPIf must be for the next one
                                mainNode = AttachMainDiv(root, mainInfo)
                                subItemInfo = Nothing
                                subSubItemInfo = Nothing
                            End If
                            mainInfo = New InfoMainDiv("temp", InfoMenuNode.MenuNodeType.mainDiv + iconOffset)     ' temp name filled in when we hit topItem
                            mainInfo.aspIf = pieces(i)
                        End If

                    Case InfoMenuNode.MenuNodeType.ASPElse
                        ' only applies in subItems
                        If (InSubItemMode(mainInfo)) Then
                            name = "} else {" & SpaceToNum & i
                            subItemInfo = New InfoSubItem(name, InfoMenuNode.MenuNodeType.ASPElse + iconOffset, pieces(i))
                            ' ASP get added to the current mainDiv 
                            If (Not IsNothing(mainInfo)) Then
                                mainInfo.AddSubItem(subItemInfo)
                            End If
                        End If

                    Case InfoMenuNode.MenuNodeType.ASPEnd
                        If (InSubItemMode(mainInfo)) Then
                            name = "}" & SpaceToNum & i
                            subItemInfo = New InfoSubItem(name, InfoMenuNode.MenuNodeType.ASPEnd + iconOffset, pieces(i))
                            ' ASP get added to the current mainDiv 
                            If (Not IsNothing(mainInfo)) Then
                                mainInfo.AddSubItem(subItemInfo)
                            End If
                        Else
                            If (Not IsNothing(mainInfo)) Then
                                mainInfo.aspBrace = pieces(i)
                                mainNode = AttachMainDiv(root, mainInfo)
                                subItemInfo = Nothing
                                subSubItemInfo = Nothing
                                mainInfo = Nothing
                            End If
                        End If

                    Case InfoMenuNode.MenuNodeType.divTrailer
                        ' should be the next trailer for the mainDiv
                        If (IsNothing(mainInfo)) Then
                            MsgBox("divTrailer with no mainInfo")
                        End If
                        If (mainInfo.subMenuTrailer = "") Then
                            mainInfo.subMenuTrailer = pieces(i)
                        ElseIf (mainInfo.dropMenuTrailer = "") Then
                            mainInfo.dropMenuTrailer = pieces(i)
                        ElseIf (mainInfo.mainDivTrailer = "") Then
                            mainInfo.mainDivTrailer = pieces(i)
                        Else
                            MsgBox("MakeMainDivInfo: unrecognized div trailer. i = " & i)
                        End If

                    Case InfoMenuNode.MenuNodeType.dropMenu
                        mainInfo.dropMenu = pieces(i)

                    Case InfoMenuNode.MenuNodeType.topItem
                        mainInfo.topItem = pieces(i)
                        mainInfo.Name = ExtractTopItemName(pieces(i))

                    Case InfoMenuNode.MenuNodeType.subMenu
                        mainInfo.subMenu = pieces(i)

                    Case Else

                End Select
            End If
        Next

        ' Last MainDiv needs to be output
        If (Not IsNothing(mainInfo)) Then
            If (mainInfo.mainDiv <> "") Then
                ' we already have a main, we are done with it
                mainNode = AttachMainDiv(root, mainInfo)
            End If
        End If
    End Sub

    Private Function AttachMainDiv(root As TreeNode, info As InfoMainDiv) As TreeNode
        ' create treenode for this main div
        Dim mainNode As TreeNode
        Dim sNode As TreeNode
        Dim ssNode As TreeNode
        Dim sublist As List(Of InfoMenuNode)

        ' if the name is temp, make it Unnamed 1
        If (info.Name = "temp") Then
            info.Name = "Unnamed " & mUnnamedCount
            mUnnamedCount = mUnnamedCount + 1
        End If
        mainNode = New TreeNode(info.Name, info.NodeType, info.NodeType)
        mainNode.Text = info.Name
        mainNode.Name = info.Name
        mainNode.Tag = info
        root.Nodes.Add(mainNode)

        ' now add the subitems in main's list
        sublist = info.GetSubList()
        For Each sInfo As InfoSubItem In sublist
            sNode = New TreeNode(sInfo.Name, sInfo.NodeType, sInfo.NodeType)
            sNode.Text = sInfo.Name
            sNode.Name = sInfo.Name
            sNode.Tag = sInfo
            mainNode.Nodes.Add(sNode)

            ' now do any subsubitems
            Dim subsublist As List(Of InfoSubItem) = sInfo.GetSubSubList()
            For Each ssinfo As InfoSubItem In subsublist
                ssNode = New TreeNode(ssinfo.Name, ssinfo.NodeType, ssinfo.NodeType)
                ssNode.Text = ssinfo.Name
                ssNode.Name = ssinfo.Name
                ssNode.Tag = ssinfo
                sNode.Nodes.Add(ssNode)
            Next
        Next

        Return mainNode
    End Function

    Private Function InSubItemMode(mainInfo As InfoMainDiv) As Boolean
        ' return true if we are in the process of handling subitems/subsubitems under a maindiv
        Dim subItemMode As Boolean = False

        If (Not IsNothing(mainInfo)) Then
            If (mainInfo.mainDiv <> "") Then    ' do we have a mainDiv started?
                If (mainInfo.mainDivTrailer = "") Then       ' Havent hit the trailer yet?
                    subItemMode = True
                End If
            End If
        End If

        Return subItemMode
    End Function

    Private Function GetSubItemName(p As String) As String
        Dim name As String = ""

        'Try
        '    name = ExtractField(p, "title=")
        'Catch ex As Exception
        '    Throw New Exception("MainMenu.GetSubItemName: ExtractField for title failed with err " & ex.Message & vbCrLf & " for piece " & " text " & p)
        'End Try
        If (name = "") Then
            Try
                name = ExtractTopItemName(p)
            Catch ex As Exception
                Throw New Exception("MainMenu.GetSubItemName: ExtractTopItemName failed with err " & ex.Message & vbCrLf & " for piece " & " text " & p)
            End Try
        End If
        If (name = "") Then
            Throw New Exception("MainMenu.GetSubItemName: subitem has no name for piece  " & " text " & p)
        End If
        Return name
    End Function

    Private Function GetASPifName(p As String) As String
        ' from asp statement
        '   <!--<% if(screenFlats) { %>-->
        ' get the if part    if(screenFlats)
        Dim s As String = ""
        Dim posStart As Integer = 0
        Dim posEnd As Integer = 0
        posStart = p.IndexOf("if(", 0)
        posEnd = p.IndexOf(") {", 0)
        If ((posStart > -1) And (posEnd > -1)) Then
            s = p.Substring(posStart, posEnd - posStart + 1)
        End If

        Return s
    End Function

    Private Function ObsFindSibling(parent As TreeNode, searchtype As InfoMenuNode.MenuNodeType) As TreeNode
        ' look for sibling under parent node that matches searchtype
        Dim info As InfoMenuNode

        For Each node As TreeNode In parent.Nodes
            info = node.Tag
            If (info.NodeType = searchtype) Then
                Return node
            End If
        Next

        Return Nothing
    End Function

    Private Function ObsFindParent(parent As TreeNode, searchtype As InfoMenuNode.MenuNodeType) As TreeNode
        ' look for siblings under parent node
        Dim info As InfoMenuNode
        Dim checkNode As TreeNode = parent
        checkNode = checkNode.Parent
        info = checkNode.Tag
        If (info.NodeType = InfoMenuNode.MenuNodeType.mainDiv) Then
            ' check the children until find searchtype
            For Each node As TreeNode In checkNode.Nodes
                info = node.Tag
                If (info.NodeType = searchtype) Then
                    Return node
                End If
            Next
        End If

        Return Nothing
    End Function





    Private Const ITEMREF_START = " displayTiddler(this,'"
    Private Const ITEMREF_END = "',null"
    Private Function GetSubItemTiddlerKey(m As String) As String
        ' m is the menu item, like
        ' <div class="subSubItem"><a href="javascript:;" title="Acquire a single image" onClick="story.displayTiddler(this,'Acquire a Single Image',null,config.options.chkAnimate,false)">Single Image</a></div>
        ' javascript items will have the tiddler key in the displayTiddler section.
        ' Note that not all subItems and subSubItems will refer to a tiddler - return "" in these cases
        Dim ref As String = ""
        Dim pos As Integer
        Dim posend As Integer

        pos = m.IndexOf(ITEMREF_START, 0)
        If (pos > -1) Then
            pos = pos + ITEMREF_START.Length
            posend = m.IndexOf(ITEMREF_END, pos)
            If (posend > -1) Then
                ref = m.Substring(pos, posend - pos)
            Else
                MsgBox("subitem missing null portion: " & m)
            End If
        End If
        Return ref
    End Function


    Private Function ExtractField(s As String, field As String) As String
        Dim val As String = ""
        Dim pos As Integer = s.IndexOf(field, 0)
        If (pos > 0) Then
            pos = pos + field.Length + 1         ' get past "
            Dim posEnd As Integer = s.IndexOf("""", pos)
            val = s.Substring(pos, posEnd - pos)
        End If

        Return val
    End Function

    Private Function ExtractTopItemName(p As String) As String
        ' p looks like <div class="topItem" >Scheduled</div>
        ' extract Scheduled
        ' Could have two ">
        '   <div class="subItem"><a href="javascript:;" onClick="story.displayTiddler(this,'Welcome',null,config.options.chkAnimate,false)">Welcome</a></div>
        '  <div class="subItem">Single Object Imaging</div>
        '
        ' <div class="subItem"><a href="javascript:;" title="Authoring welcome and contents" onClick="story.displayTiddler(this,'Authoring System',null,config.options.chkAnimate,false)">Welcome</a></div>


        Dim name As String = ""
        Dim pos As Integer
        Dim pos2 As Integer
        Dim posEnd As Integer
        pos = p.IndexOf(">", 0)
        While ((pos > -1) And (pos < p.Length - 1) And (p.Substring(pos, 2) = "><"))
            pos = p.IndexOf(">", pos + 1)
        End While
        If (pos > -1) Then
            posEnd = p.IndexOf("<", pos)
        End If

        If ((pos > -1) And (posEnd > -1)) Then
            name = p.Substring(pos + 1, posEnd - pos - 1)
        End If

        Return name
    End Function

    Private Function GetPieceType(p As String) As InfoMenuNode.MenuNodeType
        Dim menType As InfoMenuNode.MenuNodeType = InfoMenuNode.MenuNodeType.Unused
        Dim posStart As Integer
        Dim posEnd As Integer
        Dim className As String = ""

        ' is this a subItem?
        posStart = p.IndexOf("<div")
        posEnd = p.IndexOf("</div>")
        If (posStart > -1) Then
            If (posEnd > -1) Then
                ' we have subItem or topIem
                className = ExtractField(p, "class=")
                If (className = "subItem") Then
                    menType = InfoMenuNode.MenuNodeType.subItem
                ElseIf (className = "subSubItem") Then
                    menType = InfoMenuNode.MenuNodeType.subSubItem
                ElseIf (className = "topItem") Then
                    menType = InfoMenuNode.MenuNodeType.topItem
                ElseIf (className = "") Then
                    menType = InfoMenuNode.MenuNodeType.divComment
                Else
                    'Throw New Exception("Unrecognized menu node type " & p.Substring(0, 30))
                End If

            Else
                ' no </div, so we have mainDiv, navBar, or dropMenu, subMenu. Get class=
                className = ExtractField(p, "class=")
                If (className = "mainDiv") Then
                    menType = InfoMenuNode.MenuNodeType.mainDiv
                ElseIf (className = "dropMenu") Then
                    menType = InfoMenuNode.MenuNodeType.dropMenu
                ElseIf (className = "navbar") Then
                    menType = InfoMenuNode.MenuNodeType.navBar
                ElseIf (className = "subMenu") Then
                    menType = InfoMenuNode.MenuNodeType.subMenu
                End If
            End If
        ElseIf (posEnd > -1) Then
            ' we have </div>
            menType = InfoMenuNode.MenuNodeType.divTrailer
        Else
            ' look for asp stuff
            If (p.IndexOf("<!--<% if", 0) > -1) Then
                ' yep, asp
                menType = InfoMenuNode.MenuNodeType.ASPif
            ElseIf (p.IndexOf("} else {", 0) > -1) Then
                menType = InfoMenuNode.MenuNodeType.ASPElse
            ElseIf (p.IndexOf("}", 0) > -1) Then
                menType = InfoMenuNode.MenuNodeType.ASPEnd
            End If
        End If

        Return menType
    End Function

    Public Function GetTreeNodesList(objTree As TreeView) As SortedList(Of String, TreeNode)
        ' get list of Unique tree nodes
        Dim nodes As SortedList(Of String, TreeNode) = New SortedList(Of String, TreeNode)
        For Each parentNode As TreeNode In objTree.Nodes
            If (Not nodes.ContainsKey(parentNode.Name)) Then
                nodes.Add(parentNode.Name, parentNode)
            End If
            GetAllChildren(parentNode, nodes)
        Next

        Return nodes
    End Function

    Public Sub GetAllChildren(parentNode As TreeNode, nodes As SortedList(Of String, TreeNode))
        For Each childNode As TreeNode In parentNode.Nodes
            If (Not nodes.ContainsKey(childNode.Name)) Then
                nodes.Add(childNode.Name, childNode)
            End If
            GetAllChildren(childNode, nodes)
        Next
    End Sub

    Private Sub AddThisItemToMrg(info As InfoSubItem, mrgRootNode As TreeNode, acpTV As TreeView, acpNode As TreeNode)
        ' create new node for this subitem which is in acpTV, add it in appropriate spot in mTv
        Dim acpParentNode As TreeNode = Nothing
        Dim acpLeftSibling As TreeNode = Nothing
        Dim acpRightSibling As TreeNode = Nothing
        Dim mrgLeftSibling As TreeNode = Nothing
        Dim mrgRightSibling As TreeNode = Nothing
        Dim posIdx As Integer = 0

        acpParentNode = acpNode.Parent
        Dim parentInfo As InfoMenuNode = acpParentNode.Tag
        Dim mrgParent As TreeNode = GetTVNode(acpParentNode.Name)
        If (IsNothing(mrgParent)) Then
            ' Hmm, the parent is not in the mergeTree. What now?
            MsgBox("AddThisItemToMrg: parent " & acpParentNode.Name & " is not in Merge Tree for " & acpNode.Name)
            Exit Sub
        End If

        ' find left and right siblings in ACP tree
        ' If mrgleftSibling exists then insIdx = mrgLeftSibling.index+1
        ' else if mrgRightSibling exists then insIdx = mrgRightSibling.index
        posIdx = acpNode.Index
        Dim insIdx As Integer = posIdx
        If (posIdx > 0) Then
            acpLeftSibling = acpParentNode.Nodes(posIdx - 1)
            If (Not IsNothing(acpLeftSibling)) Then
                ' is the left sibling in mrg?
                mrgLeftSibling = GetTVNode(acpLeftSibling.Name)
                If (Not IsNothing(mrgLeftSibling)) Then
                    insIdx = mrgLeftSibling.Index + 1
                End If
            End If
        ElseIf (posIdx < acpParentNode.Nodes.Count - 1) Then
            acpRightSibling = acpParentNode.Nodes(posIdx + 1)
            If (Not IsNothing(acpRightSibling)) Then
                ' is the left sibling in mrg?
                mrgRightSibling = GetTVNode(acpRightSibling.Name)
                If (Not IsNothing(mrgRightSibling)) Then
                    insIdx = mrgRightSibling.Index
                End If
            End If
        End If


        Dim mrgNode As TreeNode = New TreeNode(info.Name, InfoMenuNode.MenuNodeType.subItem, InfoMenuNode.MenuNodeType.subItem)
        Dim mrgInfo As InfoSubItem = New InfoSubItem(info.Name, InfoMenuNode.MenuNodeType.subItem, info.TextPart1(False))    ' info.nodetype?

        ' mrgInfo.Copy(info)  fields are  put in by New()
        mrgNode.Tag = mrgInfo
        mrgNode.Name = mrgInfo.Name
        mrgNode.Text = mrgInfo.Name
        mrgParent.Nodes.Insert(insIdx, mrgNode)
    End Sub

    Private Function CompareMrgACPNode(mrgNode As TreeNode, acpNode As TreeNode) As Boolean
        ' if The mrgNode text is different from the acpNode text, replace
        ' the mrgNode with one with a red indicator
        ' Return True if mrgNode was replaced
        Dim ret As Boolean = False
        Dim mrgInfo As InfoSubItem = mrgNode.Tag
        Dim mrgCode As String = mrgInfo.entryText
        mrgCode = Trim(mrgCode.Replace(vbTab, ""))
        Dim acpInfo As InfoSubItem = acpNode.Tag
        Dim acpCode As String = acpInfo.entryText
        acpCode = Trim(acpCode.Replace(vbTab, ""))
        If (mrgCode <> acpCode) Then
            ' Mark this one as a warning! replace mrgNode
            Dim posIdx As Integer = mrgNode.Index
            Dim repNode As TreeNode = New TreeNode(mrgInfo.Name, mrgInfo.NodeType + 13, mrgInfo.NodeType + 13)
            repNode.Name = mrgNode.Name
            repNode.Text = mrgNode.Text
            repNode.Tag = mrgNode.Tag
            ' set tooltip with warning message
            repNode.ToolTipText = "Warning: ACP and Customized text do not match"
            Dim parent As TreeNode = mrgNode.Parent
            parent.Nodes.Remove(mrgNode)
            parent.Nodes.Insert(posIdx, repNode)
            ret = True
        End If
        Return ret
    End Function

End Class
