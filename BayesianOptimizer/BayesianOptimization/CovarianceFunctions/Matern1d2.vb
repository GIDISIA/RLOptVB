﻿
Imports MathNet.Numerics.LinearAlgebra

Public Class Matern1d2 : Inherits CovarianceFunction

    Public Overrides Function k(Xi As Vector(Of Double), Xj As Vector(Of Double), sigmaSquaredF As Double, sigmaSquaredN As Double, lVector As Vector(Of Double)) As Double
        Dim lMatrix As Matrix(Of Double) = Matrix(Of Double).Build.Dense(Xi.Count, Xi.Count, 0)
        For i = 0 To Xi.Count - 1
            lMatrix.Item(i, i) = Math.Pow(lVector.Item(i), -2)
        Next
        Dim rSquared As Double = ((Xi.ToColumnMatrix - Xj.ToColumnMatrix).Transpose * lMatrix * (Xi - Xj)).Item(0)

        If Xi.Equals(Xj) Then
            Return sigmaSquaredF * Math.E ^ (-Math.Sqrt(rSquared)) + sigmaSquaredN
        Else
            Return sigmaSquaredF * Math.E ^ (-Math.Sqrt(rSquared))
        End If
    End Function
End Class
