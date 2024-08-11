Public Class UpdateBookCommandValidatorTests
    Private ReadOnly _validator As UpdateBookCommandValidator

    Public Sub New()
        _validator = New UpdateBookCommandValidator()
    End Sub

    <Fact>
    Public Sub Should_Have_Error_When_Title_Is_Empty()
        ' Arrange
        Dim command As New UpdateBookCommand With {.Id = 1, .Title = String.Empty}

        ' Act
        Dim result = _validator.Validate(command)

        ' Assert
        result.Errors.Should().Contain(Function(x) x.PropertyName = "Title" AndAlso x.ErrorMessage = "Title is required.")
    End Sub

    <Fact>
    Public Sub Should_Not_Have_Error_When_Command_Is_Valid()
        ' Arrange
        Dim command As New UpdateBookCommand With {.Id = 1, .Title = "Valid Title"}

        ' Act
        Dim result = _validator.Validate(command)

        ' Assert
        result.Errors.Should().BeEmpty()
    End Sub
End Class
