Public Class UpdateGenreCommandValidatorTests
    Private ReadOnly _validator As UpdateGenreCommandValidator

    Public Sub New()
        _validator = New UpdateGenreCommandValidator()
    End Sub

    <Fact>
    Public Sub Should_Have_Error_When_Name_Is_Empty()
        ' Arrange
        Dim command As New UpdateGenreCommand With {.Id = 1, .Name = String.Empty}

        ' Act
        Dim result = _validator.Validate(command)

        ' Assert
        result.Errors.Should().Contain(Function(x) x.PropertyName = "Name" AndAlso x.ErrorMessage = "Genre name is required.")
    End Sub

    <Fact>
    Public Sub Should_Not_Have_Error_When_Command_Is_Valid()
        ' Arrange
        Dim command As New UpdateGenreCommand With {.Id = 1, .Name = "Valid Genre"}

        ' Act
        Dim result = _validator.Validate(command)

        ' Assert
        result.Errors.Should().BeEmpty()
    End Sub
End Class
