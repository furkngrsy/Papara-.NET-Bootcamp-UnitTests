Public Class DeleteBookCommandValidatorTests
    Private ReadOnly _validator As DeleteBookCommandValidator

    Public Sub New()
        _validator = New DeleteBookCommandValidator()
    End Sub

    <Fact>
    Public Sub Should_Have_Error_When_Id_Is_Zero()
        ' Arrange
        Dim command As New DeleteBookCommand With {.Id = 0}

        ' Act
        Dim result = _validator.Validate(command)

        ' Assert
        result.Errors.Should().Contain(Function(x) x.PropertyName = "Id" AndAlso x.ErrorMessage = "Id must be greater than 0.")
    End Sub

    <Fact>
    Public Sub Should_Not_Have_Error_When_Id_Is_Valid()
        ' Arrange
        Dim command As New DeleteBookCommand With {.Id = 1}

        ' Act
        Dim result = _validator.Validate(command)

        ' Assert
        result.Errors.Should().BeEmpty()
    End Sub
End Class
