' ***********************************************************************
' Author   : Elektro
' Modified : 24-October-2015
' ***********************************************************************
' <copyright file="RecycleBin Util.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Required References "

' Microsoft.WindowsAPICodePack.dll
' Microsoft.WindowsAPICodePack.Shell.dll

#End Region

#Region " Public Members Summary "

#Region " Child Classes "

' RecycleBinUtil.MasterBinLayout <Hidden>
' RecycleBinUtil.Tools

#End Region

#Region " Enumerations "

' RecycleBinUtil.CleanFlags As Integer
' RecycleBinUtil.ItemVerbs As Integer

#End Region

#Region " Properties "

' RecycleBinUtil.MasterBin As RecycleBinUtil.MasterBinLayout
' RecycleBinUtil.MasterBin.KnownFolder As IKnownFolder
' RecycleBinUtil.MasterBin.Files As IEnumerable(Of ShellFile)
' RecycleBinUtil.MasterBin.Folders As IEnumerable(Of ShellFolder)
' RecycleBinUtil.MasterBin.Items As IEnumerable(Of ShellObject)
' RecycleBinUtil.MasterBin.ItemsCount As Long
' RecycleBinUtil.MasterBin.LastRecycledFile As ShellFile
' RecycleBinUtil.MasterBin.LastRecycledFolder As ShellFolder
' RecycleBinUtil.MasterBin.LastRecycledItem As ShellObject
' RecycleBinUtil.MasterBin.Size As Long

#End Region

#Region " Functions "

' RecycleBinUtil.MasterBin.Clean(Opt: RecycleBinUtil.RecycleBinFlags) As Boolean
' RecycleBinUtil.MasterBin.UpdateIcon() As Boolean

' RecycleBinUtil.Tools.Clean(Char, Opt: CleanFlags) As Boolean
' RecycleBinUtil.Tools.GetBinSize(Char) As Long
' RecycleBinUtil.Tools.GetItemsCount(Char) As Long
' RecycleBinUtil.Tools.GetRecycledFiles(Char) As IEnumerable(Of ShellFile)
' RecycleBinUtil.Tools.GetRecycledFolders(Char) As IEnumerable(Of Shellfolder)
' RecycleBinUtil.Tools.GetRecycledItems(Char) As IEnumerable(Of ShellObject)
' RecycleBinUtil.Tools.GetLastRecycledFile(Char) As ShellFile
' RecycleBinUtil.Tools.GetLastRecycledFolder(Char) As ShellFolder
' RecycleBinUtil.Tools.GetLastRecycledItem(Char) As ShellObject

#End Region

#Region " Methods "

' RecycleBinUtil.Tools.DeleteItem(ShellObject)
' RecycleBinUtil.Tools.UndeleteItem(ShellObject)
' RecycleBinUtil.Tools.InvokeItemVerb(ShellObject, RecycleBinUtil.ItemVerbs)
' RecycleBinUtil.Tools.InvokeItemVerb(ShellObject, String)

#End Region

#End Region

#Region " Usage Examples "

#Region " Miscellaneous method calls "

'' Clean all the Recycle Bins.
'RecycleBinUtil.MasterBin.Clean()

'' Clean the Recycle Bin of the "E" drive.
'RecycleBinUtil.Tools.Clean("E"c, RecycleBinUtil.CleanFlags.DontShowConfirmation)

'' Update the icon of the master Recycle Bin (on desktop).
'RecycleBinUtil.MasterBin.UpdateIcon()

'' Get the accumulated size (in bytes) of the master Recycle Bin.
'Dim binSize As Long = RecycleBinUtil.MasterBin.Size
'Console.WriteLine(String.Format("Bin Size: {0}", binSize))

'' Get the recycled item count of the master recycle bin.
'Dim binItemCount As Long = RecycleBinUtil.MasterBin.ItemsCount
'Console.WriteLine(String.Format("item count: {0}", binItemCount))

'' Get all the recycled items of the master Recycle Bin.
'Dim binItems As IEnumerable(Of ShellObject) = RecycleBinUtil.MasterBin.Items
'Console.WriteLine(String.Format("Items: {0}", String.Join(Environment.NewLine, binItems)))

'' Get all the recycled files of the the master Recycle Bin.
'Dim binFiles As IEnumerable(Of ShellFile) = RecycleBinUtil.MasterBin.Files

'' Get all the recycled folders of the the master Recycle Bin.
'Dim binFolders As IEnumerable(Of ShellFolder) = RecycleBinUtil.MasterBin.Folders

'' Get all the recycled items of the the Recycle Bin on "E" drive.
'Dim binItemsE As IEnumerable(Of ShellObject) = RecycleBinUtil.Tools.GetRecycledItems("E"c)

'' Get all the recycled files of the the Recycle Bin on "E" drive.
'Dim binFilesE As IEnumerable(Of ShellFile) = RecycleBinUtil.Tools.GetRecycledFiles("E"c)

'' Get all the recycled folders of the the Recycle Bin on "E" drive.
'Dim binFoldersE As IEnumerable(Of ShellFolder) = RecycleBinUtil.Tools.GetRecycledFolders("E"c)

'' Gets the Last recycled item in the the master Recycle Bin.
'MsgBox(RecycleBinUtil.MasterBin.LastRecycledItem.Name)

'' Gets the Last recycled item in the Recycle Bin on "E" drive
'MsgBox(RecycleBinUtil.Tools.GetLastRecycledItem("E"c).Name)

'' Undeletes an item.
'RecycleBinUtil.Tools.UndeleteItem(RecycleBinUtil.MasterBin.LastRecycledItem)

'' Permanently deletes an item.
'RecycleBinUtil.Tools.DeleteItem(RecycleBinUtil.MasterBin.LastRecycledItem)

'' Invokes an Item verb
'RecycleBinUtil.Tools.InvokeItemVerb(RecycleBinUtil.MasterBin.LastRecycledItem, RecycleBinUtil.ItemVerbs.Properties)

'' Invokes a custom item verb
'RecycleBinUtil.Tools.InvokeItemVerb(RecycleBinUtil.MasterBin.LastRecycledItem, "play")

#End Region

#Region " Loop through recycled items "

'Sub Test()
'
'    Dim sb As New StringBuilder
'
'    ' Get all the deleted items inside all the Recycle Bins.
'    Dim recycledItems As IEnumerable(Of ShellObject) = RecycleBinUtil.MasterBin.Items
'
'    ' Loop through the deleted Items (Ordered by las deleted).
'    For Each item As ShellObject In (From itm In recycledItems
'                                   Order By itm.Properties.GetProperty("System.Recycle.DateDeleted").ValueAsObject
'                                   Descending)
'
'        ' Append the property bags information.
'        With sb
'            .AppendLine(String.Format("Full Name....: {0}", item.Name))
'            .AppendLine(String.Format("Item Name....: {0}", item.Properties.System.FileName.Value))
'            .AppendLine(String.Format("Deleted From.: {0}", item.Properties.GetProperty("System.Recycle.DeletedFrom").ValueAsObject))
'            .AppendLine(String.Format("Item Type....: {0}", item.Properties.System.ItemTypeText.Value))
'            .AppendLine(String.Format("Item Size....: {0}", CStr(item.Properties.System.Size.Value)))
'            .AppendLine(String.Format("Attributes...: {0}", [Enum].Parse(GetType(IO.FileAttributes), item.Properties.System.FileAttributes.Value.ToString)))
'            .AppendLine(String.Format("Date Deleted.: {0}", item.Properties.GetProperty("System.Recycle.DateDeleted").ValueAsObject))
'            .AppendLine(String.Format("Date Modified: {0}", CStr(item.Properties.System.DateModified.Value)))
'            .AppendLine(String.Format("Date Created.: {0}", CStr(item.Properties.System.DateCreated.Value)))
'        End With
'
'        MessageBox.Show(sb.ToString)
'        sb.Clear()
'
'    Next item
'
'End Sub

#End Region

#End Region

#Region " Option Statements "

Option Strict On
Option Explicit On
Option Infer Off

#End Region

#Region " Imports "

Imports Microsoft.WindowsAPICodePack.Shell
Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.InteropServices

#End Region

#Region " RecycleBin Util "

''' ----------------------------------------------------------------------------------------------------
''' <summary>
''' Manages the system's Recycle Bins.
''' </summary>
''' ----------------------------------------------------------------------------------------------------
''' <example> This is a code example that demonstrates how to loop through recycled items.
''' <code>
''' Private Sub Test()
''' 
'''     Dim sb As New StringBuilder
''' 
'''     ' Get all the deleted items inside all the Recycle Bins.
'''     Dim recycledItems As IEnumerable(Of ShellObject) = RecycleBinUtil.MasterBin.Items
''' 
'''     ' Loop through the deleted Items (Ordered by las deleted).
'''     For Each item As ShellObject In (From itm In recycledItems
'''                                    Order By itm.Properties.GetProperty("System.Recycle.DateDeleted").ValueAsObject
'''                                    Descending)
''' 
'''         ' Append the property bags information.
'''         With sb
'''             .AppendLine(String.Format("Full Name....: {0}", item.Name))
'''             .AppendLine(String.Format("Item Name....: {0}", item.Properties.System.FileName.Value))
'''             .AppendLine(String.Format("Deleted From.: {0}", item.Properties.GetProperty("System.Recycle.DeletedFrom").ValueAsObject))
'''             .AppendLine(String.Format("Item Type....: {0}", item.Properties.System.ItemTypeText.Value))
'''             .AppendLine(String.Format("Item Size....: {0}", CStr(item.Properties.System.Size.Value)))
'''             .AppendLine(String.Format("Attributes...: {0}", [Enum].Parse(GetType(IO.FileAttributes), item.Properties.System.FileAttributes.Value.ToString)))
'''             .AppendLine(String.Format("Date Deleted.: {0}", item.Properties.GetProperty("System.Recycle.DateDeleted").ValueAsObject))
'''             .AppendLine(String.Format("Date Modified: {0}", CStr(item.Properties.System.DateModified.Value)))
'''             .AppendLine(String.Format("Date Created.: {0}", CStr(item.Properties.System.DateCreated.Value)))
'''         End With
''' 
'''         MessageBox.Show(sb.ToString)
'''         sb.Clear()
''' 
'''     Next item
''' 
''' End Sub
''' </code>
''' </example>
''' ----------------------------------------------------------------------------------------------------
Public Module RecycleBinUtil

#Region " P/Invoking "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Platform Invocation methods (P/Invoke), access unmanaged code.
    ''' This class does not suppress stack walks for unmanaged code permission.
    ''' <see cref="System.Security.SuppressUnmanagedCodeSecurityAttribute"/> must not be applied to this class.
    ''' This class is for methods that can be used anywhere because a stack walk will be performed.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <remarks>
    ''' <see href="http://msdn.microsoft.com/en-us/library/ms182161.aspx"/>
    ''' </remarks>
    ''' ----------------------------------------------------------------------------------------------------
    Private NotInheritable Class NativeMethods

#Region " Functions "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Empties the Recycle Bin on the specified drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="hWnd">
        ''' A handle to the parent window of any dialog boxes that might be displayed during the operation.
        ''' This parameter can be <see langword="Nothing"/>.
        ''' </param>
        ''' 
        ''' <param name="RootPath">
        ''' The address of a null-terminated string of maximum length MAX_PATH that contains the path of the
        ''' root drive on which the Recycle Bin is located.
        ''' 
        ''' This parameter can contain the address of a string formatted with the drive, folder, and subfolder names,
        ''' for example 'C:\windows\system\'.
        ''' 
        ''' It can also contain an empty string or <see langword="Nothing"/>.
        ''' If this value is an empty string or <see langword="Nothing"/>, all Recycle Bins on all drives will be emptied.
        ''' </param>
        ''' 
        ''' <param name="Flags">
        ''' Specifies the Recycle bin behavior, this parameter can be one or more flags.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' <see langword="True"/> if operation succeeds, <see langword="False"/> otherwise.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="https://msdn.microsoft.com/en-us/library/windows/desktop/bb762160%28v=vs.85%29.aspx"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <DllImport("shell32.dll", EntryPoint:="SHEmptyRecycleBin", CharSet:=CharSet.Unicode)>
        Friend Shared Function EmptyRecycleBin(
                               Optional ByVal hWnd As IntPtr = Nothing,
                               Optional ByVal rootPath As String = Nothing,
                               Optional ByVal flags As RecycleBinUtil.CleanFlags = Nothing
        ) As Boolean
        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Updates the Recycle Bin icon on the desktop to reflect the state of the systemwide Recycle Bin,
        ''' for example if an error occurs during an <see cref="NativeMethods.EmptyRecycleBin"/> call.
        ''' 
        ''' But since the other Recycle Bin management functions will update this icon on their own,
        ''' there's almost no reason why your applications would need to call this function explicitly.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' <see langword="True"/> if operation succeeds, <see langword="False"/> otherwise.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <DllImport("shell32.dll", EntryPoint:="SHUpdateRecycleBinIcon")>
        Friend Shared Function UpdateRecycleBinIcon(
        ) As Boolean
        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Retrieves the accumulated size of the Recycle Bin and the number of items in it, for a specified drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="RootPath">
        ''' The address of a null-terminated string of maximum length MAX_PATH to contain the path of the
        ''' root drive on which the Recycle Bin is located.
        ''' 
        ''' This parameter can contain the address of a string formatted with the drive, folder,
        ''' and subfolder names (C:\Windows\System32\).
        ''' </param>
        ''' 
        ''' <param name="QueryRBInfo">
        ''' The address of a <see cref="NativeMethods.SHQueryRBInfo"/> structure that receives the Recycle Bin information.
        ''' The <see cref="NativeMethods.SHQueryRBInfo.StructSize"/> member of the structure must be set to the size of the structure 
        ''' before calling this API.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' <see langword="True"/> if operation succeeds, <see langword="False"/> otherwise.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="https://msdn.microsoft.com/en-us/library/windows/desktop/bb762241%28v=vs.85%29.aspx"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <DllImport("shell32.dll", EntryPoint:="SHQueryRecycleBin", CharSet:=CharSet.Unicode)>
        Friend Shared Function QueryRecycleBin(
                               ByVal rootPath As String,
                               ByRef queryRBInfo As SHQueryRBInfo
        ) As Boolean
        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Performs an operation on a specified file..
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="lpExecInfo">
        ''' A pointer to a <see cref="NativeMethods.ShellExecuteInfo"/> structure that contains and receives information about
        ''' the application being executed.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' <see langword="True"/> if successful, <see langword="False"/> otherwise.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DllImport("Shell32", CharSet:=CharSet.Auto, SetLastError:=True)>
        Friend Shared Function ShellExecuteEx(
                               ByRef lpExecInfo As ShellExecuteInfo
        ) As Boolean
        End Function

#End Region

#Region " Structures "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Contains the accumulated size and item count information retrieved by the <see cref="NativeMethods.QueryRecycleBin"/> function.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="http://msdn.microsoft.com/en-us/library/windows/desktop/bb759803%28v=vs.85%29.aspx"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <StructLayout(LayoutKind.Sequential)>
        Friend Structure SHQueryRBInfo

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' The size of the structure, in bytes.
            ''' This member must be filled in prior to calling the function.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            Public StructSize As Integer

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' The total size of all the objects in the specified Recycle Bin, in bytes.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            Public BinSize As Long

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' The total number of items in the specified Recycle Bin.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            Public ItemCount As Long

        End Structure

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Contains information used by the <see cref="NativeMethods.ShellExecuteEx"/> function.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="http://msdn.microsoft.com/en-us/library/windows/desktop/bb759784%28v=vs.85%29.aspx"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <StructLayout(LayoutKind.Sequential)>
        Friend Structure ShellExecuteInfo

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Required. 
            ''' The size of this structure, in bytes.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            Public CbSize As Integer

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Flags that indicate the content and validity of the other structure members.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            Public FMask As Integer

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Optional. 
            ''' A handle to the parent window, 
            ''' used to display any message boxes that the system might produce while executing this function. 
            ''' This value can be NULL.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            Public Hwnd As IntPtr

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' A string, referred to as a verb, that specifies the action to be performed. 
            ''' The set of available verbs depends on the particular file or folder. 
            ''' Generally, the actions available from an object's shortcut menu are available verbs. 
            ''' This parameter can be NULL, in which case the default verb is used if available. 
            ''' If not, the "open" verb is used. 
            ''' If neither verb is available, the system uses the first verb listed in the registry. 
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            <MarshalAs(UnmanagedType.LPTStr)> Public LpVerb As String

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' The address of a null-terminated string that specifies the name of the file 
            ''' or object on which ShellExecuteEx will perform the action specified by the lpVerb parameter. 
            ''' The system registry verbs that are supported by the ShellExecuteEx function include "open" 
            ''' for executable files and document files and "print" for document files 
            ''' for which a print handler has been registered. 
            ''' Other applications might have added Shell verbs through the system registry, 
            ''' such as "play" for .avi and .wav files.
            ''' To specify a Shell namespace object, pass the fully qualified parse name 
            ''' and set the SEE_MASK_INVOKEIDLIST flag in the fMask parameter.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            <MarshalAs(UnmanagedType.LPTStr)> Public LpFile As String

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Optional. 
            ''' The address of a null-terminated string that contains the application parameters. 
            ''' The parameters must be separated by spaces. 
            ''' If the lpFile member specifies a document file, lpParameters should be NULL.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            <MarshalAs(UnmanagedType.LPTStr)> Public LpParameters As String

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Optional. 
            ''' The address of a null-terminated string that specifies the name of the working directory. 
            ''' If this member is NULL, the current directory is used as the working directory.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            <MarshalAs(UnmanagedType.LPTStr)> Public LpDirectory As String

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Required. 
            ''' Flags that specify how an application is to be shown when it is opened; 
            ''' one of the SW_ values listed for the ShellExecute function. 
            ''' If lpFile specifies a document file, the flag is simply passed to the associated application. 
            ''' It is up to the application to decide how to handle it.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            Dim nShow As WindowShowCommand

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' If SEE_MASK_NOCLOSEPROCESS is set and the ShellExecuteEx call succeeds, 
            ''' it sets this member to a value greater than 32. 
            ''' If the function fails, it is set to an SE_ERR_XXX error value that indicates the cause of the failure. 
            ''' Although hInstApp is declared as an HINSTANCE for compatibility with 16-bit Windows applications, 
            ''' it is not a true HINSTANCE. 
            ''' It can be cast only to an int and compared to either 32 or the following SE_ERR_XXX error codes.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            Dim hInstApp As IntPtr

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' The address of an absolute ITEMIDLIST structure (PCIDLIST_ABSOLUTE) 
            ''' to contain an item identifier list that uniquely identifies the file to execute. 
            ''' This member is ignored if the fMask member does not include SEE_MASK_IDLIST or SEE_MASK_INVOKEIDLIST.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            Dim lpIDList As IntPtr

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' The address of a null-terminated string that specifies one of the following
            ''' A ProgId. For example, "Paint.Picture".
            ''' A URI protocol scheme. For example, "http".
            ''' A file extension. For example, ".txt".
            ''' A registry path under HKEY_CLASSES_ROOT that names a subkey that contains one or more Shell verbs. 
            ''' This key will have a subkey that conforms to the Shell verb registry schema, such as shell\verb name.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            <MarshalAs(UnmanagedType.LPTStr)> Public LpClass As String

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' A handle to the registry key for the file type. 
            ''' The access rights for this registry key should be set to KEY_READ. 
            ''' This member is ignored if fMask does not include SEE_MASK_CLASSKEY.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            Public HkeyClass As IntPtr

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' A keyboard shortcut to associate with the application. 
            ''' The low-order word is the virtual key code, and the high-order word is a modifier flag (HOTKEYF_).
            ''' For a list of modifier flags, see the description of the WM_SETHOTKEY message. 
            ''' This member is ignored if fMask does not include SEE_MASK_HOTKEY.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            Public DwHotKey As Integer

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' A handle to the icon for the file type. 
            ''' This member is ignored if fMask does not include SEE_MASK_ICON. 
            ''' This value is used only in Windows XP and earlier. 
            ''' It is ignored as of Windows Vista.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            Public HIcon As IntPtr

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' A handle to the monitor upon which the document is to be displayed. 
            ''' This member is ignored if fMask does not include SEE_MASK_HMONITOR.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            Public HProcess As IntPtr

        End Structure

#End Region

    End Class

#End Region

#Region " Enumerations "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Specifies the Recycle Bin behavior when cleaning the bin.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    <Flags>
    Public Enum CleanFlags As Integer

        ''' <summary>
        ''' Don't show deletion confirmation.
        ''' </summary>
        DontShowConfirmation = &H1

        ''' <summary>
        ''' Don't show deletion progress.
        ''' </summary>
        DontShowProgressUI = &H2

        ''' <summary>
        ''' Don't play sound on deletion.
        ''' </summary>
        DontPlaySound = &H4

    End Enum

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' A verb is a string used to specify a particular action that an item supports.
    ''' Invoking a verb is equivalent to selecting a command from an item's context menu.
    ''' Typically, invoking a verb launches a related application.
    ''' For example, invoking the "open" verb on a ".txt" file opens the file with a text editor, usually Notepad.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Public Enum ItemVerbs As Integer

        ''' <summary>
        ''' Opens an item.
        ''' This is usually the default verb.
        ''' </summary>
        Open = 0

        ''' <summary>
        ''' Opens dialog when no program is associated to the file-extension.
        ''' </summary>
        OpenAs = 1

        ''' <summary>
        ''' Opens the default text editor on the item.
        ''' </summary>
        Edit = 2

        ''' <summary>
        ''' Opens the Windows Explorer in the item Folder.
        ''' </summary>
        Explore = 3

        ''' <summary>
        ''' Opens the properties window of the item.
        ''' </summary>
        Properties = 4

        ''' <summary>
        ''' Starts a search.
        ''' </summary>
        Find = 5

        ''' <summary>
        ''' Start printing the file with the default application.
        ''' </summary>
        Print = 6

        ''' <summary>
        ''' Opens the run UAC dialog in the file.
        ''' </summary>
        RunAs = 7

        ''' <summary>
        ''' Copies the item.
        ''' </summary>
        Copy = 8

        ''' <summary>
        ''' Cuts the item.
        ''' </summary>
        Cut = 9

        ''' <summary>
        ''' Pastes the item.
        ''' </summary>
        Paste = 10

        ''' <summary>
        ''' Deletes an item.
        ''' If the Item is inside the recycle bin, it will be permanently deleted.
        ''' </summary>
        Delete = 11

        ''' <summary>
        ''' Undeletes an item from the recycle bin.
        ''' </summary>
        Undelete = 12

    End Enum

#End Region

#Region " Properties "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Gets the master recycle bin representation.
    ''' The master Recycle Bin is the one that contains all the recycled items of all the recycle bins.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <value>
    ''' The master recycle bin.
    ''' </value>
    ''' ----------------------------------------------------------------------------------------------------
    Public ReadOnly Property MasterBin As MasterBinLayout
        <DebuggerStepThrough>
        Get
            If (masterBinB Is Nothing) Then
                masterBinB = New MasterBinLayout
            End If
            Return masterBinB
        End Get
    End Property
    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' ( Backing field )
    ''' The master recycle bin.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Private masterBinB As MasterBinLayout

#End Region

#Region " Hidden methods "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the specified System.Object instances are considered equal.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Function Equals(ByVal obj As Object) As Boolean
        Return Nothing
    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the specified System.Object instances are the same instance.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Function ReferenceEquals(ByVal objA As Object, ByVal objB As Object) As Boolean
        Return Nothing
    End Function

#End Region

#Region " Child Classes "

#Region " Master Bin Layout "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Retrieves information about the master Recycle Bin, and perform other operations.
    ''' The master Recycle Bin is the one that also contains all the recycled items of all the recycle bins.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public NotInheritable Class MasterBinLayout

#Region " Properties "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' The Recycle Bin virtual folder.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Public ReadOnly Property KnownFolder As IKnownFolder
            <DebuggerStepThrough>
            Get
                Return KnownFolders.RecycleBin
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets all the items (files, folders, etc) that are inside the master Recycle bin.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <value>
        ''' All the items (files, folders, etc) that are inside the master Recycle bin.
        ''' </value>
        ''' ----------------------------------------------------------------------------------------------------
        Public ReadOnly Property Items As IEnumerable(Of ShellObject)
            <DebuggerStepThrough>
            Get
                Return RecycleBinUtil.Tools.GetRecycledItems(Nothing)
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets all the files that are inside the master Recycle bin.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <value>
        ''' All the files that are inside the master Recycle bin.
        ''' </value>
        ''' ----------------------------------------------------------------------------------------------------
        Public ReadOnly Property Files As IEnumerable(Of ShellFile)
            <DebuggerStepThrough>
            Get
                Return RecycleBinUtil.Tools.GetRecycledFiles(Nothing)
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets all the folders that are inside the master Recycle bin.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <value>
        ''' All the folders that are inside the master Recycle bin.
        ''' </value>
        ''' ----------------------------------------------------------------------------------------------------
        Public ReadOnly Property Folders As IEnumerable(Of ShellFolder)
            <DebuggerStepThrough>
            Get
                Return RecycleBinUtil.Tools.GetRecycledFolders(Nothing)
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the last recycled item that is inside the master Recycle bin.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <value>
        ''' The last recycled item that is inside the master Recycle bin.
        ''' </value>
        ''' ----------------------------------------------------------------------------------------------------
        Public ReadOnly Property LastRecycledItem As ShellObject
            <DebuggerStepThrough>
            Get
                Return RecycleBinUtil.Tools.GetLastRecycledItem(Nothing)
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets last recycled file that is inside the master Recycle bin.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <value>
        ''' The last recycled file that is inside the master Recycle bin.
        ''' </value>
        ''' ----------------------------------------------------------------------------------------------------
        Public ReadOnly Property LastRecycledFile As ShellFile
            <DebuggerStepThrough>
            Get
                Return RecycleBinUtil.Tools.GetLastRecycledFile(Nothing)
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets last recycled folder that is inside the master Recycle bin.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <value>
        ''' The last recycled folder that is inside the master Recycle bin.
        ''' </value>
        ''' ----------------------------------------------------------------------------------------------------
        Public ReadOnly Property LastRecycledFolder As ShellFolder
            <DebuggerStepThrough>
            Get
                Return RecycleBinUtil.Tools.GetLastRecycledFolder(Nothing)
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the accumulated size of the master Recycle bin.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <value>
        ''' The accumulated size of the master Recycle bin.
        ''' </value>
        ''' ----------------------------------------------------------------------------------------------------
        Public ReadOnly Property Size As Long
            <DebuggerStepThrough>
            Get
                Return RecycleBinUtil.Tools.GetBinSize(Nothing)
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the item count of the master Recycle bin.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <value>
        ''' The item count of the master Recycle bin.
        ''' </value>
        ''' ----------------------------------------------------------------------------------------------------
        Public ReadOnly Property ItemsCount As Long
            <DebuggerStepThrough>
            Get
                Return RecycleBinUtil.Tools.GetItemsCount(Nothing)
            End Get
        End Property

#End Region

#Region " Constructors "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new instance of the <see cref="MasterBinLayout"/> class.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Public Sub New()
        End Sub

#End Region

#Region " Public Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Cleans the master Recycle Bin.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="Flags">
        ''' The recycle bin behavior.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' <see langword="True"/> if operation succeeds, <see langword="False"/> otherwise.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Function Clean(Optional ByVal flags As RecycleBinUtil.CleanFlags =
                                                      RecycleBinUtil.CleanFlags.DontShowConfirmation) As Boolean

            Return NativeMethods.EmptyRecycleBin(IntPtr.Zero, Nothing, flags)

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Refreshes the Recycle bin icon.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' <see langword="True"/> if operation succeeds, <see langword="False"/> otherwise.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Function UpdateIcon() As Boolean

            Return NativeMethods.UpdateRecycleBinIcon()

        End Function

#End Region

#Region " Hidden methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Determines whether the specified System.Object instances are considered equal.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Function Equals(ByVal obj As Object) As Boolean
            Return MyBase.Equals(obj)
        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Serves as a hash function for a particular type.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Function GetHashCode() As Integer
            Return MyBase.GetHashCode
        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the System.Type of the current instance.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Function [GetType]() As Type
            Return MyBase.GetType
        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Returns a String that represents the current object.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Function ToString() As String
            Return MyBase.ToString
        End Function

#End Region

    End Class

#End Region

#Region " Tools "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Retrieves information about the Recycle Bin of an specific drive, and perform other operations.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Public NotInheritable Class Tools

#Region " Public Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Cleans the Recycle Bin of an specific Drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="DriveLetter">
        ''' The recycle bin drive letter.
        ''' 
        ''' If this parameter is <see langword="Nothing"/> then it cleans all the Recycle Bins.
        ''' </param>
        ''' 
        ''' <param name="Flags">
        ''' The recycle bin behavior.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' <see langword="True"/> if operation succeeds, <see langword="False"/> otherwise.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Function Clean(ByVal driveLetter As Char,
                                     Optional ByVal flags As CleanFlags = Nothing) As Boolean

            Select Case driveLetter = Nothing

                Case True
                    Return NativeMethods.EmptyRecycleBin(IntPtr.Zero, String.Empty, flags)

                Case Else
                    Return NativeMethods.EmptyRecycleBin(IntPtr.Zero, String.Format("{0}:\", driveLetter), flags)

            End Select

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the accumulated size (in bytes) of the recycle bin of an specific drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="driveLetter">
        ''' The recycle bin drive letter.
        ''' </param>    
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' The accumulated size (in bytes) of the recycle bin of an specific drive.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Function GetBinSize(ByVal driveLetter As Char) As Long

            Dim sqrbi As New NativeMethods.SHQueryRBInfo() With
                {
                    .StructSize = Marshal.SizeOf(GetType(NativeMethods.SHQueryRBInfo))
                }

            Select Case driveLetter = Nothing

                Case True
                    NativeMethods.QueryRecycleBin(String.Empty, sqrbi)

                Case Else
                    NativeMethods.QueryRecycleBin(String.Format("{0}:\", driveLetter), sqrbi)

            End Select

            Return sqrbi.BinSize

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the count of the items that are inside the recycle bin of an specific drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="driveLetter">
        ''' The recycle bin drive letter.
        ''' </param>      
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' The count of the items that are inside the recycle bin of an specific drive.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Function GetItemsCount(ByVal driveLetter As Char) As Long

            Dim sqrbi As New NativeMethods.SHQueryRBInfo() With
                {
                    .StructSize = Marshal.SizeOf(GetType(NativeMethods.SHQueryRBInfo))
                }

            Select Case driveLetter = Nothing

                Case True
                    NativeMethods.QueryRecycleBin(String.Empty, sqrbi)

                Case Else
                    NativeMethods.QueryRecycleBin(String.Format("{0}:\", driveLetter), sqrbi)

            End Select

            Return sqrbi.ItemCount

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets all the recycled items that are inside the recycle bin of an specific drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="driveLetter">
        ''' The recycle bin drive letter.
        ''' </param>        
        '''  ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' All the recycled items that are inside the recycle bin of an specific drive.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Function GetRecycledItems(ByVal driveLetter As Char) As IEnumerable(Of ShellObject)

            Return (From Item As ShellObject In KnownFolders.RecycleBin
                    Where If(driveLetter = Nothing,
                             Item.Name = Item.Name,
                             Item.Name.StartsWith(driveLetter, StringComparison.InvariantCultureIgnoreCase)))

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets all the recycled files that are inside the recycle bin of an specific drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="driveLetter">
        ''' The recycle bin drive letter.
        ''' </param>        
        '''  ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' All the recycled files that are inside the recycle bin of an specific drive.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Function GetRecycledFiles(ByVal driveLetter As Char) As IEnumerable(Of ShellFile)

            Return RecycleBinUtil.Tools.GetRecycledItemsOf(Of ShellFile)(driveLetter)

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets all the recycled folders that are inside the recycle bin of an specific drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="driveLetter">
        ''' The recycle bin drive letter.
        ''' </param>        
        '''  ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' All the recycled folders that are inside the recycle bin of an specific drive.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Function GetRecycledFolders(ByVal driveLetter As Char) As IEnumerable(Of ShellFolder)

            Return RecycleBinUtil.Tools.GetRecycledItemsOf(Of FileSystemKnownFolder)(driveLetter).Cast(Of ShellFolder).
                                        Concat(RecycleBinUtil.Tools.GetRecycledItemsOf(Of NonFileSystemKnownFolder)(driveLetter).AsEnumerable).
                                        Cast(Of ShellFolder)()

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the last recycled item that is inside the recycle bin of an specific drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="driveLetter">
        ''' The recycle bin drive letter.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' The last recycled item that is inside the recycle bin of an specific drive.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Function GetLastRecycledItem(ByVal driveLetter As Char) As ShellObject

            Return (From item As ShellObject
                    In RecycleBinUtil.Tools.GetRecycledItems(driveLetter)
                    Order By item.Properties.GetProperty("DateDeleted").ValueAsObject Descending).
                    FirstOrDefault

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the last recycled file that is inside the recycle bin of an specific drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="driveLetter">
        ''' The recycle bin drive letter.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' The last recycled file that is inside the recycle bin of an specific drive.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Function GetLastRecycledFile(ByVal driveLetter As Char) As ShellFile

            Return (From item As ShellFile
                    In RecycleBinUtil.Tools.GetRecycledItemsOf(Of ShellFile)(driveLetter)
                    Order By item.Properties.GetProperty("DateDeleted").ValueAsObject Descending).
                    FirstOrDefault

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the last recycled folder that is inside the recycle bin of an specific drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="driveLetter">
        ''' The recycle bin drive letter.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' The last recycled folder that is inside the recycle bin of an specific drive.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Function GetLastRecycledFolder(ByVal driveLetter As Char) As ShellFolder

            Return (From item As ShellFolder
                    In RecycleBinUtil.Tools.GetRecycledFolders(driveLetter)
                    Order By item.Properties.GetProperty("DateDeleted").ValueAsObject Descending).
                    FirstOrDefault

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Permanently deletes a recycled Item.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="item">
        ''' The item to permanently delete.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Sub DeleteItem(ByVal item As ShellObject)

            RecycleBinUtil.Tools.InvokeItemVerb(item, ItemVerbs.Delete)

        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Undeletes a recycled Item.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="item">
        ''' The item to undelete.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Sub UndeleteItem(ByVal item As ShellObject)

            RecycleBinUtil.Tools.InvokeItemVerb(item, ItemVerbs.Undelete)

        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Invokes a custom verb on a ShellObject item.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="item">
        ''' The item.
        ''' </param>
        ''' 
        ''' <param name="verb">
        ''' The verb to invoke on the item.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Sub InvokeItemVerb(ByVal item As ShellObject,
                                         ByVal verb As String)

            Dim fileName As String =
                item.ParsingName.Split("\"c).Last

            Dim fileDir As String =
                Path.GetDirectoryName(item.ParsingName)

            Dim sei As New NativeMethods.ShellExecuteInfo

            With sei

                .CbSize = Marshal.SizeOf(sei)

                ' Here we want ONLY the file name (without the path).
                .LpFile = fileName

                ' Here we want the exact directory from the parsing name.
                .LpDirectory = fileDir

                .nShow = WindowShowCommand.Show
                .LpVerb = verb

            End With

            ' Invoke the verb.
            NativeMethods.ShellExecuteEx(sei)

        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Invokes a verb on a <see cref="ShellObject"/> item.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="item">
        ''' The item.
        ''' </param>
        ''' 
        ''' <param name="verb">
        ''' The verb to invoke on the item.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Sub InvokeItemVerb(ByVal item As ShellObject,
                                         ByVal verb As ItemVerbs)

            RecycleBinUtil.Tools.InvokeItemVerb(item, verb.ToString)

        End Sub

#End Region

#Region " Private Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the items of the specified <see cref="Type"/> that are inside the recycle bin of the specified drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <typeparam name="T">
        ''' The kind of recycled items to retrieve (<see langword="ShellFile"/>, <see langword="ShellFolder"/>, etc...)
        ''' </typeparam>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="DriveLetter">The recycle bin drive letter.
        ''' If this parameter is <see langword="Nothing"/> then it returns the merged contents of all the Recycle Bins.</param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' The items of the specified <see cref="Type"/> that are inside the recycle bin of the specified drive.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Private Shared Function GetRecycledItemsOf(Of T)(Optional ByVal driveLetter As Char = Nothing) As IEnumerable(Of T)

            Return (From Item As ShellObject In MasterBin.KnownFolder
                    Where If(driveLetter = Nothing,
                             Item.GetType = GetType(T),
                             Item.GetType = GetType(T) AndAlso
                             Item.Name.StartsWith(driveLetter, StringComparison.InvariantCultureIgnoreCase))).Cast(Of T)()

        End Function

#End Region

#Region " Hidden methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Determines whether the specified System.Object instances are considered equal.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Function Equals(ByVal obj As Object) As Boolean
            Return MyBase.Equals(obj)
        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Determines whether the specified System.Object instances are the same instance.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Function ReferenceEquals(ByVal objA As Object, ByVal objB As Object) As Boolean
            Return Nothing
        End Function

#End Region

    End Class

#End Region

#End Region

End Module

#End Region
