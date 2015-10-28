' ***********************************************************************
' Author   : Elektro
' Modified : 28-October-2015
' ***********************************************************************
' <copyright file="Numeric Extensions.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Public Members Summary "

#Region " Functions "

' Short.DifferenceOf(Double) As Double
' UShort.DifferenceOf(Double) As Double
' Integer.DifferenceOf(Double) As Double
' UInteger.DifferenceOf(Double) As Double
' Long.DifferenceOf(Double) As Double
' ULong.DifferenceOf(Double) As Double
' Decimal.DifferenceOf(Double) As Double
' Single.DifferenceOf(Double) As Double
' Double.DifferenceOf(Double) As Double

' Short.IsDivisibleBy(Double) As Boolean
' UShort.IsDivisibleBy(Double) As Boolean
' Integer.IsDivisibleBy(Double) As Boolean
' UInteger.IsDivisibleBy(Double) As Boolean
' Long.IsDivisibleBy(Double) As Boolean
' ULong.IsDivisibleBy(Double) As Boolean
' Decimal.IsDivisibleBy(Double) As Boolean
' Single.IsDivisibleBy(Double) As Boolean
' Double.IsDivisibleBy(Double) As Boolean

' Short.IsInRangeOf(Double, Double) As Boolean
' UShort.IsInRangeOf(Double, Double) As Boolean
' Integer.IsInRangeOf(Double, Double) As Boolean
' UInteger.IsInRangeOf(Double, Double) As Boolean
' Long.IsInRangeOf(Double, Double) As Boolean
' ULong.IsInRangeOf(Double, Double) As Boolean
' Decimal.IsInRangeOf(Double, Double) As Boolean
' Single.IsInRangeOf(Double, Double) As Boolean
' Double.IsInRangeOf(Double, Double) As Boolean

' Short.IsPositive() As Boolean
' UShort.IsPositive() As Boolean
' Integer.IsPositive() As Boolean
' UInteger.IsPositive() As Boolean
' Long.IsPositive() As Boolean
' ULong.IsPositive() As Boolean
' Decimal.IsPositive() As Boolean
' Single.IsPositive() As Boolean
' Double.IsPositive() As Boolean

' Short.IsNegative() As Boolean
' UShort.IsNegative() As Boolean
' Integer.IsNegative() As Boolean
' UInteger.IsNegative() As Boolean
' Long.IsNegative() As Boolean
' ULong.IsNegative() As Boolean
' Decimal.IsNegative() As Boolean
' Single.IsNegative() As Boolean
' Double.IsNegative() As Boolean

' Short.IsMultipleBOf(Double) As Boolean
' UShort.IsMultipleBOf(Double) As Boolean
' Integer.IsMultipleBOf(Double) As Boolean
' UInteger.IsMultipleBOf(Double) As Boolean
' Long.IsMultipleBOf(Double) As Boolean
' ULong.IsMultipleBOf(Double) As Boolean
' Decimal.IsMultipleBOf(Double) As Boolean
' Single.IsMultipleBOf(Double) As Boolean
' Double.IsMultipleBOf(Double) As Boolean

' Short.PercentageOf(Double) As Boolean
' UShort.PercentageOf(Double) As Boolean
' Integer.PercentageOf(Double) As Boolean
' UInteger.PercentageOf(Double) As Boolean
' Long.PercentageOf(Double) As Boolean
' ULong.PercentageOf(Double) As Boolean
' Decimal.PercentageOf(Double) As Boolean
' Single.PercentageOf(Double) As Boolean
' Double.PercentageOf(Double) As Boolean

' Short.FractionBy(Double) As Double
' UShort.FractionBy(Double) As Double
' Integer.FractionBy(Double) As Double
' UInteger.FractionBy(Double) As Double
' Long.FractionBy(Double) As Double
' ULong.FractionBy(Double) As Double
' Decimal.FractionBy(Double) As Double
' Single.FractionBy(Double) As Double
' Double.FractionBy(Double) As Double

' Short.Formatted(Double, Opt: Integer) As String
' UShort.Formatted(Double, Opt: Integer) As String
' Integer.Formatted(Double, Opt: Integer) As String
' UInteger.Formatted(Double, Opt: Integer) As String
' Long.Formatted(Double, Opt: Integer) As String
' ULong.Formatted(Double, Opt: Integer) As String
' Decimal.Formatted(Double, Opt: Integer) As String
' Single.Formatted(Double, Opt: Integer) As String
' Double.Formatted(Double, Opt: Integer) As String

' Short.Formatted(Double, CultureInfo, Opt: Integer) As String
' UShort.Formatted(Double, CultureInfo, Opt: Integer) As String
' Integer.Formatted(Double, CultureInfo, Opt: Integer) As String
' UInteger.Formatted(Double, CultureInfo, Opt: Integer) As String
' Long.Formatted(Double, CultureInfo, Opt: Integer) As String
' ULong.Formatted(Double, CultureInfo, Opt: Integer) As String
' Decimal.Formatted(Double, CultureInfo, Opt: Integer) As String
' Single.Formatted(Double, CultureInfo, Opt: Integer) As String
' Double.Formatted(Double, CultureInfo, Opt: Integer) As String

' Short.IsPrime() As Boolean
' UShort.IsPrime() As Boolean
' Integer.IsPrime() As Boolean
' UInteger.IsPrime() As Boolean
' Long.IsPrime() As Boolean

' Short.ToVBHex() As String
' UShort.ToVBHex() As String
' Integer.ToVBHex() As String
' UInteger.ToVBHex() As String
' Long.ToVBHex() As String

' Short.ToCSharpHex() As String
' UShort.ToCSharpHex() As String
' Integer.ToCSharpHex() As String
' UInteger.ToCSharpHex() As String
' Long.ToCSharpHex() As String

#End Region

#End Region

#Region " Option Statements "

Option Strict On
Option Explicit On
Option Infer Off

#End Region

#Region " Imports "

Imports System
Imports System.Diagnostics
Imports System.Runtime.CompilerServices

#End Region

#Region " Numeric Extensions "

''' ----------------------------------------------------------------------------------------------------
''' <summary>
''' Contains custom extension methods to use with the <see cref="Short"/>, <see cref="UShort"/>, 
''' <see cref="Integer"/>, <see cref="UInteger"/>, <see cref="Long"/>, <see cref="ULong"/>, 
''' <see cref="Decimal"/>, <see cref="Single"/> and <see cref="Double"/> data-types.
''' </summary>
''' ----------------------------------------------------------------------------------------------------
Public Module NumericExtensions

#Region " Public Extension Methods "

#Region " Percentage of... "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Given a total number, calculates which percentage of is the source value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As Short = CShort(10S.PercentageOf(50S))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="total">
    ''' The total value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The percentage value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function PercentageOf(ByVal sender As Short, ByVal total As Double) As Double

        Return NumericExtensions.InternalGetPercentageOf(sender, total)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Given a total number, calculates which percentage of is the source value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As UShort = CUShort(10US.PercentageOf(50US))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="total">
    ''' The total value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The percentage value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function PercentageOf(ByVal sender As UShort, ByVal total As Double) As Double

        Return NumericExtensions.InternalGetPercentageOf(sender, total)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Given a total number, calculates which percentage of is the source value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As Integer = CInt(10I.PercentageOf(50I))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="total">
    ''' The total value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The percentage value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function PercentageOf(ByVal sender As Integer, ByVal total As Double) As Double

        Return NumericExtensions.InternalGetPercentageOf(sender, total)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Given a total number, calculates which percentage of is the source value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As UInteger = CUInt(10UI.PercentageOf(50UI))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="total">
    ''' The total value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The percentage value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function PercentageOf(ByVal sender As UInteger, ByVal total As Double) As Double

        Return NumericExtensions.InternalGetPercentageOf(sender, total)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Given a total number, calculates which percentage of is the source value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As Long = CLng(10L.PercentageOf(50L))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="total">
    ''' The total value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The percentage value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function PercentageOf(ByVal sender As Long, ByVal total As Double) As Double

        Return NumericExtensions.InternalGetPercentageOf(sender, total)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Given a total number, calculates which percentage of is the source value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As ULong = CULng(10UL.PercentageOf(50UL))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="total">
    ''' The total value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The percentage value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function PercentageOf(ByVal sender As ULong, ByVal total As Double) As Double

        Return NumericExtensions.InternalGetPercentageOf(sender, total)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Given a total number, calculates which percentage of is the source value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As Decimal = CDec(10D.PercentageOf(50D))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="total">
    ''' The total value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The percentage value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function PercentageOf(ByVal sender As Decimal, ByVal total As Double) As Double

        Return NumericExtensions.InternalGetPercentageOf(sender, total)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Given a total number, calculates which percentage of is the source value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As Single = CSng(10.0F.PercentageOf(50.0F))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="total">
    ''' The total value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The percentage value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function PercentageOf(ByVal sender As Single, ByVal total As Double) As Double

        Return NumericExtensions.InternalGetPercentageOf(sender, total)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Given a total number, calculates which percentage of is the source value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As Double = 10.0R.PercentageOf(50.0R)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="total">
    ''' The total value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The percentage value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function PercentageOf(ByVal sender As Double, ByVal total As Double) As Double

        Return NumericExtensions.InternalGetPercentageOf(sender, total)

    End Function

#End Region

#Region " Fraction by... "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Takes a fraction of the source value that corresponds to the given percent value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As Short = CShort(10S.FractionBy(50S))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="percentage">
    ''' The percentage to fractionize by.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The fraction value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function FractionBy(ByVal sender As Short, ByVal percentage As Double) As Double

        Return NumericExtensions.InternalFractionBy(percentage, sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Takes a fraction of the source value that corresponds to the given percent value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As UShort = CUShort(10US.FractionBy(50US))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="percentage">
    ''' The percentage to fractionize by.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The fraction value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function FractionBy(ByVal sender As UShort, ByVal percentage As Double) As Double

        Return NumericExtensions.InternalFractionBy(percentage, sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Takes a fraction of the source value that corresponds to the given percent value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As Integer = CInt(10I.FractionBy(50I))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="percentage">
    ''' The percentage to fractionize by.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The fraction value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function FractionBy(ByVal sender As Integer, ByVal percentage As Double) As Double

        Return NumericExtensions.InternalFractionBy(percentage, sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Takes a fraction of the source value that corresponds to the given percent value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As UInteger = CUInt(10UI.FractionBy(50UI))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="percentage">
    ''' The percentage to fractionize by.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The fraction value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function FractionBy(ByVal sender As UInteger, ByVal percentage As Double) As Double

        Return NumericExtensions.InternalFractionBy(percentage, sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Takes a fraction of the source value that corresponds to the given percent value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As Long = CLng(10L.FractionBy(50L))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="percentage">
    ''' The percentage to fractionize by.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The fraction value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function FractionBy(ByVal sender As Long, ByVal percentage As Double) As Double

        Return NumericExtensions.InternalFractionBy(percentage, sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Takes a fraction of the source value that corresponds to the given percent value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As ULong = CULng(10UL.FractionBy(50UL))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="percentage">
    ''' The percentage to fractionize by.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The fraction value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function FractionBy(ByVal sender As ULong, ByVal percentage As Double) As Double

        Return NumericExtensions.InternalFractionBy(percentage, sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Takes a fraction of the source value that corresponds to the given percent value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As Decimal = CDec(10D.FractionBy(50D))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="percentage">
    ''' The percentage to fractionize by.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The fraction value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function FractionBy(ByVal sender As Decimal, ByVal percentage As Double) As Double

        Return NumericExtensions.InternalFractionBy(percentage, sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Takes a fraction of the source value that corresponds to the given percent value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As Single = CSng(10.0F.FractionBy(50.0F))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="percentage">
    ''' The percentage to fractionize by.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The fraction value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function FractionBy(ByVal sender As Single, ByVal percentage As Double) As Double

        Return NumericExtensions.InternalFractionBy(percentage, sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Takes a fraction of the source value that corresponds to the given percent value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As Double = 10.0R.FractionBy(50.0R)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="percentage">
    ''' The percentage to fractionize by.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The fraction value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function FractionBy(ByVal sender As Double, ByVal percentage As Double) As Double

        Return NumericExtensions.InternalFractionBy(percentage, sender)

    End Function

#End Region

#Region " Is positive ? "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the value is a positive number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10S.IsPositive()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a positive number, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsPositive(ByVal sender As Short) As Boolean

        Return NumericExtensions.InternalIsPositive(sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the value is a positive number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10US.IsPositive()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a positive number, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsPositive(ByVal sender As UShort) As Boolean

        Return NumericExtensions.InternalIsPositive(sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the value is a positive number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10I.IsPositive()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a positive number, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsPositive(ByVal sender As Integer) As Boolean

        Return NumericExtensions.InternalIsPositive(sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the value is a positive number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10UI.IsPositive()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a positive number, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsPositive(ByVal sender As UInteger) As Boolean

        Return NumericExtensions.InternalIsPositive(sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the value is a positive number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10L.IsPositive()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a positive number, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsPositive(ByVal sender As Long) As Boolean

        Return NumericExtensions.InternalIsPositive(sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the value is a positive number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10UL.IsPositive()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a positive number, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsPositive(ByVal sender As ULong) As Boolean

        Return NumericExtensions.InternalIsPositive(sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the value is a positive number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10D.IsPositive()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a positive number, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsPositive(ByVal sender As Decimal) As Boolean

        Return NumericExtensions.InternalIsPositive(sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the value is a positive number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10.0F.IsPositive()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a positive number, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsPositive(ByVal sender As Single) As Boolean

        Return NumericExtensions.InternalIsPositive(sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the value is a positive number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10.0R.IsPositive()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a positive number, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsPositive(ByVal sender As Double) As Boolean

        Return NumericExtensions.InternalIsPositive(sender)

    End Function

#End Region

#Region " Is negative ? "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the value is a negative number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10S.IsNegative()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a negative number, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsNegative(ByVal sender As Short) As Boolean

        Return NumericExtensions.InternalIsNegative(sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the value is a negative number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10US.IsNegative()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a negative number, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsNegative(ByVal sender As UShort) As Boolean

        Return NumericExtensions.InternalIsNegative(sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the value is a negative number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10I.IsNegative()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a negative number, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsNegative(ByVal sender As Integer) As Boolean

        Return NumericExtensions.InternalIsNegative(sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the value is a negative number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10UI.IsNegative()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a negative number, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsNegative(ByVal sender As UInteger) As Boolean

        Return NumericExtensions.InternalIsNegative(sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the value is a negative number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10L.IsNegative()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a negative number, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsNegative(ByVal sender As Long) As Boolean

        Return NumericExtensions.InternalIsNegative(sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the value is a negative number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10UL.IsNegative()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a negative number, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsNegative(ByVal sender As ULong) As Boolean

        Return NumericExtensions.InternalIsNegative(sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the value is a negative number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10D.IsNegative()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a negative number, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsNegative(ByVal sender As Decimal) As Boolean

        Return NumericExtensions.InternalIsNegative(sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the value is a negative number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10.0F.IsNegative()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a negative number, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsNegative(ByVal sender As Single) As Boolean

        Return NumericExtensions.InternalIsNegative(sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the value is a negative number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10.0R.IsNegative()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a negative number, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsNegative(ByVal sender As Double) As Boolean

        Return NumericExtensions.InternalIsNegative(sender)

    End Function

#End Region

#Region " Is prime ? "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is a prime number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10S.IsPrime()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is prime, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsPrime(ByVal sender As Short) As Boolean

        Return NumericExtensions.InternalIsPrime(sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is a prime number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10US.IsPrime()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is prime, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsPrime(ByVal sender As UShort) As Boolean

        Return NumericExtensions.InternalIsPrime(sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is a prime number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10I.IsPrime()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is prime, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsPrime(ByVal sender As Integer) As Boolean

        Return NumericExtensions.InternalIsPrime(sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is a prime number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10UI.IsPrime()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is prime, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsPrime(ByVal sender As UInteger) As Boolean

        Return NumericExtensions.InternalIsPrime(sender)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is a prime number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10L.IsPrime()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is prime, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsPrime(ByVal sender As Long) As Boolean

        Return NumericExtensions.InternalIsPrime(sender)

    End Function

#End Region

#Region " Is divisible by... ? "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is divisible by the given value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10S.IsDivisibleBy(5S)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value to divide by.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is divisible, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsDivisibleBy(ByVal sender As Short, ByVal value As Double) As Boolean

        Return NumericExtensions.InternalIsDivisibleBy(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is divisible by the given value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10US.IsDivisibleBy(5US)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value to divide by.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is divisible, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsDivisibleBy(ByVal sender As UShort, ByVal value As Double) As Boolean

        Return NumericExtensions.InternalIsDivisibleBy(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is divisible by the given value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10I.IsDivisibleBy(5I)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value to divide by.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is divisible, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsDivisibleBy(ByVal sender As Integer, ByVal value As Double) As Boolean

        Return NumericExtensions.InternalIsDivisibleBy(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is divisible by the given value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10UI.IsDivisibleBy(5UI)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value to divide by.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is divisible, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsDivisibleBy(ByVal sender As UInteger, ByVal value As Double) As Boolean

        Return NumericExtensions.InternalIsDivisibleBy(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is divisible by the given value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10L.IsDivisibleBy(5L)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value to divide by.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is divisible, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsDivisibleBy(ByVal sender As Long, ByVal value As Double) As Boolean

        Return NumericExtensions.InternalIsDivisibleBy(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is divisible by the given value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10UL.IsDivisibleBy(5UL)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value to divide by.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is divisible, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsDivisibleBy(ByVal sender As ULong, ByVal value As Double) As Boolean

        Return NumericExtensions.InternalIsDivisibleBy(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is divisible by the given value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10D.IsDivisibleBy(5D)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value to divide by.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is divisible, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsDivisibleBy(ByVal sender As Decimal, ByVal value As Double) As Boolean

        Return NumericExtensions.InternalIsDivisibleBy(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is divisible by the given value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10.0F.IsDivisibleBy(5.0F)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value to divide by.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is divisible, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsDivisibleBy(ByVal sender As Single, ByVal value As Double) As Boolean

        Return NumericExtensions.InternalIsDivisibleBy(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is divisible by the given value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10.0R.IsDivisibleBy(5.0R)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value to divide by.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is divisible, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsDivisibleBy(ByVal sender As Double, ByVal value As Double) As Boolean

        Return NumericExtensions.InternalIsDivisibleBy(sender, value)

    End Function

#End Region

#Region " Is multiple of...? "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is a multiple of the given value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10S.IsMultipleOf(5S)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a multiple, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsMultipleOf(ByVal sender As Short, ByVal value As Double) As Boolean

        Return NumericExtensions.InternalIsMultipleOf(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is a multiple of the given value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10US.IsMultipleOf(5US)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a multiple, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsMultipleOf(ByVal sender As UShort, ByVal value As Double) As Boolean

        Return NumericExtensions.InternalIsMultipleOf(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is a multiple of the given value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10I.IsMultipleOf(5I)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a multiple, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsMultipleOf(ByVal sender As Integer, ByVal value As Double) As Boolean

        Return NumericExtensions.InternalIsMultipleOf(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is a multiple of the given value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10UI.IsMultipleOf(5UI)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a multiple, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsMultipleOf(ByVal sender As UInteger, ByVal value As Double) As Boolean

        Return NumericExtensions.InternalIsMultipleOf(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is a multiple of the given value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10L.IsMultipleOf(5L)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a multiple, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsMultipleOf(ByVal sender As Long, ByVal value As Double) As Boolean

        Return NumericExtensions.InternalIsMultipleOf(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is a multiple of the given value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10UL.IsMultipleOf(5UL)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a multiple, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsMultipleOf(ByVal sender As ULong, ByVal value As Double) As Boolean

        Return NumericExtensions.InternalIsMultipleOf(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is a multiple of the given value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10D.IsMultipleOf(5D)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a multiple, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsMultipleOf(ByVal sender As Decimal, ByVal value As Double) As Boolean

        Return NumericExtensions.InternalIsMultipleOf(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is a multiple of the given value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10.0F.IsMultipleOf(5.0F)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a multiple, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsMultipleOf(ByVal sender As Single, ByVal value As Double) As Boolean

        Return NumericExtensions.InternalIsMultipleOf(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is a multiple of the given value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10.0R.IsMultipleOf(5.0R)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a multiple, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsMultipleOf(ByVal sender As Double, ByVal value As Double) As Boolean

        Return NumericExtensions.InternalIsMultipleOf(sender, value)

    End Function

#End Region

#Region " Is in range of...? "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is in range of the given <paramref name="minimum"/> and <paramref name="maximum"/> values.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10S.IsInRangeOf(min:=1S, max:=100S)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="min">
    ''' The minimum value of the range.
    ''' </param>
    ''' 
    ''' <param name="max">
    ''' The maximum value of the range.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is in range, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsInRangeOf(ByVal sender As Short, ByVal min As Double, ByVal max As Double) As Boolean

        Return NumericExtensions.InternalIsInRangeOf(sender, min, max)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is in range of the given <paramref name="minimum"/> and <paramref name="maximum"/> values.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10US.IsInRangeOf(min:=1US, max:=100US)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="min">
    ''' The minimum value of the range.
    ''' </param>
    ''' 
    ''' <param name="max">
    ''' The maximum value of the range.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is in range, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsInRangeOf(ByVal sender As UShort, ByVal min As Double, ByVal max As Double) As Boolean

        Return NumericExtensions.InternalIsInRangeOf(sender, min, max)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is in range of the given <paramref name="minimum"/> and <paramref name="maximum"/> values.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10I.IsInRangeOf(min:=1I, max:=100I)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="min">
    ''' The minimum value of the range.
    ''' </param>
    ''' 
    ''' <param name="max">
    ''' The maximum value of the range.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is in range, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsInRangeOf(ByVal sender As Integer, ByVal min As Double, ByVal max As Double) As Boolean

        Return NumericExtensions.InternalIsInRangeOf(sender, min, max)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is in range of the given <paramref name="minimum"/> and <paramref name="maximum"/> values.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10UI.IsInRangeOf(min:=1UI, max:=100UI)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="min">
    ''' The minimum value of the range.
    ''' </param>
    ''' 
    ''' <param name="max">
    ''' The maximum value of the range.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is in range, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsInRangeOf(ByVal sender As UInteger, ByVal min As Double, ByVal max As Double) As Boolean

        Return NumericExtensions.InternalIsInRangeOf(sender, min, max)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is in range of the given <paramref name="minimum"/> and <paramref name="maximum"/> values.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10L.IsInRangeOf(min:=1L, max:=100L)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="min">
    ''' The minimum value of the range.
    ''' </param>
    ''' 
    ''' <param name="max">
    ''' The maximum value of the range.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is in range, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsInRangeOf(ByVal sender As Long, ByVal min As Double, ByVal max As Double) As Boolean

        Return NumericExtensions.InternalIsInRangeOf(sender, min, max)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is in range of the given <paramref name="minimum"/> and <paramref name="maximum"/> values.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10UL.IsInRangeOf(min:=1UL, max:=100UL)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="min">
    ''' The minimum value of the range.
    ''' </param>
    ''' 
    ''' <param name="max">
    ''' The maximum value of the range.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is in range, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsInRangeOf(ByVal sender As ULong, ByVal min As Double, ByVal max As Double) As Boolean

        Return NumericExtensions.InternalIsInRangeOf(sender, min, max)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is in range of the given <paramref name="minimum"/> and <paramref name="maximum"/> values.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10.0D.IsInRangeOf(min:=1.0D, max:=100.0D)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="min">
    ''' The minimum value of the range.
    ''' </param>
    ''' 
    ''' <param name="max">
    ''' The maximum value of the range.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is in range, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsInRangeOf(ByVal sender As Decimal, ByVal min As Double, ByVal max As Double) As Boolean

        Return NumericExtensions.InternalIsInRangeOf(sender, min, max)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is in range of the given <paramref name="minimum"/> and <paramref name="maximum"/> values.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10.0F.IsInRangeOf(min:=1.0F, max:=100.0F)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="min">
    ''' The minimum value of the range.
    ''' </param>
    ''' 
    ''' <param name="max">
    ''' The maximum value of the range.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is in range, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsInRangeOf(ByVal sender As Single, ByVal min As Double, ByVal max As Double) As Boolean

        Return NumericExtensions.InternalIsInRangeOf(sender, min, max)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is in range of the given <paramref name="minimum"/> and <paramref name="maximum"/> values.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim result As Boolean = 10.0R.IsInRangeOf(min:=1.0R, max:=100.0R)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="min">
    ''' The minimum value of the range.
    ''' </param>
    ''' 
    ''' <param name="max">
    ''' The maximum value of the range.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is in range, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function IsInRangeOf(ByVal sender As Double, ByVal min As Double, ByVal max As Double) As Boolean

        Return NumericExtensions.InternalIsInRangeOf(sender, min, max)

    End Function

#End Region

#Region " Difference Of... "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Gets the difference between the source value and the specified value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As Short = CShort(10S.DifferenceOf(100S))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The difference.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function DifferenceOf(ByVal sender As Short, ByVal value As Double) As Double

        Return NumericExtensions.InternalDifferenceOf(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Gets the difference between the source value and the specified value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As UShort = CUShort(10US.DifferenceOf(100US))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The difference.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function DifferenceOf(ByVal sender As UShort, ByVal value As Double) As Double

        Return NumericExtensions.InternalDifferenceOf(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Gets the difference between the source value and the specified value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As Integer = CInt(10I.DifferenceOf(100I))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The difference.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function DifferenceOf(ByVal sender As Integer, ByVal value As Double) As Double

        Return NumericExtensions.InternalDifferenceOf(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Gets the difference between the source value and the specified value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As UInteger = CUInt(10UI.DifferenceOf(100UI))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The difference.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function DifferenceOf(ByVal sender As UInteger, ByVal value As Double) As Double

        Return NumericExtensions.InternalDifferenceOf(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Gets the difference between the source value and the specified value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As Long = CLng(10L.DifferenceOf(100L))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The difference.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function DifferenceOf(ByVal sender As Long, ByVal value As Double) As Double

        Return NumericExtensions.InternalDifferenceOf(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Gets the difference between the source value and the specified value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As ULong = CULng(10UL.DifferenceOf(100UL))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The difference.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function DifferenceOf(ByVal sender As ULong, ByVal value As Double) As Double

        Return NumericExtensions.InternalDifferenceOf(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Gets the difference between the source value and the specified value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As Decimal = CDec(10.0D.DifferenceOf(100.0D))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The difference.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function DifferenceOf(ByVal sender As Decimal, ByVal value As Double) As Double

        Return NumericExtensions.InternalDifferenceOf(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Gets the difference between the source value and the specified value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As Single = CSng(10.0F.DifferenceOf(100.0F))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The difference.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function DifferenceOf(ByVal sender As Single, ByVal value As Double) As Double

        Return NumericExtensions.InternalDifferenceOf(sender, value)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Gets the difference between the source value and the specified value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim value As Double = 10.DifferenceOf(100)
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The difference.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function DifferenceOf(ByVal sender As Double, ByVal value As Double) As Double

        Return NumericExtensions.InternalDifferenceOf(sender, value)

    End Function

#End Region

#Region " Value To VB's Hexadecimal "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Converts a value to its Visual Basic literal Hexadecimal representation.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim vbHex As String = 10S.ToVBHex()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The Hexadecimal value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function ToVBHex(ByVal sender As Short) As String

        Return String.Format("&H{0}S", Convert.ToString(sender, toBase:=16).ToUpper)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Converts a value to its Visual Basic literal Hexadecimal representation.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim vbHex As String = 10US.ToVBHex()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The Hexadecimal value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function ToVBHex(ByVal sender As UShort) As String

        Return String.Format("&H{0}US", Convert.ToString(sender, toBase:=16).ToUpper)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Converts a value to its Visual Basic literal Hexadecimal representation.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim vbHex As String = 10I.ToVBHex()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The Hexadecimal value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function ToVBHex(ByVal sender As Integer) As String

        Return String.Format("&H{0}I", Convert.ToString(sender, toBase:=16).ToUpper)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Converts a value to its Visual Basic literal Hexadecimal representation.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim vbHex As String = 10UI.ToVBHex()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The Hexadecimal value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function ToVBHex(ByVal sender As UInteger) As String

        Return String.Format("&H{0}UI", Convert.ToString(sender, toBase:=16).ToUpper)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Converts a value to its Visual Basic literal Hexadecimal representation.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim vbHex As String = 10L.ToVBHex()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The Hexadecimal value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function ToVBHex(ByVal sender As Long) As String

        Return String.Format("&H{0}L", Convert.ToString(sender, toBase:=16).ToUpper)

    End Function

#End Region

#Region " Value To C#'s Hexadecimal "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Converts a value to its C# literal Hexadecimal representation.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim vbHex As String = 10S.ToCSharpHex()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The Hexadecimal value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function ToCSharpHex(ByVal sender As Short) As String

        Return String.Format("0x{0}", Convert.ToString(sender, toBase:=16).ToUpper)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Converts a value to its C# literal Hexadecimal representation.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim vbHex As String = 10US.ToCSharpHex()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The Hexadecimal value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function ToCSharpHex(ByVal sender As UShort) As String

        Return String.Format("0x{0}", Convert.ToString(sender, toBase:=16).ToUpper)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Converts a value to its C# literal Hexadecimal representation.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim vbHex As String = 10I.ToCSharpHex()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The Hexadecimal value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function ToCSharpHex(ByVal sender As Integer) As String

        Return String.Format("0x{0}", Convert.ToString(sender, toBase:=16).ToUpper)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Converts a value to its C# literal Hexadecimal representation.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim vbHex As String = 10UI.ToCSharpHex()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The Hexadecimal value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function ToCSharpHex(ByVal sender As UInteger) As String

        Return String.Format("0x{0}U", Convert.ToString(sender, toBase:=16).ToUpper)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Converts a value to its C# literal Hexadecimal representation.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim vbHex As String = 10L.ToCSharpHex()
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The Hexadecimal value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function ToCSharpHex(ByVal sender As Long) As String

        Return String.Format("0x{0}L", Convert.ToString(sender, toBase:=16).ToUpper)

    End Function

#End Region

#Region " Format number "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Formats a value by placing dots or commas in the corresponding positions depending on the specified culture.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim number As String = 10000S.Formatted(precision:=0, culture:=CultureInfo.GetCultureInfo("en-US"))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="precision">
    ''' The decimals precision.
    ''' </param>
    ''' 
    ''' <param name="culture">
    ''' The culture format.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The formatted value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function Formatted(ByVal sender As Short, Optional ByVal precision As Integer = 0,
                              Optional ByVal culture As CultureInfo = Nothing) As String

        Return NumericExtensions.InternalFormatted(sender, precision, culture)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Formats a value by placing dots or commas in the corresponding positions depending on the specified culture.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim number As String = 10000US.Formatted(precision:=0, culture:=CultureInfo.GetCultureInfo("en-US"))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="precision">
    ''' The decimals precision.
    ''' </param>
    ''' 
    ''' <param name="culture">
    ''' The culture format.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The formatted value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function Formatted(ByVal sender As UShort, Optional ByVal precision As Integer = 0,
                              Optional ByVal culture As CultureInfo = Nothing) As String

        Return NumericExtensions.InternalFormatted(sender, precision, culture)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Formats a value by placing dots or commas in the corresponding positions depending on the specified culture.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim number As String = 10000I.Formatted(precision:=0, culture:=CultureInfo.GetCultureInfo("en-US"))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="precision">
    ''' The decimals precision.
    ''' </param>
    ''' 
    ''' <param name="culture">
    ''' The culture format.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The formatted value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function Formatted(ByVal sender As Integer, Optional ByVal precision As Integer = 0,
                              Optional ByVal culture As CultureInfo = Nothing) As String

        Return NumericExtensions.InternalFormatted(sender, precision, culture)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Formats a value by placing dots or commas in the corresponding positions depending on the specified culture.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim number As String = 10000UI.Formatted(precision:=0, culture:=CultureInfo.GetCultureInfo("en-US"))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="precision">
    ''' The decimals precision.
    ''' </param>
    ''' 
    ''' <param name="culture">
    ''' The culture format.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The formatted value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function Formatted(ByVal sender As UInteger, Optional ByVal precision As Integer = 0,
                              Optional ByVal culture As CultureInfo = Nothing) As String

        Return NumericExtensions.InternalFormatted(sender, precision, culture)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Formats a value by placing dots or commas in the corresponding positions depending on the specified culture.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim number As String = 10000L.Formatted(precision:=0, culture:=CultureInfo.GetCultureInfo("en-US"))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="precision">
    ''' The decimals precision.
    ''' </param>
    ''' 
    ''' <param name="culture">
    ''' The culture format.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The formatted value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function Formatted(ByVal sender As Long, Optional ByVal precision As Integer = 0,
                              Optional ByVal culture As CultureInfo = Nothing) As String

        Return NumericExtensions.InternalFormatted(sender, precision, culture)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Formats a value by placing dots or commas in the corresponding positions depending on the specified culture.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim number As String = 10000UL.Formatted(precision:=0, culture:=CultureInfo.GetCultureInfo("en-US"))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="precision">
    ''' The decimals precision.
    ''' </param>
    ''' 
    ''' <param name="culture">
    ''' The culture format.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The formatted value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function Formatted(ByVal sender As ULong, Optional ByVal precision As Integer = 0,
                              Optional ByVal culture As CultureInfo = Nothing) As String

        Return NumericExtensions.InternalFormatted(sender, precision, culture)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Formats a value by placing dots or commas in the corresponding positions depending on the specified culture.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim number As String = 10000D.Formatted(precision:=0, culture:=CultureInfo.GetCultureInfo("en-US"))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="precision">
    ''' The decimals precision.
    ''' </param>
    ''' 
    ''' <param name="culture">
    ''' The culture format.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The formatted value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function Formatted(ByVal sender As Decimal, Optional ByVal precision As Integer = 0,
                              Optional ByVal culture As CultureInfo = Nothing) As String

        Return NumericExtensions.InternalFormatted(sender, precision, culture)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Formats a value by placing dots or commas in the corresponding positions depending on the specified culture.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim number As String = 10000.0F.Formatted(precision:=0, culture:=CultureInfo.GetCultureInfo("en-US"))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="precision">
    ''' The decimals precision.
    ''' </param>
    ''' 
    ''' <param name="culture">
    ''' The culture format.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The formatted value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function Formatted(ByVal sender As Single, Optional ByVal precision As Integer = 0,
                              Optional ByVal culture As CultureInfo = Nothing) As String

        Return NumericExtensions.InternalFormatted(sender, precision, culture)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Formats a value by placing dots or commas in the corresponding positions depending on the specified culture.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim number As String = 10000.0R.Formatted(precision:=0, culture:=CultureInfo.GetCultureInfo("en-US"))
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="precision">
    ''' The decimals precision.
    ''' </param>
    ''' 
    ''' <param name="culture">
    ''' The culture format.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The formatted value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    <Extension>
    Public Function Formatted(ByVal sender As Double, Optional ByVal precision As Integer = 0,
                              Optional ByVal culture As CultureInfo = Nothing) As String

        Return NumericExtensions.InternalFormatted(sender, precision, culture)

    End Function

#End Region

#End Region

#Region " Private Methods "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Given a total number, calculates which percentage of is the value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="value">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="total">
    ''' The total value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The percentage value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Private Function InternalGetPercentageOf(ByVal value As Double, ByVal total As Double) As Double

        If (total < value) Then
            Throw New ArgumentException(paramName:="total", message:="Total value should be bigger than value.")

        Else
            Return ((value / total) * 100)

        End If

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Takes a fraction of the source value that corresponds to the given percent value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="total">
    ''' The total value.
    ''' </param>
    ''' 
    ''' <param name="percent">
    ''' The percentage to take from the <paramref name="total"/> value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The fraction value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Private Function InternalFractionBy(ByVal total As Double, ByVal percent As Double) As Double

        If (total < percent) Then
            Throw New ArgumentException(paramName:="total", message:="Total value should be bigger than portion value.")

        Else
            Return (total / (100.0R / percent))

        End If

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether a value is a positive number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a positive number, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Private Function InternalIsPositive(ByVal value As Double) As Boolean

        Return (value > 0)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether a value is a negative number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a negative number, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Private Function InternalIsNegative(ByVal value As Double) As Boolean

        Return (value < 0)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is a prime number.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <remarks>
    ''' Source taken from: <see href="http://www.dotnetperls.com/prime"/>
    ''' </remarks>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is prime, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Private Function InternalIsPrime(ByVal value As Long) As Boolean

        If ((value And 1L) = 0L) Then

            If (value = 2L) Then
                Return True

            Else
                Return False

            End If

        Else
            Dim i As Long = 3L
            While ((i * i) <= value)

                If (value Mod i) = 0L Then
                    Return False
                End If

                i += 2L

            End While

            Return (value <> 1L)

        End If

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is a divisible by the given value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="source">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value to divide by.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is divisible, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Private Function InternalIsDivisibleBy(ByVal source As Double, ByVal value As Double) As Boolean

        Return (source Mod value = 0)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is a multiple of the given value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="source">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is a multiple, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Private Function InternalIsMultipleOf(ByVal source As Double, ByVal value As Double) As Boolean

        Return (source Mod value = 0)

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Determines whether the source value is in range of the given <paramref name="minimum"/> and <paramref name="maximum"/> values.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="source">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="minimum">
    ''' The minimum value of the range.
    ''' </param>
    ''' 
    ''' <param name="maximum">
    ''' The maximum value of the range.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' <see langword="True"/> if the value is in range, <see langword="False"/> otherwise.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Function InternalIsInRangeOf(ByVal source As Double, ByVal minimum As Double, ByVal maximum As Double) As Boolean

        Return ((source >= minimum) AndAlso (source <= maximum))

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Gets the difference between the source value and the specified value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="source">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="value">
    ''' The value.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The difference.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Private Function InternalDifferenceOf(ByVal source As Double, ByVal value As Double) As Double

        Select Case value

            Case Is > source
                Return +(value - source)

            Case Is < source
                Return -(source - value)

            Case Else
                Return 0.0R

        End Select

    End Function

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Formats a value by placing dots or commas in the corresponding positions depending on the specified culture.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source value.
    ''' </param>
    ''' 
    ''' <param name="precision">
    ''' The decimals precision.
    ''' </param>
    ''' 
    ''' <param name="culture">
    ''' The culture format.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The formatted value.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Private Function InternalFormatted(ByVal sender As Double, ByVal precision As Integer, ByVal culture As CultureInfo) As String

        If culture Is Nothing Then
            culture = CultureInfo.CurrentUICulture
        End If

        Return sender.ToString("X" & precision, culture)

    End Function

#End Region

End Module

#End Region
