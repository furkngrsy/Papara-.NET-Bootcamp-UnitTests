Public Class GetGenreDetailQueryValidatorTests
    Private ReadOnly _validator As GetGenreDetailQueryValidator

    Public Sub New()
        _validator = New GetGenreDetailQueryValidator()
    End Sub

    <Fact>
    Public Sub Should_Have_Error_When_Id_Is_Zero()
        ' Arrange
        Dim query As New GetGenreDetailQuery With {.Id = 0}

        ' Act
        Dim result = _validator.Validate(query)

        ' Assert
        result.Errors.Should().Contain(Function(x) x.PropertyName = "Id" AndAlso x.ErrorMessage = "Id must be greater than 0.")
    End Sub

    <Fact>
    Public Sub Should_Not_Have_Error_When_Id_Is_Valid()
        ' Arrange
        Dim query As New GetGenreDetailQuery With {.Id = 1}

        ' Act
        Dim result = _validator.Validate(query)

        ' Assert
        result.Errors.Should().BeEmpty()
    End Sub
End Class
