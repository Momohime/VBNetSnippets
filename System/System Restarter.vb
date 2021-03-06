' ***********************************************************************
' Author   : Elektro
' Modified : 24-October-2015
' ***********************************************************************
' <copyright file="System Restarter.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Public Members Summary "

#Region " Constants "

' SystemRestarter.MaxShutdownTimeout As UInteger

#End Region

#Region " Enumerations "

' SystemRestarter.LogOffMode As UInteger
' SystemRestarter.ShutdownMode As UInteger
' SystemRestarter.ShutdownReason As UInteger <Flags>
' SystemRestarter.ShutdownPlanning As UInteger

#End Region

#Region " Functions "

' SystemRestarter.Abort(Opt: String, Opt: Boolean) As Boolean
' SystemRestarter.LogOff(Opt: LogOffMode, Opt: ShutdownReason, Opt: Boolean) As Boolean
' SystemRestarter.PowerOff(Opt: String, Opt: Integer, Opt: String, Opt: ShutdownMode, Opt: ShutdownReason, Opt: ShutdownPlanning, Opt: Boolean) As Boolean
' SystemRestarter.Restart(Opt: String, Opt: Integer, Opt: String, Opt: ShutdownMode, Opt: ShutdownReason, Opt: ShutdownPlanning, Opt: Boolean) As Boolean
' SystemRestarter.RestartApps(Opt: String, Opt: Integer, Opt: String, Opt: ShutdownMode, Opt: ShutdownReason, Opt: ShutdownPlanning, Opt: Boolean) As Boolean
' SystemRestarter.Shutdown(Opt: String, Opt: Integer, Opt: String, Opt: ShutdownMode, Opt: ShutdownReason, Opt: ShutdownPlanning, Opt: Boolean) As Boolean
' SystemRestarter.HybridShutdown(Opt: String = Nothing, Opt: Integer, Opt: String, Opt: ShutdownMode, Opt: ShutdownReason, Opt: ShutdownPlanning, Opt: Boolean) As Boolean

#End Region

#End Region

#Region " Usage Examples "

'' Restart the current computer in 60 seconds and wait for applications to close.
'' Specify that the restart operation is planned because a consecuence of an installation.
'Dim success As Boolean =
'    SystemRestarter.Restart(Nothing, 60, "System is gonna be restarted quickly, go save all your data now...!",
'                            SystemRestarter.ShutdownMode.Wait,
'                            SystemRestarter.ShutdownReason.MajorOperatingSystem Or
'                            SystemRestarter.ShutdownReason.MinorInstallation,
'                            SystemRestarter.ShutdownPlanning.Planned)
'
'Console.WriteLine(String.Format("Restart operation initiated successfully?: {0}", CStr(success)))
'
'' Abort the current operation.
'If success Then
'    Dim isAborted As Boolean = SystemRestarter.Abort(computer:=Nothing, ignoreErrors:=False)
'    Console.WriteLine(String.Format("Restart operation aborted   successfully?: {0}", CStr(isAborted)))
'Else
'    Console.WriteLine("There is any restart operation to abort.")
'End If
'
'If MessageBox.Show("Want to proceed inmediately with a shutdown that cannot be aborted ?", "",
'                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
'
'    ' Shutdown the current computer instantlly and force applications to close.
'    ' ( When timeout is '0' the operation can't be aborted )
'    SystemRestarter.Shutdown(Nothing, 0, Nothing, SystemRestarter.ShutdownMode.ForceSelf)
'
'    ' LogOffs the current user.
'    SystemRestarter.LogOff(SystemRestarter.LogOffMode.Wait)
'
'End If

#End Region

#Region " Option Statements "

Option Strict On
Option Explicit On
Option Infer Off

#End Region

#Region " Imports "

Imports System
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.ComponentModel

#End Region

#Region " System Restarter "

''' ----------------------------------------------------------------------------------------------------
''' <summary>
''' Shutdown, restart or logoff the local or a remote computer.
''' </summary>
''' ----------------------------------------------------------------------------------------------------
''' <example> This is a code example.
''' <code>
''' ' Restart the current computer in 60 seconds and wait for applications to close.
''' ' Specify that the restart operation is planned because a consecuence of an installation.
''' Dim success As Boolean =
'''     SystemRestarter.Restart(Nothing, 60, "System is gonna be restarted quickly, go save all your data now...!",
'''                             SystemRestarter.ShutdownMode.Wait,
'''                             SystemRestarter.ShutdownReason.MajorOperatingSystem Or
'''                             SystemRestarter.ShutdownReason.MinorInstallation,
'''                             SystemRestarter.ShutdownPlanning.Planned)
''' 
''' Console.WriteLine(String.Format("Restart operation initiated successfully?: {0}", CStr(success)))
''' 
''' ' Abort the current operation.
''' If success Then
'''     Dim isAborted As Boolean = SystemRestarter.Abort(computer:=Nothing, ignoreErrors:=False)
'''     Console.WriteLine(String.Format("Restart operation aborted   successfully?: {0}", CStr(isAborted)))
''' Else
'''     Console.WriteLine("There is any restart operation to abort.")
''' End If
''' 
''' If MessageBox.Show("Want to proceed inmediately with a shutdown that cannot be aborted ?", "",
'''                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
''' 
'''     ' Shutdown the current computer instantlly and force applications to close.
'''     ' ( When timeout is '0' the operation can't be aborted )
'''     SystemRestarter.Shutdown(Nothing, 0, Nothing, SystemRestarter.ShutdownMode.ForceSelf)
''' 
'''     ' LogOffs the current user.
'''     SystemRestarter.LogOff(SystemRestarter.LogOffMode.Wait)
''' 
''' End If
''' </code>
''' </example>
''' ----------------------------------------------------------------------------------------------------
Public Module SystemRestarter

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
        ''' Logs off the interactive user, shuts down the system, or shuts down and restarts the system. 
        ''' It sends the 'WM_QUERYENDSESSION' message to all applications to determine if they can be terminated.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="uFlags">
        ''' Indicates the shutdown type.
        ''' </param>
        ''' 
        ''' <param name="dwReason">
        ''' Indicates the reason for initiating the shutdown.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' If the function succeeds, the return value is <see langword="True"/>. 
        ''' The function executes asynchronously so a <see langword="True"/> return value indicates that the shutdown has been initiated. 
        ''' It does not indicate whether the shutdown will succeed. 
        ''' It is possible that the system, the user, or another application will abort the shutdown.
        ''' If the function fails, the return value is <see langword="False"/>. 
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa376868%28v=vs.85%29.aspx"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <DllImport("user32.dll", SetLastError:=True)>
        Friend Shared Function ExitWindowsEx(
                               ByVal uFlags As UInteger,
                               ByVal dwReason As UInteger
        ) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Initiates a shutdown and restart of the specified computer, 
        ''' and restarts any applications that have been registered for restart.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="lpMachineName">
        ''' The name of the computer to be shut down. 
        ''' If the value of this parameter is <c>Nothing</c>, the local computer is shut down.
        ''' This parameter can be an addres, for example: '127.0.0.1'
        ''' </param>
        ''' 
        ''' <param name="lpMessage">
        ''' The message to be displayed in the interactive shutdown dialog box.
        ''' </param>
        ''' 
        ''' <param name="dwGracePeriod">
        ''' The number of seconds to wait before shutting down the computer. 
        ''' If the value of this parameter is zero, the computer is shut down immediately. 
        ''' This value is limited to 'MAX_SHUTDOWN_TIMEOUT'.
        ''' If the value of this parameter is greater than zero, and the <paramref name="dwShutdownFlags"></paramref> parameter 
        ''' specifies the flag 'GRACE_OVERRIDE', the function fails and returns the error code 'ERROR_BAD_ARGUMENTS'.
        ''' </param>
        ''' 
        ''' <param name="dwShutdownFlags">
        ''' Specifies options for the shutdown.
        ''' </param>
        ''' 
        ''' <param name="dwReason">
        ''' The reason for initiating the shutdown. 
        ''' If this parameter is zero, 
        ''' the default is an undefined shutdown that is logged as "No title for this reason could be found". 
        ''' By default, it is also an 'unplanned' shutdown.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' If the function succeeds, it returns ERROR_SUCCESS.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa376872%28v=vs.85%29.aspx"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Auto, BestFitMapping:=False, ThrowOnUnmappableChar:=True)>
        Friend Shared Function InitiateShutdown(
                               ByVal lpMachineName As String,
                               ByVal lpMessage As String,
                               ByVal dwGracePeriod As Integer,
                               ByVal dwShutdownFlags As UInteger,
                               ByVal dwReason As UInteger
        ) As UInteger
        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Aborts a system shutdown that has been initiated.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="lpMachineName">
        ''' The network name of the computer where the shutdown is to be stopped. 
        ''' If this parameter is <c>Nothing</c> or an empty string, the function aborts the shutdown on the local computer.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' <see langword="True"/> if the function succeeds, <see langword="False"/> otherwise.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="http://msdn.microsoft.com/es-es/library/windows/desktop/aa376630%28v=vs.85%29.aspx"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Auto, BestFitMapping:=False, ThrowOnUnmappableChar:=True)>
        Friend Shared Function AbortSystemShutdown(
                      Optional ByVal lpMachineName As String = "127.0.0.1"
        ) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Opens the access token associated with a process.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="ProcessHandle">
        ''' An <see cref="IntPtr"></see> handle to the process whose access token is opened. 
        ''' The process must have the 'PROCESS_QUERY_INFORMATION' access permission.
        ''' </param>
        ''' 
        ''' <param name="DesiredAccess">
        ''' Specifies an access mask that specifies the requested types of access to the access token. 
        ''' These requested access types are compared with the discretionary access control list (DACL) 
        ''' of the token to determine which accesses are granted or denied.
        ''' </param>
        ''' 
        ''' <param name="TokenHandle">
        ''' Am <see cref="IntPtr"></see> handle that identifies the newly opened access token when the function returns.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>If the function succeeds, the return value is nonzero.
        ''' If the function fails, the return value is zero. 
        ''' To get extended error information, call <see cref="Marshal.GetLastWin32Error"></see>.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa379295%28v=vs.85%29.aspx"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <DllImport("advapi32.dll", SetLastError:=True)>
        Friend Shared Function OpenProcessToken(
                               ByVal processHandle As IntPtr,
                               ByVal desiredAccess As SystemRestarter.NativeMethods.AccessRights,
                               ByRef tokenHandle As IntPtr
        ) As Integer
        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Enables or disables privileges in the specified access token.
        ''' Enabling or disabling privileges in an access token requires 'TOKEN_ADJUST_PRIVILEGES' access.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="tokenHandle">
        ''' An <see cref="IntPtr"></see> pointer handle to the access token that contains the privileges to be modified. 
        ''' The handle must have 'TOKEN_ADJUST_PRIVILEGES' access to the token. 
        ''' If the <paramref name="previousState"></paramref> parameter is not <see cref="IntPtr.Zero"></see>, the handle must also have 'TOKEN_QUERY' access.
        ''' </param>
        ''' 
        ''' <param name="disableAllPrivileges">
        ''' Specifies whether the function disables all of the token's privileges. 
        ''' If this value is <see langword="True"/>, the function disables all privileges and ignores the <paramref name="newState"></paramref> parameter. 
        ''' If it is <see langword="False"/>, the function modifies privileges based on the information pointed to by the <paramref name="newState"></paramref> parameter.
        ''' </param>
        ''' 
        ''' <param name="newState">
        ''' A <see cref="IntPtr"></see> pointer to a <see cref="SystemRestarter.NativeMethods.TokenPrivileges"></see> structure that specifies an
        ''' array of privileges and their attributes. 
        ''' If the <paramref name="disableAllPrivileges"></paramref> parameter is <see langword="False"/>, 
        ''' the <paramref name="adjustTokenPrivileges"></paramref> function enables, disables, or removes these privileges for the token. 
        ''' </param>
        ''' 
        ''' <param name="bufferLength">
        ''' Specifies the size, in bytes, of the buffer pointed to by the <paramref name="previousState"></paramref> parameter. 
        ''' This parameter can be zero if the <paramref name="previousState"></paramref> parameter is <see cref="IntPtr.Zero"></see>.
        ''' </param>
        ''' 
        ''' <param name="previousState">
        ''' A <see cref="IntPtr"></see> pointer to a buffer that the function fills with a <see cref="SystemRestarter.NativeMethods.TokenPrivileges"></see> structure
        ''' that contains the previous state of any privileges that the function modifies. 
        ''' That is, if a privilege has been modified by this function, 
        ''' the privilege and its previous state are contained in the <see cref="SystemRestarter.NativeMethods.TokenPrivileges"></see> structure 
        ''' referenced by <paramref name="previousState"></paramref>. 
        ''' If the <paramref name="privilegeCount"></paramref> member of <see cref="SystemRestarter.NativeMethods.TokenPrivileges"></see> is zero,
        ''' then no privileges have been changed by this function. 
        ''' This parameter can be <see cref="IntPtr.Zero"></see>.
        ''' </param>
        ''' 
        ''' <param name="returnLength">
        ''' A <see cref="IntPtr"></see> pointer to a variable that receives the required size, in bytes, 
        ''' of the buffer pointed to by the <paramref name="previousState"></paramref> parameter. 
        ''' This parameter can be <see cref="IntPtr.Zero"></see> if <paramref name="previousState"></paramref> is <see cref="IntPtr.Zero"></see>.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' If the function succeeds, the return value is <see langword="True"/>, otherwise, <see langword="False"/>.
        ''' To determine whether the function adjusted all of the specified privileges, call <see cref="Marshal.GetLastWin32Error"></see>.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="http://msdn.microsoft.com/es-es/library/windows/desktop/aa375202%28v=vs.85%29.aspx"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <DllImport("advapi32.dll", SetLastError:=True)>
        Friend Shared Function AdjustTokenPrivileges(
                               ByVal tokenHandle As IntPtr,
                               <MarshalAs(UnmanagedType.Bool)> ByVal disableAllPrivileges As Boolean,
                               ByRef newState As SystemRestarter.NativeMethods.TokenPrivileges,
                               ByVal bufferLength As UInteger,
                               ByVal previousState As IntPtr,
                               ByVal returnLength As IntPtr
        ) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Retrieves the locally unique identifier (LUID) used on a specified system, 
        ''' to locally represent the specified privilege name.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="lpSystemName">
        ''' A pointer to a null-terminated string that specifies the name of the system 
        ''' on which the privilege name is retrieved. 
        ''' If a null string is specified, the function attempts to find the privilege name on the local system
        ''' </param>
        ''' 
        ''' <param name="lpName">
        ''' A pointer to a null-terminated string that specifies the name of the privilege, 
        ''' as defined in the Winnt.h header file.
        ''' For example, this parameter could specify the constant, 'SE_SECURITY_NAME', 
        ''' or its corresponding string, "SeSecurityPrivilege".
        ''' </param>
        ''' 
        ''' <param name="lpLuid">
        ''' A pointer to a variable that receives the LUID by which the privilege is known on
        ''' the system specified by the <paramref name="lpSystemName"></paramref> parameter.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' If the function succeeds, the function returns nonzero.
        ''' If the function fails, it returns zero. 
        ''' To get extended error information, call <see cref="Marshal.GetLastWin32Error"></see>.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa379180%28v=vs.85%29.aspx"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Auto, BestFitMapping:=False, ThrowOnUnmappableChar:=True)>
        Friend Shared Function LookupPrivilegeValue(
                               ByVal lpSystemName As String,
                               ByVal lpName As String,
                               ByRef lpLuid As SystemRestarter.NativeMethods.Luid
        ) As Integer
        End Function

#End Region

#Region " Enumerations "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Flags for <paramref name="uFlags"/> parameter of <see cref="SystemRestarter.NativeMethods.ExitWindowsEx"/> function.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa376868%28v=vs.85%29.aspx"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <Flags>
        Friend Enum ExitwindowsExFlags As UInteger

            ''' <summary>
            ''' Shuts down all processes running in the logon session of the current process. 
            ''' Then it logs the user off.
            ''' This flag can be used only by processes running in an interactive user's logon session.
            ''' </summary>
            LogOff = &H0UI

            ' ''' <summary>
            ' ''' Shuts down the system to a point at which it is safe to turn off the power. 
            ' ''' All file buffers have been flushed to disk, and all running processes have stopped.
            ' ''' The calling process must have the SE_SHUTDOWN_NAME privilege. 
            ' ''' Specifying this flag will not turn off the power even if the system supports the power-off feature, 
            ' ''' You must use <see cref="SystemRestarter.NativeMethods.ExitWindowsExFlags.PowerOff"/> to do this.
            ' ''' </summary>
            ' ShutDown = &H1UI

            ' ''' <summary>
            ' ''' ( Beginning with Windows 8 )
            ' ''' You can prepare the system for a faster startup by combining the 
            ' ''' <see cref="SystemRestarter.NativeMethods.ExitWindowsExFlags.HybridShutdown"/> flag with the 
            ' ''' <see cref="SystemRestarter.NativeMethods.ExitWindowsExFlags.Shutdown"/> flag.
            ' ''' </summary>
            ' HybridShutdown = &H400000UI

            ' ''' <summary>
            ' ''' Shuts down the system and then restarts the system.
            ' ''' The calling process must have the SE_SHUTDOWN_NAME privilege
            ' ''' </summary>
            ' Reboot = &H2UI

            ' ''' <summary>
            ' ''' Shuts down the system and turns off the power. 
            ' ''' The system must support the power-off feature.
            ' ''' The calling process must have the SE_SHUTDOWN_NAME privilege.
            ' ''' </summary>
            ' PowerOff = &H8UI

            ' ''' <summary>
            ' ''' Shuts down the system and then restarts it, 
            ' ''' as well as any applications that have been registered for restart using the RegisterApplicationRestart function. 
            ' ''' These application receive the WM_QUERYENDSESSION message with lParam set to the ENDSESSION_CLOSEAPP value. 
            ' ''' For more information, see Guidelines for Applications: http://msdn.microsoft.com/en-us/library/windows/desktop/aa373651%28v=vs.85%29.aspx
            ' ''' </summary>
            ' RestartApps = &H40UI

            ''' <summary>
            ''' This flag has no effect if terminal services is enabled. 
            ''' Otherwise, the system does not send the WM_QUERYENDSESSION message. 
            ''' This can cause applications to lose data. 
            ''' Therefore, you should only use this flag in an emergency.
            ''' </summary>
            Force = &H4UI

            ''' <summary>
            ''' Forces processes to terminate if they do not respond to the WM_QUERYENDSESSION or WM_ENDSESSION message within the timeout interval. 
            ''' </summary>
            ForceIfHung = &H10UI

        End Enum

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Flags for <paramref name="dwShutdownFlags"/> parameter of <see cref="SystemRestarter.NativeMethods.InitiateShutdown"/> function.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa376872%28v=vs.85%29.aspx"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <Flags>
        Friend Enum InitiateShutdownFlags As UInteger

            ''' <summary>
            ''' Overrides the grace period so that the computer is shut down immediately.
            ''' </summary>
            GraceOverride = &H20UI

            ' ''' <summary>
            ' ''' The computer installs any updates before starting the shutdown.
            ' ''' </summary>
            ' InstallUpdates = &H40UI

            ''' <summary>
            ''' The computer is shut down but is not powered down or restarted.
            ''' </summary>
            Shutdown = &H10UI

            ''' <summary>
            ''' ( Beginning with Windows 8 )
            ''' Prepares the system for a faster startup by combining 
            ''' the <see cref="SystemRestarter.NativeMethods.InitiateShutdownFlags.HybridShutdown"/> flag with the 
            ''' <see cref="SystemRestarter.NativeMethods.InitiateShutdownFlags.Shutdown"/> flag. 
            ''' <see cref="SystemRestarter.NativeMethods.InitiateShutdown"/> always initiate a full system shutdown if the 
            ''' <see cref="SystemRestarter.NativeMethods.InitiateShutdownFlags.HybridShutdown"/> flag is not set. 
            ''' </summary>
            HybridShutdown = &H200UI

            ''' <summary>
            ''' The computer is shut down and powered down.
            ''' </summary>
            PowerOff = &H8UI

            ''' <summary>
            ''' The computer is shut down and restarted.
            ''' </summary>
            Restart = &H4UI

            ''' <summary>
            ''' The system is restarted using the <see cref="SystemRestarter.NativeMethods.ExitWindowsEx"/> function with the 
            ''' <see cref="SystemRestarter.NativeMethods.InitiateShutdownFlags.RestartApps"/> flag. 
            ''' This restarts any applications that have been registered for restart 
            ''' using the 'RegisterApplicationRestart' function.
            ''' </summary>
            RestartApps = &H80UI

            ''' <summary>
            ''' Don't force the system to close the applications.
            ''' This is the default parameter.
            ''' </summary>
            Wait = &H0UI

            ''' <summary>
            ''' All sessions are forcefully logged off. 
            ''' If this flag is not set and users other than the current user are logged on to the computer 
            ''' specified by the <paramref name="lpMachineName"/> parameter.
            ''' </summary>
            ForceOthers = &H1UI

            ''' <summary>
            ''' Specifies that the originating session is logged off forcefully. 
            ''' If this flag is not set, the originating session is shut down interactively, 
            ''' so a shutdown is not guaranteed even if the function returns successfully.
            ''' </summary>
            ForceSelf = &H2UI

        End Enum

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Flags for <paramref name="dwReason"/> parameter of <see cref="SystemRestarter.NativeMethods.ExitWindowsEx"/> function.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa376885%28v=vs.85%29.aspx"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <Flags>
        Friend Enum ShutdownReason As UInteger

            ''' <summary>
            ''' Application issue.
            ''' </summary>
            MajorApplication = &H40000

            ''' <summary>
            ''' Hardware issue.
            ''' </summary>
            MajorHardware = &H10000

            ' ''' <summary>
            ' ''' The <see cref="SystemRestarter.NativeMethods.InitiateShutdown"/> function was used instead of 'InitiateSystemShutdownEx' function.
            ' ''' </summary>
            ' MajorLegacyApi = &H70000

            ''' <summary>
            ''' Operating system issue.
            ''' </summary>
            MajorOperatingSystem = &H20000

            ''' <summary>
            ''' Other issue.
            ''' </summary>
            MajorOther = &H0

            ''' <summary>
            ''' Power failure.
            ''' </summary>
            MajorPower = &H60000

            ''' <summary>
            ''' Software issue.
            ''' </summary>
            MajorSoftware = &H30000

            ''' <summary>
            ''' System failure..
            ''' </summary>
            MajorSystem = &H50000

            ''' <summary>
            ''' Blue screen crash event.
            ''' </summary>
            MinorBlueScreen = &HF

            ''' <summary>
            ''' Unplugged.
            ''' </summary>
            MinorCordUnplugged = &HB

            ''' <summary>
            ''' Disk.
            ''' </summary>
            MinorDisk = &H7

            ''' <summary>
            ''' Environment.
            ''' </summary>
            MinorEnvironment = &HC

            ''' <summary>
            ''' Driver.
            ''' </summary>
            MinorHardwareDriver = &HD

            ''' <summary>
            ''' Hot fix.
            ''' </summary>
            MinorHotfix = &H11

            ''' <summary>
            ''' Hot fix uninstallation.
            ''' </summary>
            MinorHotfixUninstall = &H17

            ''' <summary>
            ''' Unresponsive.
            ''' </summary>
            MinorHung = &H5

            ''' <summary>
            ''' Installation.
            ''' </summary>
            MinorInstallation = &H2

            ''' <summary>
            ''' Maintenance.
            ''' </summary>
            MinorMaintenance = &H1

            ''' <summary>
            ''' MMC issue.
            ''' </summary>
            MinorMmc = &H19

            ''' <summary>
            ''' Network connectivity.
            ''' </summary>
            MinorNetworkConnectivity = &H14

            ''' <summary>
            ''' Network card.
            ''' </summary>
            MinorNetworkCard = &H9

            ''' <summary>
            ''' Other issue.
            ''' </summary>
            MinorOther = &H0

            ''' <summary>
            ''' Other driver event.
            ''' </summary>
            MinorOtherDriver = &HE

            ''' <summary>
            ''' Power supply.
            ''' </summary>
            MinorPowerSupply = &HA

            ''' <summary>
            ''' Processor.
            ''' </summary>
            MinorProcessor = &H8

            ''' <summary>
            ''' Reconfigure.
            ''' </summary>
            MinorReconfig = &H4

            ''' <summary>
            ''' Security issue.
            ''' </summary>
            MinorSecurity = &H13

            ''' <summary>
            ''' Security patch.
            ''' </summary>
            MinorSecurityFix = &H12

            ''' <summary>
            ''' Security patch uninstallation.
            ''' </summary>
            MinorSecurityFixUninstall = &H18

            ''' <summary>
            ''' Service pack.
            ''' </summary>
            MinorServicePack = &H10

            ''' <summary>
            ''' Service pack uninstallation.
            ''' </summary>
            MinorServicePackUninstall = &H16

            ''' <summary>
            ''' Terminal Services.
            ''' </summary>
            MinorTermSrv = &H20

            ''' <summary>
            ''' Unstable.
            ''' </summary>
            MinorUnstable = &H6

            ''' <summary>
            ''' Upgrade.
            ''' </summary>
            MinorUpgrade = &H3

            ''' <summary>
            ''' WMI issue.
            ''' </summary>
            MinorWmi = &H15

        End Enum

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Flags combination for <paramref name="dwReason"/> parameter of <see cref="SystemRestarter.NativeMethods.ExitWindowsEx"/> 
        ''' and <see cref="SystemRestarter.NativeMethods.InitiateShutdown"/> functions.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa376885%28v=vs.85%29.aspx"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        Friend Enum ShutdownPlanning As UInteger

            ''' <summary>
            ''' The shutdown was unplanned.
            ''' This is the default parameter.
            ''' </summary>
            Unplanned = &H0UI

            ''' <summary>
            ''' The reason code is defined by the user. 
            ''' For more information, see Defining a Custom Reason Code.
            ''' If this flag is not present, the reason code is defined by the system.
            ''' </summary>
            UserDefined = &H40000000UI

            ''' <summary>
            ''' The shutdown was planned. 
            ''' The system generates a System State Data (SSD) file. 
            ''' This file contains system state information such as the processes, threads, memory usage, and configuration.
            ''' If this flag is not present, the shutdown was unplanned.
            ''' </summary>
            Planned = &H80000000UI

        End Enum

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Flags combination for <paramref name="privileges"/> parameter of <see cref="SystemRestarter.NativeMethods.TokenPrivileges"/> structure.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa376885%28v=vs.85%29.aspx"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <Flags>
        Friend Enum TokenPrivilegesFlags As UInteger

            ' '''' <summary>
            ' '''' The privilege is enabled by default.
            ' '''' </summary>
            'PrivilegeEnabledBYDefault = &H1UI

            ''' <summary>
            ''' The privilege is enabled.
            ''' </summary>
            PrivilegeEnabled = &H2UI

            ' ''' <summary>
            ' ''' Used to remove a privilege.
            ' ''' </summary>
            'PrivilegeRemoved = &H4UI

            ' ''' <summary>
            ' ''' The privilege was used to gain access to an object or service. 
            ' ''' This flag is used to identify the relevant privileges 
            ' ''' in a set passed by a client application that may contain unnecessary privileges
            ' ''' </summary>
            'PrivilegeUsedForAccess = &H80000000UI

        End Enum

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Flags combination for <paramref name="desiredAccess"/> parameter of 
        ''' <see cref="SystemRestarter.NativeMethods.OpenProcessToken"/> function.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa374905%28v=vs.85%29.aspx"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <Flags>
        Friend Enum AccessRights As UInteger

            ' *****************************************************************************
            '                            WARNING!, NEED TO KNOW...
            '
            '  THIS ENUMERATION IS PARTIALLY DEFINED JUST FOR THE PURPOSES OF THIS PROJECT
            ' *****************************************************************************

            ''' <summary>
            ''' Required to enable or disable the privileges in an access token.
            ''' </summary>
            TokenAdjustPrivileges = &H32UI

            ''' <summary>
            ''' Required to query an access token.
            ''' </summary>
            TokenQuery = &H8UI

        End Enum

#End Region

#Region " Structures "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' An 'LUID' is a 64-bit value guaranteed to be unique only on the system on which it was generated. 
        ''' The uniqueness of a locally unique identifier (LUID) is guaranteed only until the system is restarted.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa379261%28v=vs.85%29.aspx"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <StructLayout(LayoutKind.Sequential)>
        Friend Structure Luid

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' The Low-order bits.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            Public LowPart As UInteger

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' The High-order bits.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            Public HighPart As Integer

        End Structure

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Represents a locally unique identifier (LUID) and its attributes.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa379263%28v=vs.85%29.aspx"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <StructLayout(LayoutKind.Sequential)>
        Friend Structure LuIdAndAttributes

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Specifies a <see cref="SystemRestarter.NativeMethods.Luid"/> (locally unique identifier) value.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            Public PLuid As SystemRestarter.NativeMethods.Luid

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Specifies attributes of the 'LUID'. 
            ''' This value contains up to 32 one-bit flags.
            ''' Its meaning is dependent on the definition and use of the 'LUID'.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            Public Attributes As SystemRestarter.NativeMethods.TokenPrivilegesFlags

        End Structure

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Contains information about a set of privileges for an access token.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <StructLayout(LayoutKind.Sequential)>
        Friend Structure TokenPrivileges

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' This must be set to the number of entries in the Privileges array
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            Public PrivilegeCount As Integer

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Specifies an array of <see cref="SystemRestarter.NativeMethods.LuIdAndAttributes"/> structures. 
            ''' Each structure contains the 'LUID' and attributes of a privilege. 
            ''' To get the name of the privilege associated with a 'LUID', call the 'LookupPrivilegeName' function, 
            ''' passing the address of the 'LUID' as the value of the 'lpLuid' parameter.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            Public Privileges As SystemRestarter.NativeMethods.LuIdAndAttributes

        End Structure

#End Region

    End Class

#End Region

#Region " Constants "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' The maximum number of seconds to wait before shutting down the computer. 
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <remarks>
    ''' <see href="http://msdn.microsoft.com/es-es/library/windows/desktop/aa376872%28v=vs.85%29.aspx"/>
    ''' </remarks>
    ''' ----------------------------------------------------------------------------------------------------
    Public Const MaxShutdownTimeout As Integer = 315360000I

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' SE_REMOTE_SHUTDOWN
    ''' 
    ''' privilege required to shut down a local system.
    ''' User Right: Shut down the system.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <remarks>
    ''' <see href="http://msdn.microsoft.com/en-us/library/windows/desktop/bb530716%28v=vs.85%29.aspx"/>
    ''' </remarks>
    ''' ----------------------------------------------------------------------------------------------------
    Private Const PrivilegeNameOfShutdown As String = "SeShutdownPrivilege"

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' SE_REMOTE_SHUTDOWN
    ''' 
    ''' privilege required to shut down a local system.
    ''' User Right: Shut down the system.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <remarks>
    ''' <see href="http://msdn.microsoft.com/en-us/library/windows/desktop/bb530716%28v=vs.85%29.aspx"/>
    ''' </remarks>
    ''' ----------------------------------------------------------------------------------------------------
    Private Const PrivilegeNameOfRemoteShutdown As String = "SeRemoteShutdownPrivilege"

#End Region

#Region " Enumerations "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Specifies the mode to logoff an user session.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Public Enum LogOffMode As UInteger

        ''' <summary>
        ''' Don't force the system to close the applications.
        ''' </summary>
        Wait = 0UI

        ''' <summary>
        ''' This flag has no effect if terminal services is enabled. 
        ''' Otherwise, the system does not send the WM_QUERYENDSESSION message. 
        ''' This can cause applications to lose data. 
        ''' Therefore, you should only use this flag in an emergency.
        ''' </summary>
        Force = SystemRestarter.NativeMethods.ExitwindowsExFlags.Force

        ''' <summary>
        ''' Forces processes to terminate if they do not respond to the WM_QUERYENDSESSION or WM_ENDSESSION message within the timeout interval. 
        ''' </summary>
        ForceIfHung = SystemRestarter.NativeMethods.ExitwindowsExFlags.ForceIfHung

    End Enum

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Specifies the mode to shutdown/restart the system.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Public Enum ShutdownMode As UInteger

        ''' <summary>
        ''' Don't force the system to close the applications.
        ''' </summary>
        Wait = SystemRestarter.NativeMethods.InitiateShutdownFlags.Wait

        ''' <summary>
        ''' All sessions are forcefully logged off.
        ''' </summary>
        ForceOthers = SystemRestarter.NativeMethods.InitiateShutdownFlags.ForceOthers

        ''' <summary>
        ''' Specifies that the originating session is logged off forcefully. 
        ''' If this flag is not set, the originating session is shut down interactively, 
        ''' so a shutdown is not guaranteed.
        ''' </summary>
        ForceSelf = SystemRestarter.NativeMethods.InitiateShutdownFlags.ForceSelf

    End Enum

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Specifies a shutdown/restart reason.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    <Flags>
    Public Enum ShutdownReason As UInteger

        ''' <summary>
        ''' Application issue.
        ''' </summary>
        MajorApplication = SystemRestarter.NativeMethods.ShutdownReason.MajorApplication

        ''' <summary>
        ''' Hardware issue.
        ''' </summary>
        MajorHardware = SystemRestarter.NativeMethods.ShutdownReason.MajorHardware

        ''' <summary>
        ''' Operating system issue.
        ''' </summary>
        MajorOperatingSystem = SystemRestarter.NativeMethods.ShutdownReason.MajorOperatingSystem

        ''' <summary>
        ''' Other issue.
        ''' </summary>
        MajorOther = SystemRestarter.NativeMethods.ShutdownReason.MajorOther

        ''' <summary>
        ''' Power failure.
        ''' </summary>
        MajorPower = SystemRestarter.NativeMethods.ShutdownReason.MajorPower

        ''' <summary>
        ''' Software issue.
        ''' </summary>
        MajorSoftware = SystemRestarter.NativeMethods.ShutdownReason.MajorSoftware

        ''' <summary>
        ''' System failure..
        ''' </summary>
        MajorSystem = SystemRestarter.NativeMethods.ShutdownReason.MajorSystem

        ''' <summary>
        ''' Blue screen crash event.
        ''' </summary>
        MinorBlueScreen = SystemRestarter.NativeMethods.ShutdownReason.MinorBlueScreen

        ''' <summary>
        ''' Unplugged.
        ''' </summary>
        MinorCordUnplugged = SystemRestarter.NativeMethods.ShutdownReason.MinorCordUnplugged

        ''' <summary>
        ''' Disk.
        ''' </summary>
        MinorDisk = SystemRestarter.NativeMethods.ShutdownReason.MinorDisk

        ''' <summary>
        ''' Environment.
        ''' </summary>
        MinorEnvironment = SystemRestarter.NativeMethods.ShutdownReason.MinorEnvironment

        ''' <summary>
        ''' Driver.
        ''' </summary>
        MinorHardwareDriver = SystemRestarter.NativeMethods.ShutdownReason.MinorHardwareDriver

        ''' <summary>
        ''' Hot fix.
        ''' </summary>
        MinorHotfix = SystemRestarter.NativeMethods.ShutdownReason.MinorHotfix

        ''' <summary>
        ''' Hot fix uninstallation.
        ''' </summary>
        MinorHotfixUninstall = SystemRestarter.NativeMethods.ShutdownReason.MinorHotfixUninstall

        ''' <summary>
        ''' Unresponsive.
        ''' </summary>
        MinorHung = SystemRestarter.NativeMethods.ShutdownReason.MinorHung

        ''' <summary>
        ''' Installation.
        ''' </summary>
        MinorInstallation = SystemRestarter.NativeMethods.ShutdownReason.MinorInstallation

        ''' <summary>
        ''' Maintenance.
        ''' </summary>
        MinorMaintenance = SystemRestarter.NativeMethods.ShutdownReason.MinorMaintenance

        ''' <summary>
        ''' MMC issue.
        ''' </summary>
        MinorMmc = SystemRestarter.NativeMethods.ShutdownReason.MinorMmc

        ''' <summary>
        ''' Network connectivity.
        ''' </summary>
        MinorNetworkConnectivity = SystemRestarter.NativeMethods.ShutdownReason.MinorNetworkConnectivity

        ''' <summary>
        ''' Network card.
        ''' </summary>
        MinorNetworkCard = SystemRestarter.NativeMethods.ShutdownReason.MinorNetworkCard

        ''' <summary>
        ''' Other issue.
        ''' </summary>
        MinorOther = SystemRestarter.NativeMethods.ShutdownReason.MinorOther

        ''' <summary>
        ''' Other driver event.
        ''' </summary>
        MinorOtherDriver = SystemRestarter.NativeMethods.ShutdownReason.MinorOtherDriver

        ''' <summary>
        ''' Power supply.
        ''' </summary>
        MinorPowerSupply = SystemRestarter.NativeMethods.ShutdownReason.MinorPowerSupply

        ''' <summary>
        ''' Processor.
        ''' </summary>
        MinorProcessor = SystemRestarter.NativeMethods.ShutdownReason.MinorProcessor

        ''' <summary>
        ''' Reconfigure.
        ''' </summary>
        MinorReconfig = SystemRestarter.NativeMethods.ShutdownReason.MinorReconfig

        ''' <summary>
        ''' Security issue.
        ''' </summary>
        MinorSecurity = SystemRestarter.NativeMethods.ShutdownReason.MinorSecurity

        ''' <summary>
        ''' Security patch.
        ''' </summary>
        MinorSecurityFix = SystemRestarter.NativeMethods.ShutdownReason.MinorSecurityFix

        ''' <summary>
        ''' Security patch uninstallation.
        ''' </summary>
        MinorSecurityFixUninstall = SystemRestarter.NativeMethods.ShutdownReason.MinorSecurityFixUninstall

        ''' <summary>
        ''' Service pack.
        ''' </summary>
        MinorServicePack = SystemRestarter.NativeMethods.ShutdownReason.MinorServicePack

        ''' <summary>
        ''' Service pack uninstallation.
        ''' </summary>
        MinorServicePackUninstall = SystemRestarter.NativeMethods.ShutdownReason.MinorServicePackUninstall

        ''' <summary>
        ''' Terminal Services.
        ''' </summary>
        MinorTermSrv = SystemRestarter.NativeMethods.ShutdownReason.MinorTermSrv

        ''' <summary>
        ''' Unstable.
        ''' </summary>
        MinorUnstable = SystemRestarter.NativeMethods.ShutdownReason.MinorUnstable

        ''' <summary>
        ''' Upgrade.
        ''' </summary>
        MinorUpgrade = SystemRestarter.NativeMethods.ShutdownReason.MinorUpgrade

        ''' <summary>
        ''' WMI issue.
        ''' </summary>
        MinorWmi = SystemRestarter.NativeMethods.ShutdownReason.MinorWmi

    End Enum

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Specifies a shutdown planning.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Public Enum ShutdownPlanning As UInteger

        ''' <summary>
        ''' The shutdown was unplanned.
        ''' </summary>
        Unplanned = SystemRestarter.NativeMethods.ShutdownPlanning.Unplanned

        ''' <summary>
        ''' The reason code is defined by the user. 
        ''' If this flag is not present, the reason code is defined by the system.
        ''' </summary>
        UserDefined = SystemRestarter.NativeMethods.ShutdownPlanning.UserDefined

        ''' <summary>
        ''' The shutdown was planned. 
        ''' The system generates a System State Data (SSD) file. 
        ''' This file contains system state information such as the processes, threads, memory usage, and configuration.
        ''' If this flag is not present, the shutdown was unplanned.
        ''' </summary>
        Planned = SystemRestarter.NativeMethods.ShutdownPlanning.Planned

    End Enum

#End Region

#Region " Public Methods "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Aborts a system shutdown operation that has been initiated (unless a LogOff).
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="computer">
    ''' The network name of the computer where the shutdown is to be stopped. 
    ''' If this parameter is an empty string, the function aborts the shutdown on the local computer.
    ''' </param>
    ''' 
    ''' <param name="ignoreErrors">
    ''' If <see langword="True"/>, a <see cref="Win32Exception"></see> exception will be thrown if error found.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <exception cref="Win32Exception">
    ''' </exception>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the function succeeds, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function Abort(Optional ByVal computer As String = Nothing,
                          Optional ByVal ignoreErrors As Boolean = True) As Boolean

        SystemRestarter.GetShutdownPrivileges(Nothing, SystemRestarter.PrivilegeNameOfShutdown)
        SystemRestarter.GetShutdownPrivileges(Nothing, SystemRestarter.PrivilegeNameOfRemoteShutdown)

        If (Not SystemRestarter.NativeMethods.AbortSystemShutdown(computer)) AndAlso (Not ignoreErrors) Then
            Throw New Win32Exception([error]:=Marshal.GetLastWin32Error)

        Else
            Return True

        End If

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Shuts down all processes running in the logon session and then logs off the interactive user. 
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="mode">
    ''' Indicates whether to force the logoff.
    ''' </param>
    ''' 
    ''' <param name="reason">
    ''' Indicates the reason for initiating the shutdown.
    ''' </param>
    ''' 
    ''' <param name="ignoreErrors">
    ''' If <see langword="True"/>, a <see cref="Win32Exception"></see> exception will be thrown if error found.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <exception cref="Win32Exception">
    ''' </exception>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' If the function succeeds, the return value is <see langword="True"/>. 
    ''' The function executes asynchronously so a <see langword="True"/> return value indicates that the shutdown has been initiated. 
    ''' It does not indicate whether the shutdown will succeed. 
    ''' It is possible that the system, the user, or another application will abort the shutdown.
    ''' If the function fails, the return value is <see langword="False"/>. 
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function LogOff(Optional ByVal mode As SystemRestarter.LogOffMode = SystemRestarter.LogOffMode.ForceIfHung,
                           Optional ByVal reason As SystemRestarter.ShutdownReason = SystemRestarter.ShutdownReason.MajorOther,
                           Optional ByVal ignoreErrors As Boolean = True) As Boolean

        SystemRestarter.GetShutdownPrivileges(Nothing, SystemRestarter.PrivilegeNameOfShutdown)
        SystemRestarter.GetShutdownPrivileges(Nothing, SystemRestarter.PrivilegeNameOfRemoteShutdown)

        If (Not NativeMethods.ExitWindowsEx(SystemRestarter.NativeMethods.ExitwindowsExFlags.LogOff Or mode, reason)) AndAlso (Not ignoreErrors) Then
            Throw New Win32Exception(Marshal.GetLastWin32Error)

        Else
            Return True

        End If

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Shutdowns the specified computer and begins powered down.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="computer">
    ''' The name of the computer to poweroff.
    ''' If the value of this parameter is an empty string, the local computer is shut down.
    ''' This parameter can be an addres, for example: '127.0.0.1'
    ''' </param>
    ''' 
    ''' <param name="message">
    ''' The message to be displayed in the interactive poweroff dialog box.
    ''' </param>
    ''' 
    ''' <param name="timeout">
    ''' The number of seconds to wait before shutting down the computer.
    ''' If the value of this parameter is zero, the computer is poweroff immediately.
    ''' This value is limited to 'MAX_SHUTDOWN_TIMEOUT'.
    ''' </param>
    ''' 
    ''' <param name="mode">
    ''' Indicates whether to force the PowerOff.
    ''' </param>
    ''' 
    ''' <param name="reason">
    ''' The reason for initiating the PowerOff.
    ''' If this parameter is zero,
    ''' the default is an undefined PowerOff that is logged as "No title for this reason could be found".
    ''' By default, it is also an 'unplanned' PowerOff.
    ''' </param>
    ''' 
    ''' <param name="planning">
    ''' Indicates whether it's a planned or unplanned PowerOff operation.
    ''' </param>
    ''' 
    ''' <param name="ignoreErrors">
    ''' If <see langword="True"/>, a <see cref="Win32Exception"></see> exception will be thrown if error found.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <exception cref="ArgumentException">
    ''' Timeout should be zero or greater than zero.;timeout
    ''' </exception>
    ''' 
    ''' <exception cref="Win32Exception">
    ''' </exception>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the PowerOff operation is initiated correctlly, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function PowerOff(Optional ByVal computer As String = Nothing,
                             Optional ByVal timeout As Integer = 0,
                             Optional ByVal message As String = Nothing,
                             Optional ByVal mode As SystemRestarter.ShutdownMode = SystemRestarter.ShutdownMode.Wait,
                             Optional ByVal reason As SystemRestarter.ShutdownReason = SystemRestarter.ShutdownReason.MajorOther,
                             Optional ByVal planning As SystemRestarter.ShutdownPlanning = SystemRestarter.ShutdownPlanning.Unplanned,
                             Optional ByVal ignoreErrors As Boolean = True) As Boolean

        SystemRestarter.GetShutdownPrivileges(computer, SystemRestarter.PrivilegeNameOfShutdown)
        SystemRestarter.GetShutdownPrivileges(computer, SystemRestarter.PrivilegeNameOfRemoteShutdown)

        Dim exitCode As UInteger

        Select Case timeout

            Case Is < 0
                Throw New ArgumentException(message:="Timeout should be zero or greater than zero.", paramName:="timeout")

            Case Is = 0
                exitCode = NativeMethods.InitiateShutdown(computer, message, timeout,
                                                          SystemRestarter.NativeMethods.InitiateShutdownFlags.PowerOff Or
                                                          SystemRestarter.NativeMethods.InitiateShutdownFlags.GraceOverride Or mode,
                                                          reason Or planning)

            Case Else
                exitCode = NativeMethods.InitiateShutdown(computer, message, timeout,
                                                          SystemRestarter.NativeMethods.InitiateShutdownFlags.PowerOff Or mode,
                                                          reason Or planning)

        End Select

        If (exitCode <> 0) AndAlso (Not ignoreErrors) Then
            Throw New Win32Exception([error]:=Convert.ToInt32(exitCode))

        Else
            Return True

        End If

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Restarts the specified computer.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="computer">
    ''' The name of the computer to restart.
    ''' If the value of this parameter is an empty string, the local computer is shut down.
    ''' This parameter can be an addres, for example: '127.0.0.1'
    ''' </param>
    ''' 
    ''' <param name="message">
    ''' The message to be displayed in the interactive restart dialog box.
    ''' </param>
    ''' 
    ''' <param name="timeout">
    ''' The number of seconds to wait before restarting the computer.
    ''' If the value of this parameter is zero, the computer is restarted immediately.
    ''' This value is limited to 'MAX_SHUTDOWN_TIMEOUT'.
    ''' </param>
    ''' 
    ''' <param name="mode">
    ''' Indicates whether to force the restart.
    ''' </param>
    ''' 
    ''' <param name="reason">
    ''' The reason for initiating the restart.
    ''' If this parameter is zero,
    ''' the default is an undefined restart that is logged as "No title for this reason could be found".
    ''' By default, it is also an 'unplanned' restart.
    ''' </param>
    ''' 
    ''' <param name="planning">
    ''' Indicates whether it's a planned or unplanned restart operation.
    ''' </param>
    ''' 
    ''' <param name="ignoreErrors">
    ''' If <see langword="True"/>, a <see cref="Win32Exception"></see> exception will be thrown if error found.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <exception cref="ArgumentException">
    ''' Timeout should be zero or greater than zero.;timeout
    ''' </exception>
    ''' 
    ''' <exception cref="Win32Exception">
    ''' </exception>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the restart operation is initiated correctlly, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function Restart(Optional ByVal computer As String = Nothing,
                            Optional ByVal timeout As Integer = 0,
                            Optional ByVal message As String = Nothing,
                            Optional ByVal mode As SystemRestarter.ShutdownMode = SystemRestarter.ShutdownMode.Wait,
                            Optional ByVal reason As SystemRestarter.ShutdownReason = SystemRestarter.ShutdownReason.MajorOther,
                            Optional ByVal planning As SystemRestarter.ShutdownPlanning = SystemRestarter.ShutdownPlanning.Unplanned,
                            Optional ByVal ignoreErrors As Boolean = True) As Boolean

        SystemRestarter.GetShutdownPrivileges(computer, SystemRestarter.PrivilegeNameOfShutdown)
        SystemRestarter.GetShutdownPrivileges(computer, SystemRestarter.PrivilegeNameOfRemoteShutdown)

        Dim exitCode As UInteger

        Select Case timeout

            Case Is < 0
                Throw New ArgumentException(message:="Timeout should be zero or greater than zero.", paramName:="timeout")

            Case Is = 0
                exitCode = NativeMethods.InitiateShutdown(computer, message, timeout,
                                                          SystemRestarter.NativeMethods.InitiateShutdownFlags.Restart Or
                                                          SystemRestarter.NativeMethods.InitiateShutdownFlags.GraceOverride Or mode,
                                                          reason Or planning)

            Case Else
                exitCode = NativeMethods.InitiateShutdown(computer, message, timeout,
                                                          SystemRestarter.NativeMethods.InitiateShutdownFlags.Restart Or mode,
                                                          reason Or planning)


        End Select

        If (exitCode <> 0) AndAlso (Not ignoreErrors) Then
            Throw New Win32Exception([error]:=Convert.ToInt32(exitCode))

        Else
            Return True

        End If

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Restarts the specified computer,
    ''' also restarts any applications that have been registered for restart in the system.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="computer">
    ''' The name of the computer to restart.
    ''' If the value of this parameter is an empty string, the local computer is shut down.
    ''' This parameter can be an addres, for example: '127.0.0.1'
    ''' </param>
    ''' 
    ''' <param name="message">
    ''' The message to be displayed in the interactive restart dialog box.
    ''' </param>
    ''' 
    ''' <param name="timeout">
    ''' The number of seconds to wait before restarting the computer.
    ''' If the value of this parameter is zero, the computer is restarted immediately.
    ''' This value is limited to 'MAX_SHUTDOWN_TIMEOUT'.
    ''' </param>
    ''' 
    ''' <param name="mode">
    ''' Indicates whether to force the restart.
    ''' </param>
    ''' 
    ''' <param name="reason">
    ''' The reason for initiating the restart.
    ''' If this parameter is zero,
    ''' the default is an undefined restart that is logged as "No title for this reason could be found".
    ''' By default, it is also an 'unplanned' restart.
    ''' </param>
    ''' 
    ''' <param name="planning">
    ''' Indicates whether it's a planned or unplanned restart operation.
    ''' </param>
    ''' 
    ''' <param name="ignoreErrors">
    ''' If <see langword="True"/>, a <see cref="Win32Exception"></see> exception will be thrown if error found.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <exception cref="ArgumentException">
    ''' Timeout should be zero or greater than zero.;timeout
    ''' </exception>
    ''' 
    ''' <exception cref="Win32Exception">
    ''' </exception>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the restart operation is initiated correctlly, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function RestartApps(Optional ByVal computer As String = Nothing,
                                Optional ByVal timeout As Integer = 0,
                                Optional ByVal message As String = Nothing,
                                Optional ByVal mode As SystemRestarter.ShutdownMode = SystemRestarter.ShutdownMode.Wait,
                                Optional ByVal reason As SystemRestarter.ShutdownReason = SystemRestarter.ShutdownReason.MajorOther,
                                Optional ByVal planning As SystemRestarter.ShutdownPlanning = SystemRestarter.ShutdownPlanning.Unplanned,
                                Optional ByVal ignoreErrors As Boolean = True) As Boolean

        SystemRestarter.GetShutdownPrivileges(computer, SystemRestarter.PrivilegeNameOfShutdown)
        SystemRestarter.GetShutdownPrivileges(computer, SystemRestarter.PrivilegeNameOfRemoteShutdown)

        Dim exitCode As UInteger

        Select Case timeout

            Case Is < 0
                Throw New ArgumentException(message:="Timeout should be zero or greater than zero.", paramName:="timeout")

            Case Is = 0
                exitCode = NativeMethods.InitiateShutdown(computer, message, timeout,
                                                          SystemRestarter.NativeMethods.InitiateShutdownFlags.RestartApps Or
                                                          SystemRestarter.NativeMethods.InitiateShutdownFlags.GraceOverride Or mode,
                                                          reason Or planning)

            Case Else
                exitCode = NativeMethods.InitiateShutdown(computer, message, timeout,
                                                          SystemRestarter.NativeMethods.InitiateShutdownFlags.RestartApps Or mode,
                                                          reason Or planning)

        End Select

        If (exitCode <> 0) AndAlso (Not ignoreErrors) Then
            Throw New Win32Exception([error]:=Convert.ToInt32(exitCode))

        Else
            Return True

        End If

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Shutdowns the specified computer.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="computer">
    ''' The name of the computer to be shut down.
    ''' If the value of this parameter is an empty string, the local computer is shut down.
    ''' This parameter can be an addres, for example: '127.0.0.1'
    ''' </param>
    ''' 
    ''' <param name="message">
    ''' The message to be displayed in the interactive shutdown dialog box.
    ''' </param>
    ''' 
    ''' <param name="timeout">
    ''' The number of seconds to wait before shutting down the computer.
    ''' If the value of this parameter is zero, the computer is shut down immediately.
    ''' This value is limited to 'MAX_SHUTDOWN_TIMEOUT'.
    ''' </param>
    ''' 
    ''' <param name="mode">
    ''' Indicates whether to force the shutdown.
    ''' </param>
    ''' 
    ''' <param name="reason">
    ''' The reason for initiating the shutdown.
    ''' If this parameter is zero,
    ''' the default is an undefined shutdown that is logged as "No title for this reason could be found".
    ''' By default, it is also an 'unplanned' shutdown.
    ''' </param>
    ''' 
    ''' <param name="planning">
    ''' Indicates whether it's a planned or unplanned shutdoen operation.
    ''' </param>
    ''' 
    ''' <param name="ignoreErrors">
    ''' If <see langword="True"/>, a <see cref="Win32Exception"></see> exception will be thrown if error found.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <exception cref="ArgumentException">
    ''' Timeout should be zero or greater than zero.;timeout
    ''' </exception>
    ''' 
    ''' <exception cref="Win32Exception">
    ''' </exception>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the shutdown operation is initiated correctlly, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function Shutdown(Optional ByVal computer As String = Nothing,
                             Optional ByVal timeout As Integer = 0,
                             Optional ByVal message As String = Nothing,
                             Optional ByVal mode As SystemRestarter.ShutdownMode = SystemRestarter.ShutdownMode.Wait,
                             Optional ByVal reason As SystemRestarter.ShutdownReason = SystemRestarter.ShutdownReason.MajorOther,
                             Optional ByVal planning As SystemRestarter.ShutdownPlanning = SystemRestarter.ShutdownPlanning.Unplanned,
                             Optional ByVal ignoreErrors As Boolean = True) As Boolean

        SystemRestarter.GetShutdownPrivileges(computer, SystemRestarter.PrivilegeNameOfShutdown)
        SystemRestarter.GetShutdownPrivileges(computer, SystemRestarter.PrivilegeNameOfRemoteShutdown)

        Dim exitCode As UInteger

        Select Case timeout

            Case Is < 0
                Throw New ArgumentException(message:="Timeout should be zero or greater than zero.", paramName:="timeout")

            Case Is = 0
                exitCode = NativeMethods.InitiateShutdown(computer, message, timeout,
                                                          SystemRestarter.NativeMethods.InitiateShutdownFlags.Shutdown Or
                                                          SystemRestarter.NativeMethods.InitiateShutdownFlags.GraceOverride Or mode,
                                                          reason Or planning)

            Case Else
                exitCode = NativeMethods.InitiateShutdown(computer, message, timeout,
                                                          SystemRestarter.NativeMethods.InitiateShutdownFlags.Shutdown Or mode,
                                                          reason Or planning)

        End Select

        If (exitCode <> 0) AndAlso (Not ignoreErrors) Then
            Throw New Win32Exception([error]:=Convert.ToInt32(exitCode))

        Else
            Return True

        End If

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Shutdowns the specified computer and prepares the system for a faster startup.
    ''' Use this function only for Windows 8/8.1
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="computer">
    ''' The name of the computer to be shut down.
    ''' If the value of this parameter is an empty string, the local computer is shut down.
    ''' This parameter can be an addres, for example: '127.0.0.1'
    ''' </param>
    ''' 
    ''' <param name="message">
    ''' The message to be displayed in the interactive shutdown dialog box.
    ''' </param>
    ''' 
    ''' <param name="timeout">
    ''' The number of seconds to wait before shutting down the computer.
    ''' If the value of this parameter is zero, the computer is shut down immediately.
    ''' This value is limited to 'MAX_SHUTDOWN_TIMEOUT'.
    ''' </param>
    ''' 
    ''' <param name="mode">
    ''' Indicates whether to force the shutdown.
    ''' </param>
    ''' 
    ''' <param name="reason">
    ''' The reason for initiating the shutdown.
    ''' If this parameter is zero,
    ''' the default is an undefined shutdown that is logged as "No title for this reason could be found".
    ''' By default, it is also an 'unplanned' shutdown.
    ''' </param>
    ''' 
    ''' <param name="planning">
    ''' Indicates whether it's a planned or unplanned shutdoen operation.
    ''' </param>
    ''' 
    ''' <param name="ignoreErrors">
    ''' If <see langword="True"/>, a <see cref="Win32Exception"></see> exception will be thrown if error found.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <exception cref="ArgumentException">
    ''' Timeout should be zero or greater than zero.;timeout
    ''' </exception>
    ''' 
    ''' <exception cref="Win32Exception">
    ''' </exception>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the hydrid shutdown operation is initiated correctlly, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function HybridShutdown(Optional ByVal computer As String = Nothing,
                                   Optional ByVal timeout As Integer = 0,
                                   Optional ByVal message As String = Nothing,
                                   Optional ByVal mode As SystemRestarter.ShutdownMode = SystemRestarter.ShutdownMode.Wait,
                                   Optional ByVal reason As SystemRestarter.ShutdownReason = SystemRestarter.ShutdownReason.MajorOther,
                                   Optional ByVal planning As SystemRestarter.ShutdownPlanning = SystemRestarter.ShutdownPlanning.Unplanned,
                                   Optional ByVal ignoreErrors As Boolean = True) As Boolean

        SystemRestarter.GetShutdownPrivileges(computer, SystemRestarter.PrivilegeNameOfShutdown)
        SystemRestarter.GetShutdownPrivileges(computer, SystemRestarter.PrivilegeNameOfRemoteShutdown)

        Dim exitCode As UInteger

        Select Case timeout

            Case Is < 0
                Throw New ArgumentException(message:="Timeout should be zero or greater than zero.", paramName:="timeout")

            Case Is = 0
                exitCode = NativeMethods.InitiateShutdown(computer, message, timeout,
                                                          SystemRestarter.NativeMethods.InitiateShutdownFlags.Shutdown Or
                                                          SystemRestarter.NativeMethods.InitiateShutdownFlags.HybridShutdown Or
                                                          SystemRestarter.NativeMethods.InitiateShutdownFlags.GraceOverride Or mode,
                                                          reason Or planning)

            Case Else
                exitCode = NativeMethods.InitiateShutdown(computer, message, timeout,
                                                          SystemRestarter.NativeMethods.InitiateShutdownFlags.Shutdown Or
                                                          SystemRestarter.NativeMethods.InitiateShutdownFlags.HybridShutdown Or mode,
                                                          reason Or planning)

        End Select

        If (exitCode <> 0) AndAlso (Not ignoreErrors) Then
            Throw New Win32Exception([error]:=Convert.ToInt32(exitCode))

        Else
            Return True

        End If

    End Function

#End Region

#Region " Private Methods "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Gets the necessary shutdown privileges to perform a local shutdown operation.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="Computer">
    ''' Indicates the computer where to set the privileges.
    ''' If an empty string is specified, the function attempts to find the privilege name on the local system.
    ''' </param>
    ''' 
    ''' <param name="privilegeName">
    ''' The privilege name.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Private Sub GetShutdownPrivileges(ByVal computer As String,
                                      ByVal privilegeName As String)

        Dim hToken As IntPtr
        Dim tkp As New SystemRestarter.NativeMethods.TokenPrivileges

        SystemRestarter.NativeMethods.OpenProcessToken(Process.GetCurrentProcess.Handle,
                                                       SystemRestarter.NativeMethods.AccessRights.TokenAdjustPrivileges Or
                                                       SystemRestarter.NativeMethods.AccessRights.TokenQuery,
                                                       hToken)

        With tkp
            .PrivilegeCount = 1
            .Privileges.Attributes = SystemRestarter.NativeMethods.TokenPrivilegesFlags.PrivilegeEnabled
        End With

        SystemRestarter.NativeMethods.LookupPrivilegeValue(computer, privilegeName, tkp.Privileges.PLuid)
        SystemRestarter.NativeMethods.AdjustTokenPrivileges(hToken, False, tkp, 0UI, IntPtr.Zero, IntPtr.Zero)

    End Sub

#End Region

End Module

#End Region
