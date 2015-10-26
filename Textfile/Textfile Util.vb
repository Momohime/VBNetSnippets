' ***********************************************************************
' Author   : Elektro
' Modified : 26-October-2015
' ***********************************************************************
' <copyright file="Textfile Util.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Public Members Summary "

#Region " Functions "

' TextfileUtil.Contains(String, String, IEqualityComparer(Of String), Encoding) As Boolean

' TextfileUtil.CountAllLines(String, Opt: Encoding) As Integer
' TextfileUtil.CountBlankLines(String, Opt: Encoding) As Integer
' TextfileUtil.CountNonBlankLines(String, Opt: Encoding) As Integer

' TextfileUtil.GetEncoding(String) As Encoding

' TextfileUtil.GetLine(String, Integer, TextfileUtil.TextDirection, Opt: Encoding) As String
' TextfileUtil.GetLines(String, Integer(), TextfileUtil.TextDirection, Opt: Encoding) As IEnumerable(Of String)

' TextfileUtil.InsertLine(String, Integer, String(), TextfileUtil.TextDirection, Opt: Encoding) As IEnumerable(Of String)
' TextfileUtil.InsertLine(String, Integer, String, TextfileUtil.TextDirection, Opt: Encoding) As IEnumerable(Of String)

' TextfileUtil.Randomize(String, Opt: Encoding) As IEnumerable(Of String)

' TextfileUtil.RemoveLine(String, Integer, TextfileUtil.TextDirection, Opt: Encoding) As IEnumerable(Of String)
' TextfileUtil.RemoveLines(String, Integer(), TextfileUtil.TextDirection, Opt: Encoding) As IEnumerable(Of String)

' TextfileUtil.ReplaceLine(String, Integer, String(), TextfileUtil.TextDirection, Opt: Encoding) As IEnumerable(Of String)
' TextfileUtil.ReplaceLine(String, Integer, String, TextfileUtil.TextDirection, Opt: Encoding) As IEnumerable(Of String)
' TextfileUtil.ReplaceLines(String, Integer(), String(), TextfileUtil.TextDirection, Opt: Encoding) As IEnumerable(Of String)
' TextfileUtil.ReplaceLines(String, Integer(), String, TextfileUtil.TextDirection, Opt: Encoding) As IEnumerable(Of String)

' TextfileUtil.Reverse(String, Opt: Encoding) As IEnumerable(Of String)

' TextfileUtil.SkipLines(String, Integer, TextfileUtil.TextDirection, Opt: Encoding) As IEnumerable(Of String)

' TextfileUtil.Sort(String, ListSortDirection, Opt: Encoding) As IEnumerable(Of String)
' TextfileUtil.SortBy(Of T)(String, ListSortDirection, Func(Of String, T), Opt: Encoding) As IEnumerable(Of String)

' TextfileUtil.Split(String, Char(),  Opt: StringSplitOptions, Opt: Encoding) As IEnumerable(Of String)
' TextfileUtil.Split(String, Char,  Opt: StringSplitOptions, Opt: Encoding) As IEnumerable(Of String)
' TextfileUtil.Split(String, String(),  Opt: StringSplitOptions, Opt: Encoding) As IEnumerable(Of String)
' TextfileUtil.Split(String, String,  Opt: StringSplitOptions, Opt: Encoding) As IEnumerable(Of String)

' TextfileUtil.SplitByLines(String, Integer, Opt: Encoding) As IEnumerable(Of IEnumerable(Of String))

' TextfileUtil.TakeLines(String, Integer, TextfileUtil.TextDirection, Opt: Encoding) As IEnumerable(Of String)

' TextfileUtil.Trim(String, Opt: Char(), Opt: Encoding) As IEnumerable(Of String)
' TextfileUtil.TrimEnd(String, Opt: Char(), Opt: Encoding) As IEnumerable(Of String)
' TextfileUtil.TrimStart(String, Opt: Char(), Opt: Encoding) As IEnumerable(Of String)

#End Region

#Region " Methods "

' TextfileUtil.InsertLine(String, String, Integer, String(), TextfileUtil.TextDirection, Opt: Encoding)
' TextfileUtil.InsertLine(String, String, Integer, String, TextfileUtil.TextDirection, Opt: Encoding)

' TextfileUtil.Randomize(String, String, Opt: Encoding)

' TextfileUtil.RemoveLine(String, String, Integer, TextfileUtil.TextDirection, Opt: Encoding)
' TextfileUtil.RemoveLines(String, String, Integer(), TextfileUtil.TextDirection, Opt: Encoding)

' TextfileUtil.ReplaceLine(String, String, Integer, String(), TextfileUtil.TextDirection, Opt: Encoding)
' TextfileUtil.ReplaceLine(String, String, Integer, String, TextfileUtil.TextDirection, Opt: Encoding)
' TextfileUtil.ReplaceLines(String, String, Integer(), String(), TextfileUtil.TextDirection, Opt: Encoding)
' TextfileUtil.ReplaceLines(String, String, Integer(), String, TextfileUtil.TextDirection, Opt: Encoding)

' TextfileUtil.Reverse(String, String, Opt: Encoding)

' TextfileUtil.SkipLines(String, String, Integer, TextfileUtil.TextDirection, Opt: Encoding)

' TextfileUtil.Sort(String, String, ListSortDirection, Opt: Encoding)
' TextfileUtil.SortBy(Of T)(String, String, ListSortDirection, Func(Of String, T), Opt: Encoding)

' TextfileUtil.TakeLines(String, String, Integer, TextfileUtil.TextDirection, Opt: Encoding)

' TextfileUtil.Trim(String, String, Opt: Char(), Opt: Encoding)
' TextfileUtil.TrimEnd(String, String, Opt: Char(), Opt: Encoding)
' TextfileUtil.TrimStart(String, String, Opt: Char(), Opt: Encoding)

#End Region

#End Region

#Region " Option Statements "

Option Strict On
Option Explicit On
Option Infer Off

#End Region

#Region " Imports "

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.IO
Imports System.Linq
Imports System.Text

#End Region

#Region " TextfileUtil "

''' ----------------------------------------------------------------------------------------------------
''' <summary>
''' Contains related text-file utilities.
''' </summary>
''' ----------------------------------------------------------------------------------------------------
Public Module TextfileUtil

#Region " Enumerations "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Specifies a text direction to iterate a textfile content.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Public Enum TextDirection As Integer

        ''' <summary>
        ''' From top to bottom.
        ''' </summary>
        Top = 0

        ''' <summary>
        ''' From bottom to top.
        ''' </summary>
        Bottom = 1

    End Enum

#End Region

#Region " Public Functions "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines the <see cref="Encoding"/> of the source textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim encoding As Encoding = TextfileUtil.GetEncoding("C:\file.txt")
    ''' Dim encodingName As String = TextfileUtil.GetEncoding("C:\file.txt").WebName
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' If the encoding can be detected, the return value is the detected <see cref="Encoding"/>,
    ''' if the encoding can't be detected, the return value is <see cref="Encoding.Default"/>.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function GetEncoding(ByVal sourceFilepath As String) As Encoding

        TextfileUtil.CheckFilePath(sourceFilepath)

        Dim encoding As Encoding = Nothing
        Dim bytes As Byte() = File.ReadAllBytes(sourceFilepath)

        For Each encodingInfo As EncodingInfo In encoding.GetEncodings()

            Dim currentEncoding As Encoding = encodingInfo.GetEncoding()
            Dim preamble As Byte() = currentEncoding.GetPreamble()
            Dim match As Boolean = True

            If (preamble.Length > 0) AndAlso (preamble.Length <= bytes.Length) Then

                For i As Integer = 0 To (preamble.Length - 1)

                    If preamble(i) <> bytes(i) Then
                        match = False
                        Exit For
                    End If

                Next i

            Else
                match = False

            End If

            If match Then
                encoding = currentEncoding
                Exit For
            End If

        Next encodingInfo

        If encoding Is Nothing Then
            Return encoding.Default

        Else
            Return encoding

        End If

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Gets the total amount of lines of the source textfile.
    ''' </summary>   
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lineCount As Integer = TextfileUtil.CountAllLines("C:\file.txt", Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' A value that contains the total amount of lines of the source textfile.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function CountAllLines(ByVal sourceFilepath As String,
                                  Optional ByVal encoding As Encoding = Nothing) As Integer

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        Return File.ReadAllLines(sourceFilepath, encoding).Count

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Gets the total amount of blank lines of the source textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lineCount As Integer = TextfileUtil.CountBlanktLines("C:\file.txt", Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' A value that contains the total amount of blank lines of the source textfile.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function CountBlanktLines(ByVal sourceFilepath As String,
                                     Optional ByVal encoding As Encoding = Nothing) As Integer

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        Return (From line As String In File.ReadAllLines(sourceFilepath, encoding)
               Where String.IsNullOrEmpty(line) OrElse String.IsNullOrWhiteSpace(line)).Count

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Gets the total amount of non-blank lines of the source textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lineCount As Integer = TextfileUtil.CountNonBlanktLines("C:\file.txt", Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' A value that contains the total amount of non-blank lines of the source textfile.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function CountNonBlanktLines(ByVal sourceFilepath As String,
                                        Optional ByVal encoding As Encoding = Nothing) As Integer

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        Return (From line As String In File.ReadAllLines(sourceFilepath, encoding)
               Where Not String.IsNullOrEmpty(line) AndAlso Not String.IsNullOrWhiteSpace(line)).Count

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Gets the specified line number from the source textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim line As String = TextfileUtil.GetLine("C:\file.txt", 5, TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="lineNumber">
    ''' The index of the line to get.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <exception cref="IndexOutOfRangeException">
    ''' </exception>
    ''' 
    ''' <exception cref="ArgumentException">
    ''' Invalid enumeration value.;textDirection
    ''' </exception>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' A <see cref="String"/> that contains the text of the obtained line.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function GetLine(ByVal sourceFilepath As String,
                            ByVal lineNumber As Integer,
                            ByVal textDirection As TextfileUtil.TextDirection,
                            Optional ByVal encoding As Encoding = Nothing) As String

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        Dim lines As IEnumerable(Of String) = File.ReadAllLines(sourceFilepath, encoding)
        Dim lineCount As Integer = lines.Count

        Select Case lineNumber

            Case Is < 0, Is > lineCount
                Throw New IndexOutOfRangeException()

            Case Else

                Select Case textDirection

                    Case TextfileUtil.TextDirection.Top
                        Return lines.Skip(lineNumber - 1).Take(1).First

                    Case TextfileUtil.TextDirection.Bottom
                        Return lines.Skip(lineCount - lineNumber).Take(1).First

                    Case Else
                        Throw New ArgumentException(message:="Invalid enumeration value.", paramName:="textDirection")

                End Select

        End Select

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Gets the specified line numbers from the source textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.GetLines("C:\file.txt", {1, 2, 3}, TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="lineNumbers">
    ''' The indexes of the lines to get.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <exception cref="IndexOutOfRangeException">
    ''' </exception>
    ''' 
    ''' <exception cref="ArgumentException">
    ''' The specified line number collection has duplicated values.;lineNumbers
    ''' </exception>
    ''' 
    ''' <exception cref="ArgumentException">
    ''' Invalid enumeration value.;textDirection
    ''' </exception>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the text of the obtained lines.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function GetLines(ByVal sourceFilepath As String,
                             ByVal lineNumbers As IEnumerable(Of Integer),
                             ByVal textDirection As TextfileUtil.TextDirection,
                             Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        If lineNumbers.Distinct().Count <> lineNumbers.Count Then
            Throw New ArgumentException(message:="The specified line number collection has duplicated values.", paramName:="lineNumbers")
        End If

        Dim lines As IEnumerable(Of String) = File.ReadAllLines(sourceFilepath, encoding)
        Dim lineCount As Integer = lines.Count

        Select Case lineNumbers.Max

            Case Is < 0, Is > lineCount
                Throw New IndexOutOfRangeException()

            Case Else

                Select Case textDirection

                    Case TextfileUtil.TextDirection.Top
                        Return lines.Select(Function(line As String, index As Integer)
                                                Return New With
                                                       {
                                                           Key .line = line,
                                                           Key .index = index + 1
                                                       }
                                            End Function).
                                    Where(Function(con) lineNumbers.Contains(con.index)).
                                    OrderBy(Function(con) lineNumbers.ToList().IndexOf(con.index)).
                                    Select(Function(con) con.line)

                    Case TextfileUtil.TextDirection.Bottom
                        Return lines.Skip(lineCount - lineNumbers.Max).Reverse.
                                    Select(Function(line As String, index As Integer)
                                               Return New With
                                                      {
                                                          Key .line = line,
                                                          Key .index = index + 1
                                                      }
                                           End Function).
                                    Where(Function(con) lineNumbers.Contains(con.index)).
                                    OrderBy(Function(con) lineNumbers.ToList().IndexOf(con.index)).
                                    Select(Function(con) con.line)

                    Case Else
                        Throw New ArgumentException(message:="Invalid enumeration value.", paramName:="textDirection")

                End Select

        End Select

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Takes the specified amount of lines from the source textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.TakeLines("C:\file.txt", 5, TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="amountOfLines">
    ''' The amount of lines to take.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <exception cref="IndexOutOfRangeException">
    ''' </exception>
    ''' 
    ''' <exception cref="ArgumentException">
    ''' Invalid enumeration value.;textDirection
    ''' </exception>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the taken lines.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function TakeLines(ByVal sourceFilepath As String,
                              ByVal amountOfLines As Integer,
                              ByVal textDirection As TextfileUtil.TextDirection,
                              Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        Dim lines As IEnumerable(Of String) = File.ReadAllLines(sourceFilepath, encoding)
        Dim lineCount As Integer = lines.Count

        Select Case amountOfLines

            Case Is < 0, Is > lineCount
                Throw New IndexOutOfRangeException()

            Case Else

                Select Case textDirection

                    Case TextfileUtil.TextDirection.Top
                        Return lines.Take(amountOfLines)

                    Case TextfileUtil.TextDirection.Bottom
                        Return lines.Skip(lineCount - amountOfLines)

                    Case Else
                        Throw New ArgumentException(message:="Invalid enumeration value.", paramName:="textDirection")

                End Select

        End Select

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Skips the specified amount of lines in the source textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.SkipLines("C:\file.txt", 5, TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="amountOfLines">
    ''' The amount of lines to skip.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <exception cref="IndexOutOfRangeException">
    ''' </exception>
    ''' 
    ''' <exception cref="ArgumentException">
    ''' Invalid enumeration value.;textDirection
    ''' </exception>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the non-skipped lines.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function SkipLines(ByVal sourceFilepath As String,
                              ByVal amountOfLines As Integer,
                              ByVal textDirection As TextfileUtil.TextDirection,
                              Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        Dim lines As IEnumerable(Of String) = File.ReadAllLines(sourceFilepath, encoding)
        Dim lineCount As Integer = lines.Count

        Select Case amountOfLines

            Case Is < 0, Is > lineCount
                Throw New IndexOutOfRangeException()

            Case Else

                Select Case textDirection

                    Case TextfileUtil.TextDirection.Top
                        Return lines.Skip(amountOfLines)

                    Case TextfileUtil.TextDirection.Bottom
                        Return lines.Take(lineCount - amountOfLines)

                    Case Else
                        Throw New ArgumentException(message:="Invalid enumeration value.", paramName:="textDirection")

                End Select

        End Select

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Inserts the specified text-lines in the given line number of the source textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.InsertLines("C:\old file.txt", "C:\new file.txt", 5, {"Text"}, TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>   
    '''
    ''' <param name="lineNumber">
    ''' The start index of the line to insert.
    ''' </param>
    ''' 
    ''' <param name="textCol">
    ''' The text-line to insert.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <exception cref="IndexOutOfRangeException">
    ''' </exception>
    ''' 
    ''' <exception cref="ArgumentException">
    ''' Invalid enumeration value.;textDirection
    ''' </exception>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the textfile lines with the inserted lines.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function InsertLines(ByVal sourceFilepath As String,
                                ByVal lineNumber As Integer,
                                ByVal textCol As IEnumerable(Of String),
                                ByVal textDirection As TextfileUtil.TextDirection,
                                Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        Dim lines As IEnumerable(Of String) = File.ReadAllLines(sourceFilepath, encoding)
        Dim lineCount As Integer = lines.Count

        Select Case lineNumber

            Case Is < 0, Is > lineCount
                Throw New IndexOutOfRangeException()

            Case Else

                Select Case textDirection

                    Case TextfileUtil.TextDirection.Top
                        Return Enumerable.Concat(lines.Take(lineNumber - 1), textCol).Concat(lines.Skip(lineNumber - 1))

                    Case TextfileUtil.TextDirection.Bottom
                        Return Enumerable.Concat(lines.Take(lineCount - lineNumber + 1), textCol).Concat(lines.Skip(lineCount - lineNumber + 1))

                    Case Else
                        Throw New ArgumentException(message:="Invalid enumeration value.", paramName:="textDirection")

                End Select

        End Select

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Inserts the specified text-line in the given line number of the source textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.InsertLine("C:\old file.txt", "C:\new file.txt", 5, "Text", TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>   
    '''
    ''' <param name="lineNumber">
    ''' The start index of the line to insert.
    ''' </param>
    ''' 
    ''' <param name="text">
    ''' The text-line to insert.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <exception cref="IndexOutOfRangeException">
    ''' </exception>
    ''' 
    ''' <exception cref="ArgumentException">
    ''' Invalid enumeration value.;textDirection
    ''' </exception>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the textfile lines with the inserted line.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function InsertLine(ByVal sourceFilepath As String,
                               ByVal lineNumber As Integer,
                               ByVal text As String,
                               ByVal textDirection As TextfileUtil.TextDirection,
                               Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        Return TextfileUtil.InsertLines(sourceFilepath, lineNumber, {text}, textDirection, encoding)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Replaces the specified line numbers in the source textfile with the given text-lines.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.ReplaceLines("C:\file.txt", {1, 2, 3}, {"Hello", "World"}, TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="lineNumbers">
    ''' The index of the lines to replace.
    ''' </param>
    ''' 
    ''' <param name="textCol">
    ''' The text-lines to replace.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <exception cref="IndexOutOfRangeException">
    ''' </exception>
    ''' 
    ''' <exception cref="ArgumentException">
    ''' Invalid enumeration value.;textDirection
    ''' </exception>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the textfile lines with the replaced lines.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function ReplaceLines(ByVal sourceFilepath As String,
                                 ByVal lineNumbers As IEnumerable(Of Integer),
                                 ByVal textCol As IEnumerable(Of String),
                                 ByVal textDirection As TextfileUtil.TextDirection,
                                 Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        Dim lines As IEnumerable(Of String) = File.ReadAllLines(sourceFilepath, encoding)
        Dim lineCount As Integer = lines.Count

        Select Case lineNumbers.Max

            Case Is < 0, Is > lineCount
                Throw New IndexOutOfRangeException()

            Case Else

                Select Case textDirection

                    Case TextfileUtil.TextDirection.Top
                        Return lines.Select(Function(line As String, index As Integer)
                                                Return New With
                                                       {
                                                           Key .line = line,
                                                           Key .index = index + 1
                                                       }
                                            End Function).
                                     Select(Function(con)
                                                If lineNumbers.Contains(con.index) Then
                                                    Return String.Join(Environment.NewLine, textCol)
                                                Else
                                                    Return con.line
                                                End If
                                            End Function)

                    Case TextfileUtil.TextDirection.Bottom
                        Return lines.Select(Function(line As String, index As Integer)
                                                Return New With
                                                       {
                                                           Key .line = line,
                                                           Key .index = index
                                                       }
                                            End Function).
                                     Select(Function(con)
                                                If lineNumbers.Contains(lineCount - con.index) Then
                                                    Return String.Join(Environment.NewLine, textCol)
                                                Else
                                                    Return con.line
                                                End If
                                            End Function)

                    Case Else
                        Throw New ArgumentException(message:="Invalid enumeration value.", paramName:="textDirection")

                End Select

        End Select

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Replaces the specified line numbers in the source textfile with the given text-line.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.ReplaceLines("C:\file.txt", {1, 2, 3}, "Text", TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="lineNumbers">
    ''' The index of the lines to replace.
    ''' </param>
    ''' 
    ''' <param name="text">
    ''' The text-line to replace.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <exception cref="IndexOutOfRangeException">
    ''' </exception>
    ''' 
    ''' <exception cref="ArgumentException">
    ''' Invalid enumeration value.;textDirection
    ''' </exception>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the textfile lines with the replaced lines.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function ReplaceLines(ByVal sourceFilepath As String,
                                 ByVal lineNumbers As IEnumerable(Of Integer),
                                 ByVal text As String,
                                 ByVal textDirection As TextfileUtil.TextDirection,
                                 Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        Return TextfileUtil.ReplaceLines(sourceFilepath, lineNumbers, {text}, textDirection, encoding)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Replaces the specified line number in the source textfile with the given text-lines.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.ReplaceLine("C:\file.txt", 5, {"Text"}, TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="lineNumber">
    ''' The index of the line to replace.
    ''' </param>
    ''' 
    ''' <param name="textCol">
    ''' The text-lines to replace.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <exception cref="IndexOutOfRangeException">
    ''' </exception>
    ''' 
    ''' <exception cref="ArgumentException">
    ''' Invalid enumeration value.;textDirection
    ''' </exception>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the textfile lines with the replaced lines.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function ReplaceLine(ByVal sourceFilepath As String,
                                ByVal lineNumber As Integer,
                                ByVal textCol As IEnumerable(Of String),
                                ByVal textDirection As TextfileUtil.TextDirection,
                                Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        Dim lines As IEnumerable(Of String) = File.ReadAllLines(sourceFilepath, encoding)
        Dim lineCount As Integer = lines.Count

        Select Case lineNumber

            Case Is < 0, Is > lineCount
                Throw New IndexOutOfRangeException()

            Case Else

                Select Case textDirection

                    Case TextfileUtil.TextDirection.Top
                        Return Enumerable.Concat(lines.Take(lineNumber - 1), textCol).Concat(lines.Skip(lineNumber))

                    Case TextfileUtil.TextDirection.Bottom
                        Return Enumerable.Concat(lines.Take(lineCount - lineNumber), textCol).Concat(lines.Skip(lineCount - lineNumber + 1))

                    Case Else
                        Throw New ArgumentException(message:="Invalid enumeration value.", paramName:="textDirection")

                End Select

        End Select

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Replaces the specified line number in the source textfile with the given text-line.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.ReplaceLine("C:\file.txt", 5, "Text", TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>   
    '''
    ''' <param name="lineNumber">
    ''' The index of the line to replace.
    ''' </param>
    ''' 
    ''' <param name="text">
    ''' The text-line to replace.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the textfile lines with the replaced line.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function ReplaceLine(ByVal sourceFilepath As String,
                                ByVal lineNumber As Integer,
                                ByVal text As String,
                                ByVal textDirection As TextfileUtil.TextDirection,
                                Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        Return TextfileUtil.ReplaceLine(sourceFilepath, lineNumber, {text}, textDirection, encoding)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Reverses the lines of the source textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.Reverse("C:\file.txt", Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the reversed lines.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function Reverse(ByVal sourceFilepath As String,
                            Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        Return File.ReadAllLines(sourceFilepath, encoding).Reverse

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Randomizes the lines of the source textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.Randomize("C:\file.txt", Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the randomized lines.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function Randomize(ByVal sourceFilepath As String,
                              Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        Dim rand As New Random

        Return From line As String In File.ReadAllLines(sourceFilepath, encoding)
               Order By rand.Next

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Sorts the lines of the source textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.Sort("C:\file.txt", ListSortDirection.Ascending, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="sortDirection">
    ''' The sorting direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <exception cref="ArgumentException">
    ''' Invalid enumeration value.;sortDirection
    ''' </exception>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the sorted lines.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function Sort(ByVal sourceFilepath As String,
                         ByVal sortDirection As ListSortDirection,
                         Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        Select Case sortDirection

            Case ListSortDirection.Ascending
                Return From line As String In File.ReadAllLines(sourceFilepath, encoding)
                       Order By line Ascending

            Case ListSortDirection.Descending
                Return From line As String In File.ReadAllLines(sourceFilepath, encoding)
                       Order By line Descending

            Case Else
                Throw New ArgumentException(message:="Invalid enumeration value.", paramName:="sortDirection")

        End Select

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Sorts the lines of the source textfile by evaluating the result of the given condition.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.SortBy("C:\file.txt", ListSortDirection.Ascending, Function(line As String) line.EndsWith("5"), Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="sortDirection">
    ''' The sorting direction.
    ''' </param>
    ''' 
    ''' <param name="sortExpr">
    ''' The sorting expression to evaluate.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <exception cref="ArgumentException">
    ''' Invalid enumeration value.;sortDirection
    ''' </exception>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the sorted lines.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function SortBy(Of T)(ByVal sourceFilepath As String,
                                 ByVal sortDirection As ListSortDirection,
                                 ByVal sortExpr As Func(Of String, T),
                                 Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        Select Case sortDirection

            Case ListSortDirection.Ascending
                Return From line As String In File.ReadAllLines(sourceFilepath, encoding)
                       Order By sortExpr.Invoke(line) Ascending

            Case ListSortDirection.Descending
                Return From line As String In File.ReadAllLines(sourceFilepath, encoding)
                       Order By sortExpr.Invoke(line) Descending

            Case Else
                Throw New ArgumentException(message:="Invalid enumeration value.", paramName:="sortDirection")

        End Select

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Trims the specified chars in the lines of the source textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.Trim("C:\file.txt", {" "c, ControlChars.NullChar}, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="trimChars">
    ''' The characters to trim from lines.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the trimmed lines.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function Trim(ByVal sourceFilepath As String,
                         Optional ByVal trimChars As Char() = Nothing,
                         Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        If trimChars Is Nothing Then
            trimChars = {" "c, ControlChars.NullChar}
        End If

        Return From line As String In File.ReadAllLines(sourceFilepath, encoding)
               Select line.Trim(trimChars)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Trims the specified chars from the start of the lines of the source textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.TrimStart("C:\file.txt", {" "c, ControlChars.NullChar}, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="trimChars">
    ''' The characters to trim from lines.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the trimmed lines.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function TrimStart(ByVal sourceFilepath As String,
                              Optional ByVal trimChars As Char() = Nothing,
                              Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        If trimChars Is Nothing Then
            trimChars = {" "c, ControlChars.NullChar}
        End If

        Return From line As String In File.ReadAllLines(sourceFilepath, encoding)
               Select line.TrimStart(trimChars)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Trims the specified chars from the end of the lines of the source textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.TrimEnd("C:\file.txt", {" "c, ControlChars.NullChar}, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="trimChars">
    ''' The characters to trim from lines.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the trimmed lines.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function TrimEnd(ByVal sourceFilepath As String,
                            Optional ByVal trimChars As Char() = Nothing,
                            Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        If trimChars Is Nothing Then
            trimChars = {" "c, ControlChars.NullChar}
        End If

        Return From line As String In File.ReadAllLines(sourceFilepath, encoding)
               Select line.TrimEnd(trimChars)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Splits the source textfile by the specified characters.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.Split("C:\file.txt", {" "c}, StringSplitOptions.RemoveEmptyEntries, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="characters">
    ''' The characters that delimits the split.
    ''' </param>
    ''' 
    ''' <param name="splitOptions">
    ''' The split behavior option.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the splitted lines.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    Public Function Split(ByVal sourceFilepath As String,
                          ByVal characters As Char(),
                          Optional ByVal splitOptions As StringSplitOptions = StringSplitOptions.None,
                          Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        Return File.ReadAllText(sourceFilepath, encoding).Split(characters, splitOptions)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Splits the source textfile by the specified character.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.Split("C:\file.txt", " "c, StringSplitOptions.RemoveEmptyEntries, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="character">
    ''' The character that delimits the split.
    ''' </param>
    ''' 
    ''' <param name="splitOptions">
    ''' The split behavior option.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the splitted lines.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    Public Function Split(ByVal sourceFilepath As String,
                          ByVal character As Char,
                          Optional ByVal splitOptions As StringSplitOptions = StringSplitOptions.None,
                          Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        Return TextfileUtil.Split(sourceFilepath, {character}, splitOptions, encoding)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Splits the source textfile by the specified strings.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.Split("C:\file.txt", {"Hello World"}, StringSplitOptions.RemoveEmptyEntries, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="strCol">
    ''' The strings that delimits the split.
    ''' </param>
    ''' 
    ''' <param name="splitOptions">
    ''' The split behavior option.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the splitted lines.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    Public Function Split(ByVal sourceFilepath As String,
                          ByVal strCol As IEnumerable(Of String),
                          Optional ByVal splitOptions As StringSplitOptions = StringSplitOptions.None,
                          Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        Return File.ReadAllText(sourceFilepath, encoding).Split(strCol.ToArray, splitOptions)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Splits the source textfile by the specified string.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.Split("C:\file.txt", "Hello World", StringSplitOptions.RemoveEmptyEntries, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="str">
    ''' The string that delimits the split.
    ''' </param>
    ''' 
    ''' <param name="splitOptions">
    ''' The split behavior option.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the splitted lines.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    Public Function Split(ByVal sourceFilepath As String,
                          ByVal str As String,
                          Optional ByVal splitOptions As StringSplitOptions = StringSplitOptions.None,
                          Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        Return TextfileUtil.Split(sourceFilepath, {str}, splitOptions, encoding)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Splits the source textfile by the specified amount of lines.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim parts As IEnumerable(Of IEnumerable(Of String)) = TextfileUtil.SplitByLines("C:\file.txt", 2, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="amountOfLines">
    ''' The amount of lines.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of IEnumerable(Of String))"/> that contains the splitted parts.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    Public Function SplitByLines(ByVal sourceFilepath As String,
                                 ByVal amountOfLines As Integer,
                                 Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of IEnumerable(Of String))

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        Dim lines As IEnumerable(Of String) = File.ReadAllLines(sourceFilepath, encoding)
        Dim lineCount As Integer = lines.Count

        Select Case amountOfLines

            Case Is < 0, Is > lineCount
                Throw New IndexOutOfRangeException()

            Case Else
                Return From index As Integer In Enumerable.Range(0, CInt(Math.Ceiling(lines.Count() / amountOfLines)))
                       Select lines.Skip(index * amountOfLines).Take(amountOfLines)

        End Select

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Removes the specified line numbers in the source textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.RemoveLines("C:\file.txt", {1, 2, 3}, TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>   
    '''
    ''' <param name="lineNumbers">
    ''' The indexes of the lines to remove.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the textfile lines less the removed lines.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function RemoveLines(ByVal sourceFilepath As String,
                                ByVal lineNumbers As IEnumerable(Of Integer),
                                ByVal textDirection As TextfileUtil.TextDirection,
                                Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        Dim lines As IEnumerable(Of String) = File.ReadAllLines(sourceFilepath, encoding)
        Dim lineCount As Integer = lines.Count

        Select Case lineNumbers.Max

            Case Is < 0, Is > lineCount
                Throw New IndexOutOfRangeException()

            Case Else

                Select Case textDirection

                    Case TextfileUtil.TextDirection.Top
                        Return lines.Select(Function(line As String, index As Integer)
                                                Return New With
                                                       {
                                                           Key .line = line,
                                                           Key .index = index + 1
                                                       }
                                            End Function).
                                     Where(Function(con) Not lineNumbers.Contains(con.index)).
                                     Select(Function(con) con.line)

                    Case TextfileUtil.TextDirection.Bottom
                        Return lines.Select(Function(line As String, index As Integer)
                                                Return New With
                                                       {
                                                           Key .line = line,
                                                           Key .index = index
                                                       }
                                            End Function).
                                     Where(Function(con) Not lineNumbers.Contains(lineCount - con.index)).
                                     Select(Function(con) con.line)

                    Case Else
                        Throw New ArgumentException(message:="Invalid enumeration value.", paramName:="textDirection")

                End Select

        End Select

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Removes the specified line number in the source textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim lines As IEnumerable(Of String) = TextfileUtil.RemoveLine("C:\file.txt", 5, TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>   
    '''
    ''' <param name="lineNumber">
    ''' The index of the line to remove.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' An <see cref="IEnumerable(Of String)"/> that contains the textfile lines less the removed line.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function RemoveLine(ByVal sourceFilepath As String,
                               ByVal lineNumber As Integer,
                               ByVal textDirection As TextfileUtil.TextDirection,
                               Optional ByVal encoding As Encoding = Nothing) As IEnumerable(Of String)

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        Dim lines As IEnumerable(Of String) = File.ReadAllLines(sourceFilepath, encoding)
        Dim lineCount As Integer = lines.Count

        Select Case lineNumber

            Case Is < 0, Is > lineCount
                Throw New IndexOutOfRangeException()

            Case Else

                Select Case textDirection

                    Case TextfileUtil.TextDirection.Top
                        Return Enumerable.Concat(lines.Take(lineNumber - 1), lines.Skip(lineNumber))

                    Case TextfileUtil.TextDirection.Bottom
                        Return Enumerable.Concat(lines.Take(lineCount - lineNumber), lines.Skip(lineCount - lineNumber + 1))

                    Case Else
                        Throw New ArgumentException(message:="Invalid enumeration value.", paramName:="textDirection")

                End Select

        End Select

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source textfile contains the specified string.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim contains As Boolean = TextfileUtil.Contains("C:\file.txt", "Hello World!", StringComparer.OrdinalIgnoreCase)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <code>True</code> if the value is found, otherwise, <code>False</code>.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function Contains(ByVal sourceFilepath As String,
                             ByVal value As String,
                             Optional ByVal comparer As IEqualityComparer(Of String) = Nothing,
                             Optional ByVal encoding As Encoding = Nothing) As Boolean

        TextfileUtil.CheckEncoding(encoding)
        TextfileUtil.CheckFilePath(sourceFilepath)

        If comparer Is Nothing Then
            comparer = StringComparer.Ordinal
        End If

        Return File.ReadAllLines(sourceFilepath, encoding).Contains(value, comparer)

    End Function

#End Region

#Region " Public Methods "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Takes the specified amount of lines from the source textfile, 
    ''' then writes the result in the target textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' TextfileUtil.TakeLines("C:\old file.txt", "C:\new file.txt", 5, TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>   
    '''
    ''' <param name="targetFilepath">
    ''' The target textfile path.
    ''' </param>
    ''' 
    ''' <param name="amountOfLines">
    ''' The amount of lines to take.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read/write the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Sub TakeLines(ByVal sourceFilepath As String,
                         ByVal targetFilepath As String,
                         ByVal amountOfLines As Integer,
                         ByVal textDirection As TextfileUtil.TextDirection,
                         Optional ByVal encoding As Encoding = Nothing)

        TextfileUtil.CheckEncoding(encoding)

        File.WriteAllLines(targetFilepath, TakeLines(sourceFilepath, amountOfLines, textDirection, encoding), encoding)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Skips the specified amount of lines in the source textfile,
    ''' then writes the result in the target textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' TextfileUtil.SkipLines("C:\old file.txt", "C:\new file.txt", 5, TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>   
    '''
    ''' <param name="targetFilepath">
    ''' The target textfile path.
    ''' </param>
    ''' 
    ''' <param name="amountOfLines">
    ''' The amount of lines to skip.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read/write the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Sub SkipLines(ByVal sourceFilepath As String,
                         ByVal targetFilepath As String,
                         ByVal amountOfLines As Integer,
                         ByVal textDirection As TextfileUtil.TextDirection,
                         Optional ByVal encoding As Encoding = Nothing)

        TextfileUtil.CheckEncoding(encoding)

        File.WriteAllLines(targetFilepath, SkipLines(sourceFilepath, amountOfLines, textDirection, encoding), encoding)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Inserts the specified text-lines in the given line number of the source textfile,
    ''' then writes the result in the target textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' TextfileUtil.InsertLines("C:\old file.txt", "C:\new file.txt", 5, {"Text"}, TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>   
    '''
    ''' <param name="targetFilepath">
    ''' The target textfile path.
    ''' </param>
    ''' 
    ''' <param name="lineNumber">
    ''' The start index of the line to insert.
    ''' </param>
    ''' 
    ''' <param name="textCol">
    ''' The text-lines to insert.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read/write the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Sub InsertLines(ByVal sourceFilepath As String,
                           ByVal targetFilepath As String,
                           ByVal lineNumber As Integer,
                           ByVal textCol As IEnumerable(Of String),
                           ByVal textDirection As TextfileUtil.TextDirection,
                           Optional ByVal encoding As Encoding = Nothing)

        TextfileUtil.CheckEncoding(encoding)

        File.WriteAllLines(targetFilepath, InsertLines(sourceFilepath, lineNumber, textCol, textDirection, encoding), encoding)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Inserts the specified text-line in the given line number of the source textfile,
    ''' then writes the result in the target textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' TextfileUtil.InsertLine("C:\old file.txt", "C:\new file.txt", 5, "Text", TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>   
    '''
    ''' <param name="targetFilepath">
    ''' The target textfile path.
    ''' </param>
    ''' 
    ''' <param name="lineNumber">
    ''' The start index of the line to insert.
    ''' </param>
    ''' 
    ''' <param name="line">
    ''' The text-line to insert.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read/write the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Sub InsertLine(ByVal sourceFilepath As String,
                          ByVal targetFilepath As String,
                          ByVal lineNumber As Integer,
                          ByVal line As String,
                          ByVal textDirection As TextfileUtil.TextDirection,
                          Optional ByVal encoding As Encoding = Nothing)

        TextfileUtil.CheckEncoding(encoding)

        File.WriteAllLines(targetFilepath, InsertLines(sourceFilepath, lineNumber, {line}, textDirection, encoding), encoding)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Replaces the specified line numbesr in the source textfile with the given text-line,
    ''' then writes the result in the target textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' TextfileUtil.ReplaceLines("C:\old file.txt", "C:\new file.txt", {1, 2, 3}, {"Hello", "World"}, TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    '''
    ''' <param name="targetFilepath">
    ''' The target textfile path.
    ''' </param>
    ''' 
    ''' <param name="lineNumbers">
    ''' The index of the lines to replace.
    ''' </param>
    ''' 
    ''' <param name="textCol">
    ''' The text-lines to replace.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read/write the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Sub ReplaceLines(ByVal sourceFilepath As String,
                            ByVal targetFilepath As String,
                            ByVal lineNumbers As IEnumerable(Of Integer),
                            ByVal textCol As IEnumerable(Of String),
                            ByVal textDirection As TextfileUtil.TextDirection,
                            Optional ByVal encoding As Encoding = Nothing)

        TextfileUtil.CheckEncoding(encoding)

        File.WriteAllLines(targetFilepath, ReplaceLines(sourceFilepath, lineNumbers, textCol, textDirection, encoding), encoding)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Replaces the specified line numbesr in the source textfile with the given text-line,
    ''' then writes the result in the target textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' TextfileUtil.ReplaceLines("C:\old file.txt", "C:\new file.txt", {1, 2, 3}, "Text", TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    '''
    ''' <param name="targetFilepath">
    ''' The target textfile path.
    ''' </param>
    ''' 
    ''' <param name="lineNumbers">
    ''' The index of the lines to replace.
    ''' </param>
    ''' 
    ''' <param name="text">
    ''' The text-line to replace.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read/write the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Sub ReplaceLines(ByVal sourceFilepath As String,
                            ByVal targetFilepath As String,
                            ByVal lineNumbers As IEnumerable(Of Integer),
                            ByVal text As String,
                            ByVal textDirection As TextfileUtil.TextDirection,
                            Optional ByVal encoding As Encoding = Nothing)

        TextfileUtil.CheckEncoding(encoding)

        File.WriteAllLines(targetFilepath, ReplaceLines(sourceFilepath, lineNumbers, {text}, textDirection, encoding), encoding)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Replaces the specified line number in the source textfile with the given text-lines,
    ''' then writes the result in the target textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' TextfileUtil.ReplaceLine("C:\old file.txt", "C:\new file.txt", 5, "Text", TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>   
    '''
    ''' <param name="targetFilepath">
    ''' The target textfile path.
    ''' </param>
    ''' 
    ''' <param name="lineNumber">
    ''' The index of the line to replace.
    ''' </param>
    ''' 
    ''' <param name="textCol">
    ''' The text-lines to replace.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read/write the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Sub ReplaceLine(ByVal sourceFilepath As String,
                           ByVal targetFilepath As String,
                           ByVal lineNumber As Integer,
                           ByVal textCol As IEnumerable(Of String),
                           ByVal textDirection As TextfileUtil.TextDirection,
                           Optional ByVal encoding As Encoding = Nothing)

        TextfileUtil.CheckEncoding(encoding)

        File.WriteAllLines(targetFilepath, ReplaceLine(sourceFilepath, lineNumber, textCol, textDirection, encoding), encoding)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Replaces the specified line number in the source textfile with the given text-line,
    ''' then writes the result in the target textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' TextfileUtil.ReplaceLine("C:\old file.txt", "C:\new file.txt", 5, "Text", TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>   
    '''
    ''' <param name="targetFilepath">
    ''' The target textfile path.
    ''' </param>
    ''' 
    ''' <param name="lineNumber">
    ''' The index of the line to replace.
    ''' </param>
    ''' 
    ''' <param name="line">
    ''' The text-line to replace.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read/write the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Sub ReplaceLine(ByVal sourceFilepath As String,
                           ByVal targetFilepath As String,
                           ByVal lineNumber As Integer,
                           ByVal line As String,
                           ByVal textDirection As TextfileUtil.TextDirection,
                           Optional ByVal encoding As Encoding = Nothing)

        TextfileUtil.CheckEncoding(encoding)

        File.WriteAllLines(targetFilepath, ReplaceLine(sourceFilepath, lineNumber, {line}, textDirection, encoding), encoding)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Reverses the lines of the source textfile, 
    ''' then writes the result in the target textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' TextfileUtil.Reverse("C:\old file.txt", "C:\new file.txt", Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>   
    '''
    ''' <param name="targetFilepath">
    ''' The target textfile path.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read/write the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Sub Reverse(ByVal sourceFilepath As String,
                       ByVal targetFilepath As String,
                       Optional ByVal encoding As Encoding = Nothing)

        TextfileUtil.CheckEncoding(encoding)

        File.WriteAllLines(targetFilepath, Reverse(sourceFilepath, encoding), encoding)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Randomizes the lines of the source textfile, 
    ''' then writes the result in the target textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' TextfileUtil.Randomize("C:\old file.txt", "C:\new file.txt", Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>   
    '''
    ''' <param name="targetFilepath">
    ''' The target textfile path.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read/write the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Sub Randomize(ByVal sourceFilepath As String,
                         ByVal targetFilepath As String,
                         Optional ByVal encoding As Encoding = Nothing)

        TextfileUtil.CheckEncoding(encoding)

        File.WriteAllLines(targetFilepath, Randomize(sourceFilepath, encoding), encoding)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Sorts the lines of the source textfile,
    ''' then writes the result in the target textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' TextfileUtil.Sort("C:\old file.txt", "C:\new file.txt", ListSortDirection.Ascending, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>   
    '''
    ''' <param name="targetFilepath">
    ''' The target textfile path.
    ''' </param>
    ''' 
    ''' <param name="sortDirection">
    ''' The sorting direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read/write the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Sub Sort(ByVal sourceFilepath As String,
                    ByVal targetFilepath As String,
                    ByVal sortDirection As ListSortDirection,
                    Optional ByVal encoding As Encoding = Nothing)

        TextfileUtil.CheckEncoding(encoding)

        File.WriteAllLines(targetFilepath, Sort(sourceFilepath, sortDirection, encoding), encoding)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Sorts the lines of the source textfile by evaluating the result of the given condition.
    ''' then writes the result in the target textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' TextfileUtil.SortBy("C:\old file.txt", "C:\new file.txt", ListSortDirection.Ascending, Function(line As String) line.EndsWith("5"), Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="targetFilepath">
    ''' The target textfile path.
    ''' </param>
    ''' 
    ''' <param name="sortDirection">
    ''' The sorting direction.
    ''' </param>
    ''' 
    ''' <param name="sortExpr">
    ''' The sorting expression to evaluate.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read/write the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Sub SortBy(Of T)(ByVal sourceFilepath As String,
                            ByVal targetFilepath As String,
                            ByVal sortDirection As ListSortDirection,
                            ByVal sortExpr As Func(Of String, T),
                            Optional ByVal encoding As Encoding = Nothing)

        TextfileUtil.CheckEncoding(encoding)

        File.WriteAllLines(targetFilepath, SortBy(sourceFilepath, sortDirection, sortExpr, encoding), encoding)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Trims the specified chars in the lines of the source textfile,
    ''' then writes the result in the target textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' TextfileUtil.Trim("C:\old file.txt", "C:\new file.txt", {" "c, ControlChars.NullChar}, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="targetFilepath">
    ''' The target textfile path.
    ''' </param>
    ''' 
    ''' <param name="trimChars">
    ''' The characters to trim from lines.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read/write the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Sub Trim(ByVal sourceFilepath As String,
                    ByVal targetFilepath As String,
                    Optional ByVal trimChars As Char() = Nothing,
                    Optional ByVal encoding As Encoding = Nothing)

        TextfileUtil.CheckEncoding(encoding)

        File.WriteAllLines(targetFilepath, Trim(sourceFilepath, trimChars, encoding), encoding)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Trims the specified chars from the start of the lines of the source textfile,
    ''' then writes the result in the target textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' TextfileUtil.TrimStart("C:\old file.txt", "C:\new file.txt", {" "c, ControlChars.NullChar}, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="targetFilepath">
    ''' The target textfile path.
    ''' </param>
    ''' 
    ''' <param name="trimChars">
    ''' The characters to trim from lines.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read/write the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Sub TrimStart(ByVal sourceFilepath As String,
                         ByVal targetFilepath As String,
                         Optional ByVal trimChars As Char() = Nothing,
                         Optional ByVal encoding As Encoding = Nothing)

        TextfileUtil.CheckEncoding(encoding)

        File.WriteAllLines(targetFilepath, TrimStart(sourceFilepath, trimChars, encoding), encoding)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Trims the specified chars from the end of the lines of the source textfile,
    ''' then writes the result in the target textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' TextfileUtil.TrimEnd("C:\old file.txt", "C:\new file.txt", {" "c, ControlChars.NullChar}, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>
    ''' 
    ''' <param name="targetFilepath">
    ''' The target textfile path.
    ''' </param>
    ''' 
    ''' <param name="trimChars">
    ''' The characters to trim from lines.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read/write the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Sub TrimEnd(ByVal sourceFilepath As String,
                       ByVal targetFilepath As String,
                       Optional ByVal trimChars As Char() = Nothing,
                       Optional ByVal encoding As Encoding = Nothing)

        TextfileUtil.CheckEncoding(encoding)

        File.WriteAllLines(targetFilepath, TrimEnd(sourceFilepath, trimChars, encoding), encoding)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Removes the specified line numbers in the source textfile,
    ''' then writes the result in the target textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' TextfileUtil.RemoveLines("C:\old file.txt", "C:\new file.txt", {1, 2, 3}, TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>   
    '''
    ''' <param name="targetFilepath">
    ''' The target textfile path.
    ''' </param> 
    '''
    ''' <param name="lineNumbers">
    ''' The index of the lines to remove.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read/write the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Sub RemoveLines(ByVal sourceFilepath As String,
                           ByVal targetFilepath As String,
                           ByVal lineNumbers As IEnumerable(Of Integer),
                           ByVal textDirection As TextfileUtil.TextDirection,
                           Optional ByVal encoding As Encoding = Nothing)

        TextfileUtil.CheckEncoding(encoding)

        File.WriteAllLines(targetFilepath, RemoveLines(sourceFilepath, lineNumbers, textDirection, encoding), encoding)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Removes the specified line number in the source textfile,
    ''' then writes the result in the target textfile.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------     
    ''' <example> This is a code example.
    ''' <code>
    ''' TextfileUtil.RemoveLine("C:\old file.txt", "C:\new file.txt", 5, TextfileUtil.TextDirection.Top, Encoding.Default)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The source textfile path.
    ''' </param>   
    '''
    ''' <param name="targetFilepath">
    ''' The target textfile path.
    ''' </param> 
    '''
    ''' <param name="lineNumber">
    ''' The index of the line to remove.
    ''' </param>
    ''' 
    ''' <param name="textDirection">
    ''' The text direction.
    ''' </param>
    ''' 
    ''' <param name="encoding">
    ''' The file encoding used to read/write the textfile.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Sub RemoveLine(ByVal sourceFilepath As String,
                          ByVal targetFilepath As String,
                          ByVal lineNumber As Integer,
                          ByVal textDirection As TextfileUtil.TextDirection,
                          Optional ByVal encoding As Encoding = Nothing)

        TextfileUtil.CheckEncoding(encoding)

        File.WriteAllLines(targetFilepath, RemoveLine(sourceFilepath, lineNumber, textDirection, encoding), encoding)

    End Sub

#End Region

#Region " Private Methods "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Checks the referenced <see cref="Encoding"/> value, if the value is <c>Nothing</c>, 
    ''' then sets the value as <see cref="Encoding.Default"/>.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="refEncoding">
    ''' The <see cref="Encoding"/> referenced value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Private Sub CheckEncoding(ByRef refEncoding As Encoding)

        If (refEncoding Is Nothing) Then
            refEncoding = Encoding.Default
        End If

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Checks the specified filepath, if the filepath doesn't exists, then throws a <see cref="FileNotFoundException"/> exception.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sourceFilepath">
    ''' The filepath.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <exception cref="FileNotFoundException">
    ''' File not found.
    ''' </exception>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerHidden>
    <DebuggerStepThrough>
    Private Sub CheckFilePath(ByVal sourceFilepath As String)

        If Not File.Exists(sourceFilepath) Then
            Throw New FileNotFoundException("File not found.", sourceFilepath)
        End If

    End Sub

#End Region

End Module

#End Region
