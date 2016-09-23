

Public Class AuthorData
    ' Holding the various pieces of an author file

    Structure TiddlerInfo
        Public tiddler As String
        Public source As String      ' OLD or NEW
    End Structure

    Private mHeader As String = ""
    Private mTrailer As String = ""
    Private mTiddlers As SortedDictionary(Of String, TiddlerInfo)
    Private mMainMenu As MainMenu
    Private mAuthorName As String        ' Allows distinguishing which chunk we are working with - old, NEW, Merge

    Public Sub New(tv As TreeView)
        'mTiddlers = New Dictionary(Of String, TiddlerInfo)(System.StringComparer.Ordinal)
        mTiddlers = New SortedDictionary(Of String, TiddlerInfo)
        mMainMenu = New MainMenu(tv)
        mAuthorName = tv.Name
    End Sub

    Public Sub AddHeader(h As String)
        mHeader = h
    End Sub

    Public Sub AddTrailer(h As String)
        mTrailer = h
    End Sub

    Public Sub AddTiddler(t As String, source As String, skipMenu As Boolean)
        ' get the tiddler name, use it as key
        Dim key As String = ExtractField(t, "tiddler=")
        Dim inf As TiddlerInfo = New TiddlerInfo
        Dim iconSource As MainMenu.MMIconSource
        inf.tiddler = t
        inf.source = source
        mTiddlers.Add(key, inf)

        If ((key = "MainMenu") And (Not skipMenu)) Then
            ' Build the Menu Tree view
            If (source = "OLD") Then
                iconSource = MainMenu.MMIconSource.OldFile
            Else
                iconSource = MainMenu.MMIconSource.NewFile
            End If
            AddMainMenu(t, iconSource)
        End If

    End Sub

    Public Sub ReplaceTiddler(key As String, t As String, source As String)
        ' Replace the tiddler already in the list (Bob's) with my updated one from the
        ' Old customized list
        If (key = "MainMenu") Then
            ' Skip replacing, that is handled separately
            Exit Sub
        End If

        Dim infExist As TiddlerInfo = mTiddlers.Item(key)
        Dim infNew As TiddlerInfo = New TiddlerInfo
        infNew.tiddler = t
        infNew.source = source

        mTiddlers(key) = infNew
        infExist = mTiddlers.Item(key)          ' check it worked

    End Sub

    Public Sub AddMainMenu(tiddler As String, iconSource As MainMenu.MMIconSource)
        ' Convert the MainMenu tiddler into a treeView structure
        mMainMenu.AddMainMenu(tiddler, iconSource)

    End Sub

    Public Function GetHeader() As String
        Return mHeader
    End Function
    Public Function GetTrailer() As String
        Return mTrailer
    End Function

    Public Function GetTiddlers() As String
        ' pack all of the tiddlers into one big string
        Dim s As String = ""
        'For Each tid As TiddlerInfo In mTiddlers.Values
        '    s = s & tid.tiddler & vbCrLf
        'Next

        'For count As Integer = 0 To mTiddlers.Count - 1     ' see if this comes out in order
        '    Dim element = mTiddlers.ElementAt(count)
        '    Dim tid As TiddlerInfo = element.Value
        '    s = s & tid.tiddler & vbCrLf
        'Next
        'For Each item As KeyValuePair(Of String, TiddlerInfo) In mTiddlers
        '    'Dim tid As String = item.Value.tiddler
        '    s = s & item.Value.tiddler & vbCrLf
        'Next
        For Each key As String In mTiddlers.Keys
            Dim tid As TiddlerInfo = mTiddlers(key)
            s = s & tid.tiddler & vbCrLf
        Next

        ' take off the last crlf
        s = s.Substring(0, s.Length - 2)
        Return s
    End Function


    Public Function GetMainMenu() As MainMenu
        Return mMainMenu
    End Function

    Public Sub MergeMainMenu(oldAuth As AuthorData, newAuth As AuthorData)
        If (mAuthorName <> "tvMerge") Then
            MsgBox("MergeMainMenu should only be called with gMerge",, "Coding Problem")
            Exit Sub
        End If

        mMainMenu.MergeMainMenu(oldAuth, newAuth)

        '    ' Now build the resultant tiddler, add to the tiddler list
        Dim mainmenuTiddler As String = mMainMenu.BuildMainMenuTiddler()
        DeleteTiddler("MainMenu")
        Try
            AddTiddler(mainmenuTiddler, BrewAuthorMerge.SOURCE_OLD, True)     ' true - don't redo menu
        Catch ex As Exception
            MsgBox("MergeMainMenu: Error adding MainMenu after merge" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub ObsAddMenuItemToMerge(oldmenu As InfoMenuNode, oldNode As TreeNode)
        Dim oldParent As TreeNode = oldNode.Parent
        Dim info As InfoMenuNode = oldParent.Tag
        'If (info.NodeType = InfoMenuNode.MenuNodeType.subMenu) Then
        '    AddSubItemToMerge(oldmenu, oldNode)
        'ElseIf (info.NodeType = InfoMenuNode.MenuNodeType.subItem) Then
        '    AddSubSubItemToMerge(oldmenu, oldNode)
        'Else
        '    Throw New Exception("AddMenuItemToMerge: the node to be added (" & oldNode.Name & ") is not a subItem or subSubItem")
        'End If
    End Sub

    Private Sub ObsAddMainDivToMerge(oldNode As TreeNode)
        ' oldNode is mainDiv node in OLD tree
        ' May need to insert this mainDiv copy into Merge
        ' Find the subItem in Merge
        ' IF the subItem does not exist in Merge, 
        '   Find merge's parent navbar 
        '   Find oldNode's left sibling (if any).
        '   Find that mainDiv in Merge 
        ' Add the oldnode clone after the sibling
        Dim oldLeftSibling As TreeNode = Nothing
        Dim mergeNavBar As TreeNode = Nothing
        Dim mergeSibling As TreeNode = Nothing
        Dim idxSibling As Integer = 0

        mergeNavBar = mMainMenu.GetTVNode("navbar")
        If (IsNothing(mergeNavBar)) Then
            ' navbar does not exist in Merge side. something is wrong
            Throw New Exception("AddMainDivToMerge: Merge menu does not have a navbar")
            Exit Sub
        End If

        ' find Old mainDiv left sibling 
        Try
            oldLeftSibling = oldNode.PrevNode()
        Catch ex As Exception                    ' fails, oldLeftSibling stays Nothing
        End Try

        ' get Merge sibling (and index position) of sibling
        If (Not IsNothing(oldLeftSibling)) Then
            mergeSibling = mMainMenu.GetTVNode(oldLeftSibling.Name)
            If (Not IsNothing(mergeSibling)) Then
                idxSibling = mergeSibling.Index + 1
            End If
        End If

        ' Add this node to Merge
        Dim newNode As TreeNode = New TreeNode(oldNode.Text, InfoMenuNode.MenuNodeType.ModmainDiv, InfoMenuNode.MenuNodeType.ModmainDiv)
        newNode = oldNode.Clone()                   ' includes everything underneath!
        'newNode.SelectedImageIndex = MainMenu.MenuNodeType.ModmainDiv
        'newNode.ImageIndex = MainMenu.MenuNodeType.ModmainDiv
        Dim theNode As TreeNode
        Try
            mergeNavBar.Nodes.Insert(idxSibling, newNode)
            theNode = mMainMenu.GetTVNode(oldNode.Name)
            mergeNavBar.TreeView.Invalidate()
        Catch ex As Exception
            MsgBox("AddMainDivToMerge: Failed add of " & oldNode.Name & " clone to Merge Main Menu")
        End Try
    End Sub

    Private Sub ObsAddSubItemToMerge(oldmenu As InfoMenuNode, oldNode As TreeNode)
        ' May need to insert this subitem into Merge
        ' Find the subItem in Merge
        ' IF the subItem does not exist in Merge, Add the oldnode after the sibling
        '   Find oldnode's parent subMenu, which contains topItem's name (subMenu - thename), 
        '   Find oldNode's left sibling (if any).
        '   Find that subMenu in Merge 
        Dim oldSubMenuName As String
        Dim oldParentType As InfoMenuNode.MenuNodeType = InfoMenuNode.MenuNodeType.mainDiv
        Dim oldLeftSibling As TreeNode = Nothing
        Dim mergeSubMenu As TreeNode = Nothing
        Dim mergeSibling As TreeNode = Nothing
        Dim oldParent As TreeNode = oldNode.Parent
        Dim info As InfoMenuNode = oldParent.Tag
        Dim idxSibling As Integer = 0

        ' subItem does not exist in Merge side. Need to add it
        ' find upper subMenu 
        While (info.NodeType <> InfoMenuNode.MenuNodeType.mainDiv)
            oldParent = oldParent.Parent
            info = oldParent.Tag
        End While

        oldSubMenuName = oldParent.Name                ' name is like subMenu - label of topItem

        ' Get prior sibling
        Try
            oldLeftSibling = oldNode.PrevNode()
        Catch ex As Exception                    ' fails, oldLeftSibling stays Nothing
        End Try

        ' Get Merge subMenu of same name
        mergeSubMenu = mMainMenu.GetTVNode(oldSubMenuName)
        ' get Merge sibling (and index position) of sibling
        If (Not IsNothing(oldLeftSibling)) Then
            mergeSibling = mMainMenu.GetTVNode(oldLeftSibling.Name)
            If (Not IsNothing(mergeSibling)) Then
                idxSibling = mergeSibling.Index + 1
            End If
        End If


        ' Add this node to Merge
        Dim newNode As TreeNode = New TreeNode(oldNode.Text, InfoMenuNode.MenuNodeType.ModsubItem, InfoMenuNode.MenuNodeType.ModsubItem)
        newNode = oldNode.Clone()
        'newNode.SelectedImageIndex = MainMenu.MenuNodeType.ModsubItem
        'newNode.ImageIndex = MainMenu.MenuNodeType.ModsubItem
        Dim theNode As TreeNode
        Try
            mergeSubMenu.Nodes.Insert(idxSibling, newNode)
            theNode = mMainMenu.GetTVNode(oldNode.Name)
            mergeSubMenu.TreeView.Invalidate()
        Catch ex As Exception
            MsgBox("AddSubItemToMerge: Failed add of " & oldNode.Name & " duplicate to Merge Main Menu")
        End Try
    End Sub

    Private Sub ObsAddSubSubItemToMerge(oldmenu As InfoMenuNode, oldNode As TreeNode)
        ' need to insert this subSubitem into Merge
        '   Find oldnode's parent subItem 
        '   Find oldNode's left sibling (if any).
        '   Find parent subitem in Merge 
        ' Add the oldnode clone after the sibling
        Dim oldParentType As InfoMenuNode.MenuNodeType = InfoMenuNode.MenuNodeType.mainDiv
        Dim oldLeftSibling As TreeNode = Nothing
        Dim mergeSubItem As TreeNode = Nothing
        Dim mergeSibling As TreeNode = Nothing
        Dim oldParent As TreeNode = oldNode.Parent
        Dim info As InfoMenuNode = oldParent.Tag
        Dim idxSibling As Integer = 0

        ' subItem does not exist in Merge side. Need to add it
        ' find parent subItem 
        oldParent = oldNode.Parent
        info = oldParent.Tag

        ' Get prior sibling
        Try
            oldLeftSibling = oldNode.PrevNode()
        Catch ex As Exception                    ' fails, oldLeftSibling stays Nothing
        End Try

        ' Get Merge subItem of same name (where we need to add the new node)
        mergeSubItem = mMainMenu.GetTVNode(oldParent.Name)

        ' get Merge sibling (and index position) of sibling
        If (Not IsNothing(oldLeftSibling)) Then
            mergeSibling = mMainMenu.GetTVNode(oldLeftSibling.Name)
            If (Not IsNothing(mergeSibling)) Then
                idxSibling = mergeSibling.Index + 1
            End If
        End If


        ' Add this node to Merge
        Dim newNode As TreeNode = New TreeNode(oldNode.Text, InfoMenuNode.MenuNodeType.ModsubSubItem, InfoMenuNode.MenuNodeType.ModsubSubItem)
        newNode = oldNode.Clone()
        Dim theNode As TreeNode
        Try
            mergeSubItem.Nodes.Insert(idxSibling, newNode)
            theNode = mMainMenu.GetTVNode(oldNode.Name)
            mergeSubItem.TreeView.Invalidate()
        Catch ex As Exception
            MsgBox("AddSubSubItemToMerge: Failed add of " & oldNode.Name & " duplicate to Merge Main Menu")
        End Try

    End Sub


    Public Function GetTreeNodes(objTree As TreeView) As List(Of TreeNode)
        Dim nodes As List(Of TreeNode) = New List(Of TreeNode)
        For Each parentNode As TreeNode In objTree.Nodes
            nodes.Add(parentNode)
            GetAllChildren(parentNode, nodes)
        Next

        Return nodes
    End Function

    Public Sub GetAllChildren(parentNode As TreeNode, nodes As List(Of TreeNode))
        For Each childNode As TreeNode In parentNode.Nodes
            nodes.Add(childNode)
            GetAllChildren(childNode, nodes)
        Next
    End Sub



    Public Function GetAuthor(key As String) As String
        Dim author As String = ""
        Dim tiddler As String = GetTiddler(key)
        If (tiddler <> "") Then
            author = ExtractField(tiddler, "modifier=")
        End If
        Return author
    End Function

    Public Function GetDate(key As String) As String
        Dim dateS As String = ""
        Dim tiddler As String = GetTiddler(key)
        If (tiddler <> "") Then
            dateS = ExtractField(tiddler, "modified=")
        End If
        Return dateS
    End Function

    Public Function Count() As Integer
        Dim cnt As Integer = 0
        If (Not IsNothing(mTiddlers)) Then
            cnt = mTiddlers.Count
        End If
        Return cnt
    End Function

    Public Function GetTiddler(key As String) As String
        Dim tiddler As String = ""
        Dim inf As TiddlerInfo
        Try
            inf = mTiddlers.Item(key)
            tiddler = inf.tiddler
        Catch ex As KeyNotFoundException
            Return ""
        End Try
        Return tiddler
    End Function

    Public Function GetTiddlerSource(key As String) As String
        Dim source As String = ""
        Dim inf As TiddlerInfo
        Try
            inf = mTiddlers.Item(key)
            source = inf.source
        Catch ex As KeyNotFoundException
            Return ""
        End Try
        Return source
    End Function

    Public Function GetKey(num As Integer) As String
        Dim element = mTiddlers.ElementAt(num)
        Return element.Key
    End Function

    Public Sub PopulateListView(ByRef lv As ListView)
        Dim author As String
        Dim dateS As String
        Dim key As String
        Dim lvitem As ListViewItem
        Dim imageKey As String = ""

        lv.Items.Clear()
        For Each key In mTiddlers.Keys
            author = GetAuthor(key)
            dateS = GetDate(key)

            imageKey = GetTiddlerSource(key)

            ' add list view item and subfields
            lvitem = lv.Items.Add(key, imageKey)  ' oldom, NEW Or Edited
            lvitem.SubItems.Add(author)
            lvitem.SubItems.Add(dateS)
        Next
    End Sub



    Private Function ExtractField(tiddler As String, field As String) As String
        Dim val As String = ""
        Dim pos As Integer = tiddler.IndexOf(field, 0)
        If (pos > 0) Then
            pos = pos + field.Length + 1         ' get past "
            Dim posEnd As Integer = tiddler.IndexOf("""", pos)
            val = tiddler.Substring(pos, posEnd - pos)
        End If

        Return val
    End Function

    Public Sub DeleteTiddler(key As String)
        Try
            Dim ret As Boolean = mTiddlers.Remove(key)
        Catch ex As ArgumentNullException
            MsgBox("DeleteTiddler: key " & key & " not found to delete" & vbCrLf & ex.Message)
        End Try
    End Sub


End Class
